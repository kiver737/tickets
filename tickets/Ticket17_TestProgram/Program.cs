using System;
using System.Collections.Generic;
using System.IO;

namespace Ticket17_TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Провести тестирование");
            Console.WriteLine("2. Заполнить файл вопросами теста");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                ConductTest();
            }
            else if (choice == 2)
            {
                CreateTestFile();
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }
        }

        static void ConductTest()
        {
            Console.Write("Введите имя файла с тестом: ");
            string testFile = Console.ReadLine();

            if (!File.Exists(testFile))
            {
                Console.WriteLine("Файл с тестом не найден.");
                return;
            }

            Console.Write("Введите ФИО студента: ");
            string studentName = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string studentGroup = Console.ReadLine();

            string[] lines = File.ReadAllLines(testFile);
            int correctAnswers = 0;
            int questionCount = 0;

            Console.WriteLine("\nНачало тестирования:");
            for (int i = 0; i < lines.Length; i += 6)
            {
                questionCount++;
                Console.WriteLine($"\nВопрос {questionCount}: {lines[i]}");
                for (int j = 1; j <= 4; j++)
                {
                    Console.WriteLine($"{j}. {lines[i + j]}");
                }

                Console.Write("Ваш ответ (1-4): ");
                int answer = int.Parse(Console.ReadLine());
                int correctAnswer = int.Parse(lines[i + 5]);

                if (answer == correctAnswer)
                {
                    correctAnswers++;
                }
            }

            Console.WriteLine($"\nТест завершен. Ваш результат: {correctAnswers}/{questionCount}");

            string resultFile = "result.txt";
            using (StreamWriter writer = new StreamWriter(resultFile, append: true))
            {
                writer.WriteLine($"ФИО: {studentName}, Группа: {studentGroup}, Результат: {correctAnswers}/{questionCount}");
            }

            Console.WriteLine($"Результаты сохранены в файл: {resultFile}");
        }

        static void CreateTestFile()
        {
            Console.Write("Введите имя файла для сохранения теста: ");
            string testFile = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(testFile))
            {
                Console.WriteLine("Введите вопросы теста. Для завершения ввода оставьте вопрос пустым.");

                while (true)
                {
                    Console.Write("Введите вопрос: ");
                    string question = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(question)) break;

                    writer.WriteLine(question);

                    for (int i = 1; i <= 4; i++)
                    {
                        Console.Write($"Введите вариант ответа {i}: ");
                        writer.WriteLine(Console.ReadLine());
                    }

                    Console.Write("Введите номер правильного ответа (1-4): ");
                    writer.WriteLine(Console.ReadLine());
                }
            }

            Console.WriteLine("Тест сохранен.");
        }
    }
}

