using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fei {
    namespace BaseLib {
        /// <summary>
        /// Basic math convertor library
        /// decimal -> binary
        /// binary -> decimal
        /// decimal -> roman
        /// roman -> decimal 
        /// </summary>
        public class MathConvertor {
            /// <summary>
            /// Converts Int32 to binary number in string format
            /// </summary>
            /// <param name="intNumber"></param>
            /// <returns>string</returns>
            public static string ConvertInt32ToBinaryNumberString(int intNumber) {
                return Convert.ToString(intNumber, 2);
            }

            /// <summary>
            /// Converts binary number in string format to Int32
            /// </summary>
            /// <param name="binaryNumber"></param>
            /// <returns>int</returns>
            public static int ConvertBinaryStringToInt32(string binaryNumber) {
                return Convert.ToInt32(binaryNumber, 2);
            }

            /// <summary>
            /// Converts Int32 Number in range from 1 to 3999 to roman numerals string.
            /// </summary>
            /// <param name="intNumber"></param>
            /// <returns>string</returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static string ConvertInt32ToRomanNumberString(int intNumber) {
                if (intNumber <= 0 || intNumber > 4000) {
                    throw new ArgumentOutOfRangeException(nameof(intNumber));
                }

                int[] decimalValue = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
                string[] romanNumeral = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
                var numCp = intNumber;
                var sb = new StringBuilder();

                for (var i = 0; i < decimalValue.Length; i = i + 1) {
                    while (decimalValue[i] <= numCp) {
                        sb.Append(romanNumeral[i]);
                        numCp -= decimalValue[i];
                    }
                }

                return sb.ToString();
            }

            private static Dictionary<char, int> RomanMap = new Dictionary<char, int>() {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            /// <summary>
            /// Converts roman numeral string in range from I to MMMM to Int32 
            /// </summary>
            /// <param name="roman"></param>
            /// <returns>int</returns>
            public static int ConvertRomanNumeralStringToInt32(string roman) {
                if (!new Regex("^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$").IsMatch(roman)) {
                    throw new ArgumentException("Provided string is not a valid roman numeral or is out of range.");
                }
                
                roman = roman.ToUpper();
                var number = 0;
                for (var i = 0; i < roman.Length; i++) {
                    if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]]) {
                        number -= RomanMap[roman[i]];
                    }
                    else {
                        number += RomanMap[roman[i]];
                    }
                }

                return number;
            }
        }
    }
}