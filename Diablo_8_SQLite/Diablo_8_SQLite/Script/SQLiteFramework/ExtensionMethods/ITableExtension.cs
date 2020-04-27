using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.ExtensionMethods
{
    static class ITableExtension
    {
        public static bool CompareProviders(this ITable[] tables)
        {
            bool result = false;

            foreach (ITable otherTable in tables)
                if (tables[0].Provider == otherTable.Provider)
                    result = true;
                else
                {
                    result = false;
                    break;
                }

            return result;
        }
    }
}
