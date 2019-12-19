using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BO4E.meta;

namespace BO4E.Extensions.Encryption
{
    internal static class FieldInfoExtensions
    {
        internal static bool IsAnonymizerRelevant(this FieldInfo field, AnonymizerApproach approach, DataCategory? dataCategory)
        {
            switch (approach)
            {
                case AnonymizerApproach.DELETE:
                    return field.IsDeletionRelevant(dataCategory);
                case AnonymizerApproach.HASH:
                    return field.IsHashingRelevant(dataCategory);
                case AnonymizerApproach.ENCRYPT:
                case AnonymizerApproach.DECRYPT:
                    return field.IsEncryptionRelevant(dataCategory);
                case AnonymizerApproach.KEEP:
                default:
                    return false;
            }
        }
    
        internal static bool IsHashingRelevant(this FieldInfo field, DataCategory? dataCategory)
        {
            if (field.FieldType.IsSubclassOf(typeof(BO4E.COM.COM)) || field.FieldType.IsSubclassOf(typeof(BO4E.BO.BusinessObject)))
            {
                return true;
            }
            else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
            {
                var listElementType = field.FieldType.GetGenericArguments()[0];
                return listElementType.IsSubclassOf(typeof(BO4E.COM.COM)) || listElementType.IsSubclassOf(typeof(BO4E.BO.BusinessObject));
            }
            else if (dataCategory.HasValue)
            {
                foreach (Attribute attribute in field.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    DataCategoryAttribute dataCatagoryAttribute = (DataCategoryAttribute)attribute;
                    if (!dataCatagoryAttribute.Mapping.Contains(dataCategory.Value))
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        internal static bool IsEncryptionRelevant(this FieldInfo field, DataCategory? dataCategory)
        {
            if (field.FieldType.IsSubclassOf(typeof(BO4E.COM.COM)) || field.FieldType.IsSubclassOf(typeof(BO4E.BO.BusinessObject)) || field.FieldType.IsEnum)
            {
                return false; // not yet supported for encryption
            }
            if (dataCategory.HasValue)
            {
                foreach (Attribute attribute in field.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    DataCategoryAttribute dataCatagoryAttribute = (DataCategoryAttribute)attribute;
                    if (!dataCatagoryAttribute.Mapping.Contains(dataCategory.Value))
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        internal static bool IsDeletionRelevant(this FieldInfo field, DataCategory? dataCategory)
        {
            if (field.FieldType.IsEnum)
            {
                return false;
            }
            if (dataCategory.HasValue)
            {
                foreach (Attribute attribute in field.GetCustomAttributes().Where(a => a.GetType() == typeof(DataCategoryAttribute)))
                {
                    DataCategoryAttribute dataCatagoryAttribute = (DataCategoryAttribute)attribute;
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
