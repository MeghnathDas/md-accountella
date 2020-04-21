/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DL.Core
{
    using Amazon;
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.Model;
    using MD.Accountella.Core.Models;
    using MD.Accountella.DomainObjects.Helpers;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    public class DynamoDBStore : IDynamoDBStore
    {
        private readonly AwsConfig _awsConfig;
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _dbContext;
        private class TableInfo
        {
            public string tableName { get; set; }
            public List<attrINfo> attributes { get; set; }

            public class attrINfo
            {
                public string name { get; set; }
                public Type dataType { get; set; }
                public bool isPrimary { get; set; }
            }
        }
        public AmazonDynamoDBClient Client => _client;

        public DynamoDBContext DBContext => _dbContext;

        public DynamoDBStore(IOptions<AwsConfig> configOp)
        {
            _awsConfig = configOp.Value;

            var region = RegionEndpoint.GetBySystemName(_awsConfig.Region);
            //RegionEndpoint.APSouth1
            //Creating DynamoDB client
            _client = new AmazonDynamoDBClient(_awsConfig.AccessKeyID, _awsConfig.AccessKey, region);
            _dbContext = new DynamoDBContext(_client);

            this.Init().Wait();
        }

        private async Task Init()
        {
            TableInfo convertTableInfo(Type typ)
            {
                var tbl = new TableInfo();
                tbl.tableName = typ.GetCustomAttribute<DynamoDBTableAttribute>().TableName;
                tbl.attributes = typ.GetProperties().Select(tf =>
                {
                    var attr = new TableInfo.attrINfo
                    {
                        name = tf.Name,
                        dataType = tf.GetType(),
                        isPrimary = tf.GetCustomAttributes(typeof(DynamoDBHashKeyAttribute), true).Length > 0
                    };
                    return attr;
                }).ToList();
                return tbl;
            }

            //Get all available tables in database
            var tableResponse = await _client.ListTablesAsync();

            Utils.GetTableTypes()
                .Select(tblTyp => convertTableInfo(tblTyp))
                .Where(x => !tableResponse.TableNames.Contains(x.tableName))
                .ToList()
                .ForEach(tblSpec =>
                {
                    createTable(tblSpec);   
                });
        }
        private async void createTable(TableInfo tblToCreate)
        {
            var pk = tblToCreate.attributes.Where(attr => attr.isPrimary).FirstOrDefault();

            await _client.CreateTableAsync(new CreateTableRequest
            {
                TableName = tblToCreate.tableName,
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 4,
                    WriteCapacityUnits = 2
                },
                KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = pk.name,
                            KeyType = KeyType.HASH,
                        }
                    },
                AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { 
                            AttributeName = pk.name,
                            AttributeType = pk.dataType == typeof(int) ? ScalarAttributeType.N : ScalarAttributeType.S
                        }
                    }
            });

            bool isTableAvailable = false;
            while (!isTableAvailable)
            {
                //"Waiting for table to be active...
                Thread.Sleep(5000);
                var tableStatus = await _client.DescribeTableAsync(tblToCreate.tableName);
                isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
            }

            if (isTableAvailable)
            {
                var originalColor = System.Console.ForegroundColor;
                System.Console.ForegroundColor = System.ConsoleColor.Green;
                System.Console.Write("info: ");
                System.Console.ForegroundColor = originalColor;
                System.Console.WriteLine("Created table: {0}", tblToCreate.tableName);
                System.Console.ForegroundColor = originalColor;
            }
            else
            {
                var originalColor = System.Console.BackgroundColor;
                System.Console.BackgroundColor = System.ConsoleColor.Red;
                System.Console.Write("failed: ");
                System.Console.ForegroundColor = originalColor;
                System.Console.WriteLine("Unable to to create table: {0}", tblToCreate.tableName);
                System.Console.BackgroundColor = originalColor;
            }
        }
    }
}
