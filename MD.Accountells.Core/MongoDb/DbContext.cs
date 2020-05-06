/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class DbContext : IDbContext
    {
        private readonly IMongoDatabase _db;
        public readonly MongoClient _client;
        private readonly EntityBuilder _entityBuilder;

        public event EventHandler<DbContextActionMessage> OnMessaging;
        public abstract void OnModelCreating(EntityBuilder entityBuilder);

        public IMongoDatabase DB => this._db;
        public DbContext(IMongoDbConfig config)
        {
            this._client = new MongoClient(config.ConnectionString);
            this._db = this._client.GetDatabase(config.DataBaseName);
            this._entityBuilder = new EntityBuilder();
        }
        public void EnsureTablesCreatedWithSeedData()
        {
            OnModelCreating(this._entityBuilder);
            if (_entityBuilder.TableSpecs == null || !_entityBuilder.TableSpecs.Any())
            {
                throw new Exception("At least one entity should be present to execute");
            }

            processSeedData(this._entityBuilder.TableSpecs.SelectMany(tbl => tbl.SeedDataProviders).ToArray());
        }
        private void processSeedData(ICollection<IDataProcessor> seedDataProcessors)
        {
            OnMessaging.Invoke(this,
                    new DbContextActionMessage("Working on seed data", DbContextActionMessageType.Info)
                );

            bool isSuccess = false;
            string msg = string.Empty;
            try
            {
                var allBatch = Task.WhenAll(
                    seedDataProcessors.Select(sp => sp.ExecuteAsync(DB))
                );
                allBatch.Wait();

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

            if (!isSuccess)
                throw new Exception($"Seed data processing error: {msg}");
        }
    }

    public interface IDbContext
    {
        event EventHandler<DbContextActionMessage> OnMessaging;
        IMongoDatabase DB { get; }
        void EnsureTablesCreatedWithSeedData();
    }
}
