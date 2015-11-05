namespace TraverseDirectories
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var entryPoint = new DirectoryInfo(@"C:\Windows");
            var result = Traverse(entryPoint);
            Console.WriteLine(result);
            
            var fileName = "WindowsTraverseResults.txt";
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

            using (var writer = File.CreateText(path))
            {
                writer.Write(result);
                Console.WriteLine(Environment.NewLine + "The result is also saved on the Desktop as {0}", fileName);
            }
        }

        private static string Traverse(DirectoryInfo directory)
        {
            var output = new StringBuilder();

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
                return string.Empty;
            }

            foreach (var subDir in directory.GetDirectories())
            {
                output.Append(Traverse(subDir));
            }

            return output.ToString();
        }
    }
}
