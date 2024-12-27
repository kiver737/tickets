using System;
using System.IO;

namespace Ticket17_FileEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Закодировать файл");
            Console.WriteLine("2. Декодировать файл");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Введите имя исходного файла: ");
            string inputFile = Console.ReadLine();

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            Console.Write("Введите ключ кодирования (целое число): ");
            int key = int.Parse(Console.ReadLine());

            Console.Write("Введите имя файла для сохранения результата: ");
            string outputFile = Console.ReadLine();

            try
            {
                string text = File.ReadAllText(inputFile);

                if (string.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("Исходный файл пуст или содержит только пробелы.");
                    return;
                }

                string result = choice switch
                {
                    1 => EncodeText(text, key, true), // Кодирование через одного символа
                    2 => EncodeText(text, -key, true), // Декодирование через одного символа
                    _ => throw new InvalidOperationException("Некорректный выбор.")
                };

                File.WriteAllText(outputFile, result);
                Console.WriteLine($"Результат сохранен в файл: {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        // Метод для кодирования и декодирования текста
        static string EncodeText(string text, int key, bool skipEveryOther)
        {
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                if (skipEveryOther && i % 2 != 0)
                {
                    result[i] = text[i]; // Пропускаем каждый второй символ
                }
                else
                {
                    result[i] = (char)(text[i] + key);
                }
            }

            return new string(result);
        }
    }
}
