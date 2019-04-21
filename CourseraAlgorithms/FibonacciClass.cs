using System;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine($"FibonacciLastDigit({n}) = {FibonacciLastDigit(n, 10)}");

            long a = 28851538, b = 1183019;
            Console.WriteLine($"GCD({a},{b}) = {GCD(a, b)}");

            a = 28851538;
            b = 1183019;
            Console.WriteLine($"LCM({a},{b}) = {LCM(a, b)}");

            long n_new = 239;
            int m = 1000;
            Console.WriteLine($"PisanoPeriod = {GetPisanoPeriod(m)}");
            Console.WriteLine($"FibinacciNumberAgain({n_new},{m}) = {FibinacciNumberAgain(n_new, m)}");

            n_new = 1000000000000000;
            m = 10;
            Console.WriteLine($"PisanoPeriod = {GetPisanoPeriod(m)}");
            Console.WriteLine($"LastDigitSumFibonacci({n_new},{m}) = {LastDigitSumFibonacci(n_new, m)}");


            a = 1;
            b = 200;
            m = 10;
            Console.WriteLine($"LastDigitSumFibonacciAgain({a},{b},{m}) = {LastDigitSumFibonacciAgain(a, b, m)}");




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
        static int FibonacciLastDigit(long n, int m)
        {
            int[] F = new int[n + 1];
            if (n <= 1)
                return (int)n;
            else
            {
                F[0] = 0;
                F[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    F[i] = (F[i - 1] + F[i - 2]) % m;
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

        static int GetPisanoPeriod(int m)
        {
            int current = 0, next = 1;
            List<int> period = new List<int>();

            if (m < 2)
                return period.Count();

            period.Add(current);
            int temp = current;
            current = next;
            next += temp;

            while (current != 0 || next != 1)
            {
                period.Add(current);
                temp = current;
                current = next;
                next = (current + temp) % m;
            }

            //foreach(int num in period)
            //{
            //    Console.Write($"{num} ");
            //}

            return period.Count();
        }

        /// <summary>
        /// Находит занчение числа Фибоначчи по mod m (Имеется периодическая зависимость Пизано)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static long FibinacciNumberAgain(long n, int m)
        {
            int period = GetPisanoPeriod(m);
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

        static int GetSumFibonacci(long n, int m)
        {
            int current = 0, next = 1;
            int sum = 0;
            int temp = current;
            current = next;
            next += temp;
            sum += current;

            if (n < 1)
                return 0;


            for (int i = 2; i <= n; i++)
            {
                temp = current;
                current = next;
                next = (current + temp) % m;
                sum = (sum + current) % m;
            }
            return sum;
        }
        static int LastDigitSumFibonacci(long n, int m)
        {
            long sum = 0;
            int period = GetPisanoPeriod(m);
            if (n <= period)
                sum = GetSumFibonacci(n, m);
            else
            {
                sum = GetSumFibonacci(period, m);
                long new_n = n % period;
                sum = sum * (n / period) + GetSumFibonacci(new_n, m);
            }

            return (int)sum;
        }


        static int LastDigitSumFibonacciAgain(long a, long b, int m)
        {
            int current = FibonacciLastDigit(a, m), next = FibonacciLastDigit(a + 1, m);
            int sum = current;
            int temp = 0;


            for (long i = a + 1; i <= b; i++)
            {
                temp = current;
                current = next;
                next = (current + temp) % m;
                sum = (sum + current) % m;
            }
            return sum;
        }

    }
}



