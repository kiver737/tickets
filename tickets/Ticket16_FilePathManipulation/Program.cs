using System;
using System.IO;

namespace Ticket16_FilePathManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите абсолютный путь к файлу: ");
            string filePath = Console.ReadLine();

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            try
            {
                // Разделение пути на компоненты
                string drive = Path.GetPathRoot(filePath); // Название дисковода
                string directory = Path.GetDirectoryName(filePath); // Путь всех папок
                string fileName = Path.GetFileNameWithoutExtension(filePath); // Название файла
                string extension = Path.GetExtension(filePath); // Расширение файла

                Console.WriteLine("\nИнформация о пути к файлу:");
                Console.WriteLine($"Дисковод: {drive}");
                Console.WriteLine($"Путь папок: {directory}");
                Console.WriteLine($"Название файла: {fileName}");
                Console.WriteLine($"Расширение файла: {extension}");

                // Замена расширения файла
                Console.Write("Введите новое расширение файла (например, .txt): ");
                string newExtension = Console.ReadLine();
                string newFilePath = Path.ChangeExtension(filePath, newExtension);

                Console.WriteLine($"\nНовый путь к файлу: {newFilePath}");

                // Перемещение файла в доступный каталог (например, Documents)
                string rootFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(newFilePath));
                File.Copy(filePath, rootFilePath, overwrite: true);

                Console.WriteLine($"Новый путь к файлу в каталоге Documents: {rootFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
