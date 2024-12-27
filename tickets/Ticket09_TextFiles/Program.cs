using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ticket09_TextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя исходного текстового файла: ");
            string inputFile = Console.ReadLine();

            Console.Write("Введите имя файла для сохранения результата: ");
            string outputFile = Console.ReadLine();

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Исходный файл не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);

            // Создание нового файла с добавлением порядковых номеров
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    writer.WriteLine($"{i + 1}: {lines[i]}");
                }

                // Добавление информации об общем количестве строк
                writer.WriteLine($"\nОбщее количество строк в файле: {lines.Length}");
            }

            Console.WriteLine("Результаты записаны в файл.");

            // Частотный анализ текста
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            foreach (string line in lines)
            {
                foreach (char c in line.ToLower())
                {
                    if (char.IsLetter(c))
                    {
                        if (!frequency.ContainsKey(c))
                        {
                            frequency[c] = 0;
                        }
                        frequency[c]++;
                    }
                }
            }

            if (frequency.Count > 0)
            {
                char mostFrequent = frequency.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                char leastFrequent = frequency.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

                Console.WriteLine("Частотный анализ букв:");
                foreach (var pair in frequency.OrderBy(pair => pair.Key))
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }

                Console.WriteLine($"\nНаиболее часто встречающаяся буква: {mostFrequent} ({frequency[mostFrequent]} раз)");
                Console.WriteLine($"Наименее часто встречающаяся буква: {leastFrequent} ({frequency[leastFrequent]} раз)");
            }
            else
            {
                Console.WriteLine("В тексте не найдено букв.");
            }
        }
    }
}

