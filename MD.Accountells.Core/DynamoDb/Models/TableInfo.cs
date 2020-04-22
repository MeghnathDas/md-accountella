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
    internal class TableInfo
    {
        public string tableName { get; set; }
        public List<attrINfo> attributes { get; set; }

        public class attrINfo
        {
            public string name { get; set; }
            public Type dataType { get; set; }
            public bool isPrimary { get; set; }
        }
    }
}
