using System;
namespace tickets.Ticket01_BasesConversion;

public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Перевод из 10-тичной системы счисления в q-систему.");
            Console.WriteLine("2. Перевод из q-системы счисления в 10-тичную.");
            Console.WriteLine("3. Перевод из q1-системы счисления в q2-систему.");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DecimalToBaseQ();
                    break;
                case 2:
                    BaseQToDecimal();
                    break;
                case 3:
                    BaseQ1ToBaseQ2();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        // Перевод из 10-тичной системы счисления в q-систему
        static void DecimalToBaseQ()
        {
            Console.Write("Введите число в 10-тичной системе счисления: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Введите систему счисления q (2-9): ");
            int q = int.Parse(Console.ReadLine());

            if (q < 2 || q > 9)
            {
                Console.WriteLine("Неверная система счисления.");
                return;
            }

            string result = "";

            while (number > 0)
            {
                int remainder = number % q;
                result = remainder + result;
                number /= q;
            }

            Console.WriteLine($"Число в {q}-ичной системе счисления: {result}");
        }

        // Перевод из q-системы счисления в 10-тичную
        static void BaseQToDecimal()
        {
            Console.Write("Введите число в системе счисления q: ");
            string number = Console.ReadLine();

            Console.Write("Введите систему счисления q (2-9): ");
            int q = int.Parse(Console.ReadLine());

            if (q < 2 || q > 9)
            {
                Console.WriteLine("Неверная система счисления.");
                return;
            }

            int result = 0;
            int power = 1;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';
                if (digit < 0 || digit >= q)
                {
                    Console.WriteLine("Число не соответствует указанной системе счисления.");
                    return;
                }

                result += digit * power;
                power *= q;
            }

            Console.WriteLine($"Число в 10-тичной системе счисления: {result}");
        }

        // Перевод из q1-системы счисления в q2-систему
        static void BaseQ1ToBaseQ2()
        {
            Console.Write("Введите число в системе счисления q1: ");
            string number = Console.ReadLine();

            Console.Write("Введите систему счисления q1 (2-9): ");
            int q1 = int.Parse(Console.ReadLine());

            Console.Write("Введите систему счисления q2 (2-9): ");
            int q2 = int.Parse(Console.ReadLine());

            if (q1 < 2 || q1 > 9 || q2 < 2 || q2 > 9)
            {
                Console.WriteLine("Неверная система счисления.");
                return;
            }

            // Перевод из q1 в 10-тичную
            int decimalNumber = 0;
            int power = 1;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';
                if (digit < 0 || digit >= q1)
                {
                    Console.WriteLine("Число не соответствует указанной системе счисления.");
                    return;
                }

                decimalNumber += digit * power;
                power *= q1;
            }

            // Перевод из 10-тичной в q2
            string result = "";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % q2;
                result = remainder + result;
                decimalNumber /= q2;
            }

            Console.WriteLine($"Число в {q2}-ичной системе счисления: {result}");
        }
    }

