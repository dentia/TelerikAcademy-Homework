// Write a program to traverse the directory
// C:\WINDOWS and all its subdirectories recursively and
// to display all files matching the mask *.exe.

namespace TraverseDirectories
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    class TraverseDirectories
    {
        static void Main()
        {
            var entryPoint = new DirectoryInfo(@"C:\Windows");
            StringBuilder result = new StringBuilder();
            Traverse(entryPoint, result);
            Console.WriteLine(result);
        }

        private static void Traverse(DirectoryInfo directory, StringBuilder output)
        {
            try
            {
                var exes = directory.GetFiles().Where(file => file.Extension == ".exe");
                foreach (var file in exes)
                {
                    output.AppendLine(file.Name);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot access {0}", directory.FullName);
                return;
            }

            foreach (var subDir in directory.GetDirectories())
            {
                Traverse(subDir, output);
            }
        }
    }
}
