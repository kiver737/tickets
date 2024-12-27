using System;
using System.IO;

namespace Ticket18_TemperatureAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество дней в месяце: ");
            int days = int.Parse(Console.ReadLine());

            double[] temperatures = new double[days];
            Random random = new Random();

            Console.WriteLine("Температуры за месяц:");
            for (int i = 0; i < days; i++)
            {
                temperatures[i] = random.Next(-30, 35) + random.NextDouble(); // Генерация температуры
                Console.WriteLine($"День {i + 1}: {temperatures[i]:F1}°C");
            }

            // Средняя температура
            double averageTemperature = CalculateAverage(temperatures);
            Console.WriteLine($"\nСредняя температура за месяц: {averageTemperature:F1}°C");

            // Максимальная и минимальная температуры
            double maxTemperature = FindMax(temperatures);
            double minTemperature = FindMin(temperatures);
            Console.WriteLine($"Максимальная температура за месяц: {maxTemperature:F1}°C");
            Console.WriteLine($"Минимальная температура за месяц: {minTemperature:F1}°C");

            // Отклонения от средней температуры
            Console.WriteLine("\nОтклонения от средней температуры:");
            double[] deviations = CalculateDeviations(temperatures, averageTemperature);
            for (int i = 0; i < days; i++)
            {
                Console.WriteLine($"День {i + 1}: {deviations[i]:F1}°C");
            }

            // Запись результатов в файл
            Console.Write("Введите имя файла для сохранения данных: ");
            string fileName = Console.ReadLine();

            SaveToFile(fileName, temperatures, averageTemperature, maxTemperature, minTemperature, deviations);
            Console.WriteLine($"Данные сохранены в файл: {fileName}");
        }

        static double CalculateAverage(double[] temperatures)
        {
            double sum = 0;
            foreach (var temp in temperatures)
            {
                sum += temp;
            }
            return sum / temperatures.Length;
        }

        static double FindMax(double[] temperatures)
        {
            double max = double.MinValue;
            foreach (var temp in temperatures)
            {
                if (temp > max)
                    max = temp;
            }
            return max;
        }

        static double FindMin(double[] temperatures)
        {
            double min = double.MaxValue;
            foreach (var temp in temperatures)
            {
                if (temp < min)
                    min = temp;
            }
            return min;
        }

        static double[] CalculateDeviations(double[] temperatures, double average)
        {
            double[] deviations = new double[temperatures.Length];
            for (int i = 0; i < temperatures.Length; i++)
            {
                deviations[i] = temperatures[i] - average;
            }
            return deviations;
        }

        static void SaveToFile(string fileName, double[] temperatures, double average, double max, double min, double[] deviations)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("Температуры за месяц:");
                for (int i = 0; i < temperatures.Length; i++)
                {
                    writer.WriteLine($"День {i + 1}: {temperatures[i]:F1}°C");
                }

                writer.WriteLine($"\nСредняя температура за месяц: {average:F1}°C");
                writer.WriteLine($"Максимальная температура за месяц: {max:F1}°C");
                writer.WriteLine($"Минимальная температура за месяц: {min:F1}°C");

                writer.WriteLine("\nОтклонения от средней температуры:");
                for (int i = 0; i < deviations.Length; i++)
                {
                    writer.WriteLine($"День {i + 1}: {deviations[i]:F1}°C");
                }
            }
        }
    }
}

