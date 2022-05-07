using EntityRepoBuilder.Scanner.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Entities
{
    [TableTarget("test_table", "t")]
    public class RootEntity
    {
        [ReadOnly]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ReadOnly]
        public DateTime DateCreated { get; set; }
        [ReadOnly]
        public Guid CreatedBy { get; set; }
        [ReadOnly]
        public DateTime LastModifiedOn { get; set; }
        public Guid LastModifiedBy { get; set; }
        public int Order { get; set; }

        // stretch
        [Dependent(typeof(DependentEntity))]
        public DependentEntity Dependent { get; set; }
    }
}
