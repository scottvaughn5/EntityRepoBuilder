using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Entities
{
    public class DependentEntity
    {
        public Guid Id { get; set; }
        public Guid RootEntityUID { get; set; } 
    }
}
