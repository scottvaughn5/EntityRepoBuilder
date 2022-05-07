using EntityRepoBuilder.Enums;
using EntityRepoBuilder.Scanner.Attributes.Literals;
using EntityRepoBuilder.Scanner.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static EntityRepoBuilder.Scanner.Objects.TableTarget;

namespace EntityRepoBuilder.Scanner
{
    internal static class TableScanner
    {
        internal static IEnumerable<CustomAttributeData> _getAttributes(Type Entity)
        {
            return Entity.CustomAttributes;
        }

        internal static TableTargetMeta _buildMeta(this IEnumerable<CustomAttributeData> customAttributes)
        {
            var tableMeta = new TableTargetMeta();
            foreach (CustomAttributeData attribute in customAttributes)
            {
                TableMeta.Enum destination;
                if (CustomAttributeNames.TableMap.TryGetValue(attribute.AttributeType.Name, out destination))
                {
                    switch (destination)
                    {
                        case TableMeta.Enum.WhiteList:
                            tableMeta.WhiteList = true;
                            break;
                        case TableMeta.Enum.TableTarget:
                            tableMeta._processTableTarget(attribute);
                            break;
                        case TableMeta.Enum.CamelCase:
                            tableMeta.Case = FormattingMeta.Enum.CamelCase;
                            break;
                        case TableMeta.Enum.SnakeCase:
                            tableMeta.Case = FormattingMeta.Enum.SnakeCase;
                            break;

                    }
                }
            }

            return tableMeta;
        }
        private static void _processTableTarget(this TableTargetMeta tableMeta, CustomAttributeData attribute)
        {
            try
            {
                tableMeta.TableName = attribute.ConstructorArguments[0].Value.ToString();
                tableMeta.Alias = attribute.ConstructorArguments[1].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("DAPPERHELPER--INVALID TABLETARGET: Must define TableName and Alias");
            }
        }
    }
}
