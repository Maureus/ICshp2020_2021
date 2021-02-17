using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            const int start = 1;
            const int end = 101;
            int tries = 10;
            string input = "";
            Console.WriteLine($"Guess number between {start} and {end - 1}");
            var number = rnd.Next(start, end);
            while (true)
            {
                if (tries <= 0)
                {
                    Console.WriteLine("Sorry you have lost.");
                    break;
                }

                input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }

                if (!int.TryParse(input, out int result))
                {
                    Console.WriteLine($"Somethings went wrong. Please enter number between {start} and {end - 1}.");
                    continue;
                }

                

                if (number != result)
                {
                    tries--;
                    Console.Write($"You have {tries} more tries.");
                    if (result > number)
                    {
                        Console.WriteLine("Try lower.");
                    }
                    else if (result < number)
                    {
                        Console.WriteLine("Try higher.");
                    }
                    
                }
                else if (number == result)
                {
                    Console.WriteLine($"Congratulations! You have won.");
                }
            }
        }
    }
}