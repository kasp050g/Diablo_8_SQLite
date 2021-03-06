﻿using SQLiteFramework.ExtensionMethods;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    public class InsertRowCommand : ICommandTable
    {
        public bool IsDuplicate = true;

        public dynamic[] RowColumnData;

        public IRowElement OutputRow;

        public ITable[] ExecuteOnTables { get; set; } = new ITable[1];

        public void Execute()
        {
            if (IsDuplicate)
                CodeToExecute();
            else
            {
                if (!CheckIfRowExists(ExecuteOnTables[0]))
                    CodeToExecute();
            }
        }

        private void CodeToExecute()
        {
            IDbConnection connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO {ExecuteOnTables[0].TableName} ({string.Join(", ", ExecuteOnTables[0].TableColumnData.Keys)}) VALUES ({string.Join(", ", RowColumnData.ArrayStringsToSQLiteStrings())});", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();

            SQLiteCommand cmdID = new SQLiteCommand("SELECT last_insert_rowid()", (SQLiteConnection)connection);
            int lastID = Convert.ToInt32(cmdID.ExecuteScalar());

            connection.Close();

            OutputRow = new RowElement(ExecuteOnTables[0], lastID, DictionaryExtension.CombineArrays(ExecuteOnTables[0].TableColumnData.Keys.ToArray(), RowColumnData));
        }

        private bool CheckIfRowExists(ITable table)
        {
            try
            {
                List<IRowElement> elementsToCompare = table.GetAllRows();

                foreach (IRowElement element in elementsToCompare)
                    if (RowColumnData.SequenceEqual(element.RowElementVariables.Values.ToArray()))
                        return true;

                return false;
            }

            catch
            { return false; }
        }
    }
}
