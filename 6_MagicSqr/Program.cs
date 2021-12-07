using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_MagicSqr
{
    class Program
    {
        /*
         * Запросить у пользователя целочисленное значение N. Сформировать двумерный массив размера NxN. Заполнить массив
         * числами, вводимыми с клавиатуры. Проверить, является ли введенная с клавиатуры матрица магическим квадратом.
         * Магическим квадратом называется матрица, сумма элементов которой в каждой строке, в каждом столбце и по каждой
         * диагонали одинакова.
         */
        static void Main(string[] args)
        {
            Console.Write("Введите размер двумерного массива больше 2-х: ");
            byte arrayLenght = Convert.ToByte(Console.ReadLine());
            if (arrayLenght > 2) //Условие корректности массива
            {
                sbyte[,] array = new sbyte[arrayLenght, arrayLenght];
                for (byte i = 0; i < arrayLenght; i++) //Формирование массива вводом пользовательских значений
                {
                    for (byte j = 0; j < arrayLenght; j++)
                    {
                        Console.Write($"Введите элемент {i + 1}-й строки {j + 1}-го столбца: "); //i+1 чтобы для пользователя начало не с 0
                        array[i, j] = Convert.ToSByte(Console.ReadLine());
                    }
                }
                Console.WriteLine("Введенный массив: "); //Вывод введенного пользователем двумерного массива
                for (byte i = 0; i < arrayLenght; i++)
                {
                    for (byte j = 0; j < arrayLenght; j++)
                        Console.Write($"{array[i, j],3}");
                    Console.WriteLine();
                }

                int magicConst = ((int)Math.Pow(arrayLenght, 2) + 1) * arrayLenght / 2; //Магическая константа
                int diagLeft = 0; //Сумма по одной диагонали
                int diagRight = 0; //Сумма по второй диагонали
                int stringSum = 0; //Сумма по строке
                int columnSum = 0; //Сумма по колонке
                int[] stringSumArray = new int[arrayLenght]; //Массив с суммами по каждой строке
                int[] columnSumArray = new int[arrayLenght]; //Массив с суммами по каждому столбцу
                bool magicSqrDiag = false;
                bool magicSqrString = false;
                bool magicSqrColumn = false;

                for (byte i = 0; i < arrayLenght; i++) //Подсчет сумм по строкам и столбцам
                {
                    for (byte j = 0; j < arrayLenght; j++)
                    {
                        if (i == j)
                            diagLeft += array[i, j];
                        if (j == arrayLenght - 1 - i)
                            diagRight += array[i, j];
                        stringSum += array[i, j];
                        columnSum += array[j, i];
                    }
                    stringSumArray[i] = stringSum;
                    columnSumArray[i] = columnSum;
                    // Console.WriteLine($"Сумма по {i + 1}-й строке: {stringSum}");
                    // Console.WriteLine($"Сумма по {i + 1}-му столбу: {columnSum}");
                    stringSum = 0; columnSum = 0;
                }

                Console.WriteLine($"Магическая константа: {magicConst}");
                Console.WriteLine($"Сумма по одной диагонали: {diagLeft}");
                Console.WriteLine($"Сумма по другой диагонали: {diagRight}");
                //Console.WriteLine((diagLeft == diagRight) ? $"Диагонали равны: {diagRight}" : "Диагонали не равны друг другу. Массив не является магическим квадратом");
                magicSqrDiag = diagLeft == diagRight ? true : false;
                Console.WriteLine(magicSqrDiag ? $"Диагонали равны: {diagRight}" : "Диагонали не равны");
                Console.Write("Суммы по строкам: "); //Два отдельных цикла вывода массивов сумм по строкам и столбцам  
                for (byte i = 0; i < arrayLenght; i++)
                    Console.Write($" {stringSumArray[i]}");
                Console.WriteLine();
                Console.Write("Суммы по столбцам: ");
                for (byte i = 0; i < arrayLenght; i++)
                    Console.Write($" {columnSumArray[i]}");
                Console.WriteLine();

                for (byte i = 1; i < arrayLenght; i++) //Цикл проверки равенства сумм по строкам
                {
                    if (stringSumArray[0] == stringSumArray[i])
                    {
                        //Console.WriteLine($"Строка 1 равна строке {i+1}");
                        magicSqrString = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Строки не равны");
                        magicSqrString = false;
                        break;
                    }
                    //Console.WriteLine((stringSumArray[i - 1] == stringSumArray[i])?$"Строки равны":"Строки не равны");
                }
                for (byte i = 1; i < arrayLenght; i++) //Цикл проверки равенства сумм по столбцам
                {
                    if (columnSumArray[0] == columnSumArray[i])
                    {
                        //Console.WriteLine($"Столбец 1 равен столбцу {i+1}");
                        magicSqrColumn = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Столбцы не равны");
                        magicSqrColumn = false;
                        break;
                    }
                }

                /*
                 * К текущему этапу проверено:
                 * 1. Равенство диагоналей
                 * 2. Равенство сумм всех строк
                 * 3. Равенство сумм всех столбцов
                 * Осталось проверить равенство диагоналей и строк, диагоналей и столбцов
                 */
                Console.WriteLine((stringSumArray[0] == diagRight && magicSqrDiag && magicSqrString) ? $"Диагонали и строки равны: {diagRight}" : "Диагонали, строки не равны");
                Console.WriteLine((columnSumArray[0] == diagRight && magicSqrDiag && magicSqrColumn) ? $"Диагонали и столбы равны: {diagRight}" : "Диагонали, столбы не равны");
                if (magicSqrDiag&&magicSqrString&&magicSqrColumn&&stringSumArray[0]==columnSumArray[0]&&stringSumArray[0]==diagRight)
                    Console.WriteLine("МАГИЧЕСКИЙ КВАДРАТ !");
                else
                    Console.WriteLine("Не магический квадрат!"); //Тернарный оператор не применял специально изза длинного условия проверки


            }
            else Console.WriteLine("Введен некорректный размер двумерного массива");

            Console.ReadKey();
        }
    }
}
