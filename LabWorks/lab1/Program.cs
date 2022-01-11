using System;
using McMaster.Extensions.CommandLineUtils;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using System.Linq;

namespace lab1
{
    public class Program
    {
        [Option(ShortName = "i")]
        public string InputFile { get; }

        [Option(ShortName = "o")]
        public string OutputFile { get; }

        static void Main(string[] args)
            => CommandLineApplication.Execute<Program>(args);


        private void OnExecute()
        {
            string[] lines = File.ReadAllLines(InputFile);

            int N;
            int[] A, B;

            MyLibrary.ParseStrings(lines, out N, out A, out B);

            int[] sumAB = new int[N];

            for (int i = 0; i < N; i++)
                sumAB[i] = A[i] + B[i];

            int s1 = 0, s2 = 0;

            for (int i = 0; i < N; i++)
            {
                int t = Array.IndexOf(sumAB, sumAB.Max());

                if (i % 2 == 0)
                    s1 += A[t];
                else
                    s2 += B[t];

                
                
                sumAB = MyLibrary.DeleteColum(sumAB, t);
                A = MyLibrary.DeleteColum(A, t);
                B = MyLibrary.DeleteColum(B, t);
            }

            Console.WriteLine(Math.Abs(s1 - s2));

            File.WriteAllText(OutputFile, Math.Abs(s1 - s2).ToString());
        }
    }
}
