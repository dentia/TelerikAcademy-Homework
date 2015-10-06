using System.IO;

namespace XslTransform
{
    using System;
    using System.Xml.Xsl;

    class Program
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../style.xslt");
            xslt.Transform("../../../catalogue.xml", "../../catalogue.html");

            var currentDir = Directory.GetCurrentDirectory();
            var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
            Console.WriteLine("result saved as " + savedDir + "catalogue.html");
        }
    }
}
