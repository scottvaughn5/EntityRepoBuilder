using EntityRepoBuilder.Scanner.Attributes.Literals;
using EntityRepoBuilder.Scanner.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityRepoBuilder.Scanner
{
    internal static class PropertyScanner
    {
        internal static Dictionary<PropertyMeta.Enum, List<PropertyInfo>> _categorize(this IList<PropertyInfo> properties, bool whiteList = false)
        {
            var sortedProps = new Dictionary<PropertyMeta.Enum, List<PropertyInfo>>();
            foreach (PropertyInfo property in properties)
            {
                sortedProps._assignCategory(property);
            }
            return sortedProps._mergeReadTypes();
        }

        private static Dictionary<PropertyMeta.Enum, List<PropertyInfo>> _mergeReadTypes(this Dictionary<PropertyMeta.Enum, List<PropertyInfo>> sortedProps)
        {
            if (sortedProps.ContainsKey(PropertyMeta.Enum.ReadOnly) && sortedProps.ContainsKey(PropertyMeta.Enum.Read))
            {
                sortedProps[PropertyMeta.Enum.Read] = sortedProps[PropertyMeta.Enum.ReadOnly].Concat(sortedProps[PropertyMeta.Enum.Read]).ToList();
            }
            return sortedProps;
        }

        private static Dictionary<PropertyMeta.Enum, List<PropertyInfo>> _assignCategory(this Dictionary<PropertyMeta.Enum, List<PropertyInfo>> sortedProps, PropertyInfo currentProp, bool whiteList=false)
        {
            var addedViaCustom = new HashSet<PropertyMeta.Enum>();
            // scan the properties for any custom attributes registered for the scanner
            if (currentProp.CustomAttributes.Any())
            {
                foreach (var attribute in currentProp.CustomAttributes)
                {
                    PropertyMeta.Enum attributeMappedDest;
                    if (CustomAttributeNames.PropMap.TryGetValue(attribute.AttributeType.Name, out attributeMappedDest))
                    {
                        sortedProps._assignPropToType(attributeMappedDest, currentProp);
                        addedViaCustom.Add(attributeMappedDest);
                    }
                }
            }
            // if no custom attribute is assigned to a property then we default it to CRUD
            if (!whiteList && 
                !(addedViaCustom.Contains(PropertyMeta.Enum.ReadOnly) || addedViaCustom.Contains(PropertyMeta.Enum.Dependent)))
            {
                sortedProps._assignCRU(currentProp);
            }
            return sortedProps;
        }
        /// <summary>
        /// Handles adding new dictionary entry or updating existing
        /// </summary>
        /// <param name="sortedProps"></param>
        /// <param name="destination"></param>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private static Dictionary<PropertyMeta.Enum, List<PropertyInfo>> _assignPropToType(this Dictionary<PropertyMeta.Enum, List<PropertyInfo>> sortedProps, PropertyMeta.Enum destination, PropertyInfo propertyInfo)
        {
            List<PropertyInfo> properties;
            if (sortedProps.TryGetValue(destination, out properties))
            {
                properties.Add(propertyInfo);
                sortedProps[destination] = properties;
            }
            else
            {
                sortedProps.Add(destination, new List<PropertyInfo>() { propertyInfo });
            }
            return sortedProps;
        }
        /// <summary>
        /// Fetches list of property info values from type
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        internal static IList<PropertyInfo> _getProperties(this Type Entity)
        {
            return new List<PropertyInfo>(Entity.GetProperties());
        }

        private static Dictionary<PropertyMeta.Enum, List<PropertyInfo>> _assignCRU(this Dictionary<PropertyMeta.Enum, List<PropertyInfo>> sortedProps, PropertyInfo currentProp)
        {
            sortedProps._assignPropToType(PropertyMeta.Enum.Create, currentProp);
            sortedProps._assignPropToType(PropertyMeta.Enum.Read, currentProp);
            sortedProps._assignPropToType(PropertyMeta.Enum.Update, currentProp);
            return sortedProps;
        }
    }
}
