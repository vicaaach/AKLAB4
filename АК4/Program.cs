using System;
using System.IO;

namespace SubdirectoryCount
{
    class Program
    {
        static int CountSubdirectories(string directoryPath)
        {
            int count = 0;
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    string[] subdirectories = Directory.GetDirectories(directoryPath);
                    count = subdirectories.Length;

                    foreach (string subdirectory in subdirectories)
                    {
                        count += CountSubdirectories(subdirectory);
                    }
                }
                else
                {
                    Console.WriteLine("Directory does not exist.");
                }
            }
            catch (Exception ex)
            {
                // Обробка винятків при доступі до директорій
                Console.WriteLine("Error: " + ex.Message);
            }

            return count;
        }

        static void Main(string[] args)
        {
            string directoryPath;
            bool isValidDirectory = false;

            do
            {
                Console.Write("Enter the directory path: ");
                directoryPath = Console.ReadLine();

                if (Directory.Exists(directoryPath))
                {
                    isValidDirectory = true;
                }
                else
                {
                    Console.WriteLine("Invalid directory path. Please try again.");
                }
            } while (!isValidDirectory);

            int subdirectoryCount = CountSubdirectories(directoryPath);
            Console.WriteLine("Count of subdirectories: " + subdirectoryCount);

            Console.ReadLine();
        }
    }
}