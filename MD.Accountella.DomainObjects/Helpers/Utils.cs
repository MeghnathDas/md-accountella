using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
/// <summary>
/// Author: Meghnath Das
/// Description: 
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects.Helpers
{
    public static class Utils
    {
        internal const string tableNamePrefix = "AcTla_";

        public static Type[] GetTableTypes()
        {
            IEnumerable<Type> getTypesWithHelpAttribute(Assembly assembly)
            {
                return assembly.GetTypes()
                    .Where(type => type.GetCustomAttributes(typeof(DynamoDBTableAttribute), true).Length > 0);
            }
            return getTypesWithHelpAttribute(Assembly.GetExecutingAssembly()).ToArray();
        }
    }
}
