// using System;
//
// namespace Ticket19_MatrixFormation
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Выберите действие:");
//             Console.WriteLine("1. Сформировать массив B из массива A");
//             Console.WriteLine("2. Отзеркалить массив B");
//             int choice = int.Parse(Console.ReadLine());
//
//             const int size = 21; // Размер исходного массива A
//             int[] arrayA = new int[size];
//
//             // Заполнение массива A случайными числами
//             Random random = new Random();
//             for (int i = 0; i < size; i++)
//             {
//                 arrayA[i] = random.Next(1, 100); // Значения от 1 до 99
//             }
//
//             Console.WriteLine("Исходный массив A:");
//             PrintArray(arrayA);
//
//             // Формирование массива B
//             int[,] matrixB = new int[6, 6]; // Размерность массива B 6x6
//             FillMatrixB(arrayA, matrixB);
//
//             switch (choice)
//             {
//                 case 1:
//                     Console.WriteLine("\nСформированный массив B:");
//                     PrintMatrix(matrixB);
//                     break;
//                 case 2:
//                     Console.WriteLine("\nОтзеркаленный массив B:");
//                     MirrorMatrix(matrixB);
//                     PrintMatrix(matrixB);
//                     break;
//                 default:
//                     Console.WriteLine("Некорректный выбор.");
//                     break;
//             }
//         }
//
//         static void FillMatrixB(int[] arrayA, int[,] matrixB)
//         {
//             int index = 0;
//             for (int i = 0; i < matrixB.GetLength(0); i++)
//             {
//                 for (int j = 0; j < matrixB.GetLength(1); j++)
//                 {
//                     if (i >= j && index < arrayA.Length)
//                     {
//                         matrixB[i, j] = arrayA[index++];
//                     }
//                     else
//                     {
//                         matrixB[i, j] = 0; // Остальные элементы заполняем нулями
//                     }
//                 }
//             }
//         }
//
//         static void MirrorMatrix(int[,] matrixB)
//         {
//             int rows = matrixB.GetLength(0);
//             int cols = matrixB.GetLength(1);
//
//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < cols / 2; j++)
//                 {
//                     // Меняем местами элементы
//                     int temp = matrixB[i, j];
//                     matrixB[i, j] = matrixB[i, cols - j - 1];
//                     matrixB[i, cols - j - 1] = temp;
//                 }
//             }
//         }
//
//         static void PrintArray(int[] array)
//         {
//             foreach (var item in array)
//             {
//                 Console.Write(item + " ");
//             }
//             Console.WriteLine();
//         }
//
//         static void PrintMatrix(int[,] matrix)
//         {
//             for (int i = 0; i < matrix.GetLength(0); i++)
//             {
//                 for (int j = 0; j < matrix.GetLength(1); j++)
//                 {
//                     Console.Write(matrix[i, j] + "\t");
//                 }
//                 Console.WriteLine();
//             }
//         }
//     }
// }



using System;

namespace Ticket19_MatrixFormation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Сформировать массив B из массива A");
            Console.WriteLine("2. Отзеркалить массив B");
            int choice = int.Parse(Console.ReadLine());

            const int size = 21; // Размер исходного массива A
            int[] arrayA = new int[size];

            // Заполнение массива A вручную
            Console.WriteLine("Введите 21 элемент массива A через пробел:");
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < size; i++)
            {
                arrayA[i] = int.Parse(input[i]);
            }

            Console.WriteLine("Исходный массив A:");
            PrintArray(arrayA);

            // Формирование массива B
            int[,] matrixB = new int[6, 6]; // Размерность массива B 6x6
            FillMatrixB(arrayA, matrixB);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nСформированный массив B:");
                    PrintMatrix(matrixB);
                    break;
                case 2:
                    Console.WriteLine("\nОтзеркаленный массив B:");
                    MirrorMatrix(matrixB);
                    PrintMatrix(matrixB);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }

        static void FillMatrixB(int[] arrayA, int[,] matrixB)
        {
            int index = 0;
            for (int i = 0; i < matrixB.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    if (i >= j && index < arrayA.Length)
                    {
                        matrixB[i, j] = arrayA[index++];
                    }
                    else
                    {
                        matrixB[i, j] = 0; // Остальные элементы заполняем нулями
                    }
                }
            }
        }

        static void MirrorMatrix(int[,] matrixB)
        {
            int rows = matrixB.GetLength(0);
            int cols = matrixB.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols / 2; j++)
                {
                    // Меняем местами элементы
                    int temp = matrixB[i, j];
                    matrixB[i, j] = matrixB[i, cols - j - 1];
                    matrixB[i, cols - j - 1] = temp;
                }
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}