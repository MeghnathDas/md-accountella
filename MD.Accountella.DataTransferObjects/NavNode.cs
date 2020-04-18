/// <summary>
/// Author: Meghnath Das
/// Description: Model represents single node of navigation menu
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DataTransferObjects
{
    using System.Collections.Generic;

    public class NavNode
    {
        public int id { get; set; }
        public string label { get; set; }
        public string icon { get; set; }
        public string route { get; set; }
        public NavNode[] nodes { get; set; }
    }
}
