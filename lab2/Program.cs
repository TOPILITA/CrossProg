using System;
using McMaster.Extensions.CommandLineUtils;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Numerics;
using System.Linq;

namespace lab2
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

            int K, P;

            MyLibrary.ParseStrings(lines, out K, out P);

            int result;

            if (K < 2)
                result = 0;
            else
            {
                int[] num = new int[K + 1];
                num[2] = 1;

                for (int i = 2; i < K; i++)
                {
                    num[i + 1] = (num[i + 1] + num[i]) % P;
                    if (2 * i <= K)
                        num[2 * i] = num[i];
                }

                result = num[K];
            }

            Console.WriteLine(result);

            File.WriteAllText(OutputFile, result.ToString());
        }
    }
}