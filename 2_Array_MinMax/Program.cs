using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Array_MinMax
{
    class Program
    {
        /*
         * Сформировать одномерный массив из 15 элементов, которые выбираются случайным образом из диапазона [0; 50]. 
         * Определить сумму максимального и минимального элементов массива
         */
        static void Main(string[] args)
        {

            const int arrayLenght = 15;
            int[] array = new int[arrayLenght];
            Random random = new Random();

            for (int i = 0; i < arrayLenght; i++) //Цикл на формирование массива
            {
                array[i] = random.Next(0, 50);
                Console.Write("{0,2} ", array[i]);
            }
            int minArray = array[0];
            int maxArray = array[0];

            for (int i = 0; i < arrayLenght; i++) // Цикл обработки массива
            {
                if (array[i] < minArray) minArray = array[i];
                if (array[i] > maxArray) maxArray = array[i];
            }

            Console.WriteLine();
            Console.WriteLine($"Максимальный элемент массива: {maxArray}");
            Console.WriteLine($"Минимальный элемент массива: {minArray}");
            Console.WriteLine($"Сумма максимального и минимального элемента массива: {maxArray + minArray}");
            Console.ReadKey();
        }
    }
}
