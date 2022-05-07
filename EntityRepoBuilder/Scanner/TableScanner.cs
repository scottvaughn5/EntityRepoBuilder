using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner
{
    internal static class TableScanner
    {
        internal static IEnumerable<CustomAttributeData> _getAttributes(Type Entity)
        {
            return Entity.CustomAttributes;
        }

        internal static string _categorize(this IEnumerable<CustomAttributeData> customAttributes)
        {


            return "";
        }
    }
}
