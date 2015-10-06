namespace TraverseDirectory
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            using (XmlTextWriter writer = new XmlTextWriter("../../dir.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                
                writer.WriteStartDocument();
                writer.WriteStartElement("Desktop");
                Traverse(desktopPath, writer);
                writer.WriteEndDocument();
            }
            
            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "dir.xml");
        }

        static void Traverse(string dir, XmlTextWriter writer)
        {
            foreach (var directory in Directory.GetDirectories(dir))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", directory);
                Traverse(directory, writer);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileNameWithoutExtension(file));
                writer.WriteAttributeString("ext", Path.GetExtension(file));
                writer.WriteEndElement();
            }
        }
    }
}
