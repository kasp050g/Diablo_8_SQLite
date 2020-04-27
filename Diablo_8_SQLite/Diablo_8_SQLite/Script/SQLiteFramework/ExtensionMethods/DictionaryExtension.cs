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
    }
}
