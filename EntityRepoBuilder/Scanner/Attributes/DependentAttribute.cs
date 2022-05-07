using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner.Attributes
{
    internal class DependentAttribute: Attribute
    {
        public Type DependentType { get; set; }
        public DependentAttribute(Type dependentType)
        {
            DependentType = dependentType;
        }
    }
}
