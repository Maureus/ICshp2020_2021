using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = 'a';
            const int numberOfSymbols = 25;

            for (int i = 0; i <= numberOfSymbols; i++)
            {
                Console.Write($"{start++} ");
            }
            Console.WriteLine();
        }
    }
}
