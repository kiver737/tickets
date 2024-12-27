using System;
namespace Ticket02_FractionsOperations
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Ввод дробей");
                Console.WriteLine("2. Сложение дробей");
                Console.WriteLine("3. Вычитание дробей");
                Console.WriteLine("4. Умножение дробей");
                Console.WriteLine("5. Деление дробей");
                Console.WriteLine("6. Сокращение дроби");
                Console.WriteLine("0. Выход");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Fraction fraction = InputFraction();
                        Console.WriteLine("Вы ввели дробь: " + FractionToString(fraction));
                        break;
                    case 2:
                        Fraction f1 = InputFraction("Введите первую дробь:");
                        Fraction f2 = InputFraction("Введите вторую дробь:");
                        Fraction sum = AddFractions(f1, f2);
                        Console.WriteLine("Сумма: " + FractionToString(sum));
                        break;
                    case 3:
                        f1 = InputFraction("Введите первую дробь:");
                        f2 = InputFraction("Введите вторую дробь:");
                        Fraction difference = SubtractFractions(f1, f2);
                        Console.WriteLine("Разность: " + FractionToString(difference));
                        break;
                    case 4:
                        f1 = InputFraction("Введите первую дробь:");
                        f2 = InputFraction("Введите вторую дробь:");
                        Fraction product = MultiplyFractions(f1, f2);
                        Console.WriteLine("Произведение: " + FractionToString(product));
                        break;
                    case 5:
                        f1 = InputFraction("Введите первую дробь:");
                        f2 = InputFraction("Введите вторую дробь:");
                        Fraction quotient = DivideFractions(f1, f2);
                        Console.WriteLine("Частное: " + FractionToString(quotient));
                        break;
                    case 6:
                        fraction = InputFraction("Введите дробь для сокращения:");
                        Fraction reduced = ReduceFraction(fraction);
                        Console.WriteLine("Сокращенная дробь: " + FractionToString(reduced));
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        // Структура для представления дроби
        public struct Fraction
        {
            public int Numerator;
            public int Denominator;
        }

        // Функция для ввода дроби
        static Fraction InputFraction(string prompt = "Введите дробь:")
        {
            Console.WriteLine(prompt);
            Console.Write("Числитель: ");
            int numerator = int.Parse(Console.ReadLine());
            Console.Write("Знаменатель: ");
            int denominator = int.Parse(Console.ReadLine());

            if (denominator == 0)
            {
                Console.WriteLine("Знаменатель не может быть равен нулю. Попробуйте снова.");
                return InputFraction(prompt);
            }

            return new Fraction { Numerator = numerator, Denominator = denominator };
        }

        // Функция для вывода дроби в строковом формате
        static string FractionToString(Fraction fraction)
        {
            return $"{fraction.Numerator}/{fraction.Denominator}";
        }

        // Функция сложения дробей
        static Fraction AddFractions(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator;
            int denominator = f1.Denominator * f2.Denominator;
            return ReduceFraction(new Fraction { Numerator = numerator, Denominator = denominator });
        }

        // Функция вычитания дробей
        static Fraction SubtractFractions(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator;
            int denominator = f1.Denominator * f2.Denominator;
            return ReduceFraction(new Fraction { Numerator = numerator, Denominator = denominator });
        }

        // Функция умножения дробей
        static Fraction MultiplyFractions(Fraction f1, Fraction f2)
        {
            int numerator = f1.Numerator * f2.Numerator;
            int denominator = f1.Denominator * f2.Denominator;
            return ReduceFraction(new Fraction { Numerator = numerator, Denominator = denominator });
        }

        // Функция деления дробей
        static Fraction DivideFractions(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
            {
                throw new DivideByZeroException("Невозможно разделить на дробь с числителем 0.");
            }

            int numerator = f1.Numerator * f2.Denominator;
            int denominator = f1.Denominator * f2.Numerator;
            return ReduceFraction(new Fraction { Numerator = numerator, Denominator = denominator });
        }

        // Функция сокращения дроби
        static Fraction ReduceFraction(Fraction fraction)
        {
            int gcd = GCD(fraction.Numerator, fraction.Denominator);
            return new Fraction
            {
                Numerator = fraction.Numerator / gcd,
                Denominator = fraction.Denominator / gcd
            };
        }

        // Функция нахождения наибольшего общего делителя (НОД)
        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
    }
}

