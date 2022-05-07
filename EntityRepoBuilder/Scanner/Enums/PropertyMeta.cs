using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner.Constants
{
    internal static class PropertyMeta
    {
        public enum Enum
        {
            Create,
            Read,
            Update,
            Destroy,
            Mutation, // encompasses all Create, Update, Destroy
            CRUD,
            Dependent
            
        }
    }
}
