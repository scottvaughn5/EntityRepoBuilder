using EntityRepoBuilder.Enums;
using EntityRepoBuilder.QueryBuilder;
using EntityRepoBuilder.Scanner.Constants;
using EntityRepoBuilder.Scanner.Objects;
using EntityRepoBuilder.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Objects.Extensions
{
    public static class TableTargetExtensions
    {
        #region Col Strings
        private static string GenerateCreateColString(this TableTarget tableTarget)
        {
            return tableTarget.GenerateColString(PropertyMeta.Enum.Create);
        }
        private static string GenerateReadColString(this TableTarget tableTarget)
        {
            return tableTarget.GenerateColString(PropertyMeta.Enum.Read);
        }
        private static string GenerateUpdateColString(this TableTarget tableTarget)
        {
            return tableTarget.GenerateColString(PropertyMeta.Enum.Update);
        }


        private static string GenerateColString(this TableTarget tableTarget, PropertyMeta.Enum queryType)
        {
            StringBuilder colString = new StringBuilder();
            var properties = tableTarget.Properties[queryType];
            int index = 0;
            int len = properties.Count - 1;
            foreach (var property in properties)
            {
                // never alias create col string
                if (!string.IsNullOrEmpty(tableTarget.Meta.Alias) && queryType != PropertyMeta.Enum.Create)
                {
                    colString.Append(tableTarget.Meta.Alias);
                    colString.Append(".");
                }
                colString.Append(tableTarget.ColString(property.Name, queryType, index));
                if (index < len)
                {
                    colString.Append(",");
                }
                index++;
            }
            return colString.ToString();
        }

        public static string ColString(this TableTarget tableTarget, string propertyName, PropertyMeta.Enum queryType, int index)
        {
            var colString = tableTarget.ManipulateCase(propertyName);
            switch (queryType)
            {
                case PropertyMeta.Enum.Update:
                    colString = $"{colString}=" + "{" + index + "}";
                    break;
            }
            return colString;
        }

        #endregion

        #region Case Manipulation
        private static string ManipulateCase(this TableTarget tableTarget, string propName)
        {
            switch (tableTarget.Meta.Case)
            {
                case (FormattingMeta.Enum.SnakeCase):
                    return propName.ToSnakeCase();
            }
            return propName;
        }
        #endregion

        #region Read Queries
        public static string Select(this TableTarget tableTarget)
        {
            return Queries.ConvertRead(tableTarget.GenerateReadColString(), tableTarget.Meta.TableName, tableTarget.Meta.Alias);
        }
        #endregion

        #region Update Queries
        public static string Update(this TableTarget tableTarget)
        {
            return Queries.ConvertUpdate(tableTarget.GenerateUpdateColString(), tableTarget.Meta.TableName, tableTarget.Meta.Alias);
        }
        #endregion
        #region Create Queries
        public static string Create(this TableTarget tableTarget)
        {
            return Queries.ConvertCreate(tableTarget.GenerateCreateColString(), tableTarget.Meta.TableName, tableTarget.Meta.Alias);
        }
        #endregion
    }
}
