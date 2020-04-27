using SQLiteFramework.Generics;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    static class CommanderSQL
    {
        private static ICommandTable inserter = new InsertRowCommand();
        private static ICommandTable finder = new FindRowCommand();
        private static ICommandTable deleter = new DeleteRowCommand();
        private static ICommandTable renamer = new TableRenameCommand();

        public static void InsertRow(this ITable tableToInsertTo, params dynamic[] rowColumnData)
        {
            (inserter as InsertRowCommand).RowColumnData = rowColumnData;

            inserter.ExecuteOnTables[0] = tableToInsertTo;
            inserter.Execute();
        }

        public static void DeleteRow(this ITable tableToDeleteFrom, int ID)
        {
            (deleter as DeleteRowCommand).IDToLookFor = ID;

            deleter.ExecuteOnTables[0] = tableToDeleteFrom;
            deleter.Execute();
        }

        public static void DeleteRow(this ITable tableToDeleteFrom, string column, dynamic data)
        {
            (deleter as DeleteRowCommand).ColumnToLookFor = column;
            (deleter as DeleteRowCommand).DataToLookFor = data;

            (deleter as DeleteRowCommand).IDToLookFor = 0;

            deleter.ExecuteOnTables[0] = tableToDeleteFrom;
            deleter.Execute();
        }

        public static IRowElement FindRow(this ITable tableToLookIn, int ID)
        {
            (finder as FindRowCommand).IDToLookFor = ID;

            finder.ExecuteOnTables[0] = tableToLookIn;
            finder.Execute();

            return (finder as FindRowCommand).OutputRow;
        }

        public static IRowElement FindRow(this ITable tableToLookIn, string column, dynamic data)
        {
            (finder as FindRowCommand).ColumnToLookFor = column;
            (finder as FindRowCommand).DataToLookFor = data;

            (finder as FindRowCommand).IDToLookFor = 0;

            finder.ExecuteOnTables[0] = tableToLookIn;
            finder.Execute();

            return (finder as FindRowCommand).OutputRow;
        }

        public static void RenameTable(this ITable tableToRename, string renameTo)
        {
            if (tableToRename.TableName == renameTo)
                throw new Exception($"ERROR! {nameof(tableToRename)} is already named {renameTo}.");
            else
            {
                (renamer as TableRenameCommand).NewTableName = renameTo;

                renamer.ExecuteOnTables[0] = tableToRename;
                renamer.Execute();
            }
        }
    }
}
