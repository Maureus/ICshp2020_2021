using System;

namespace Fei {
    namespace BaseLib {
        public class Reading {
            private static void PrintYourAge() {
                Console.Write("Your age: ");
            }
            
            /// <summary>
            /// Parses int from console input
            /// </summary>
            /// <returns>int</returns>
            /// <exception cref="ArgumentException"></exception>
            public static int ReadInt() {
                PrintYourAge();
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
            public static double ReadDouble() {
                PrintYourAge();
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
            public static string ReadString() {
                PrintYourAge();
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
            public static char ReadChar() {
                PrintYourAge();
                var text = Console.ReadLine();
                if (!char.TryParse(text, out char result)) {
                    throw new ArgumentException($"Cannot parse char from <{text}>.");
                }

                return result;
            }
        }
    }
}
