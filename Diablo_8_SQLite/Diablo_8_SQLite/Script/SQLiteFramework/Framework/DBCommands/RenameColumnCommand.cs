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
    class RenameColumnCommand : ICommandTable
    {
        public string ColumnName { private get; set; }
        public string NewColumnName { private get; set; }

        public ITable[] ExecuteOnTables { get; set; } = new Table[1];

        public void Execute()
        {
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            var cmd = new SQLiteCommand($"ALTER TABLE {ExecuteOnTables[0].TableName} RENAME COLUMN {ColumnName} TO {NewColumnName}", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();

            connection.Close();

            ExecuteOnTables[0].TableColumnData.ChangeKey(ColumnName, NewColumnName);
        }
    }
}
