using LibraryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Сlases;

namespace Практика3курс
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
        }
        Matrix<int> matrix = new Matrix<int>(0, 0);
        private void FirstTask_Click(object sender, RoutedEventArgs e)
        {
            if (Practice.EqualNumber(Int32.Parse(firstNumbrtTB.Text), Int32.Parse(secondNumberTB.Text)))
            {
                MessageBox.Show("Числа равны");
            } 
            else
            {
                MessageBox.Show("Числа не равны");
            }
        }

        private void SecondSolving_Click(object sender, RoutedEventArgs e)
        {
            string results = "";
            int[] numbers = Practice.SquareNumberOnlyPositivNumb(Int32.Parse(firstNumber_TB.Text), Int32.Parse(secondNumber_TB.Text), Int32.Parse(thirdNumber_TB.Text));
            for (int i = 0; i < numbers.Length; i++)
            {
                results += $"{numbers[i]} ";
            }
            resultSecondTB.Text = results;
        }

        private void CreateArray_Click(object sender, RoutedEventArgs e)
        {
            string array = "";
            Random random = new Random();
            int[] number = new int[Int32.Parse(lenghtTB.Text)];
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = random.Next(10);
                array += $"{number[i]} ";
            }
            arrayTB.Text = array;
            sumNumberTB.Text = Practice.SumAllNumberOfDivThree(number).ToString();
        }

        private void SolvingMatrix_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(rowTB.Text, out int rowMatrix) || !Int32.TryParse(columnTB.Text, out int columnMatrix)) MessageBox.Show("Вы не выполнили все условия на создание матрицы!\nВведите количество строк и столбцов.");
            else
            {
                Practice.Create(matrix, rowMatrix, columnMatrix);
                DataGrid.ItemsSource = matrix.ToDataTable().DefaultView;
                MessageBox.Show($"Столбец в котором одинаковых чисел больше - {Practice.FindFirstColumnOfContainsMaxAmouthEqualNumber(matrix)}");
                rowTB.Clear();
                columnTB.Clear();

            }
        }
    }
}
