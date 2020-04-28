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
    using Amazon.DynamoDBv2.DocumentModel;

    public abstract class DbContext : DynamoDBContext, IDbContext
    {
        private readonly IAmazonDynamoDB _client;
        private readonly EntityBuilder _entityBuilder;

        public event EventHandler<DbContextActionMessage> OnMessaging;
        public abstract void OnModelCreating(EntityBuilder entityBuilder);

        public IAmazonDynamoDB Client => this._client;
        public DbContext(IAmazonDynamoDB client) : base(client)
        {
            this._entityBuilder = new EntityBuilder();
            this._client = client;
        }
        public bool EnsureCreated()
        {
            OnModelCreating(this._entityBuilder);
            if (_entityBuilder.TableSpecs == null || !_entityBuilder.TableSpecs.Any())
            {
                throw new Exception("At least one entity should be present to execute");
            }

            try
            {
                checkAndCreate(_entityBuilder.TableSpecs).ContinueWith((t) =>
                {
                    if (t.IsCompleted)
                        processSeedData(this._entityBuilder.TableSpecs.SelectMany(tbl => tbl.SeedDataProviders).ToArray());
                });

            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        private Task checkAndCreate(DbTableWithSeedInfo[] tablesToCheck)
        {
            return Task.Run(() =>
            {
                //Get all available tables in database
                var tableResponse = _client.ListTablesAsync().Result;

                tablesToCheck
                .Where(x => !tableResponse.TableNames.Contains(x.tableName))
                .ToList()
                .ForEach(tblSpec =>
                {
                    createTable(tblSpec);
                });
            });

            void createTable(DbTableWithSeedInfo tblToCreate)
            {
                var attrDefinations = new List<AttributeDefinition>();
                var keySchema = new List<KeySchemaElement>();

                foreach (var attr in tblToCreate.attributes.Where(x => x.isPrimary || x.isRange))
                {
                    keySchema.Add(new KeySchemaElement
                    {
                        AttributeName = attr.name,
                        KeyType = attr.isPrimary ? KeyType.HASH : KeyType.RANGE
                    });
                    attrDefinations.Add(new AttributeDefinition
                    {
                        AttributeName = attr.name,
                        AttributeType = attr.dataType == typeof(int) ? ScalarAttributeType.N : ScalarAttributeType.S
                    });
                }

                _client.CreateTableAsync(new CreateTableRequest
                {
                    TableName = tblToCreate.tableName,
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 4,
                        WriteCapacityUnits = 2
                    },
                    KeySchema = keySchema,
                    AttributeDefinitions = attrDefinations
                }).Wait();

                bool isTableAvailable = false;
                while (!isTableAvailable)
                {
                    //"Waiting for table to be active...
                    Thread.Sleep(5000);
                    var tableStatus = _client.DescribeTableAsync(tblToCreate.tableName).Result;
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

        private void processSeedData(ICollection<IDataProcessor> seedDataProcessors)
        {
            OnMessaging.Invoke(this,
                    new DbContextActionMessage("Processing seed data", DbContextActionMessageType.Info)
                );

            bool isSuccess = false;
            string msg = string.Empty;
            try
            {
                var allBatch = seedDataProcessors.Select(sp => sp.GetBatchWrite(this)).ToArray();
                var superBatch = new MultiTableBatchWrite(allBatch);
                superBatch.ExecuteAsync().Wait();
                isSuccess = true;
                msg = "Seed data processed sucessfully";
            }
            catch (Exception ex)
            {
                isSuccess = false;
                msg = ex.Message;
            }

            OnMessaging.Invoke(this,
                new DbContextActionMessage(
                    isSuccess ? msg
                        : $"Seed data processing error: {msg}",
                    isSuccess ? DbContextActionMessageType.Info : DbContextActionMessageType.Error)
                );
        }
    }
}
