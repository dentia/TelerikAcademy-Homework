// Define classes File { string name, int size } and
// Folder { string name, File[] files, Folder[]
// childFolders } and using them build a tree keeping
// all files and folders on the hard drive starting from
// C:\WINDOWS. Implement a method that calculates
// the sum of the file sizes in given subtree of the tree
// and test it accordingly. Use recursive DFS traversal.

namespace FilesAndFolders
{
    using System.IO;
    using System.Text;

    class FilesAndFolders
    {
        static void Main()
        {
            // to shorten the time. you can try it with C:\Windows too, but it will take some time
            var entryPoint = new Folder("Help", @"C:\Windows\Help");
            GetSubFolders(entryPoint);
            StringBuilder sb = new StringBuilder();
            GetFileSystemString(entryPoint, sb, 0);
            System.Console.WriteLine(sb);
        }

        private static void GetFileSystemString(Folder folder, StringBuilder sb, int depth)
        {
            string indent = new string('.', depth * 3);

            sb.AppendLine(string.Format("{0}{1} size: {2}", indent, folder.Name, folder.GetSize()));

            foreach (var file in folder.Files)
            {
                sb.AppendLine(string.Format(".{0}-{1} size: {2}", indent, file.Name, file.Size));
            }

            foreach (var subFolder in folder.Folders)
            {
                GetFileSystemString(subFolder, sb, depth + 1);
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
