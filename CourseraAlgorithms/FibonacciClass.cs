using System;

namespace CourseraAlgorithms
{
    class FibonacciClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int n = 327305;
            //Console.WriteLine($"Fibonacci({n}) = {FibonacciRecursion(n)}");

            Console.WriteLine($"Fibonacci({n}) = {FibonacciLastDigit(n)}");
            Console.ReadKey();
        }


        static int FibonacciRecursion(int n)
        {
            if (n <= 1)
                return n;
            return FibonacciRecursion(n - 1) + FibonacciRecursion(n - 2);
        }

        static int FibonacciLastDigit(int n)
        {
            int[] F = new int[n+1];
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

    }
}



