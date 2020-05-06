/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    public interface IEntityBuilder
    {
        EntitySeedDataProvider<TEntity> UseSeedData<TEntity, TEntitySeedDataProvider>()
            where TEntitySeedDataProvider : IEntitySeedDataProvider<TEntity>;
    }
}
