using EntityRepoBuilder.Enums;
using EntityRepoBuilder.Scanner.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner.Objects
{
    public class TableTarget
    {
        public class TableTargetMeta
        {
            public string TableName { get; set; }
            public string Alias { get; set; }
            public bool WhiteList { get; set; } = false;
            public FormattingMeta.Enum Case { get; set; }
        }
        public TableTargetMeta Meta { get; set; }

        public Dictionary<PropertyMeta.Enum, List<PropertyInfo>> Properties { get; set; } = new Dictionary<PropertyMeta.Enum, List<PropertyInfo>>();
    }
}
