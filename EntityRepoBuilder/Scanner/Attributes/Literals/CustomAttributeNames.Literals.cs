﻿using EntityRepoBuilder.Scanner.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner.Attributes.Literals
{
    internal static class CustomAttributeNames
    {
        //table
        public static readonly string TableTargetAttribute = "TableTargetAttribute";
        public static readonly string WhiteListAttribute = "WhiteListAttribute";
        // property
        public static readonly string ReadOnlyAttribute = "ReadOnlyAttribute";
        public static readonly string DependentAttribute = "DependentAttribute";

        public static readonly Dictionary<string, PropertyMeta.Enum> PropMap = new Dictionary<string, PropertyMeta.Enum>()
        {
            { ReadOnlyAttribute, PropertyMeta.Enum.Read },
            { DependentAttribute, PropertyMeta.Enum.Dependent },
        };
        public static readonly Dictionary<string, TableMeta.Enum> TableMap = new Dictionary<string, TableMeta.Enum>()
        {
            { TableTargetAttribute, TableMeta.Enum.TableTarget },
            { WhiteListAttribute, TableMeta.Enum.WhiteList}
        };
    }
}
