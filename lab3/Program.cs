using System;

using System.IO;

namespace Lab11
{
    class Program
    {
        static int[,] ReadFromFile(string fileName)
        {
            //  Console.WriteLine("ReadFromFile");
            //  Console.WriteLine(fileName);

            int[,] result = null;

            try
            {
                string[] lines = File.ReadAllLines(fileName);

                string[] firstLine = lines[0].Split(" ");

                int n = Convert.ToInt32(firstLine[0]);
                int m = Convert.ToInt32(firstLine[1]);

                result = new int[m + 1, 3];

                result[0, 0] = n;
                result[0, 1] = m;
                result[0, 2] = 0;

                for (int i = 1; i < lines.Length; i++)
                {
                    string[] rowLine = lines[i].Split(" ");
                    for (int j = 0; j < 3; j++)
                        result[i, j] = Convert.ToInt32(rowLine[j]);
                }
            }
            catch (Exception)
            {

            }

            return result;
        }

        static void MakeTest(int[,] inputData)
        {
            if (inputData == null)
                return;

            //   Console.WriteLine();
            //   ArrayDump(inputData);

            // Значения n и m - первые в массиве
            // n - кол-во городов, m - кол-во элементов в списке (если не ошибаюсь)
            int n = inputData[0, 0];
            int m = inputData[0, 1];

            // Создание переменных для хранения оптимальных значений / временных.
            // optimalPrice хранит оптимальный ценник (1 значение в выводе, сумма всех "c" у optimalWays )
            // optimalWayCount хранит оптимальный кол-во шагов
            // optimalWays хранит в себя упорядоченные строки 
            // tempWays тоже самое что и оптимальное только временно
            int optimalPrice = 0;
            int[] optimalWays = new int[10];
            int optimalWayCount = 0;
            int[] tempWays = new int[10];

            for (int i = 1; i < m + 1; i++)
            {// Пробежимся по всем строкам
                int u = inputData[i, 0];
                int v = inputData[i, 1];
                // Запишем u и v, u обязательно должен начинаться с 1 дома

                if (u != 1)
                    continue;

                // Создадим временные переменные для хранения
                int tempPrice = inputData[i, 2];
                int tempWayCount = 1;

                for (int f = 0; f < 10; f++)
                    tempWays[i] = 0;

                int k = 0;
                tempWays[k] = i;

                // Пробежимся по всем другим строкам относительно нашей строки под номером i
                for (int j = 1; j < m + 1; j++)
                {
                    if (i == j) // одинаково - скипаем
                        continue;

                    // Получим u2, v2, c2 у строки под номером j
                    int u2 = inputData[j, 0];
                    int v2 = inputData[j, 1];
                    int c2 = inputData[j, 2];

                    /*
                        1 3 
                        3 2 
                        Концовка у i должеа совпадать с началом у j
                        но начало у i не должно совпадать с  концовкой у j
                    */

                    if (u2 == v && v2 != u)
                    {
                        tempWayCount++;
                        tempPrice += c2;
                        tempWays[++k] = j;

                        u = u2;
                        v = v2;
                        // сбрасываем i до j
                    }
                }

                // Проверяем если временные зачения лучше оптимальных - меняем
                if ((tempWayCount >= n - 1) && (optimalPrice == 0 || tempPrice < optimalPrice))
                {
                    optimalPrice = tempPrice;
                    optimalWayCount = tempWayCount;

                    for (int f = 0; f < 10; f++)
                        optimalWays[f] = tempWays[f];
                }
            }

            // Вывод результата
            //   Console.WriteLine("Result:");
            Console.WriteLine(optimalPrice + " " + optimalWayCount);

            for (int f = 0; f < 10; f++)
            {
                if (optimalWays[f] != 0)
                    Console.Write(optimalWays[f] + " ");
            }

            Console.WriteLine();
        }

        static void ArrayDump(int[,] array)
        {
            Console.WriteLine("Dump table:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (j == array.GetLength(1) - 1)
                        Console.Write(array[i, j]);
                    else
                        Console.Write(array[i, j] + ", ");
                }
                Console.WriteLine("}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            /*MakeTest(new int[4, 3]
             {
                 { 3, 3, 0 },
                 { 1, 2, 5 },
                 { 1, 3, 10 },
                 { 3, 2, 4 }
             });

            MakeTest(new int[3, 3]
            {
                { 2, 2, 0 },
                { 1, 2, 3 },
                { 1, 2, 4 }
            });*/

            MakeTest(ReadFromFile("input.txt"));

        }
    }
}
