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

        /// <summary>
        /// Inserts a row to a SQLite Database Table.
        /// </summary>
        /// <param name="tableToInsertTo"></param>
        /// <param name="rowColumnData">Variables to assign to row. Example "Name".Pair("Bob").</param>
        /// <returns>Returns the added row.</returns>
        public static IRowElement InsertRow(this ITable tableToInsertTo, params dynamic[] rowColumnData)
        {
            (inserter as InsertRowCommand).IsDuplicate = true;

            InsertRowBase(tableToInsertTo, rowColumnData);

            return (inserter as InsertRowCommand).OutputRow;
        }

        /// <summary>
        /// Inserts a row to a SQLite Database Table.
        /// </summary>
        /// <param name="tableToInsertTo"></param>
        /// <param name="isDuplication">Is the row not unique?</param>
        /// <param name="rowColumnData">Variables to assign to row. Example "Bob", 5; assigns the first column the value "Bob", and the second column the value 5.</param>
        /// <returns>Returns the added row.</returns>
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

        /// <summary>
        /// Deletes row from a SQLite Database Table.
        /// </summary>
        /// <param name="tableToDeleteFrom"></param>
        /// <param name="ID">ID of the row to delete.</param>
        public static void DeleteRow(this ITable tableToDeleteFrom, int ID)
        {
            (deleter as DeleteRowCommand).IDToLookFor = ID;

            deleter.ExecuteOnTables[0] = tableToDeleteFrom;
            deleter.Execute();
        }

        /// <summary>
        /// Deletes several rows from a SQLite Database Table.
        /// </summary>
        /// <param name="tableToDeleteFrom"></param>
        /// <param name="column">Check column.</param>
        /// <param name="data">Check for value in column.</param>
        public static void DeleteRow(this ITable tableToDeleteFrom, string column, dynamic data)
        {
            (deleter as DeleteRowCommand).ColumnToLookFor = column;
            (deleter as DeleteRowCommand).DataToLookFor = data;

            (deleter as DeleteRowCommand).IDToLookFor = 0;

            deleter.ExecuteOnTables[0] = tableToDeleteFrom;
            deleter.Execute();
        }

        /// <summary>
        /// Finds a row in a SQLite Database Table.
        /// </summary>
        /// <param name="tableToLookIn"></param>
        /// <param name="id">ID of the row to look for.</param>
        /// <returns>Returns the found row.</returns>
        public static IRowElement FindRow(this ITable tableToLookIn, int id)
        {
            (finder as FindRowCommand).IDToLookFor = id;

            finder.ExecuteOnTables[0] = tableToLookIn;
            finder.Execute();

            return (finder as FindRowCommand).OutputRow;
        }

        /// <summary>
        /// Finds a row in a SQLite Database Table.
        /// </summary>
        /// <param name="tableToLookIn"></param>
        /// <param name="column">Check in column.</param>
        /// <param name="data">Check for value in column.</param>
        /// <returns>Returns the first found row, with the given search parameters.</returns>
        public static IRowElement FindRow(this ITable tableToLookIn, string column, dynamic data)
        {
            (finder as FindRowCommand).ColumnToLookFor = column;
            (finder as FindRowCommand).DataToLookFor = data;

            (finder as FindRowCommand).IDToLookFor = 0;

            finder.ExecuteOnTables[0] = tableToLookIn;
            finder.Execute();

            return (finder as FindRowCommand).OutputRow;
        }

        /// <summary>
        /// Finds several rows in a SQLite Database Table.
        /// </summary>
        /// <param name="tableToLookIn"></param>
        /// <param name="column">Check in column.</param>
        /// <param name="data">Check for value in column.</param>
        /// <returns>Returns list of rows found.</returns>
        public static List<IRowElement> FindRows(this ITable tableToLookIn, string column, dynamic data)
        {
            (finder as FindRowCommand).ColumnToLookFor = column;
            (finder as FindRowCommand).DataToLookFor = data;

            (finder as FindRowCommand).IDToLookFor = 0;

            finder.ExecuteOnTables[0] = tableToLookIn;
            finder.Execute();

            return (finder as FindRowCommand).OutputRows;
        }

        /// <summary>
        /// Updates a row in a SQLite Database Table.
        /// </summary>
        /// <param name="tableToUpdate"></param>
        /// <param name="id">ID of the row to update.</param>
        /// <param name="valuesToOverwrite">Column and data to overwrite. Example: "Name".Pair("John"), replaces column Name with John at ID x.</param>
        public static void Update(this ITable tableToUpdate, int id, params KeyValuePair<string, dynamic>[] valuesToOverwrite)
        {
            (updater as UpdateCommand).IdToLookFor = id;
            (updater as UpdateCommand).IdsToLookFor.Clear();

            (updater as UpdateCommand).ValuesToChange = valuesToOverwrite.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            updater.ExecuteOnTables[0] = tableToUpdate;
            updater.Execute();
        }

        /// <summary>
        /// Updates several rows in a SQLite Database Table.
        /// </summary>
        /// <param name="tableToUpdate"></param>
        /// <param name="ids">ID of the rows to update.</param>
        /// <param name="valuesToOverwrite">Column and data to overwrite. Example: "Name".Pair("John"), replaces column Name with John at ID x.</param>
        public static void Update(this ITable tableToUpdate, List<int> ids, params KeyValuePair<string, dynamic>[] valuesToOverwrite)
        {
            (updater as UpdateCommand).IdToLookFor = 0;
            (updater as UpdateCommand).IdsToLookFor = ids;

            (updater as UpdateCommand).ValuesToChange = valuesToOverwrite.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            updater.ExecuteOnTables[0] = tableToUpdate;
            updater.Execute();
        }

        /// <summary>
        /// Updates several rows in a SQLite Database Table.
        /// </summary>
        /// <param name="tableToUpdate"></param>
        /// <param name="valuesToOverwrite">Updates every row with the given column and data input. Example: "Name".Pair("John"), replaces every row in column Name with "John".</param>
        public static void Update(this ITable tableToUpdate, params KeyValuePair<string, dynamic>[] valuesToOverwrite)
        {
            (updater as UpdateCommand).IdToLookFor = 0;
            (updater as UpdateCommand).IdsToLookFor.Clear();

            (updater as UpdateCommand).ValuesToChange = valuesToOverwrite.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            updater.ExecuteOnTables[0] = tableToUpdate;
            updater.Execute();
        }

        /// <summary>
        /// Renames a SQLite Database Table.
        /// </summary>
        /// <param name="tableToRename"></param>
        /// <param name="renameTo">Rename table to this.</param>
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

        /// <summary>
        /// Renames a SQLite Database Table column.
        /// </summary>
        /// <param name="tableToModify"></param>
        /// <param name="column">Column to rename.</param>
        /// <param name="newColumnName">Assign selected column this name.</param>
        public static void RenameColumn(this ITable tableToModify, string column, string newColumnName)
        {
            (columnRenamer as RenameColumnCommand).ColumnName = column;
            (columnRenamer as RenameColumnCommand).NewColumnName = newColumnName;

            columnRenamer.ExecuteOnTables[0] = tableToModify;
            columnRenamer.Execute();
        }

        /// <summary>
        /// Returns all rows from a SQLite Database Table.
        /// </summary>
        /// <param name="tableToSearchIn"></param>
        /// <returns>Returns all rows from a SQLite Database Table.</returns>
        public static List<IRowElement> GetAllRows(this ITable tableToSearchIn)
        {
            getAll.ExecuteOnTables[0] = tableToSearchIn;
            getAll.Execute();

            return (getAll as GetAllRowsCommand).OutputRows;
        }
    }
}
