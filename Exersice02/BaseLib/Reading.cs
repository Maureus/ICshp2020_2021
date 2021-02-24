using System;


namespace Fei {
    namespace BaseLib {
        /// <summary>
        /// Library for parsing int, double, char or string from console input
        /// </summary>
        public class Reading {
            private static void PrintYourAge(string input) {
                Console.Write($"{input}: ");
            }
            
            /// <summary>
            /// Parses int from console input
            /// </summary>
            /// <returns>int</returns>
            /// <exception cref="ArgumentException"></exception>
            public static int ReadInt(string input) {
                PrintYourAge(input);
                var text = Console.ReadLine();
                if (!int.TryParse(text, out int result)) {
                    throw new ArgumentException($"Cannot parse int from <{text}>.");
                }

                return result;
            }
            
            /// <summary>
            /// Parses double from console input
            /// </summary>
            /// <returns>double</returns>
            /// <exception cref="ArgumentException"></exception>
            public static double ReadDouble(string input) {
                PrintYourAge(input);
                var text = Console.ReadLine();
                if (!double.TryParse(text, out double result)) {
                    throw new ArgumentException($"Cannot parse double from <{text}>.");
                }

                return result;
            }
            
            /// <summary>
            /// Validates string input
            /// </summary>
            /// <returns>string</returns>
            /// <exception cref="ArgumentException"></exception>
            public static string ReadString(string input) {
                PrintYourAge(input);
                var text = Console.ReadLine();
                if (text.Length == 0) {
                    throw new ArgumentException($"Entered string is empty.");
                }
                return text;
            }
            
            /// <summary>
            /// Parses char from console input
            /// </summary>
            /// <returns></returns>
            /// <exception cref="ArgumentException"></exception>
            public static char ReadChar(string input) {
                PrintYourAge(input);
                var text = Console.ReadLine();
                if (!char.TryParse(text, out char result)) {
                    throw new ArgumentException($"Cannot parse char from <{text}>.");
                }

                return result;
            }
        }
    }
}
