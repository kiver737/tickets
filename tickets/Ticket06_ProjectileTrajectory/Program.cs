using System;
using System.IO;
using System.Globalization;

namespace Ticket06_ProjectileTrajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            const double g = 9.81; // Ускорение свободного падения

            // Ввод исходных данных
            Console.Write("Введите координаты пушки (x0, y0) через пробел: ");
            var coordinates = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            double x0 = coordinates[0];
            double y0 = coordinates[1];

            Console.Write("Введите начальную скорость снаряда V0 (м/с): ");
            double v0 = double.Parse(Console.ReadLine());

            Console.Write("Введите угол вылета снаряда α (градусы): ");
            double alphaDegrees = double.Parse(Console.ReadLine());
            double alphaRadians = alphaDegrees * Math.PI / 180; // Угол в радианах

            // Вычисление начальных скоростей по осям
            double vx0 = v0 * Math.Cos(alphaRadians);
            double vy0 = v0 * Math.Sin(alphaRadians);

            // Вычисление времени полета (при y=0)
            double flightTime = (vy0 + Math.Sqrt(vy0 * vy0 + 2 * g * y0)) / g;

            if (flightTime <= 0)
            {
                Console.WriteLine("Время полета некорректно. Проверьте входные данные.");
                return;
            }

            // Вычисление координат наивысшей точки траектории
            double maxTime = vy0 / g;
            double maxHeightX = x0 + vx0 * maxTime;
            double maxHeightY = y0 + vy0 * maxTime - 0.5 * g * maxTime * maxTime;

            Console.WriteLine($"Наивысшая точка траектории: X = {maxHeightX.ToString("F2", CultureInfo.InvariantCulture)}, Y = {maxHeightY.ToString("F2", CultureInfo.InvariantCulture)}");

            // Вычисление координат траектории и запись в файл
            string fileName = "trajectory.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("t (с)\tX (м)\tY (м)");

                Console.WriteLine("\nТраектория полета снаряда:");
                Console.WriteLine("t (с)\tX (м)\tY (м)");

                for (double t = 0; t <= flightTime; t += 0.1)
                {
                    double x = x0 + vx0 * t;
                    double y = y0 + vy0 * t - 0.5 * g * t * t;

                    if (y < 0) y = 0; // При падении на землю (y=0)

                    Console.WriteLine($"{t:F1}\t{x:F2}\t{y:F2}");
                    writer.WriteLine($"{t:F1}\t{x:F2}\t{y:F2}");

                    if (y == 0 && t > 0) break; // Остановить, когда снаряд достигнет земли
                }
            }

            Console.WriteLine($"\nТраектория полета сохранена в файл: {fileName}");
        }
    }
}
