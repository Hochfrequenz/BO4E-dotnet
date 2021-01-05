using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BO4E.meta;

namespace BO4E.Extensions.Encryption
{
    internal static class FieldInfoExtensions
    {
        internal static bool IsAnonymizerRelevant(this PropertyInfo prop, AnonymizerApproach approach, DataCategory? dataCategory)
        {
            switch (approach)
            {
                case AnonymizerApproach.DELETE:
                    return prop.IsDeletionRelevant(dataCategory);
                case AnonymizerApproach.HASH:
                    return prop.IsHashingRelevant(dataCategory);
                case AnonymizerApproach.ENCRYPT:
                case AnonymizerApproach.DECRYPT:
                    return prop.IsEncryptionRelevant(dataCategory);
                default:
                    return false;
            }
        }
    
        internal static bool IsHashingRelevant(this PropertyInfo property, DataCategory? dataCategory)
        {
            if (property.PropertyType.IsSubclassOf(typeof(BO4E.COM.COM)) || property.PropertyType.IsSubclassOf(typeof(BO.BusinessObject)))
            {
                return true;
            }

            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var listElementType = property.PropertyType.GetGenericArguments()[0];
                return listElementType.IsSubclassOf(typeof(BO4E.COM.COM)) || listElementType.IsSubclassOf(typeof(BO.BusinessObject));
            }
            if (dataCategory.HasValue)
            {
                return property.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)).Cast<DataCategoryAttribute>().Any(dataCatagoryAttribute => dataCatagoryAttribute.Mapping.Contains(dataCategory.Value));
            }

            return false;
        }

        internal static bool IsEncryptionRelevant(this PropertyInfo property, DataCategory? dataCategory)
        {
            if (property.PropertyType.IsSubclassOf(typeof(BO4E.COM.COM)) || property.PropertyType.IsSubclassOf(typeof(BO.BusinessObject)) || property.PropertyType.IsEnum)
            {
                return false; // not yet supported for encryption
            }
            if (dataCategory.HasValue)
            {
                foreach (var attribute in property.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    var dataCategoryAttribute = (DataCategoryAttribute)attribute;
                    if (!dataCategoryAttribute.Mapping.Contains(dataCategory.Value))
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        internal static bool IsDeletionRelevant(this PropertyInfo property, DataCategory? dataCategory)
        {
            if (property.PropertyType.IsEnum)
            {
                return false;
            }
            if (dataCategory.HasValue)
            {
                return property.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)).Cast<DataCategoryAttribute>().Any(dataCatagoryAttribute => dataCatagoryAttribute.Mapping.Contains(dataCategory.Value));
            }
            return false;
        }
    }
}
