using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    public class Class2
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="K"></param>
        /// <param name="matr"></param>
        /// <param name="sum"></param>
        /// <param name="proizvedenie"></param>
        


        //Расчет задания для матрицы
        public static void Рассчитать(int K, int[,] matr, out int sum, out int proizvedenie)
        {
            sum = 0;
            proizvedenie = 1;
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                sum += matr[i, K - 1];
                proizvedenie *= matr[i, K - 1];
            }
        }
    }
}
