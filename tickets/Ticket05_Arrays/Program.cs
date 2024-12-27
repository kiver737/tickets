using System;

namespace Ticket05_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            const int months = 12;
            Random random = new Random();
            double[] salaries = new double[months];

            // Генерация зарплат по месяцам
            for (int i = 0; i < months; i++)
            {
                salaries[i] = random.Next(1000, 5001) + random.NextDouble(); // Диапазон [1000, 5000]
            }

            // Вывод зарплат по месяцам
            Console.WriteLine("Зарплаты по месяцам:");
            for (int i = 0; i < months; i++)
            {
                Console.WriteLine($"Месяц {i + 1}: {salaries[i]:F2} $");
            }

            // Общая сумма выплат за год
            double totalSalary = 0;
            foreach (var salary in salaries)
            {
                totalSalary += salary;
            }
            Console.WriteLine($"Общая сумма выплат за год: {totalSalary:F2} $");

            // Средняя зарплата за год
            double averageSalary = totalSalary / months;
            Console.WriteLine($"Средняя зарплата за год: {averageSalary:F2} $");

            // Отчисления в пенсионный фонд
            double[] pensionDeductions = new double[months];
            double totalPensionDeductions = 0;
            Console.WriteLine("\nОтчисления в пенсионный фонд по месяцам:");
            for (int i = 0; i < months; i++)
            {
                pensionDeductions[i] = salaries[i] * 0.02;
                totalPensionDeductions += pensionDeductions[i];
                Console.WriteLine($"Месяц {i + 1}: {pensionDeductions[i]:F2} $");
            }
            Console.WriteLine($"Общая сумма отчислений в пенсионный фонд за год: {totalPensionDeductions:F2} $");

            // Отклонения зарплаты от средней
            Console.WriteLine("\nОтклонения зарплаты от средней по месяцам:");
            for (int i = 0; i < months; i++)
            {
                double deviation = salaries[i] - averageSalary;
                Console.WriteLine($"Месяц {i + 1}: {deviation:F2} $");
            }

            // Нахождение максимальной и минимальной зарплаты
            double maxSalary = double.MinValue;
            double minSalary = double.MaxValue;
            int maxMonth = -1;
            int minMonth = -1;

            for (int i = 0; i < months; i++)
            {
                if (salaries[i] > maxSalary)
                {
                    maxSalary = salaries[i];
                    maxMonth = i + 1;
                }

                if (salaries[i] < minSalary)
                {
                    minSalary = salaries[i];
                    minMonth = i + 1;
                }
            }

            Console.WriteLine($"\nМаксимальная зарплата: {maxSalary:F2} $ в месяце {maxMonth}");
            Console.WriteLine($"Минимальная зарплата: {minSalary:F2} $ в месяце {minMonth}");
        }
    }
}

