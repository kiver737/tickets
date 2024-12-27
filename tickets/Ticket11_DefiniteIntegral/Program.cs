using System;
using System.IO;

namespace Ticket11_DefiniteIntegral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите нижний предел интегрирования (a): ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите верхний предел интегрирования (b): ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введите количество разбиений (n): ");
            int n = int.Parse(Console.ReadLine());

            // Вычисление интеграла методом средних прямоугольников
            double integral = CalculateIntegral(a, b, n);

            Console.WriteLine($"Результат вычисления определенного интеграла: {integral:F6}");

            // Сохранение результата в файл
            string fileName = "integral_result.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Результат вычисления определенного интеграла: {integral:F6}");
                writer.WriteLine($"Параметры вычислений: a = {a}, b = {b}, n = {n}");
            }

            Console.WriteLine($"Результаты расчетов сохранены в файл: {fileName}");
        }

        // Функция для вычисления определенного интеграла методом средних прямоугольников
        static double CalculateIntegral(double a, double b, int n)
        {
            double h = (b - a) / n; // Шаг разбиения
            double sum = 0.0;

            for (int i = 1; i <= n; i++)
            {
                double x = a + (i - 0.5) * h; // x = a + i * h / 2
                sum += Function(x); // Добавляем значение функции в точке x
            }

            return h * sum; // Итоговое значение интеграла
        }

        // Подынтегральная функция f(x) = 2x^2 + 3x
        static double Function(double x)
        {
            return 2 * x * x + 3 * x;
        }
    }
}

