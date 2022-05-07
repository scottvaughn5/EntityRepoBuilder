using EntityRepoBuilder.Scanner.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Entities
{
    [TableTarget("test_table", "t")]
    //[WhiteList] // tells the scanner to skip default to read, update, create
    [Destroyable] // allows the creation of deletion scripts in repository
    [CamelCase] // attributes to define the casing to map entity columns to their db nomenclature
    [SnakeCase]
    public class RootEntity
    {
        [ReadOnly] // only allows property in read queries
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
