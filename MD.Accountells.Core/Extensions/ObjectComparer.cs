/// <summary>
/// Author: Meghnath Das
/// Description:
/// URL: http://meghnathdas.github.io/
/// </summary>
namespace MD.Accountella.Core.Extensions
{
    using System;
    public static class ObjectComparer
    {
        public static bool IsEqual(this object Object1, object Object2)
        {
            return AreEqual(Object1, Object2);
        }
        public static bool Equals<T>(T Object1, T Object2)
        {
            //return false if any of the object is false
            if (object.Equals(Object1, default(T)) || object.Equals(Object2, default(T)))
                return false;

            return AreEqual(Object1, Object2);
        }
        public static bool AreEqual(object Object1, object Object2)
        {
            //Get the type of the object
            Type type = Object1.GetType();

            if (!type.Equals(Object2.GetType()))
                return false;

            //Loop through each properties inside class and get values for the property from both the objects and compare
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                if (property.Name != "ExtensionData")
                {
                    string Object1Value = string.Empty;
                    string Object2Value = string.Empty;
                    if (type.GetProperty(property.Name).GetValue(Object1, null) != null)
                        Object1Value = type.GetProperty(property.Name).GetValue(Object1, null).ToString();
                    if (type.GetProperty(property.Name).GetValue(Object2, null) != null)
                        Object2Value = type.GetProperty(property.Name).GetValue(Object2, null).ToString();
                    if (Object1Value.Trim() != Object2Value.Trim())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
