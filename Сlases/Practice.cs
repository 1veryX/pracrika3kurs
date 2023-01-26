using LibraryClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Media;

namespace Сlases
{
    public static class Practice
    {
        public static void Create(this Matrix<int> numbers, int row, int column) // метод на создание матрицы
        {
            int[,] matrix = new int[row, column];
            Random random = new();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = random.Next(1, 3);
                }
            }
            numbers.Add(matrix); // метод заполнения маттрицы
        }
        public static bool EqualNumber(int firstNumber, int secondNumber) // 1 задание, Сравнивания двух цифр. Если они равны, то true, иначе false
        {
            if (firstNumber == secondNumber) return true;
            else return false;
        }
        public static int[] SquareNumberOnlyPositivNumb(int first, int second, int third) // Если число положительное, то взводим его в квадрат
        {
            int [] result = new int[3]; // массив с 3  ячейками
            result[0] = first;
            result[1] = second;
            result[2] = third;
            for (int i = 0; i < 3; i++)
            {
                if (result[i] > 0) result[i] *= result[i];
            }
            return result; // возвращает целый массив
        }
        public static int SumAllNumberOfDivThree(int[] array) // Найти сумму чисел, которые делятся на три
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++) // цикл
            {
                if (array[i] % 3 == 0) sum += array[i];
            }
            return sum;
        }
        public static int FindFirstColumnOfContainsMaxAmouthEqualNumber(this Matrix<int> matrix) // нахождение 1 столбца, где больше всего совпадений цифр
        {
            
            // Сортировка матрицы
            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                for (int k = 0; k < matrix.RowCount; k++)
                {
                    for (int i = 0; i < matrix.RowCount - 1; i++)
                    {
                        if (matrix[i, j] > matrix[i + 1, j])
                        {
                            int buffer = matrix[i, j];
                            matrix[i, j] = matrix[i + 1, j];
                            matrix[i + 1, j] = buffer;
                        }
                    }
                }
            }

            int[] maxIdentitys = new int[matrix.ColumnCount]; 

            for (int j = 0; j < matrix.ColumnCount; j++)
            {
                int count = 1;
                int maxCount = 0;
                for (int i = 0; i < matrix.RowCount - 1; i++)
                {
                    if (matrix[i, j] == matrix[i + 1, j])
                    {
                        count++;
                    }
                    else
                    {
                        count = 1;
                    }

                    if (count > maxCount)
                    {
                        maxCount = count;
                    }
                }
                maxIdentitys[j] = maxCount;
            }
            int index = 0;
            int max = maxIdentitys[0];
            for (int i = 1; i < maxIdentitys.Length; i++)
            {
                if (maxIdentitys[i] > max)
                {
                    max = maxIdentitys[i];
                    index = i;
                }
            }
            return index + 1;
        }
    }
}
