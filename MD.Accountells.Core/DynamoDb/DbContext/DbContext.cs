/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using Amazon.DynamoDBv2;
    using Amazon.DynamoDBv2.DataModel;
    using System;
    using System.Collections.Generic;
    using Amazon.DynamoDBv2.Model;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DbContext : DynamoDBContext, IDbContext
    {
        private readonly IAmazonDynamoDB _client;
        private IModelBuilder _modelBuilder;

        public event EventHandler<DbContextActionMessage> OnMessaging;

        public IAmazonDynamoDB Client => this._client;
        public DbContext(IAmazonDynamoDB client) : base(client)
        {
            this._modelBuilder = new ModelBuilder();
            this._client = client;
        }
        public bool EnsureCreated()
        {
            OnModelCreating(this._modelBuilder);

            try
            {
                checkAndCreate(this._modelBuilder.TableSpecs).Wait();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        protected virtual void OnModelCreating(IModelBuilder modelBuilder)
        {
            if (modelBuilder.Tables == null || !modelBuilder.Tables.Any())
            {
                throw new Exception("At least one entity should be present to execute");
            }
        }

        private async Task checkAndCreate(TableInfo[] tablesToCheck)
        {
            //Get all available tables in database
            var tableResponse = await _client.ListTablesAsync();

            tablesToCheck
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

            OnMessaging.Invoke(this,
                new DbContextActionMessage(
                    isTableAvailable ? $"Created table: {tblToCreate.tableName}"
                        : $"Unable to to create table: {tblToCreate.tableName}",
                    isTableAvailable ? DbContextActionMessageType.Info : DbContextActionMessageType.Error)
                );
        }
    }
}
