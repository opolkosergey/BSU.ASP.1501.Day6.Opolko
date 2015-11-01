using System;
using System.Diagnostics;
using System.Linq;

namespace Task3
{
    public static class MathMethods
    {
        public delegate int CalculateGcd(int a, int b);
        
        #region Public methods
        /// <summary>
        /// Method of calculating the root of the n-th degree among the Newton method with a given accuracy
        /// </summary>
        /// <param name="a">The number under the root</param>
        /// <param name="power">The degree of root</param>
        /// <param name="precision">Necessary accuracy of calculation</param>
        /// <returns></returns>
        public static double RootByNewtonMethod(double a, int power, double precision)
        {
            if (precision > 1 || precision < 1E-16)
                throw new ArgumentOutOfRangeException(nameof(precision));
            if (a < 0)
                throw new ArgumentOutOfRangeException(nameof(a));
            if (Math.Abs(a) < precision)
                return 0;
            if (power <= 0)
                throw new ArgumentOutOfRangeException(nameof(power));

            double possibleResult = 1.0;
            var intermediateResult = Math.Pow(possibleResult, power);

            while (Math.Abs(a - intermediateResult) > precision)
            {
                possibleResult = ((power - 1) * possibleResult + a / Math.Pow(possibleResult, power - 1)) / power;
                intermediateResult = Math.Pow(possibleResult, power);
            }
            return possibleResult;
        }

        public static int GcdByMethod(out long ticks, CalculateGcd method, params int[] values)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            if (values.Count() == 1)
                throw new ArgumentException("Enter more than one argument" + nameof(values));
                
            var watch = new Stopwatch();
            watch.Start();
            var result = method(values[0], values[1]);

            for (int i = 2; i < values.Length; i++)
                result = method(values[i], result);
            
            watch.Stop();
            ticks = watch.ElapsedTicks;
            return Math.Abs(result);
        }

        public static int BinaryGcd(int a, int b)
        {
            if (a < 0) a *= -1;
            if (b < 0) b *= -1;

            if (a == 0) return b;
            if (b == 0) return a;
            if (a == b) return a;

            if (a == 1) return 1;
            if (b == 1) return 1;

            if (a % 2 == 0 && b % 2 == 0)
                return 2 * BinaryGcd(a / 2, b / 2);

            if (a % 2 == 0 && b % 2 == 1)
                return BinaryGcd(a / 2, b);

            if (a % 2 == 1 && b % 2 == 0)
                return BinaryGcd(a, b / 2);

            if (a % 2 == 1 && b % 2 == 1 && b > a)
                return BinaryGcd((b - a) / 2, a);

            return BinaryGcd((a - b) / 2, b);
        }

        public static int EvklidGcd(int a, int b)
        {
            if (a == 0 || b == 0)
                throw new ArgumentException("Invalid arguments" + nameof(a) + "or" + nameof(b));

            if (a < b)
            {
                int c = a;
                a = b;
                b = c;
            }

            int mod = 0;
            do
            {
                mod = a % b;
                a = b;
                b = mod;
            } while (mod != 0);

            return Math.Abs(a);
        }
        #endregion
    }
}
