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
    public class FindRowCommand : ICommandTable
    {
        public IRowElement OutputRow;

        public List<IRowElement> OutputRows;

        public int IDToLookFor = 0;

        public string ColumnToLookFor;

        public dynamic DataToLookFor;

        public ITable[] ExecuteOnTables { get; set; } = new ITable[1];

        public void Execute()
        {
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            SQLiteCommand cmd;

            if (IDToLookFor != 0)
                cmd = new SQLiteCommand($"SELECT * FROM {ExecuteOnTables[0].TableName} WHERE Id = {IDToLookFor}", (SQLiteConnection)connection);
            else
                cmd = new SQLiteCommand($"SELECT * FROM {ExecuteOnTables[0].TableName} WHERE {ColumnToLookFor} = {StringExtension.CheckIfString(DataToLookFor)}", (SQLiteConnection)connection);

            var reader = cmd.ExecuteReader();

            // List Rows
            try
            { OutputRows = ExecuteOnTables[0].Mapper.MapRowsFromReader(reader, ExecuteOnTables[0]); }

            catch
            { OutputRows = null; }

            // Single Row
            try
            { OutputRow = OutputRows.First(); }

            catch
            { OutputRow = null; }

            connection.Close();
        }
    }
}
