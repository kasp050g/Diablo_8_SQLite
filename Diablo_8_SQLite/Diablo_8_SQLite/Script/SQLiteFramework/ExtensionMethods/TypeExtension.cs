using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.ExtensionMethods
{
    static class TypeExtension
    {
        public static string TypeToSQLiteDataType(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.String:
                    return "TEXT";

                case TypeCode.Char:
                    return "TEXT";

                case TypeCode.Int16:
                    return "INTEGER";

                case TypeCode.Int32:
                    return "INTEGER";

                case TypeCode.Int64:
                    return "INTEGER";

                case TypeCode.UInt16:
                    return "INTEGER";

                case TypeCode.UInt32:
                    return "INTEGER";

                case TypeCode.UInt64:
                    return "INTEGER";

                default:
                    throw new Exception($"{type.Name.ToString()} : Type not found or has not been implemented.");
            }
        }
    }
}
