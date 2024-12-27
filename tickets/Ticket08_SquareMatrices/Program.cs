using System;
using System.IO;

namespace Ticket08_SquareMatrices
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод размерности квадратной матрицы
            Console.Write("Введите размерность квадратной матрицы (N): ");
            int n = int.Parse(Console.ReadLine());

            // Объявление матриц
            int[,] matrixA = new int[n, n];
            int[,] matrixB = new int[n, n];
            int[,] resultMatrix;

            while (true)
            {
                // Меню выбора действий
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Заполнить матрицы случайными числами");
                Console.WriteLine("2. Заполнить матрицы из файла");
                Console.WriteLine("3. Вывести матрицы на экран");
                Console.WriteLine("4. Сложить матрицы");
                Console.WriteLine("5. Вычесть матрицы");
                Console.WriteLine("6. Сохранить результаты в файл");
                Console.WriteLine("0. Выход");

                // Выбор действия
                Console.Write("Выберите действие: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Заполнение матриц случайными числами
                        Console.Write("Введите минимальное значение: ");
                        int min = int.Parse(Console.ReadLine());
                        Console.Write("Введите максимальное значение: ");
                        int max = int.Parse(Console.ReadLine());
                        FillMatrixRandom(matrixA, n, min, max);
                        FillMatrixRandom(matrixB, n, min, max);
                        Console.WriteLine("Матрицы заполнены случайными числами.");
                        break;
                    case 2:
                        // Загрузка матриц из файла
                        Console.Write("Введите имя файла для загрузки матриц: ");
                        string inputFile = Console.ReadLine();
                        LoadMatricesFromFile(matrixA, matrixB, inputFile, n);
                        Console.WriteLine("Матрицы загружены из файла.");
                        break;
                    case 3:
                        // Вывод матриц на экран
                        Console.WriteLine("Матрица A:");
                        PrintMatrix(matrixA, n);
                        Console.WriteLine("Матрица B:");
                        PrintMatrix(matrixB, n);
                        break;
                    case 4:
                        // Сложение матриц
                        resultMatrix = AddMatrices(matrixA, matrixB, n);
                        Console.WriteLine("Результат сложения матриц:");
                        PrintMatrix(resultMatrix, n);
                        break;
                    case 5:
                        // Вычитание матриц
                        resultMatrix = SubtractMatrices(matrixA, matrixB, n);
                        Console.WriteLine("Результат вычитания матриц:");
                        PrintMatrix(resultMatrix, n);
                        break;
                    case 6:
                        // Сохранение результатов в файл
                        Console.Write("Введите имя файла для сохранения результатов: ");
                        string outputFile = Console.ReadLine();
                        resultMatrix = AddMatrices(matrixA, matrixB, n);
                        SaveMatrixToFile(resultMatrix, outputFile, "Сложение");
                        resultMatrix = SubtractMatrices(matrixA, matrixB, n);
                        SaveMatrixToFile(resultMatrix, outputFile, "Вычитание", append: true);
                        Console.WriteLine("Результаты сохранены в файл.");
                        break;
                    case 0:
                        // Завершение работы программы
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        // Заполнение матрицы случайными числами в указанном диапазоне
        static void FillMatrixRandom(int[,] matrix, int n, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = random.Next(min, max + 1);
                }
            }
        }

        // Вывод матрицы на экран
        static void PrintMatrix(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Сложение двух матриц
        static int[,] AddMatrices(int[,] matrixA, int[,] matrixB, int n)
        {
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return result;
        }

        // Вычитание одной матрицы из другой
        static int[,] SubtractMatrices(int[,] matrixA, int[,] matrixB, int n)
        {
            int[,] result = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = matrixA[i, j] - matrixB[i, j];
                }
            }
            return result;
        }

        // Сохранение матрицы в файл
        static void SaveMatrixToFile(int[,] matrix, string fileName, string operation, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(fileName, append))
            {
                writer.WriteLine($"{operation} матриц:");
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        writer.Write(matrix[i, j] + " ");
                    }
                    writer.WriteLine();
                }
                writer.WriteLine();
            }
        }

        // Загрузка матриц из файла
        static void LoadMatricesFromFile(int[,] matrixA, int[,] matrixB, string fileName, int n)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                for (int i = 0; i < n; i++)
                {
                    string[] lineA = reader.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        matrixA[i, j] = int.Parse(lineA[j]);
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    string[] lineB = reader.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        matrixB[i, j] = int.Parse(lineB[j]);
                    }
                }
            }
        }
    }
}
