using SQLiteFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteFramework.Framework
{
    class Mapper : IMapper
    {
        public List<IRowElement> MapRowsFromReader(IDataReader reader, ITable readFromTable)
        {
            var result = new List<IRowElement>();

            while (reader.Read())
            {
                IRowElement element = new RowElement(readFromTable, reader.GetInt32(0));

                for (int i = 0; i < readFromTable.TableColumnData.Count; i++)
                    element.RowElementVariables.Add(readFromTable.TableColumnData.ElementAt(i).Key, Convert.ChangeType(reader.GetValue(i + 1), readFromTable.TableColumnData.ElementAt(i).Value));

                if (element != null)
                    result.Add(element);
            }

            if (result.Count != 0)
                return result;
            else
                return null;
        }
    }
}
