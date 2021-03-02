using System;
using System.Linq;
using System.Text;
using Fei.BaseLib;

namespace FieldApp {
    internal class ArrayApp {
        public bool Debug { get; }

        private const string Menu = @"App menu:
1. Zadaní prvků pole z klávesnice
2. Výpis pole na obrazovku
3. Utřídění pole vzestupně
4. Utřídění pole sestupně
5. Hledání minimálního prvku
6. Hledání prvního výskytu zadaného čísla
7. Hledání posledního výskytu zadaného čísla
8. Print menu
9. Konec programu";

        private double[] _fieldOfDoubles = new double[0];
        private int _position = 0;


        public ArrayApp(bool debug) {
            Debug = debug;
        }

        public void Run() {
            PrintMenu();
            while (true) {
                try {
                    var selectedMenu = Reading.ReadInt("Please enter number from menu");
                    switch (selectedMenu) {
                        case 1:
                            EnterNewDoubleToConsole(ref _fieldOfDoubles, ref _position);
                            break;
                        case 2:
                            PrintNumbersFromField(_fieldOfDoubles);
                            break;
                        case 3:
                            try {
                                SortUtils.CocktailSortAscending(_fieldOfDoubles);
                            }
                            catch (Exception e) {
                                WriteLineColorRed(e.Message);
                            }

                            break;
                        case 4:
                            try {
                                SortUtils.CocktailSortDescending(_fieldOfDoubles);
                            }
                            catch (Exception e) {
                                WriteLineColorRed(e.Message);
                            }
                            break;
                        case 5:
                            FindMinInArrayAndPrintToConsole(_fieldOfDoubles);
                            break;
                        case 6:
                            FindFirstOccurenceOfNumberAndPrintToConsole(_fieldOfDoubles);
                            break;
                        case 7:
                            FindLastOccurenceOfNumberAndPrintToConsole(_fieldOfDoubles);
                            break;
                        case 8:
                            PrintMenu();
                            break;
                        case 9:
                            Console.WriteLine("Exiting!");
                            return;
                        default:
                            WriteLineColorRed("Unknown command!");
                            break;
                    }
                }
                catch (Exception e) {
                    WriteLineColorRed(e.Message);
                }
            }
        }

        private void PrintMenu() {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(Menu);
        }

        private void WriteLineColorRed(string input) {
            if (Debug) {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + input + "\n");
                Console.ForegroundColor = defaultColor;
            }
        }


        private void FindFirstOccurenceOfNumberAndPrintToConsole(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                WriteLineColorRed("Array is empty!");
                return;
            }

            var input = Reading.ReadDouble("Please enter double you want to find");
            for (int i = 0; i < fieldOfDoubles.Length; i++) {
                if (fieldOfDoubles[i].Equals(input)) {
                    Console.WriteLine($"Found first occurence of <{input}> at index <{i}>.");
                    return;
                }
            }

            WriteLineColorRed($"Number <{input}> was not found in array!");
        }

        private void FindLastOccurenceOfNumberAndPrintToConsole(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                WriteLineColorRed("Array is empty!");
                return;
            }

            var input = Reading.ReadDouble("Please enter double you want to find");
            for (int i = fieldOfDoubles.Length - 1; i > 0; i--) {
                if (fieldOfDoubles[i].Equals(input)) {
                    Console.WriteLine($"Found last occurence of <{input}> at index <{i}>.");
                    return;
                }
            }

            WriteLineColorRed($"Number <{input}> was not found in array!");
        }

        private void FindMinInArrayAndPrintToConsole(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                WriteLineColorRed("Array is empty!");
                return;
            }

            Console.WriteLine($"Min in array: <{fieldOfDoubles.Prepend(double.MaxValue).Min()}>.");
        }

        private void PrintNumbersFromField(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                WriteLineColorRed("Array is empty!");
                return;
            }

            var sb = new StringBuilder();
            sb.Append("[");
            foreach (var element in fieldOfDoubles) {
                sb.Append($"{element}, ");
            }

            sb.Remove(sb.Length - 2, 2);

            sb.Append("]");

            Console.WriteLine(sb.ToString());
        }


        private void EnterNewDoubleToConsole(ref double[] fieldOfDoubles, ref int position) {
            var firstInput = Reading.ReadDouble("Please enter new double");
            var length = fieldOfDoubles.Length;
            if (length == position) {
                var temp = new double[length + 1];
                for (var i = 0; i < length; i++) {
                    temp[i] = fieldOfDoubles[i];
                }

                fieldOfDoubles = temp;
            }

            fieldOfDoubles[position++] = firstInput;
        }
    }
}