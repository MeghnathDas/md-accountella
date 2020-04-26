/// <summary>
/// Author: Meghnath Das
/// Description: Converts the Module enum values to string and vice-versa.
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class EnumTypeConverter<IEnum> : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            DynamoDBEntry entry = new Primitive
            {
                Value = ((IEnum)value).ToString()
            };
            return entry;
        }

        public object FromEntry(DynamoDBEntry entry)
        {
            Primitive primitive = entry as Primitive;
            
            return (IEnum)Enum.Parse(typeof(IEnum), (string)primitive.Value);
        }
    }
}
