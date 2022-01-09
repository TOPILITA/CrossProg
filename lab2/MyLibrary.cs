using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public static class MyLibrary
    {
        private static bool CheckK(int x) => !(x <= 1_000_000);
        private static bool CheckP(int x) => !(x <= 1_000_000_000);
        private static int ConvertToInt32(string value)
        {
            bool parsed = Int32.TryParse(value, out int result);

            if (!parsed)
                throw new ArgumentException($"The value {value} was not parsed to int");

            return result;
        }
        public static void ParseStrings(string[] lines, out int K, out int P)
        {
            K = ConvertToInt32(lines[0].Split()[0]);
            P = ConvertToInt32(lines[0].Split()[1]);


            if (CheckK(K))
                throw new ArgumentException("Input values do not match criteria K <= 1_000_000");

            if (CheckP(P))
                throw new ArgumentException("Input values do not match criteria P <= 1_000_000_000");
        }
    }
}
