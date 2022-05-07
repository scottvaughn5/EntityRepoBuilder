using EntityRepoBuilder.Objects.Extensions;
using EntityRepoBuilder.Scanner.Constants;
using EntityRepoBuilder.Scanner.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.QueryBuilder
{
    internal class QueryBuilder
    {
        private TableTarget TableTarget { get; set; }
        public QueryBuilder(TableTarget tableTarget)
        {
            TableTarget = tableTarget;
        }

        public string GenerateSelect()
        {
            return TableTarget.Select();
        }
        public string GenerateUpdate()
        {
            return TableTarget.Update();
        }
        public string GenerateInsert()
        {
            return TableTarget.Create();
        }
    }
}
