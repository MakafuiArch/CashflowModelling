using Microsoft.Data.SqlClient;
using System.Reflection;

namespace IRR.Domain.ModelMappers
{
    public class SQLMap
    {

        public T MapToClass<T>(SqlDataReader reader) where T : class
        {
            T returnedObject = Activator.CreateInstance<T>();
            PropertyInfo[] modelProperties = returnedObject.GetType().GetProperties();

            foreach (PropertyInfo property in modelProperties)
            {
                ModelAttribute[] attributes = property.GetCustomAttributes<ModelAttribute>(true).ToArray();
                if (attributes.Length > 0 && attributes[0].ColumnName != null)
                {
                    property.SetValue(returnedObject, Convert.ChangeType(reader[attributes[0].ColumnName], 
                        property.PropertyType), null);
                }
            }

            return returnedObject;
        }

    }
}
