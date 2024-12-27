using System;

namespace Ticket04_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество дней в месяце: ");
            int days = int.Parse(Console.ReadLine());

            // Генерация случайного массива курсов доллара
            Random random = new Random();
            double[] dollarRates = new double[days];
            for (int i = 0; i < days; i++)
            {
                dollarRates[i] = random.Next(10, 81) + random.NextDouble(); // Диапазон [10, 80]
            }

            // Вывод сгенерированных курсов доллара
            Console.WriteLine("Курсы доллара по дням:");
            for (int i = 0; i < days; i++)
            {
                Console.WriteLine($"День {i + 1}: {dollarRates[i]:F2}");
            }

            // Нахождение максимального и минимального курса
            double maxRate = double.MinValue;
            double minRate = double.MaxValue;

            foreach (var rate in dollarRates)
            {
                if (rate > maxRate) maxRate = rate;
                if (rate < minRate) minRate = rate;
            }

            Console.WriteLine($"Самый высокий курс: {maxRate:F2}");
            Console.WriteLine($"Самый низкий курс: {minRate:F2}");

            // Обмен по самому выгодному курсу
            Console.Write("Введите сумму для обмена (рубли): ");
            double rubAmount = double.Parse(Console.ReadLine());

            double maxExchange = rubAmount / maxRate;
            double minExchange = rubAmount / minRate;

            Console.WriteLine($"Максимальная сумма долларов, которую можно купить: {maxExchange:F2}");
            Console.WriteLine($"Минимальная сумма долларов, которую можно купить: {minExchange:F2}");

            // Рассчет среднего курса доллара за месяц
            double total = 0;
            foreach (var rate in dollarRates)
            {
                total += rate;
            }
            double averageRate = total / days;
            Console.WriteLine($"Средний курс доллара за месяц: {averageRate:F2}");

            // Отклонение каждого дня от среднего значения
            Console.WriteLine("Отклонение курса по дням:");
            for (int i = 0; i < days; i++)
            {
                double deviation = dollarRates[i] - averageRate;
                Console.WriteLine($"День {i + 1}: {deviation:F2}");
            }

            // Количество дней, когда курс превышал среднемесячное значение
            int daysAboveAverage = 0;
            foreach (var rate in dollarRates)
            {
                if (rate > averageRate) daysAboveAverage++;
            }

            Console.WriteLine($"Количество дней, когда курс превышал среднемесячное значение: {daysAboveAverage}");
        }
    }
}

