using System;
using System.IO;

namespace Ticket15_StringReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1. Ввести данные вручную");
            Console.WriteLine("2. Прочитать данные из файла");
            int choice = int.Parse(Console.ReadLine());

            string inputString, searchString, replaceString;

            if (choice == 1)
            {
                Console.Write("Введите исходную строку: ");
                inputString = Console.ReadLine();

                Console.Write("Введите строку для поиска: ");
                searchString = Console.ReadLine();

                Console.Write("Введите строку для замены: ");
                replaceString = Console.ReadLine();
            }
            else if (choice == 2)
            {
                Console.Write("Введите имя файла для чтения данных: ");
                string inputFile = Console.ReadLine();

                if (!File.Exists(inputFile))
                {
                    Console.WriteLine("Файл не найден.");
                    return;
                }

                string[] fileLines = File.ReadAllLines(inputFile);

                if (fileLines.Length < 3)
                {
                    Console.WriteLine("Файл должен содержать минимум три строки: исходная строка, строка для поиска и строка для замены.");
                    return;
                }

                inputString = fileLines[0];
                searchString = fileLines[1];
                replaceString = fileLines[2];

                Console.WriteLine($"Исходная строка: {inputString}");
                Console.WriteLine($"Строка для поиска: {searchString}");
                Console.WriteLine($"Строка для замены: {replaceString}");
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
                return;
            }

            // Поиск и замена
            if (inputString.Contains(searchString))
            {
                string resultString = inputString.Replace(searchString, replaceString);
                Console.WriteLine($"Откорректированная строка: {resultString}");

                // Сохранение результата в файл
                Console.Write("Введите имя файла для сохранения результата: ");
                string outputFile = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(outputFile))
                {
                    writer.WriteLine("Исходная строка:");
                    writer.WriteLine(inputString);
                    writer.WriteLine("\nСтрока для поиска:");
                    writer.WriteLine(searchString);
                    writer.WriteLine("\nСтрока для замены:");
                    writer.WriteLine(replaceString);
                    writer.WriteLine("\nОткорректированная строка:");
                    writer.WriteLine(resultString);
                }

                Console.WriteLine($"Результат сохранен в файл: {outputFile}");
            }
            else
            {
                Console.WriteLine("Строка для поиска не найдена в исходной строке.");
            }
        }
    }
}
