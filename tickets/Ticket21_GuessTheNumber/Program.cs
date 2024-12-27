using System;
using System.IO;

namespace Ticket21_GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите ваше ФИО: ");
            string playerName = Console.ReadLine();

            bool playAgain = true;
            while (playAgain)
            {
                int secretNumber = new Random().Next(1, 11); // Генерация числа от 1 до 10
                int attempts = 5;
                bool isGuessed = false;

                Console.WriteLine("Игра: Угадай число");
                Console.WriteLine("У вас есть 5 попыток, чтобы угадать число от 1 до 10.");

                for (int i = 1; i <= attempts; i++)
                {
                    Console.Write($"Попытка {i}: Введите число: ");
                    int guess;
                    if (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 10)
                    {
                        Console.WriteLine("Введите корректное число от 1 до 10.");
                        i--;
                        continue;
                    }

                    if (guess == secretNumber)
                    {
                        Console.WriteLine("Поздравляем, вы угадали!");
                        isGuessed = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы не угадали. Попробуйте снова.");
                    }
                }

                string result = isGuessed ? "Выиграл" : "Проиграл";
                Console.WriteLine($"Игра окончена. Результат: {result}");

                Console.WriteLine("Хотите сохранить результат? (да/нет)");
                if (Console.ReadLine().Trim().ToLower() == "да")
                {
                    SaveResult(playerName, attempts - (isGuessed ? 5 - attempts : 0), result);
                    Console.WriteLine("Результат сохранён в файл results.txt.");
                }

                Console.WriteLine("Хотите сыграть ещё раз? (да/нет)");
                playAgain = Console.ReadLine().Trim().ToLower() == "да";
            }
        }

        static void SaveResult(string playerName, int attempts, string result)
        {
            string fileName = "results.txt";
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"ФИО: {playerName}, Попыток: {attempts}, Результат: {result}");
            }
        }
    }
}
