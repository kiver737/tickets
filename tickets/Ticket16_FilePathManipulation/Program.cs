﻿using System;
using System.IO;

namespace Ticket16_FilePathManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите абсолютный путь к файлу: ");
            string filePath = Console.ReadLine();

            if (!Path.IsPathFullyQualified(filePath))
            {
                Console.WriteLine("Некорректный путь к файлу.");
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

                // Перемещение файла в корневой каталог
                string rootFilePath = Path.Combine(drive, Path.GetFileName(newFilePath));
                Console.WriteLine($"Новый путь к файлу в корневом каталоге: {rootFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}