using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.ExtensionMethods
{
    static class StringExtension
    {
        public static KeyValuePair<string, Type> AsType(this string key, Type type)
        {
            return new KeyValuePair<string, Type>(key, type);
        }

        public static string JoinSQLiteKeyValuePair(this Dictionary<string, Type> keyValuePairs)
        {
            List<string> result = new List<string>();

            foreach (KeyValuePair<string, Type> keyValuePair in keyValuePairs)
            {
                result.Add($"{keyValuePair.Key} {keyValuePair.Value.TypeToSQLiteDataType()}");
            }

            return string.Join(", ", result);
        }

        public static dynamic CheckIfString(dynamic input)
        {
            if (input is string)
                return $"'{input}'";
            else
                return input;
        }

        public static dynamic[] ArrayStringsToSQLiteStrings(this dynamic[] sourceArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
                if (sourceArray[i] is string)
                    sourceArray[i] = $"'{sourceArray[i]}'";

            return sourceArray;
        }
    }
}
