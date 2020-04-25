/// <summary>
/// Author: Meghnath Das
/// Description: Converts the DateTimeOffset to string and vice-versa.
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.DomainObjects
{
    using Amazon.DynamoDBv2.DataModel;
    using Amazon.DynamoDBv2.DocumentModel;
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class DateTimeOffsetTypeConverter : IPropertyConverter
    {
        public DynamoDBEntry ToEntry(object value)
        {
            var dateTimeOffsetValue = (DateTimeOffset)value;
            if (dateTimeOffsetValue == null) throw new ArgumentOutOfRangeException();

            string data = dateTimeOffsetValue.ToString();

            DynamoDBEntry entry = new Primitive
            {
                Value = data
            };
            return entry;
        }

        public object FromEntry(DynamoDBEntry entry)
        {
            Primitive primitive = entry as Primitive;

            DateTimeOffset? dtVal = null;
            try
            {
                dtVal = DateTimeOffset.Parse((string)primitive.Value);
            }
            catch (Exception)
            {
            }

            return dtVal;
        }
    }
}
