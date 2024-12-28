// using System;
// using System.IO;
//
// namespace Ticket21_GuessTheNumber
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.Write("Enter your full name: ");
//             string playerName = Console.ReadLine();
//
//             bool playAgain = true;
//             while (playAgain)
//             {
//                 int secretNumber = new Random().Next(1, 11); // Generate a number between 1 and 10
//                 int attempts = 5;
//                 bool isGuessed = false;
//
//                 Console.WriteLine("\nGame: Guess the Number");
//                 Console.WriteLine("You have 5 attempts to guess a number between 1 and 10.");
//
//                 for (int i = 1; i <= attempts; i++)
//                 {
//                     Console.Write($"\nAttempt {i}: Enter a number: ");
//                     int guess;
//                     if (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 10)
//                     {
//                         Console.WriteLine("Please enter a valid number between 1 and 10.");
//                         i--; // Do not count this attempt
//                         continue;
//                     }
//
//                     if (guess == secretNumber)
//                     {
//                         Console.WriteLine("Congratulations, you guessed it!");
//                         isGuessed = true;
//                         break;
//                     }
//                     else
//                     {
//                         Console.WriteLine("Wrong guess. Try again.");
//                     }
//                 }
//
//                 string result = isGuessed ? "Win" : "Lose";
//                 Console.WriteLine($"\nGame over. Result: {result}");
//
//                 Console.WriteLine("\nDo you want to save the result? (yes/no)");
//                 if (Console.ReadLine().Trim().ToLower() == "yes")
//                 {
//                     SaveResult(playerName, isGuessed ? (5 - attempts + 1) : attempts, result);
//                     Console.WriteLine("The result has been saved to the file results.txt.");
//                 }
//
//                 Console.WriteLine("\nDo you want to play again? (yes/no)");
//                 playAgain = Console.ReadLine().Trim().ToLower() == "yes";
//             }
//         }
//
//         static void SaveResult(string playerName, int attempts, string result)
//         {
//             string fileName = "results.txt";
//             try
//             {
//                 using (StreamWriter writer = new StreamWriter(fileName, true))
//                 {
//                     writer.WriteLine($"Name: {playerName}, Attempts: {attempts}, Result: {result}");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"An error occurred while saving the result: {ex.Message}");
//             }
//         }
//     }
// }

//
// using System;
// using System.IO;
//
// namespace Ticket26_ZodiacAndChineseYear
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.Write("Enter your birth date (e.g., January 30): ");
//             string birthDateInput = Console.ReadLine()?.Trim();
//
//             Console.Write("Enter your birth year: ");
//             int yearOfBirth;
//             while (!int.TryParse(Console.ReadLine(), out yearOfBirth) || yearOfBirth <= 0)
//             {
//                 Console.Write("Invalid input. Please enter a valid year: ");
//             }
//
//             string zodiacSign = GetZodiacSign(birthDateInput);
//             string chineseYear = GetChineseYearByCycle(yearOfBirth);
//
//             Console.WriteLine($"\nYour Zodiac sign: {zodiacSign}");
//             Console.WriteLine($"Your Chinese year: {chineseYear}");
//
//             Console.Write("\nEnter the file name to save the result (e.g., result.txt): ");
//             string outputFile = Console.ReadLine()?.Trim();
//
//             try
//             {
//                 File.WriteAllText(outputFile,
//                     $"Birth date: {birthDateInput}\n" +
//                     $"Birth year: {yearOfBirth}\n" +
//                     $"Zodiac sign: {zodiacSign}\n" +
//                     $"Chinese year: {chineseYear}");
//                 Console.WriteLine($"The result has been saved to the file: {outputFile}");
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
//             }
//         }
//
//         static string GetZodiacSign(string birthDateInput)
//         {
//             if (string.IsNullOrEmpty(birthDateInput))
//             {
//                 return "Invalid date";
//             }
//
//             string[] parts = birthDateInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
//             if (parts.Length < 2 || !int.TryParse(parts[1], out int day))
//             {
//                 return "Invalid date";
//             }
//
//             string month = parts[0].ToLower();
//
//             return month switch
//             {
//                 "january" => day <= 19 ? "Capricorn" : "Aquarius",
//                 "february" => day <= 18 ? "Aquarius" : "Pisces",
//                 "march" => day <= 20 ? "Pisces" : "Aries",
//                 "april" => day <= 19 ? "Aries" : "Taurus",
//                 "may" => day <= 20 ? "Taurus" : "Gemini",
//                 "june" => day <= 20 ? "Gemini" : "Cancer",
//                 "july" => day <= 22 ? "Cancer" : "Leo",
//                 "august" => day <= 22 ? "Leo" : "Virgo",
//                 "september" => day <= 22 ? "Virgo" : "Libra",
//                 "october" => day <= 22 ? "Libra" : "Scorpio",
//                 "november" => day <= 21 ? "Scorpio" : "Sagittarius",
//                 "december" => day <= 21 ? "Sagittarius" : "Capricorn",
//                 _ => "Invalid date"
//             };
//         }
//
//         static string GetChineseYearByCycle(int year)
//         {
//             string[] animals = {
//                 "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox",
//                 "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"
//             };
//
//             int index = (year - 4) % 12; // Adjusting for the Chinese Zodiac cycle starting with Rat in 4 AD
//             return animals[index];
//         }
//     }
// }





