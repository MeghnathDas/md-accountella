/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    public interface IModelBuilder
    {
        public void IncludeAllAvailableEntities();
        internal TableInfo[] TableSpecs { get; }
    }
}
