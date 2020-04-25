/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.DynamoDb
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEntitySeedDataProvider<TEntity> : IExecuter
    {
        public void SetData(List<TEntity> data);
    }
}
