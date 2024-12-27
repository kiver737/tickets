using System;

namespace Ticket13_FunctionTabulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите начало отрезка (a): ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Введите конец отрезка (b): ");
            double b = double.Parse(Console.ReadLine());

            Console.Write("Введите шаг табулирования (h): ");
            double h = double.Parse(Console.ReadLine());

            if (a >= b || h <= 0)
            {
                Console.WriteLine("Некорректные данные. Убедитесь, что a < b и h > 0.");
                return;
            }

            Console.WriteLine("\nТаблица значений функции y(x) = cos(x^2) + sin^2(x):");
            Console.WriteLine("X\t\tY(X)");

            double maxY = double.MinValue;
            double minY = double.MaxValue;
            int zeroCrossings = 0;
            double previousY = double.NaN;

            for (double x = a; x <= b; x += h)
            {
                double y = Math.Cos(x * x) + Math.Pow(Math.Sin(x), 2);

                Console.WriteLine($"{x:F4}\t{y:F4}");

                // Определение максимального и минимального значения
                if (y > maxY) maxY = y;
                if (y < minY) minY = y;

                // Определение пересечений оси X
                if (!double.IsNaN(previousY) && (y * previousY < 0))
                {
                    zeroCrossings++;
                }

                previousY = y;
            }

            int pointsCount = (int)Math.Ceiling((b - a) / h) + 1;
            Console.WriteLine($"\nКоличество точек в таблице: {pointsCount}");
            Console.WriteLine($"Максимальное значение функции: {maxY:F4}");
            Console.WriteLine($"Минимальное значение функции: {minY:F4}");
            Console.WriteLine($"Количество пересечений оси X: {zeroCrossings}");
        }
    }
}

