/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.MongoDb
{
    public interface IEntityBuilder
    {
        public void Entity<TEntity>() where TEntity : class;

    }
}
