using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner.Constants
{
    public static class TableMeta
    {
        public enum Enum
        {
            TableTarget,
            WhiteList,
            Destroyable,
            CamelCase,
            SnakeCase
        }
    }
}
