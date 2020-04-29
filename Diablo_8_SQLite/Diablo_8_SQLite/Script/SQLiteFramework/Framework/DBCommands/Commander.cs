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
        private static ICommandTable columnRenamer = new RenameColumnCommand();
        private static ICommandTable updater = new UpdateCommand();
        private static ICommandTable getAll = new GetAllRowsCommand();

        //public static void InsertRow(this ITable tableToInsertTo, params dynamic[] rowColumnData)
        //{
        //    (inserter as InsertRowCommand).RowColumnData = rowColumnData;
        //
        //    inserter.ExecuteOnTables[0] = tableToInsertTo;
        //    inserter.Execute();
        //}

        public static IRowElement InsertRow(this ITable tableToInsertTo, params dynamic[] rowColumnData)
        {
            //InsertRow(tableToInsertTo, rowColumnData);
            (inserter as InsertRowCommand).IsDuplicate = true;

            InsertRowBase(tableToInsertTo, rowColumnData);

            return (inserter as InsertRowCommand).OutputRow;
        }

        public static IRowElement InsertRow(this ITable tableToInsertTo, bool isDuplication, params dynamic[] rowColumnData)
        {
            (inserter as InsertRowCommand).IsDuplicate = isDuplication;

            InsertRowBase(tableToInsertTo, rowColumnData);

            return (inserter as InsertRowCommand).OutputRow;
        }

        private static void InsertRowBase(this ITable tableToInsertTo, params dynamic[] rowColumnData)
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

        public static IRowElement FindRow(this ITable tableToLookIn, int id)
        {
            (finder as FindRowCommand).IDToLookFor = id;

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

        public static void Update(this ITable tableToUpdate, int id, params KeyValuePair<string, dynamic>[] valuesToOverwrite)
        {
            (updater as UpdateCommand).IdToLookFor = id;
            (updater as UpdateCommand).IdsToLookFor.Clear();

            (updater as UpdateCommand).ValuesToChange = valuesToOverwrite.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            updater.ExecuteOnTables[0] = tableToUpdate;
            updater.Execute();
        }

        public static void Update(this ITable tableToUpdate, List<int> ids, params KeyValuePair<string, dynamic>[] valuesToOverwrite)
        {
            (updater as UpdateCommand).IdToLookFor = 0;
            (updater as UpdateCommand).IdsToLookFor = ids;

            (updater as UpdateCommand).ValuesToChange = valuesToOverwrite.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            updater.ExecuteOnTables[0] = tableToUpdate;
            updater.Execute();
        }

        public static void Update(this ITable tableToUpdate, params KeyValuePair<string, dynamic>[] valuesToOverwrite)
        {
            (updater as UpdateCommand).IdToLookFor = 0;
            (updater as UpdateCommand).IdsToLookFor.Clear();

            (updater as UpdateCommand).ValuesToChange = valuesToOverwrite.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            updater.ExecuteOnTables[0] = tableToUpdate;
            updater.Execute();
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

        public static void RenameColumn(this ITable tableToModify, string column, string newColumnName)
        {
            (columnRenamer as RenameColumnCommand).ColumnName = column;
            (columnRenamer as RenameColumnCommand).NewColumnName = newColumnName;

            columnRenamer.ExecuteOnTables[0] = tableToModify;
            columnRenamer.Execute();
        }

        public static List<IRowElement> GetAllRows(this ITable tableToSearchIn)
        {
            getAll.ExecuteOnTables[0] = tableToSearchIn;
            getAll.Execute();

            return (getAll as GetAllRowsCommand).OutputRows;
        }
    }
}
