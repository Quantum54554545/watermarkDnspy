using System;
using System.IO;
using System.Text;
using Mono.Cecil;

namespace AsciiInjector
{
    class Program
    {
        private const string WatermarkText = @"// protect by quantum
// https://t.me/productDuckDuck\n

                   __ooooooooo__
              oOOOOOOOOOOOOOOOOOOOOOo
          oOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo
       oOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo
     oOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo
   oOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo
  oOOOOOOOOOOO*  *OOOOOOOOOOOOOO*  *OOOOOOOOOOOOo
 oOOOOOOOOOOO      OOOOOOOOOOOO      OOOOOOOOOOOOo
 oOOOOOOOOOOOOo  oOOOOOOOOOOOOOOo  oOOOOOOOOOOOOOo
oOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo
oOOOO     OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO     OOOOo
oOOOOOO OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO OOOOOOo
 *OOOOO  OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO  OOOOO*
 *OOOOOO  *OOOOOOOOOOOOOOOOOOOOOOOOOOOOO*  OOOOOO*
  *OOOOOO  *OOOOOOOOOOOOOOOOOOOOOOOOOOO*  OOOOOO*
   *OOOOOOo  *OOOOOOOOOOOOOOOOOOOOOOO*  oOOOOOO*
     *OOOOOOOo  *OOOOOOOOOOOOOOOOO*  oOOOOOOO*
       *OOOOOOOOo  *OOOOOOOOOOO*  oOOOOOOOO*      
          *OOOOOOOOo           oOOOOOOOO*      
              *OOOOOOOOOOOOOOOOOOOOO*          
                   ooooooooo
";

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("use drag & drop");
                Console.ReadKey();
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                var assembly = AssemblyDefinition.ReadAssembly(filePath, new ReaderParameters { ReadWrite = true });
                var module = assembly.MainModule;
                module.Name = WatermarkText;              
                string outputFileName = $"{Path.GetFileNameWithoutExtension(filePath)}.saves{Path.GetExtension(filePath)}";
                string outputPath = Path.Combine(Path.GetDirectoryName(filePath), outputFileName);

                assembly.Write(outputPath);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{outputPath}");
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
