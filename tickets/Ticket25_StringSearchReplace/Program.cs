using System;
using System.IO;

namespace Ticket25_StringSearchReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Ввести строку вручную");
            Console.WriteLine("2. Прочитать строку из файла");
            int choice = int.Parse(Console.ReadLine());

            string inputString;

            if (choice == 1)
            {
                Console.Write("Введите исходную строку: ");
                inputString = Console.ReadLine();
            }
            else if (choice == 2)
            {
                Console.Write("Введите имя файла для чтения строки: ");
                string inputFile = Console.ReadLine();

                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                inputString = File.ReadAllText(inputFile).Trim();
                Console.WriteLine($"Прочитанная строка: {inputString}");
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
                return;
            }

            Console.Write("Введите фрагмент для поиска: ");
            string searchString = Console.ReadLine();

            Console.Write("Введите фрагмент для замены: ");
            string replaceString = Console.ReadLine();

            string outputString;

            if (inputString.Contains(searchString))
            {
                outputString = inputString.Replace(searchString, replaceString);
                Console.WriteLine("Результат замены: " + outputString);
            }
            else
            {
                outputString = inputString;
                Console.WriteLine("Фрагмент для поиска не найден.");
            }

            Console.Write("Введите имя файла для сохранения результата: ");
            string outputFile = Console.ReadLine();

            File.WriteAllText(outputFile, outputString);
            Console.WriteLine($"Результат сохранён в файл: {outputFile}");
        }
    }
}
