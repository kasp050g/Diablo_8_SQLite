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
    public class DeleteRowCommand : ICommandTable
    {
        public int IDToLookFor { get; set; } = 0;

        public string ColumnToLookFor;
        public dynamic DataToLookFor;

        public ITable[] ExecuteOnTables { get; set; } = new ITable[1];

        public void Execute()
        {
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            SQLiteCommand cmd;

            if (IDToLookFor != 0)
                cmd = new SQLiteCommand($"DELETE FROM {ExecuteOnTables[0].TableName} WHERE Id = {IDToLookFor}");
            else
                cmd = new SQLiteCommand($"DELETE FROM {ExecuteOnTables[0].TableName} WHERE {ColumnToLookFor} = {StringExtension.CheckIfString(DataToLookFor)}");

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
