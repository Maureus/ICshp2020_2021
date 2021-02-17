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
            var input = " ";
            while (input != "exit")
            {
                input = Console.ReadLine();
                Console.WriteLine(ParseGenderFromBirthNumber(input));
            }
        }

        private static string ParseGenderFromBirthNumber(string birthNumber)
        {
            if (ValidateBirthNumber(birthNumber))
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

        private static bool ValidateBirthNumber(string birthNumber)
        {
            return birthNumber.Length != 11 || birthNumber[6] != '/';
        }
    }
}
