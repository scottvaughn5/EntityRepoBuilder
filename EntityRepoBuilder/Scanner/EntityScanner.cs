using EntityRepoBuilder.Scanner.Attributes.Literals;
using EntityRepoBuilder.Scanner.Constants;
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
        public static void Scan(this object Entity)
        {
            ScanEntity(Entity.GetType());
        }
        public static void ScanEntity(Type Entity)
        {
            Entity._ProcessEntity();
            var deeb = Entity;

        }

        private static void _ProcessEntity(this Type Entity)
        {
            var tableMeta = TableScanner._getAttributes(Entity)._categorize();
            var properties = PropertyScanner._getProperties(Entity)._categorize();
        }
    }
}
