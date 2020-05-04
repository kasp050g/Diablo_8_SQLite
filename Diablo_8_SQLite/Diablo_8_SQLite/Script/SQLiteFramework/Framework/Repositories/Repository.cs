using SQLiteFramework.ExtensionMethods;
using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    /// <summary>
    /// SQLite Database Repository.
    /// </summary>
    class Repository : IRepository
    {
        private readonly IDBProvider provider;
        private readonly IMapper mapper;


        public ITable[] RepositoryTables { get; private set; }

        public Repository(params ITable[] tables)
        {
            if (tables.CompareProviders())
            {
                RepositoryTables = tables;

                provider = tables[0].Provider;
                mapper = tables[0].Mapper;
            }
            else
                throw new Exception($"ERROR! Providers not equal: One of the tables in {nameof(RepositoryTables)} has a different Provider than the rest, check: ITable for more variables.");
        }

        public void WriteToScreen()
        {
            foreach (ITable table in RepositoryTables)
                foreach (IRowElement row in table.GetAllRows())
                {
                    if (row.Id == 1)
                        Console.WriteLine($"{row.LocatedInTable.TableName}");

                    Console.WriteLine(row);
                }
        }
    }
}
