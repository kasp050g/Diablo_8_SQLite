using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    class GetAllRowsCommand : ICommandTable
    {
        public List<IRowElement> OutputRows { get; private set; }

        public ITable[] ExecuteOnTables { get; set; } = new ITable[1];

        public void Execute()
        {
            var connection = ExecuteOnTables[0].Provider.CreateConnection();
            connection.Open();

            var cmd = new SQLiteCommand($"SELECT * FROM {ExecuteOnTables[0].TableName}", (SQLiteConnection)connection);
            var reader = cmd.ExecuteReader();

            OutputRows = ExecuteOnTables[0].Mapper.MapRowsFromReader(reader, ExecuteOnTables[0]);

            connection.Close();
        }
    }
}
