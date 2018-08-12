using System;
using System.Collections.Generic;

namespace calculator
{
    class Program
    {
        static int Number(int r, int n)
        {
            int rez = 0;
            for (int i = 0; i <= n; i++)
            {
                string search = i.ToString();
                foreach (char ch in search)
                {
                    string cha = ch.ToString();
                    if (String.Equals(cha.ToString(), r.ToString())) { rez++; }
                }
            }
            return rez;
        }

        static int findIt(int r, int n)
        {
            int baseTen = 1;
            int basePart = 0;
            int tempN = n + 1;

            List<int> bases = new List<int>();

            for (; tempN > 1; tempN = tempN / 10)
            {
                basePart = basePart * 10 + baseTen;
                baseTen = baseTen * 10;
                bases.Add(basePart);
            }

            int result = 0;
            int digit = bases.Count - 1;
            for (; baseTen > 0; baseTen = baseTen / 10)
            {
                int indexedDigit = (n * 1 / baseTen % 10);
                if (digit >= 0)
                {
                    if (indexedDigit >= r) { result = result + ((indexedDigit + 1) * bases[digit]); }
                    else { result = result + ((indexedDigit + 0) * bases[digit]); }
                }
                digit--;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!" + Number(2, 21));
            findIt(2, 21);
        }
    }
}

//10*20+100+
//  10*300+1000