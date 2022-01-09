using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public static class MyLibrary
    {
        private static bool CheckN(int x) => !(1 <= x && x <= 300000);
        private static int ConvertToInt32(string value)
        {
            bool parsed = Int32.TryParse(value, out int result);

            if (!parsed)
                throw new ArgumentException($"The value {value} was not parsed to int");

            return result;
        }
        public static void ParseStrings(string[] lines, out int N, out int[] A, out int[] B)
        {
            N = ConvertToInt32(lines[0].Split()[0]);
            int M = 2;

            if (CheckN(N))
                throw new ArgumentException("Input values do not match criteria 1 <= N <= 300000");

            if (lines.Length - 1 != N)
                throw new ArgumentException("Must be N lines");

            A = new int[N];
            B = new int[N];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split();

                if (numbers.Length != M)
                    throw new ArgumentException("Must be M numbers in all lines");

                for (int j = 0; j < M; j++)
                {
                    int node = ConvertToInt32(numbers[j]);
                    if (node < 1 || node > 3000)
                        throw new ArgumentException("Node do not match criteria 1 <= node <= 3000");

                    if (j % 2 == 0)
                        A[i - 1] = ConvertToInt32(numbers[j]);
                    else
                        B[i - 1] = ConvertToInt32(numbers[j]);
                }
            }
        }
        public static void PrintArr(int[] arr)
        {
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                Console.WriteLine(arr[i] + " ");
            }
            Console.WriteLine();
        }
        public static int[] DeleteColum(int[] arr, int i)
        {
            int[] res = new int[arr.Length - 1];

            int k = 0;

            for (int j = 0; j < arr.Length; j++)
            {
                if (! (j == i)) 
                { 
                    res[k++] = arr[j]; 
                }
            }
            return res;
        }
    }
}
