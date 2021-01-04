using System;
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
                case AnonymizerApproach.KEEP:
                default:
                    return false;
            }
        }
    
        internal static bool IsHashingRelevant(this PropertyInfo property, DataCategory? dataCategory)
        {
            if (property.PropertyType.IsSubclassOf(typeof(BO4E.COM.Com)) || property.PropertyType.IsSubclassOf(typeof(BO.BusinessObject)))
            {
                return true;
            }
            else if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var listElementType = property.PropertyType.GetGenericArguments()[0];
                return listElementType.IsSubclassOf(typeof(BO4E.COM.Com)) || listElementType.IsSubclassOf(typeof(BO.BusinessObject));
            }
            else if (dataCategory.HasValue)
            {
                foreach (var attribute in property.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    var dataCatagoryAttribute = (DataCategoryAttribute)attribute;
                    if (!dataCatagoryAttribute.Mapping.Contains(dataCategory.Value))
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        internal static bool IsEncryptionRelevant(this PropertyInfo property, DataCategory? dataCategory)
        {
            if (property.PropertyType.IsSubclassOf(typeof(BO4E.COM.Com)) || property.PropertyType.IsSubclassOf(typeof(BO.BusinessObject)) || property.PropertyType.IsEnum)
            {
                return false; // not yet supported for encryption
            }
            if (dataCategory.HasValue)
            {
                foreach (var attribute in property.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    var dataCatagoryAttribute = (DataCategoryAttribute)attribute;
                    if (!dataCatagoryAttribute.Mapping.Contains(dataCategory.Value))
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
                foreach (var attribute in property.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    var dataCatagoryAttribute = (DataCategoryAttribute)attribute;
                    if (!dataCatagoryAttribute.Mapping.Contains(dataCategory.Value))
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
