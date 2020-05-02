using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.ExtensionMethods
{
    static class DictionaryExtension
    {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, Dictionary<TKey, TValue> range)
        {
            foreach (KeyValuePair<TKey, TValue> keyValuePair in range)
                dictionary.Add(keyValuePair.Key, keyValuePair.Value);
        }

        public static void ChangeKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TKey newKey)
        {
            TValue value = dictionary[key];

            dictionary.Remove(key);
            dictionary[newKey] = value;
        }

        public static Dictionary<TKey, TValue> CombineArrays<TKey, TValue>(TKey[] arrayA, TValue[] arrayB)
        {
            return arrayA.Zip(arrayB, (k, v) => new { k, v }).ToDictionary(kvp => kvp.k, kvp => kvp.v);
        }
    }
}
