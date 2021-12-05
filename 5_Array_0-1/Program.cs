using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Array_0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер двумерного массива");
            byte arrayLenght = Convert.ToByte(Console.ReadLine());
            byte[,] array = new byte[arrayLenght, arrayLenght];

            for (byte i = 0; i < arrayLenght; i++)
            {
                for (byte j = 0; j < arrayLenght; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0) //Как эту конструкцию записать при помощи тернарного оператора?
                        array[i, j] = 1;
                    else if (i % 2 != 0 && j % 2 != 0)
                        array[i, j] = 1;
                }
            }

            for (byte i = 0; i < arrayLenght; i++) //цикл вывода двумерного массива
            {
                for (byte j = 0; j < arrayLenght; j++)
                    Console.Write($"{array[i, j],3}");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
