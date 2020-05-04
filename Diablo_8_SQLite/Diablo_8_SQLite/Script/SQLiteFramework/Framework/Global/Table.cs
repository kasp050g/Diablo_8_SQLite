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
    /// <summary>
    /// SQLite Database Table.
    /// </summary>
    class Table : ITable
    {
        public IDBProvider Provider { get; }
        public IMapper Mapper { get; }

        public string TableName { get; set; }
        public Dictionary<string, Type> TableColumnData { get; set; }

        public Table(string tableName, IDBProvider provider, IMapper mapper)
        {
            TableName = tableName;
            Provider = provider;
            Mapper = mapper;
        }

        public Table(string tableName, IDBProvider provider, IMapper mapper, Dictionary<string, Type> tableColumnData) : this(tableName, provider, mapper)
        {
            TableColumnData = tableColumnData;

            InstantiateDBTable();
        }

        public Table(string tableName, IDBProvider provider, IMapper mapper, params KeyValuePair<string, Type>[] tableColumnData) : this(tableName, provider, mapper)
        {
            TableColumnData = tableColumnData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            InstantiateDBTable();
        }

        public void WriteToScreen()
        {
            string variablesStr = string.Join("    ", TableColumnData.Keys);
            Console.WriteLine($"Id    {variablesStr}");

            foreach (IRowElement row in this.GetAllRows())
                Console.WriteLine(row);
        }

        private void InstantiateDBTable()
        {
            var connection = Provider.CreateConnection();
            connection.Open();

            var cmd = new SQLiteCommand($"CREATE TABLE IF NOT EXISTS {TableName} (Id INTEGER PRIMARY KEY, {TableColumnData.JoinSQLiteKeyValuePair()});", (SQLiteConnection)connection);
            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
