using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Interfaces
{
    public interface IRowElement
    {
        ITable LocatedInTable { get; }

        int Id { get; set; }

        Dictionary<string, dynamic> RowElementVariables { get; }

        string ToString();
    }
}
