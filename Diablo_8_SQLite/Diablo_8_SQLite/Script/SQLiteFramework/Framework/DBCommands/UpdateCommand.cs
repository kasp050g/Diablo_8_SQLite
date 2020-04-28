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
    class UpdateCommand : ICommandTable
    {
        public int IdToLookFor = 0;

        public List<int> IdsToLookFor = new List<int>();

        public Dictionary<string, dynamic> ValuesToChange = new Dictionary<string, dynamic>();

        public ITable[] ExecuteOnTables { get; set; } = new Table[1];

        public void Execute()
        {
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            SQLiteCommand cmd;

            if (IdToLookFor != 0)
                cmd = new SQLiteCommand($"UPDATE {ExecuteOnTables[0].TableName} SET {ValuesToChange.UpdateJoinSQLiteKeyValuePair()} WHERE ID = {IdToLookFor}", (SQLiteConnection)connection);
            else if (IdsToLookFor.Count != 0)
                cmd = new SQLiteCommand($"UPDATE {ExecuteOnTables[0].TableName} SET {ValuesToChange.UpdateJoinSQLiteKeyValuePair()} WHERE ID IN ({string.Join(", ", IdsToLookFor)})", (SQLiteConnection)connection);
            else
                cmd = new SQLiteCommand($"UPDATE {ExecuteOnTables[0].TableName} SET {ValuesToChange.UpdateJoinSQLiteKeyValuePair()}", (SQLiteConnection)connection);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
