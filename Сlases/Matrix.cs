using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryClasses
{
    public class Matrix<T>
    {
        //Поля
        private T[,] _items;
        private int _row, _col;
        //Конструктор
        public Matrix(int rowCount, int columnCount, string extension = ".matrix")
        {
            _items = new T[rowCount, columnCount];
            Extension = extension;
        }
        public string Extension { get; private set; }
        public int RowCount => _items.GetLength(0);
        public int ColumnCount => _items.GetLength(1);
        public int Copasity => RowCount * ColumnCount;
        public T this[int rowIndex, int columnIndex]
        {
            get => _items[rowIndex, columnIndex];
            set => _items[rowIndex, columnIndex] = value;
        }
        public void DefaultInit()
        {
            for (int i = 0; i < _items.GetLength(0); i++)
            {
                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    _items[i, j] = default;
                }
            }
            _row = default;
            _col = default;
        }

        public void Add(T[,] items)
        {
            _row = items.GetLength(0);
            _col = items.GetLength(1);
            _items = new T[_row, _col];
            for (int i = 0; i < _items.GetLength(0); i++)
            {
                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    _items[i, j] = items[i, j];
                }
            }
        }
        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _items.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _items.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    row[j] = _items[i, j];
                }

                res.Rows.Add(row);
            }
            return res;
        }
    }
}
