/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    public interface IEntityBuilder
    {
        public void IncludeAllAvailableEntities();
        public void Entity<TEntity>() where TEntity : class;

    }
}
