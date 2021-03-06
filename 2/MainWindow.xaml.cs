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
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_1;
using LibMas;
using Масивы;

namespace _3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //Вывод информации о программе
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила студентка группы ИСП-31 Васинкина Анастасия. Пр3" +
                " Дана матрица размера M × N и целое число K (1 ≤ K ≤ N). Найти сумму и произведение элементов K - го столбца данной матрицы. ");
        }

        //Закрытие программы
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        int[,] matr;
        
        //Редактирование ячеек
        private void МатрицаDataGrid(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Очищаем textbox с результатом 
            rez1.Clear();
            rez2.Clear();

            //Определяем номер столбца
            int columnIndex = e.Column.DisplayIndex;
            //Определяем номер строки
            int rowIndex = e.Row.GetIndex();

            //Заносим  отредоктированое значение в соответствующую ячейку матрицы

            if (Int32.TryParse(((TextBox)e.EditingElement).Text, out matr[rowIndex, columnIndex]))
            { }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }

        //Заполнение матрицы
        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {

            //Проверка поля на корректность введенных данных
            if(Int32.TryParse(kolStrok.Text, out int row) && Int32.TryParse(kolStolbcov.Text, out int column))
            {
                Class1.Заполнить(row, column, out matr);

                //Выводим матрицу на форму
                matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;

                //очищаем результат
                rez1.Clear();
                rez2.Clear();
            }
            else MessageBox.Show("Неверные данные!", "Ошибка");
        }
        //Расчет задания для матрицы
        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            rez1.Clear();
            rez2.Clear();

            if (matr == null || matr.Length == 0)
            {
                MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку Заполнить", "Ошибка");
            }
            else
            {
                int K = Convert.ToInt32(ZnK.Text); //Вводим K
                int N = Convert.ToInt32(kolStolbcov.Text); //Вводим M
                if (K > 0 && K <= N)
                {
                    Class2.Рассчитать(K, matr, out int sum, out int proizvedenie); //функция расчета
                    rez1.Text = Convert.ToString(sum); //выводим сумму нужной строки
                    rez2.Text = Convert.ToString(proizvedenie); //выводим прозведение нужной строки
                }
                else MessageBox.Show("Неверные данные!", "Ошибка");

            }
        }
        //Очищение матрицы
        private void ОчиститьМатрицу_Click(object sender, RoutedEventArgs e)
        {
            //Очищаем результат матрицы
            rez1.Clear();
            rez2.Clear();

            if (matr != null && matr.Length != 0)
            {
                Class1.ОчиститьМатрицу(matr);
                //Выводим матрицу на форму
                matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Вы не создали матрицу, укажите размеры матрицы и нажмите кнопку \"Заполнить", "Ошибка");
        }
        //Сохранение матрицы
        private void Savematr_Click(object sender, RoutedEventArgs e)
        {
            Class1.Savematr(matr);
        }

        //Открытие матрицы
        private void Openmatr_Click(object sender, RoutedEventArgs e)
        {
            
            Class1.Openmatr( out matr);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    //Выводим матрицу на форму
                    matrData.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
                }
            }
        }

    }
}
