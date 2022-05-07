using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner.Attributes
{
    public class TableTargetAttribute: Attribute
    {
        public string TableName { get; set; }
        public string TableAlias { get; set; }
        public TableTargetAttribute(string destTable, string alias)
        {
            (TableName, TableAlias) = (destTable, alias);
        }
    }
}
