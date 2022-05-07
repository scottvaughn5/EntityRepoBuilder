using EntityRepoBuilder.Scanner.Attributes.Literals;
using EntityRepoBuilder.Scanner.Constants;
using EntityRepoBuilder.Scanner.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner
{
    public static class EntityScanner
    {
        public static TableTarget Scan(this object Entity)
        {
            return ScanEntity(Entity.GetType());
        }
        public static TableTarget ScanEntity(Type Entity)
        {
            return Entity._ProcessEntity();
        }

        private static TableTarget _ProcessEntity(this Type Entity)
        {
            var table = new TableTarget();

            table.Meta = TableScanner._getAttributes(Entity)._buildMeta();
            table.Properties = PropertyScanner._getProperties(Entity)._categorize(table.Meta.WhiteList);
            return table;
        }
    }
}
