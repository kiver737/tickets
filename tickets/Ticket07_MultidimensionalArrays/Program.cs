// using System;
//
// namespace Ticket07_MultidimensionalArrays
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.Write("Введите количество спортсменов: ");
//             int athletesCount = int.Parse(Console.ReadLine());
//
//             Console.Write("Введите количество видов соревнований: ");
//             int eventsCount = int.Parse(Console.ReadLine());
//
//             // Создание динамического двумерного массива
//             double[,] scores = new double[athletesCount, eventsCount];
//
//             // Заполнение массива случайными оценками (1-10)
//             Random random = new Random();
//             for (int i = 0; i < athletesCount; i++)
//             {
//                 for (int j = 0; j < eventsCount; j++)
//                 {
//                     scores[i, j] = random.Next(1, 11); // Оценка в диапазоне от 1 до 10
//                 }
//             }
//
//             // Вывод оценок спортсменов
//             Console.WriteLine("\nОценки спортсменов:");
//             for (int i = 0; i < athletesCount; i++)
//             {
//                 Console.Write($"Спортсмен {i + 1}: ");
//                 for (int j = 0; j < eventsCount; j++)
//                 {
//                     Console.Write($"{scores[i, j]} ");
//                 }
//                 Console.WriteLine();
//             }
//
//             // Вычисление средних оценок и определение лучшего спортсмена
//             double[] averages = new double[athletesCount];
//             double highestAverage = double.MinValue;
//             int bestAthlete = -1;
//
//             Console.WriteLine("\nСредние оценки спортсменов:");
//             for (int i = 0; i < athletesCount; i++)
//             {
//                 double sum = 0;
//                 for (int j = 0; j < eventsCount; j++)
//                 {
//                     sum += scores[i, j];
//                 }
//
//                 averages[i] = sum / eventsCount;
//                 Console.WriteLine($"Спортсмен {i + 1}: {averages[i]:F2}");
//
//                 if (averages[i] > highestAverage)
//                 {
//                     highestAverage = averages[i];
//                     bestAthlete = i + 1;
//                 }
//             }
//
//             // Вывод спортсмена с наивысшей средней оценкой
//             Console.WriteLine($"\nСпортсмен с наивысшей средней оценкой: {bestAthlete} ({highestAverage:F2})");
//         }
//     }
// }
//


using System;

namespace Ticket07_MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество спортсменов: ");
            int athletesCount = int.Parse(Console.ReadLine());

            Console.Write("Введите количество видов соревнований: ");
            int eventsCount = int.Parse(Console.ReadLine());

            // Создание динамического двумерного массива
            double[,] scores = new double[athletesCount, eventsCount];

            // Заполнение массива вручную
            Console.WriteLine("Введите оценки спортсменов (от 1 до 10) по строкам:");
            for (int i = 0; i < athletesCount; i++)
            {
                Console.WriteLine($"Спортсмен {i + 1}:");
                for (int j = 0; j < eventsCount; j++)
                {
                    Console.Write($"Вид {j + 1}: ");
                    scores[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Вывод оценок спортсменов
            Console.WriteLine("\nОценки спортсменов:");
            for (int i = 0; i < athletesCount; i++)
            {
                Console.Write($"Спортсмен {i + 1}: ");
                for (int j = 0; j < eventsCount; j++)
                {
                    Console.Write($"{scores[i, j]} ");
                }
                Console.WriteLine();
            }

            // Вычисление средних оценок и определение лучшего спортсмена
            double[] averages = new double[athletesCount];
            double highestAverage = double.MinValue;
            int bestAthlete = -1;

            Console.WriteLine("\nСредние оценки спортсменов:");
            for (int i = 0; i < athletesCount; i++)
            {
                double sum = 0;
                for (int j = 0; j < eventsCount; j++)
                {
                    sum += scores[i, j];
                }

                averages[i] = sum / eventsCount;
                Console.WriteLine($"Спортсмен {i + 1}: {averages[i]:F2}");

                if (averages[i] > highestAverage)
                {
                    highestAverage = averages[i];
                    bestAthlete = i + 1;
                }
            }

            // Вывод спортсмена с наивысшей средней оценкой
            Console.WriteLine($"\nСпортсмен с наивысшей средней оценкой: {bestAthlete} ({highestAverage:F2})");
        }
    }
}

