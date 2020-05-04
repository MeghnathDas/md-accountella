/// <summary>
/// Author: Meghnath Das
/// Description: Interface for Nav menu service
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.BL
{
    using MD.Accountella.DataTransferObjects;
    using System.Collections.Generic;

    public interface INavMenuService
    {
        public ICollection<NavNode> GetPermisibleNavNodes();
    }
}
