namespace FieldApp {
    internal class SortUtils {
        public static void CocktailSortAscending(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                return;
            }

            var swapped = true;
            var start = 0;
            var end = fieldOfDoubles.Length;

            while (swapped) {
                swapped = false;

                for (var i = start; i < end - 1; ++i) {
                    swapped = IsSwappedAscending(fieldOfDoubles, swapped, i);
                }

                if (!swapped)
                    break;

                swapped = false;
                end--;

                for (var i = end - 1; i >= start; i--) {
                    swapped = IsSwappedAscending(fieldOfDoubles, swapped, i);
                }

                start++;
            }
        }

        private static bool IsSwappedAscending(double[] a, bool swapped, int i) {
            if (a[i] > a[i + 1]) {
                var temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
                swapped = true;
            }

            return swapped;
        }
        
        public static void CocktailSortDescending(double[] fieldOfDoubles) {
            if (fieldOfDoubles.Length == 0) {
                return;
            }

            var swapped = true;
            var start = 0;
            var end = fieldOfDoubles.Length;

            while (swapped) {
                swapped = false;

                for (var i = start; i < end - 1; ++i) {
                    swapped = IsSwappedDescending(fieldOfDoubles, swapped, i);
                }

                if (!swapped)
                    break;

                swapped = false;
                end--;

                for (var i = end - 1; i >= start; i--) {
                    swapped = IsSwappedDescending(fieldOfDoubles, swapped, i);
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
    }
}