using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Array5x5
{
    class Program
    {
        /*
         * Сформировать одномерный массив из 10 случайных чисел в диапазоне [-50;50]. Первые 5 элементов 
         * упорядочить по возрастанию, вторые 5 – по убыванию
         */
        static void Main(string[] args)
        {
            const byte arrayLenght = 10;
            sbyte[] array = new sbyte[arrayLenght];
            Random random = new Random();

            for (byte i = 0; i < arrayLenght; i++) //Цикл на формирование массива
            {
                array[i] = (sbyte)random.Next(-10, 10); // применил явное преобразование типа, т.к. всеравно за границы не выскочит
                Console.Write("{0,2} ", array[i]);
            }

            for (byte i = 0; i < arrayLenght / 2 - 1; i++) //Обработка первой половины массива, упорячдочивание по возрастанию
            {
                for (byte j = (byte)(i + 1); j < arrayLenght / 2; j++) //Почему требуется явное преобразование типов?
                {
                    if (array[i] > array[j])
                    {
                        sbyte temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            for (byte i = arrayLenght / 2; i < arrayLenght; i++) //Обработка второй половины массива, упорячдочивание по убыванию
            {
                for (byte j = (byte)(i + 1); j < arrayLenght; j++) //Разобраться почему требуется явное преобразование типов
                {
                    if (array[i] < array[j])
                    {
                        sbyte temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            Console.WriteLine();
            foreach (sbyte k in array)
                Console.Write($"{k,2} ");
            Console.ReadKey();
        }
    }
}
