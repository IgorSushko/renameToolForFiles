using System;
using System.IO;
using System.Text.RegularExpressions;

namespace renameFiles
{
    class Program
    {

        static void Main(string[] args)
        {
            string targetPath;
            string patternToFind;
            string patternToReplace;

            Console.WriteLine("Replace filename and file content tool");
            Console.WriteLine("Put target path: ");
            targetPath = Console.ReadLine();
            
            while (!Directory.Exists(targetPath))
            {
                Console.WriteLine("Path {0} is not correct!",targetPath);
                targetPath = Console.ReadLine();
            }

            Console.WriteLine("Put pattern that should be replaced");
            patternToFind = Console.ReadLine();
            Console.WriteLine("Put pattern for new value");
            patternToReplace = Console.ReadLine();
            Console.WriteLine("**************************************");
            DirectoryInfo d = new DirectoryInfo(targetPath);
            FileInfo[] infos = d.GetFiles();
            foreach (FileInfo f in infos)
            {
                Console.WriteLine("File in progress: {0}", f);
                string content = File.ReadAllText(f.ToString());
                content = content.Replace(patternToFind, patternToReplace);
                File.WriteAllText(f.ToString(), content);
                Console.WriteLine("Were {0} changes in file content", Regex.Matches(content, Regex.Escape(patternToReplace)).Count);
                File.Move(f.FullName, f.FullName.Replace(patternToFind, patternToReplace));
                
            }

            Console.WriteLine("The task is done");
        }
    }
}
