using System;
using System.IO;

namespace Ticket14_StringExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите источник выражения:");
            Console.WriteLine("1. Ввести выражение вручную");
            Console.WriteLine("2. Прочитать выражение из файла");
            int choice = int.Parse(Console.ReadLine());

            string expression;

            if (choice == 1)
            {
                Console.Write("Введите арифметическое выражение (например, 12 + 6): ");
                expression = Console.ReadLine();
            }
            else if (choice == 2)
            {
                Console.Write("Введите имя файла для чтения выражения: ");
                string inputFile = Console.ReadLine();

                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                expression = File.ReadAllText(inputFile);
                Console.WriteLine($"Выражение из файла: {expression}");
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
                return;
            }

            // Вычисление результата
            try
            {
                double result = EvaluateExpression(expression);
                Console.WriteLine($"Результат: {result}");

                // Сохранение результата в файл
                Console.Write("Введите имя файла для сохранения результата: ");
                string outputFile = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine($"Выражение: {expression}");
                    writer.WriteLine($"Результат: {result}");
                }

                Console.WriteLine($"Результат сохранен в файл: {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Функция для вычисления арифметического выражения
        static double EvaluateExpression(string expression)
        {
            string[] parts = expression.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Некорректный формат выражения. Ожидается: число оператор число.");
            }

            double operand1 = double.Parse(parts[0]);
            string operatorSymbol = parts[1];
            double operand2 = double.Parse(parts[2]);

            return operatorSymbol switch
            {
                "+" => operand1 + operand2,
                "-" => operand1 - operand2,
                "*" => operand1 * operand2,
                "/" => operand2 != 0 ? operand1 / operand2 : throw new DivideByZeroException("Деление на ноль."),
                _ => throw new InvalidOperationException($"Некорректный оператор: {operatorSymbol}")
            };
        }
    }
}
