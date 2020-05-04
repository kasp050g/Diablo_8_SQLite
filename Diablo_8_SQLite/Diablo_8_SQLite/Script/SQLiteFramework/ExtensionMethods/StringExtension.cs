using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.ExtensionMethods
{
    static class StringExtension
    {
        /// <summary>
        /// Pairs a string with a given Type.
        /// </summary>
        /// <param name="key">Name of a column.</param>
        /// <param name="type">Column Type. Example: typeof(int)</param>
        /// <returns></returns>
        public static KeyValuePair<string, Type> AsType(this string key, Type type)
        {
            return new KeyValuePair<string, Type>(key, type);
        }

        /// <summary>
        /// Pairs a string with a given value(var/dynamic).
        /// </summary>
        /// <param name="key">Name of a column.</param>
        /// <param name="value">Value to add to a column.</param>
        /// <returns></returns>
        public static KeyValuePair<string, dynamic> Pair(this string key, dynamic value)
        {
            return new KeyValuePair<string, dynamic>(key, value);
        }

        /// <summary>
        /// Joins several KvP's to a string.
        /// </summary>
        /// <param name="keyValuePairs"></param>
        /// <returns></returns>
        public static string JoinSQLiteKeyValuePair(this Dictionary<string, Type> keyValuePairs)
        {
            List<string> result = new List<string>();

            foreach (KeyValuePair<string, Type> keyValuePair in keyValuePairs)
                result.Add($"{keyValuePair.Key} {keyValuePair.Value.TypeToSQLiteDataType()}");

            return string.Join(", ", result);
        }

        /// <summary>
        /// Joins several KvP's to a string, made for SQLite UPDATE command.
        /// </summary>
        /// <typeparam name="TKey">Key type.</typeparam>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="keyValuePairs">Key Value Pairs.</param>
        /// <returns></returns>
        public static string UpdateJoinSQLiteKeyValuePair<TKey, TValue>(this Dictionary<TKey, TValue> keyValuePairs)
        {
            List<string> result = new List<string>();

            foreach (KeyValuePair<TKey, TValue> keyValuePair in keyValuePairs)
                result.Add($"{keyValuePair.Key} = {CheckIfString(keyValuePair.Value)}");

            return string.Join(", ", result);
        }

        /// <summary>
        /// Check if a dynamic is a string. If yes => Convert to SQLite string.
        /// </summary>
        /// <param name="input">Dynamic to check.</param>
        /// <returns></returns>
        public static dynamic CheckIfString(dynamic input)
        {
            if (input is string)
                return $"'{input}'";
            else
                return input;
        }

        /// <summary>
        /// Convert an array of Dynamics to a SQLite string.
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <returns></returns>
        public static dynamic[] ArrayStringsToSQLiteStrings(this dynamic[] sourceArray)
        {
            for (int i = 0; i < sourceArray.Length; i++)
                if (sourceArray[i] is string)
                    sourceArray[i] = $"'{sourceArray[i]}'";

                else if (sourceArray[i] is bool)
                    sourceArray[i] = Convert.ToString((bool)sourceArray[i].BoolToIntSQLite());

            return sourceArray;
        }
    }
}
