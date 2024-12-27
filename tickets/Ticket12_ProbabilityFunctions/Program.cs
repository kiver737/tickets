using System;

namespace Ticket12_ProbabilityFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество объектов (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите количество объектов для выборки (k): ");
            int k = int.Parse(Console.ReadLine());

            // Проверка корректности ввода
            if (n <= 0 || k < 0 || k > n)
            {
                Console.WriteLine("Некорректные данные. Убедитесь, что n > 0 и 0 <= k <= n.");
                return;
            }

            // Вычисления
            long factorialN = Factorial(n);
            long permutations = factorialN; // Pn = n!

            long arrangements = factorialN / Factorial(n - k); // An = n! / (n-k)!

            long combinations = factorialN / (Factorial(n - k) * Factorial(k)); // Cn = n! / ((n-k)! * k!)

            // Вывод результатов
            Console.WriteLine($"Число перестановок (Pn): {permutations}");
            Console.WriteLine($"Число размещений (An): {arrangements}");
            Console.WriteLine($"Число сочетаний (Cn): {combinations}");
        }

        // Функция для вычисления факториала
        static long Factorial(int num)
        {
            if (num <= 1) return 1;
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}

