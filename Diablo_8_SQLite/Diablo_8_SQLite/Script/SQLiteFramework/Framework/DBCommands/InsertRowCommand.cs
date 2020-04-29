using SQLiteFramework.ExtensionMethods;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
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
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            var cmd = new SQLiteCommand($"INSERT INTO {ExecuteOnTables[0].TableName} ({string.Join(", ", ExecuteOnTables[0].TableColumnData.Keys)}) VALUES ({string.Join(", ", RowColumnData.ArrayStringsToSQLiteStrings())})", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();

            //(ExecuteOnTables[0] as Table).CurrentID++;

            connection.Close();
        }

        private bool CheckIfRowExists(ITable table)
        {
            try
            {
                List<IRowElement> elementsToCompare = table.GetAllRows();
                //if ((table as Table).CurrentID != 0)
                //if(elementsToCompare.Count)
                //{
                foreach (IRowElement element in elementsToCompare)
                    if (element.RowElementVariables.Values.ToArray() == RowColumnData)
                    {
                        return true;
                    }

                return false;
                //}
            }

            catch
            { return false; }
        }
    }
}
