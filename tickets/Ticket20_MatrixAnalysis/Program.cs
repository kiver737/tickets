using System;

namespace Ticket20_MatrixAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            const int size = 10;
            int[,] matrix = new int[size, size];
            Random random = new Random();

            // Заполнение матрицы случайными числами и вывод
            Console.WriteLine("Матрица:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = random.Next(0, 21); // Диапазон [0..20]
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Нахождение максимального элемента
            int maxElement = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
            Console.WriteLine($"\nНаибольший элемент: {maxElement} находится на пересечении строки {maxRow + 1} и столбца {maxCol + 1}");

            // Вычисление среднего арифметического для строк
            Console.WriteLine("\nСреднее арифметическое для каждой строки:");
            for (int i = 0; i < size; i++)
            {
                double rowSum = 0;
                for (int j = 0; j < size; j++)
                {
                    rowSum += matrix[i, j];
                }
                Console.WriteLine($"Строка {i + 1}: {rowSum / size:F2}");
            }

            // Вычисление среднего арифметического для столбцов
            Console.WriteLine("\nСреднее арифметическое для каждого столбца:");
            for (int j = 0; j < size; j++)
            {
                double colSum = 0;
                for (int i = 0; i < size; i++)
                {
                    colSum += matrix[i, j];
                }
                Console.WriteLine($"Столбец {j + 1}: {colSum / size:F2}");
            }

            // Изменение четных элементов главной диагонали на 0
            Console.WriteLine("\nМатрица после изменения четных элементов главной диагонали на 0:");
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, i] % 2 == 0)
                {
                    matrix[i, i] = 0;
                }
            }

            // Вывод измененной матрицы
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

