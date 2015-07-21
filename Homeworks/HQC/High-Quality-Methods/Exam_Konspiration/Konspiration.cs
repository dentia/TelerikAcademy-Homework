namespace Exam_Konspiration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using Microsoft.CSharp;

    internal class Konspiration
    {
        internal static void Main()
        {
            StringBuilder input = GetInput();
            
            string code = input.ToString();
            code = RemoveObjectInitialization(code);
            code = RemoveStrings(code);

            string[] methods = Regex.Split(code, @"\bstatic\b").ToArray();

            Regex validMethod = new Regex(@"\b[_A-Za-z\@][A-Za-z_0-9]*\s*\(");
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();

            List<string> invokes = new List<string>();
            StringBuilder result = new StringBuilder();

            foreach (var method in methods)
            {
                foreach (Match match in validMethod.Matches(method))
                {
                    string identifier = match.ToString().Trim('(').Trim();

                    if (codeProvider.IsValidIdentifier(identifier))
                    {
                        invokes.Add(identifier);
                    }
                }

                AppendToResult(invokes, result);
                invokes.Clear();
            }

            Console.WriteLine(result.ToString());
        }

        private static void AppendToResult(List<string> invokes, StringBuilder result)
        {
            if (invokes.Count == 1)
            {
                result.AppendLine(string.Format("{0} -> None", invokes[0]));
            }
            else if (invokes.Count > 0)
            {
                result.AppendLine(string.Format("{0} -> {1} -> {2}", invokes[0], invokes.Count - 1, string.Join(", ", invokes.Skip(1))));
            }
        }

        private static string RemoveStrings(string code)
        {
            while (code.Contains("\\\""))
            {
                code = code.Replace("\\\"", string.Empty);
            }

            while (code.Contains("\"\""))
            {
                code = code.Replace("\"\"", string.Empty);
            }

            code = Regex.Replace(code, "\".*?\"", string.Empty);
            return code;
        }

        private static string RemoveObjectInitialization(string code)
        {
            code = Regex.Replace(code, @"\s+", " ");
            code = Regex.Replace(code, @"new\s[\w]+", "#");
            return code;
        }

        private static StringBuilder GetInput()
        {
            StringBuilder input = new StringBuilder();
            int lines = int.Parse(Console.ReadLine());
            for (int line = 0; line < lines; line++)
            {
                input.Append(Console.ReadLine().Trim());
            }

            return input;
        }
    }
}