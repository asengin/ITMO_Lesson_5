using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Array_PlusOddNumbersCount
{
    class Program
    {
        /*
         *Сформировать одномерный массив из 20 случайных чисел в диапазоне [-50;50]. Определить количество   
         *нечетных положительных элементов, стоящих на четных местах.
         */
        static void Main(string[] args)
        {
            const byte arrayLenght = 20;
            sbyte[] array = new sbyte[arrayLenght];
            Random random = new Random();

            for (byte i = 0; i < arrayLenght; i++) //Цикл на формирование массива
            {
                array[i] = (sbyte)random.Next(-50, 50); //Явное преобразование типа, т.к. всеравно за границы не выскочит
                Console.Write("{0,2} ", array[i]);
            }

            byte countPlusOddNum = 0;
            for (byte i = 0; i < arrayLenght; i++)
            {
                if ((i % 2 == 1 || i == 1) && (array[i] > 0 && array[i] % 2 != 0)) //Четное место имеет нечетный индекс 1, 3, 5...
                    countPlusOddNum++;
            }
            Console.WriteLine();
            Console.WriteLine($"Количество нечетных положительных элементов на четных местах: {countPlusOddNum}");
            Console.ReadKey();
        }
    }
}
