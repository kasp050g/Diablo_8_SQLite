using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    public class TableRenameCommand : ICommandTable
    {
        public string NewTableName { private get; set; }

        public ITable[] ExecuteOnTables { get; set; } = new ITable[1];

        public void Execute()
        {
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            var cmd = new SQLiteCommand($"ALTER TABLE '{ExecuteOnTables[0].TableName}' RENAME TO '{NewTableName}';", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();

            ExecuteOnTables[0].TableName = NewTableName;

            connection.Close();
        }
    }
}
