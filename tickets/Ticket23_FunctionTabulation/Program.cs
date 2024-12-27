using System;
using System.Collections.Generic;

namespace Ticket23_FunctionTabulation
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

            if (h <= 0 || a >= b)
            {
                Console.WriteLine("Некорректные входные данные.");
                return;
            }

            List<(double X, double Y)> points = new List<(double X, double Y)>();
            double maxY = double.MinValue;
            double minY = double.MaxValue;
            int signChanges = 0;
            double? previousY = null;

            Console.WriteLine("\nТаблица значений функции y(x) = √x - x * π * cos(πx):");
            Console.WriteLine("X\t\tY(X)");

            for (double x = a; x <= b; x += h)
            {
                double y;
                try
                {
                    y = Math.Sqrt(x) - x * Math.PI * Math.Cos(Math.PI * x);
                }
                catch
                {
                    y = double.NaN; // Обработка возможных ошибок вычислений
                }

                points.Add((x, y));

                Console.WriteLine($"{x:F4}\t{y:F4}");

                // Обновление максимума и минимума
                if (!double.IsNaN(y))
                {
                    if (y > maxY) maxY = y;
                    if (y < minY) minY = y;

                    // Проверка смены знака
                    if (previousY.HasValue && Math.Sign(previousY.Value) != Math.Sign(y))
                    {
                        signChanges++;
                    }
                    previousY = y;
                }
            }

            Console.WriteLine($"\nКоличество точек в таблице: {points.Count}");
            Console.WriteLine($"Максимальное значение функции: {maxY:F4}");
            Console.WriteLine($"Минимальное значение функции: {minY:F4}");
            Console.WriteLine($"Количество пересечений оси X: {signChanges}");
        }
    }
}

