using System;
using System.IO;

namespace Ticket24_StringExpressionEvaluation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Ввести выражение вручную");
            Console.WriteLine("2. Прочитать выражение из файла");
            int choice = int.Parse(Console.ReadLine());

            string expression;

            if (choice == 1)
            {
                Console.Write("Введите выражение (например, 50*5): ");
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

                expression = File.ReadAllText(inputFile).Trim();
                Console.WriteLine($"Прочитанное выражение: {expression}");
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
                return;
            }

            try
            {
                double result = EvaluateExpression(expression);
                Console.WriteLine($"Результат: {result}");

                Console.Write("Введите имя файла для сохранения результата: ");
                string outputFile = Console.ReadLine();

                File.WriteAllText(outputFile, $"Выражение: {expression}\nРезультат: {result}");
                Console.WriteLine($"Результат сохранён в файл: {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при вычислении выражения: {ex.Message}");
            }
        }

        static double EvaluateExpression(string expression)
        {
            char[] operators = { '+', '-', '*', '/' };
            foreach (var op in operators)
            {
                int index = expression.IndexOf(op);
                if (index > 0)
                {
                    string leftPart = expression.Substring(0, index).Trim();
                    string rightPart = expression.Substring(index + 1).Trim();

                    if (int.TryParse(leftPart, out int leftOperand) && int.TryParse(rightPart, out int rightOperand))
                    {
                        return op switch
                        {
                            '+' => leftOperand + rightOperand,
                            '-' => leftOperand - rightOperand,
                            '*' => leftOperand * rightOperand,
                            '/' => rightOperand != 0 ? (double)leftOperand / rightOperand : throw new DivideByZeroException("Деление на ноль"),
                            _ => throw new InvalidOperationException("Неизвестная операция")
                        };
                    }
                }
            }

            throw new FormatException("Некорректный формат выражения");
        }
    }
}
