using System;
using System.Linq;
using System.Text;
using Fei.BaseLib;

namespace FieldApp {
    class FieldApp {
        private const int MaxSize = 50;

        private static void PrintMenu() {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\nApp menu:\n"
                              + "1. Zadaní prvků pole z klávesnice\n"
                              + "2. Výpis pole na obrazovku\n"
                              + "3. Utřídění pole vzestupně\n"
                              + "4. Utřídění pole sestupně\n"
                              + "5. Hledání minimálního prvku\n"
                              + "6. Hledání prvního výskytu zadaného čísla\n"
                              + "7. Hledání posledního výskytu zadaného čísla\n"
                              + "8. Print menu\n"
                              + "9. Konec programu\n");
        }

        static void Main(string[] args) {
            double[] fieldOfDoubles = new double[0];
            int position = 0;
            PrintMenu();
            while (true) {
                try {
                    var selectedMenu = Reading.ReadInt("Please enter number from menu: ");
                    switch (selectedMenu) {
                        case 1:
                            EnterNewDouble(ref fieldOfDoubles, ref position);
                            break;
                        case 2:
                            PrintNumbersFromField(fieldOfDoubles);
                            break;
                        case 3:
                            CocktailSortAscending(fieldOfDoubles);
                            break;
                        case 4:
                            CocktailSortDescending(fieldOfDoubles);
                            break;
                        case 5:
                            FindMinInArray(fieldOfDoubles);
                            break;
                        case 6:
                            FindFirstOccurenceOfNumber(fieldOfDoubles);
                            break;
                        case 7:
                            FindLastOccurenceOfNumber(fieldOfDoubles);
                            break;
                        case 8:
                            PrintMenu();
                            return;
                        case 9:
                            Console.WriteLine("Exiting!");
                            break;
                        default:
                            var defaultColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown command!");
                            Console.ForegroundColor = defaultColor;
                            break;
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e);
                }
            }
        }

        private static void CocktailSortDescending(double[] a) {
            var swapped = true;
            var start = 0;
            var end = a.Length;

            while (swapped) {
                swapped = false;

                for (var i = start; i < end - 1; ++i) {
                    swapped = IsSwappedDescending(a, swapped, i);
                }

                if (!swapped)
                    break;

                swapped = false;
                end--;

                for (var i = end - 1; i >= start; i--) {
                    swapped = IsSwappedDescending(a, swapped, i);
                }

                start++;
            }
        }

        private static bool IsSwappedDescending(double[] a, bool swapped, int i) {
            if (a[i] < a[i + 1]) {
                var temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
                swapped = true;
            }

            return swapped;
        }

        private static void FindFirstOccurenceOfNumber(double[] fieldOfDoubles) {
            var input = Reading.ReadDouble("Please enter double you want to find");
            for (int i = 0; i < fieldOfDoubles.Length; i++) {
                if (fieldOfDoubles[i].Equals(input)) {
                    Console.WriteLine($"Found first occurence of <{input}> at index <{i}>.");
                    return;
                }
            }

            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Number <{input}> was not found in array!");
            Console.ForegroundColor = defaultColor;
        }

        private static void FindLastOccurenceOfNumber(double[] fieldOfDoubles) {
            var input = Reading.ReadDouble("Please enter double you want to find");
            for (int i = fieldOfDoubles.Length - 1; i > 0; i--) {
                if (fieldOfDoubles[i].Equals(input)) {
                    Console.WriteLine($"Found last occurence of <{input}> at index <{i}>.");
                    return;
                }
            }

            var defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Number <{input}> was not found in array!");
            Console.ForegroundColor = defaultColor;
        }

        private static void FindMinInArray(double[] fieldOfDoubles) {
            Console.WriteLine($"Min in array: <{fieldOfDoubles.Prepend(double.MaxValue).Min()}>.");
        }

        private static void PrintNumbersFromField(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                var defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Field is empty!");
                Console.ForegroundColor = defaultColor;
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

        private static void EnterNewDouble(ref double[] fieldOfDoubles, ref int position) {
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

        private static void CocktailSortAscending(double[] a) {
            var swapped = true;
            var start = 0;
            var end = a.Length;

            while (swapped) {
                swapped = false;

                for (var i = start; i < end - 1; ++i) {
                    swapped = IsSwapped(a, swapped, i);
                }

                if (!swapped)
                    break;

                swapped = false;
                end--;

                for (var i = end - 1; i >= start; i--) {
                    swapped = IsSwapped(a, swapped, i);
                }

                start++;
            }
        }

        private static bool IsSwapped(double[] a, bool swapped, int i) {
            if (a[i] > a[i + 1]) {
                var temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
                swapped = true;
            }

            return swapped;
        }
    }
}