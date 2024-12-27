using System;

namespace Ticket10_StudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            const int students = 25;
            const int subjects = 5;

            // Создание и заполнение массива случайными оценками (от 2 до 5)
            int[,] grades = new int[students, subjects];
            Random random = new Random();

            for (int i = 0; i < students; i++)
            {
                for (int j = 0; j < subjects; j++)
                {
                    grades[i, j] = random.Next(2, 6);
                }
            }

            // Вывод таблицы оценок
            Console.WriteLine("\nТаблица оценок студентов:");
            for (int i = 0; i < students; i++)
            {
                Console.Write($"Студент {i + 1}: ");
                for (int j = 0; j < subjects; j++)
                {
                    Console.Write($"{grades[i, j]} ");
                }
                Console.WriteLine();
            }

            // Расчет среднего балла по каждому предмету
            double[] subjectAverages = new double[subjects];
            for (int j = 0; j < subjects; j++)
            {
                int subjectSum = 0;
                for (int i = 0; i < students; i++)
                {
                    subjectSum += grades[i, j];
                }
                subjectAverages[j] = (double)subjectSum / students;
            }

            // Вывод среднего балла по каждому предмету
            Console.WriteLine("\nСредний балл по предметам:");
            for (int j = 0; j < subjects; j++)
            {
                Console.WriteLine($"Предмет {j + 1}: {subjectAverages[j]:F2}");
            }

            // Расчет среднего балла для каждого студента
            double[] studentAverages = new double[students];
            for (int i = 0; i < students; i++)
            {
                int studentSum = 0;
                for (int j = 0; j < subjects; j++)
                {
                    studentSum += grades[i, j];
                }
                studentAverages[i] = (double)studentSum / subjects;
            }

            // Вывод среднего балла для каждого студента
            Console.WriteLine("\nСредний балл студентов:");
            for (int i = 0; i < students; i++)
            {
                Console.WriteLine($"Студент {i + 1}: {studentAverages[i]:F2}");
            }

            // Нахождение максимального и минимального среднего балла по предметам
            double maxSubjectAverage = double.MinValue;
            double minSubjectAverage = double.MaxValue;
            int maxSubjectIndex = -1;
            int minSubjectIndex = -1;

            for (int j = 0; j < subjects; j++)
            {
                if (subjectAverages[j] > maxSubjectAverage)
                {
                    maxSubjectAverage = subjectAverages[j];
                    maxSubjectIndex = j + 1;
                }
                if (subjectAverages[j] < minSubjectAverage)
                {
                    minSubjectAverage = subjectAverages[j];
                    minSubjectIndex = j + 1;
                }
            }

            Console.WriteLine($"\nМаксимальный средний балл по предметам: {maxSubjectAverage:F2} (Предмет {maxSubjectIndex})");
            Console.WriteLine($"Минимальный средний балл по предметам: {minSubjectAverage:F2} (Предмет {minSubjectIndex})");

            // Нахождение максимального и минимального среднего балла среди студентов
            double maxStudentAverage = double.MinValue;
            double minStudentAverage = double.MaxValue;
            int maxStudentIndex = -1;
            int minStudentIndex = -1;

            for (int i = 0; i < students; i++)
            {
                if (studentAverages[i] > maxStudentAverage)
                {
                    maxStudentAverage = studentAverages[i];
                    maxStudentIndex = i + 1;
                }
                if (studentAverages[i] < minStudentAverage)
                {
                    minStudentAverage = studentAverages[i];
                    minStudentIndex = i + 1;
                }
            }

            Console.WriteLine($"\nМаксимальный средний балл среди студентов: {maxStudentAverage:F2} (Студент {maxStudentIndex})");
            Console.WriteLine($"Минимальный средний балл среди студентов: {minStudentAverage:F2} (Студент {minStudentIndex})");
        }
    }
}