using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Ввод даты рождения
        Console.WriteLine("Введите дату рождения в формате 'день месяц' (например, '8 марта'):");
        string input = Console.ReadLine();

        // Ввод года рождения
        Console.WriteLine("Введите год рождения:");
        int year = int.Parse(Console.ReadLine());

        // Определение знака зодиака
        string zodiacSign = GetZodiacSign(input);
        Console.WriteLine($"Ваш знак зодиака: {zodiacSign}");

        // Определение года по китайскому календарю
        string chineseYear = GetChineseYear(year);
        Console.WriteLine($"Ваш год по китайскому календарю: {chineseYear}");

        // Запись результата в файл
        string result = $"Дата рождения: {input}, Год: {year}, Знак зодиака: {zodiacSign}, Китайский год: {chineseYear}";
        File.WriteAllText("birthday_result.txt", result);
        Console.WriteLine("Результат записан в файл birthday_result.txt.");
    }

    static string GetZodiacSign(string date)
    {
        string[] parts = date.Split(' ');
        int day = int.Parse(parts[0]);
        string month = parts[1].ToLower();

        switch (month)
        {
            case "марта":
                return (day <= 20) ? "Рыбы" : "Овен";
            case "апреля":
                return (day <= 19) ? "Овен" : "Телец";
            case "мая":
                return (day <= 20) ? "Телец" : "Близнецы";
            case "июня":
                return (day <= 20) ? "Близнецы" : "Рак";
            case "июля":
                return (day <= 22) ? "Рак" : "Лев";
            case "августа":
                return (day <= 22) ? "Лев" : "Дева";
            case "сентября":
                return (day <= 22) ? "Дева" : "Весы";
            case "октября":
                return (day <= 22) ? "Весы" : "Скорпион";
            case "ноября":
                return (day <= 21) ? "Скорпион" : "Стрелец";
            case "декабря":
                return (day <= 21) ? "Стрелец" : "Козерог";
            case "января":
                return (day <= 19) ? "Козерог" : "Водолей";
            case "февраля":
                return (day <= 18) ? "Водолей" : "Рыбы";
            default:
                return "Неизвестно";
        }
    }

    static string GetChineseYear(int year)
    {
        string[] chineseZodiacs = { "Крыса", "Бык", "Тигр", "Кролик", "Дракон", "Змея", "Лошадь", "Коза", "Обезьяна", "Петух", "Собака", "Свинья" };
        int startYear = 1924; // Начало цикла китайского календаря
        int index = (year - startYear) % 12;
        if (index < 0) index += 12;
        return chineseZodiacs[index];
    }
}
