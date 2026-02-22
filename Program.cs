using System;
using System.IO;
using Mono.Cecil;

namespace AsciiInjector
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("use drag & drop");
                Console.ReadKey();
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath)) return;

            try
            {
                string title = "protect by quantum";

                string padding = new string(' ', 150);

                string link = "// https://t.me/productDuckDuck";

                string[] artLines = new string[]
                {
                    "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                    "⠀⠀⠀⠀⣠⣤⣶⣶⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣶⣶⣶⣤⣄⠀⠀⠀⠀",
                    "⠀⠀⠀⣼⣿⣿⣿⣿⣿⣿⡿⢂⣠⣤⣤⣤⣤⣄⡐⢿⣿⣿⣿⣿⣿⣿⣷⠀⠀⠀",
                    "⠀⠀⢸⣿⡏⠉⢻⣿⠋⢉⣴⣿⣿⣿⣿⣿⣿⣿⣿⣦⡉⠙⣿⡟⠉⢙⣿⡇⠀⠀",
                    "⠀⠀⢸⣿⣷⣶⣿⣿⠃⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠘⣿⣿⣶⣾⣿⡇⠀⠀",
                    "⠀⠀⢸⣿⣿⣿⣿⣿⠀⣿⣿⠁⠀⠘⣿⣿⠃⠀⠈⣿⣿⠆⣿⣿⣿⣿⣿⡇⠀⠀",
                    "⠀⠀⣸⣿⣿⣿⣿⣿⠀⣿⣿⣦⣤⣴⣿⣿⣶⣤⣴⣿⣿⠀⣿⣿⣿⣿⣿⣇⠀⠀",
                    "⠀⢀⣿⡿⣿⣿⢿⣿⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡄⣿⡿⣿⣿⢿⣿⡀⠀",
                    "⠀⠈⠁⠀⠈⠁⠈⠉⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠉⠁⠈⠁⠀⠈⠁⠀",
                    "⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀",
                    "⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀",
                    "⠀⠀⠀⠀⠀⠀⠀⠘⠛⠋⠘⠿⠟⠉⠿⠿⠉⠻⠿⠃⠙⠛⠃⠀⠀⠀⠀⠀⠀⠀",
                    "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
                    "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"
                };

                string art = string.Join("\r\n", artLines);

                string finalWatermark = title + padding + "\r\n" + link + "\r\n\r\n" + art;

                var assembly = AssemblyDefinition.ReadAssembly(filePath, new ReaderParameters { ReadWrite = true });
                var module = assembly.MainModule;

                module.Name = finalWatermark;

                string outputFileName = $"{Path.GetFileNameWithoutExtension(filePath)}.saves{Path.GetExtension(filePath)}";
                string outputPath = Path.Combine(Path.GetDirectoryName(filePath), outputFileName);

                assembly.Write(outputPath);

                Console.WriteLine($"saved as: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
