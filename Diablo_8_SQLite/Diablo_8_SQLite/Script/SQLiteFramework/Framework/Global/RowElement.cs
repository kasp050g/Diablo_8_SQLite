using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    class RowElement : IRowElement
    {
        public ITable LocatedInTable { get; }

        public int Id { get; set; }

        public Dictionary<string, dynamic> RowElementVariables { get; } = new Dictionary<string, dynamic>();

        public RowElement(ITable locatedInTable)
        {
            LocatedInTable = locatedInTable;
        }

        public RowElement(ITable locatedInTable, int id) : this(locatedInTable)
        {
            Id = id;
        }

        public RowElement(ITable locatedInTable, int id, Dictionary<string, dynamic> variables) : this(locatedInTable, id)
        {
            RowElementVariables = variables;
        }


        public override string ToString()
        {
            return $"{Id}     {RowElementVariablesToString()}";
        }

        private string RowElementVariablesToString()
        {
            string result = "";

            for (int i = 0; i < LocatedInTable.TableColumnData.Count; i++)
                if (i == RowElementVariables.Count - 1)
                    result += $"{RowElementVariables.ElementAt(i).Value}";
                else
                    result += $"{RowElementVariables.ElementAt(i).Value}     ";

            return result;
        }
    }
}
