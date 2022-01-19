using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLabNetFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            int K = 2;
            char[] symbols = new char[] { 'A', 'B', 'A', 'B', 'B', 'C', 'A', 'C', 'B', 'C' };

            char v = ' ';
            char v1 = symbols[0];

            int min;

            int[] array = new int['Z' - 'A'];
            int[] arrayValues = new int['Z' - 'A'];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
                arrayValues[i] = int.MaxValue;
            }

            for (int i = 2; i < K + 1; i++)
            {
                v = symbols[i];
                if (v1 == v)
                {
                    arrayValues[v - 'A'] = 0;
                }
                else
                {
                    arrayValues[v - 'A'] = 1;
                }
                array[v - 'A'] = i;
            }

            for (int i = K + 2; i < N; i++)
            {
                v = v1 = symbols[i];
                min = arrayValues[v - 'A'];

                for (char c = 'A'; c < 'Z'; c++)
                {
                    if (arrayValues[c - 'A'] < min)
                    {
                        min = arrayValues[c - 'A'];
                        v1 = c;
                    }
                }

                if (v1 != v)
                    min++;

                arrayValues[v - 'A'] = min;
                array[v - 'A'] = i;

                for (char c = 'A'; c < 'Z'; c++)
                {
                    if (array[c - 'A'] + K == i)
                    {
                        array[c - 'A'] = 0;
                        arrayValues[c - 'A'] = int.MaxValue;
                    }
                }
            }

            Console.WriteLine(arrayValues[v - 'A']);
        }
    }
}
