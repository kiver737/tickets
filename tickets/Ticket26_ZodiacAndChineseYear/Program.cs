using System;
using System.IO;

namespace Ticket26_ZodiacAndChineseYear
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите свою дату рождения (например, 8 марта): ");
            string birthDateInput = Console.ReadLine();

            Console.Write("Введите год рождения: ");
            int yearOfBirth;
            while (!int.TryParse(Console.ReadLine(), out yearOfBirth) || yearOfBirth <= 0)
            {
                Console.Write("Некорректный ввод. Введите корректный год рождения: ");
            }

            string zodiacSign = GetZodiacSign(birthDateInput);
            string chineseYear = GetChineseYear(yearOfBirth);

            Console.WriteLine($"Ваш знак зодиака: {zodiacSign}");
            Console.WriteLine($"Ваш год по китайскому календарю: {chineseYear}");

            Console.Write("Введите имя файла для сохранения результата: ");
            string outputFile = Console.ReadLine();

            File.WriteAllText(outputFile, $"Дата рождения: {birthDateInput}\nГод рождения: {yearOfBirth}\nЗнак зодиака: {zodiacSign}\nГод по китайскому календарю: {chineseYear}");
            Console.WriteLine($"Результат сохранён в файл: {outputFile}");
        }

        static string GetZodiacSign(string birthDateInput)
        {
            string[] parts = birthDateInput.Split(' ');
            if (parts.Length < 2 || !int.TryParse(parts[0], out int day))
            {
                return "Некорректная дата";
            }

            string month = parts[1].ToLower();

            return month switch
            {
                "января" => day <= 19 ? "Козерог" : "Водолей",
                "февраля" => day <= 18 ? "Водолей" : "Рыбы",
                "марта" => day <= 20 ? "Рыбы" : "Овен",
                "апреля" => day <= 19 ? "Овен" : "Телец",
                "мая" => day <= 20 ? "Телец" : "Близнецы",
                "июня" => day <= 20 ? "Близнецы" : "Рак",
                "июля" => day <= 22 ? "Рак" : "Лев",
                "августа" => day <= 22 ? "Лев" : "Дева",
                "сентября" => day <= 22 ? "Дева" : "Весы",
                "октября" => day <= 22 ? "Весы" : "Скорпион",
                "ноября" => day <= 21 ? "Скорпион" : "Стрелец",
                "декабря" => day <= 21 ? "Стрелец" : "Козерог",
                _ => "Некорректная дата"
            };
        }

        static string GetChineseYear(int year)
        {
            string[] animals = {
                "Обезьяна", "Петух", "Собака", "Свинья", "Крыса", "Бык",
                "Тигр", "Кролик", "Дракон", "Змея", "Лошадь", "Коза"
            };

            return animals[(year - 4) % 12];
        }
    }
}
