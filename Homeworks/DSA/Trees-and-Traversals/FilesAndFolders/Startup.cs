namespace FilesAndFolders
{
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            // using the Help folder to shorten the time. 
            // you can try it with C:\Windows too, but it will take some time
            var entryPoint = new Folder("Help", @"C:\Windows\Help");
            GetSubFolders(entryPoint);
            StringBuilder result = new StringBuilder();
            GetFileSystemString(entryPoint, result, 0);
            Console.WriteLine(result);
        }

        private static void GetFileSystemString(Folder folder, StringBuilder result, int depth)
        {
            string indent = new string('.', depth * 3);

            result.AppendLine(string.Format("{0}{1} size: {2}", indent, folder.Name, folder.GetSize()));

            foreach (var file in folder.Files)
            {
                result.AppendLine(string.Format(".{0}-{1} size: {2}", indent, file.Name, file.Size));
            }

            foreach (var subFolder in folder.Folders)
            {
                GetFileSystemString(subFolder, result, depth + 1);
            }
        }

        private static void GetSubFolders(Folder folder)
        {
            foreach (var file in folder.Directory.GetFiles())
            {
                folder.Files.Add(new File(file.Name, file.Length));
            }

            foreach (var subDir in folder.Directory.GetDirectories())
            {
                var subFolder = new Folder(subDir.Name, subDir.FullName);
                folder.Folders.Add(subFolder);
                GetSubFolders(subFolder);
            }
        }
    }
}
