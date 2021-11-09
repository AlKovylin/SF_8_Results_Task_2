using System;
using System.IO;

namespace SF_8_Results_Task_2
{
    class Program
    {
        static long TotalSize = 0;
        static int chD = 0;
        static int chF = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("\tПРОГРАММА ПОДСЧЁТА РАЗМЕРА УКАЗАННОЙ ДИРЕКТОРИИ, \n\t\tВКЛЮЧАЯ ВСЕ ВЛОЖЕНИЯ.\n");
            Console.Write("Введите путь до папки: ");
            string pachFolder = Console.ReadLine();
            //string pachFolder = "C://Users/user/Downloads";

            if (Directory.Exists(pachFolder))
            {
                SearchFiles(pachFolder);
                Console.WriteLine($"\nОбнаружено: {chF} файлов в {chD} папках.");
                Console.WriteLine($"Общий размер: {TotalSize} байт.");                
                Console.WriteLine("\nПрограмма завершена.");
            }
            else
            {
                Console.WriteLine("Папка не существует. Или неверно задан путь.");
            }

        }

        private static void SearchFiles(string folder)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folder);
                DirectoryInfo[] diDir = dirInfo.GetDirectories();
                FileInfo[] diFiles = dirInfo.GetFiles();
                foreach (FileInfo f in diFiles)
                {
                    TotalSize += f.Length;
                    chF++;
                }
                foreach (DirectoryInfo df in diDir)
                {
                    SearchFiles(df.FullName);
                    chD++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
