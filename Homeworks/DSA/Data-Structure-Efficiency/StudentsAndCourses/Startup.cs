namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var coursesAndStudents = new SortedDictionary<string, List<Tuple<string, string>>>();

            using (var reader = new StreamReader("../../students.txt"))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    var info = line.Split('|').Select(x => x.Trim()).ToArray();
                    var course = info[2];
                    var studentFullname = new Tuple<string, string>(info[0], info[1]);

                    if (!coursesAndStudents.ContainsKey(info[2]))
                    {
                        coursesAndStudents.Add(course, new List<Tuple<string, string>> { studentFullname });
                    }
                    else
                    {
                        coursesAndStudents[course].Add(studentFullname);
                    }
                }
            }

            var output = new StringBuilder();

            foreach (var course in coursesAndStudents)
            {
                var courseName = course.Key;
                var students =
                    course.Value.OrderBy(x => x.Item2)
                        .ThenBy(x => x.Item1)
                        .Select(x => string.Format("{0} {1}", x.Item1, x.Item2)).ToArray();

                output.AppendFormat("{0}: {1}", courseName, string.Join(", ", students)).AppendLine();
            }

            Console.WriteLine(output);
        }
    }
}
