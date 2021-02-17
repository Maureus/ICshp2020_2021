using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthNumber
{
    class Program
    {
        // 850126/1158
        // 01 + 50 -> female
        static void Main(string[] args)
        {
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(ParseGenderFromBirthNumber(input));
            }
        }

        static string ParseGenderFromBirthNumber(string birthNumber)
        {
            if (birthNumber.Length != 11 || birthNumber[6] != '/')
            {
                return "Wrong birth number format.";
            }

            int genderNumber = int.Parse(birthNumber.Substring(2, 2));
            if ((genderNumber-50) > 0 && (genderNumber - 50) <= 12)
            {
                return "female";
            }

            return "male";
        }
    }
}
