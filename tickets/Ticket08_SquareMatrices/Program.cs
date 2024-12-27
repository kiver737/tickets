using System;
using System.IO;

namespace Ticket08_SquareMatrices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность квадратной матрицы (N): ");
            int n = int.Parse(Console.ReadLine());

            int[,] matrixA = new int[n, n];
            int[,] matrixB = new int[n, n];
            int[,] resultMatrix;

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Заполнить матрицы случайными числами");
                Console.WriteLine("2. Заполнить матрицы из файла");
                Console.WriteLine("3. Вывести матрицы на экран");
                Console.WriteLine("4. Сложить матрицы");
                Console.WriteLine("5. Вычесть матрицы");
                Console.WriteLine("6. Сохранить результаты в файл");
                Console.WriteLine("0. Выход");

                Console.Write("Выберите действие: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите минимальное значение: ");
                        int min = int.Parse(Console.ReadLine());
                        Console.Write("Введите максимальное значение: ");
                        int max = int.Parse(Console.ReadLine());
                        FillMatrixRandom(matrixA, n, min, max);
                        FillMatrixRandom(matrixB, n, min, max);
                        Console.WriteLine("Матрицы заполнены случайными числами.");
                        break;
                    case 2:
                        Console.Write("Введите имя файла для загрузки матриц: ");
                        string inputFile = Console.ReadLine();
                        LoadMatricesFromFile(matrixA, matrixB, inputFile, n);
                        Console.WriteLine("Матрицы загружены из файла.");
                        break;
                    case 3:
                        Console.WriteLine("Матрица A:");
                        PrintMatrix(matrixA, n);
                        Console.WriteLine("Матрица B:");
                        PrintMatrix(matrixB, n);
                        break;
                    case 4:
                        resultMatrix = AddMatrices(matrixA, matrixB, n);
                        Console.WriteLine("Результат сложения матриц:");
                        PrintMatrix(resultMatrix, n);
                        break;
                    case 5:
                        resultMatrix = SubtractMatrices(matrixA, matrixB, n);
                        Console.WriteLine("Результат вычитания матриц:");
                        PrintMatrix(resultMatrix, n);
                        break;
                    case 6:
                        Console.Write("Введите имя файла для сохранения результатов: ");
                        string outputFile = Console.ReadLine();
                        resultMatrix = AddMatrices(matrixA, matrixB, n);
                        SaveMatrixToFile(resultMatrix, outputFile, "Сложение");
                        resultMatrix = SubtractMatrices(matrixA, matrixB, n);
                        SaveMatrixToFile(resultMatrix, outputFile, "Вычитание", append: true);
                        Console.WriteLine("Результаты сохранены в файл.");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

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

