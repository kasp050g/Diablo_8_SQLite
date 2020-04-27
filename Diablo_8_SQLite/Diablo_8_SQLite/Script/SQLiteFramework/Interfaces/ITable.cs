using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Interfaces
{
    public interface ITable
    {
        IDBProvider Provider { get; }
        IMapper Mapper { get; }

        string TableName { get; set; }

        Dictionary<string, Type> TableColumnData { get; set; }
    }
}
