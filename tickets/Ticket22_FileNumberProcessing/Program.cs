using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ticket22_FileNumberProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "number.txt";
            string outputFileName = "processed_numbers.txt";

            // Создание файла и запись случайных чисел
            Console.WriteLine("Создание файла number.txt с произвольными числами...");
            GenerateRandomNumbers(fileName);

            // Чтение чисел из файла
            Console.WriteLine("Чтение чисел из файла number.txt...");
            List<int> numbers = ReadNumbersFromFile(fileName);

            Console.WriteLine("Исходные числа:");
            Console.WriteLine(string.Join(", ", numbers));

            // Преобразование чисел
            Console.WriteLine("Преобразование чисел...");
            List<int> transformedNumbers = TransformNumbers(numbers);

            Console.WriteLine("Преобразованные числа:");
            Console.WriteLine(string.Join(", ", transformedNumbers));

            // Запись преобразованных чисел в новый файл
            Console.WriteLine($"Запись преобразованных чисел в файл {outputFileName}...");
            WriteNumbersToFile(outputFileName, transformedNumbers);

            Console.WriteLine("Операция завершена. Данные сохранены.");
        }

        static void GenerateRandomNumbers(string fileName)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < 20; i++) // Записываем 20 случайных чисел
                {
                    writer.WriteLine(random.Next(1, 21)); // Диапазон чисел от 1 до 20
                }
            }
        }

        static List<int> ReadNumbersFromFile(string fileName)
        {
            List<int> numbers = new List<int>();
            foreach (var line in File.ReadAllLines(fileName))
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }

        static List<int> TransformNumbers(List<int> numbers)
        {
            return numbers
                .Select(n => n % 2 == 0 ? n + 1 : n) // Увеличиваем четные числа на 1
                .Select(n => (int)Math.Round(n * 0.3)) // Умножаем на 0.3 и округляем
                .Where(n => n >= 5) // Удаляем числа меньше 5
                .ToList();
        }

        static void WriteNumbersToFile(string fileName, List<int> numbers)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var number in numbers)
                {
                    writer.WriteLine(number);
                }
            }
        }
    }
}
