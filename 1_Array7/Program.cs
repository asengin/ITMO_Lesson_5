
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Array7
{
    class Program
    {
        /*
         * Сформировать одномерный массив из 7 элементов. Заполнить массив числами, вводимыми с клавиатуры, определить 
         * среднее арифметическое элементов.
         */
        static void Main(string[] args)
        {
            const int arrayLenght = 7;
            int[] array = new int[arrayLenght];
            float sumArray = 0;
            for (int i = 0; i < arrayLenght; i++)
            {
                Console.WriteLine($"Введите {i+1}-й элемент массива"); // +1 нумерация не с 0 начиналась для запроса
                array[i] = Convert.ToInt32(Console.ReadLine());
                sumArray += array[i];
            }
            float averageArray = sumArray/arrayLenght;
            Console.WriteLine($"Количество элементов массива: {arrayLenght}");
            Console.WriteLine($"Среднее арифметическое значений массива: {averageArray:f2}");
            Console.ReadKey();
        }
    }
}
