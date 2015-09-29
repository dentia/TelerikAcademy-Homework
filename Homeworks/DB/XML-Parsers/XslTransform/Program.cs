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
            xslt.Transform("../../catalogue.xml", "../../catalogue.html");
            Console.WriteLine("result saved as catalogue.html");
        }
    }
}
