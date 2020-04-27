using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Interfaces
{
    interface IRepository
    {
        ITable[] RepositoryTables { get; }
    }
}
