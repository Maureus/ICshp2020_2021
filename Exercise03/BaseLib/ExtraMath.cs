using System;

namespace Fei {
    namespace BaseLib {
        /// <summary>
        /// Math library that solves quadratic equations and gets random double.
        /// </summary>
        public static class ExtraMath {
            private static readonly Random Random = new Random();

            /// <summary>
            /// Solve quadratic equation.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <param name="c"></param>
            /// <param name="x1"></param>
            /// <param name="x2"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentException"></exception>
            public static bool SolveQuadraticEquation(double a, double b, double c, out double? x1, out double? x2) {
                if (a == 0) {
                    throw new ArgumentException($"<{nameof(a)}> cannot be 0.");
                }

                var d = b * b - 4 * a * c;
                if (d == 0) {
                    x1 = -b / (2.0 * a);
                    x2 = x1;
                    return true;
                }
                else if (d > 0) {
                    x1 = (-b + Math.Sqrt(d)) / (2 * a);
                    x2 = (-b - Math.Sqrt(d)) / (2 * a);
                    return true;
                }

                x1 = null;
                x2 = null;
                return false;
            }

            /// <summary>
            /// Get random double from range.
            /// </summary>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns>double</returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static double RandomDoubleFromRange(double min, double max) {
                if (min > max) {
                    throw new ArgumentOutOfRangeException($"<{nameof(min)}> cannot be greater than <{nameof(max)}>");
                }

                return Random.NextDouble() * (max - min) + min;
            }
        }
    }
}