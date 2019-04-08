using System;

namespace CourseraAlgorithms
{
    class FibonacciClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int n = 30;
            Console.WriteLine($"FibonacciRecursion({n}) = {FibonacciRecursion(n)}");
            n = 327305;
            Console.WriteLine($"FibonacciLastDigit({n}) = {FibonacciLastDigit(n)}");

            long a = 28851538, b = 1183019;
            Console.WriteLine($"GCD({a},{b}) = {GCD(a, b)}");

            a = 28851538;
            b = 1183019;
            Console.WriteLine($"LCM({a},{b}) = {LCM(a, b)}");

            long n_new = 2816213588, m = 239;
            Console.WriteLine($"FibinacciNumberAgain({n_new},{m}) = {FibinacciNumberAgain(n_new, m)}");

            Console.ReadKey();
        }

        /// <summary>
        /// Находит число Фибоначчи рекурентный способом
        /// </summary>
        /// <param name="n">n от 0 до 45</param>
        /// <returns></returns>
        static int FibonacciRecursion(int n)
        {
            if (n <= 1)
                return n;
            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }

        /// <summary>
        /// Находит последную цифру числа Фибоначчи
        /// </summary>
        /// <param name="n">n от 0 до 10^7</param>
        /// <returns></returns>
        static int FibonacciLastDigit(int n)
        {
            int[] F = new int[n + 1];
            if (n <= 1)
                return n;
            else
            {
                F[0] = 0;
                F[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    F[i] = (F[i - 1] + F[i - 2]) % 10;
                }
                return F[n];
            }
        }

        /// <summary>
        /// Находит наибольший общий делитель двух положительный целый чисел (НОД)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Находит наименьший общий множитель двух положительный целый чисел (НОМ)
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static long LCM(long a, long b)
        {
            long gcd = GCD(a, b);
            return a * b / gcd;
        }

        /// <summary>
        /// Находит занчение числа Фибоначчи по mod m (Имеется периодическая зависимость Пизано)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static long FibinacciNumberAgain(long n, long m)
        {
            long period = (long)Math.Pow(m, 2) - 1;
            long equal = n % period;

            long[] F = new long[equal + 1];
            if (equal <= 1)
                return equal;
            else
            {
                F[0] = 0;
                F[1] = 1;
                for (int i = 2; i <= equal; i++)
                {
                    F[i] = (F[i - 1] + F[i - 2]) % m;
                }
                return F[equal];
            }

        }

    }
}



