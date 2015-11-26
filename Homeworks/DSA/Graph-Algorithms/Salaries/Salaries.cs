namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Salaries
    {
        internal static void Main()
        {
            IDictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
            var n = int.Parse(Console.ReadLine());
            var employees = new long[n];

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                adjacencyList[i] = new List<int>();

                for (var j = 0; j < n; j++)
                {
                    if (input[j] == 'Y')
                    {
                        adjacencyList[i].Add(j);
                    }
                }

                if (adjacencyList[i].Count == 0)
                {
                    employees[i] = 1;
                }
            }

            Console.WriteLine(CalculateSalary(employees, adjacencyList));
        }

        private static long CalculateSalary(IList<long> employees, IDictionary<int, List<int>> adjacencyList)
        {
            return employees.Select((t, i) => Calculate(i, employees, adjacencyList)).Sum();
        }

        private static long Calculate(int employeeId, IList<long> employees, IDictionary<int, List<int>> adjacencyList)
        {
            if (employees[employeeId] != 0)
            {
                return employees[employeeId];
            }

            foreach (var employee in adjacencyList[employeeId])
            {
                employees[employeeId] += Calculate(employee, employees, adjacencyList);
            }

            return employees[employeeId];
        }
    }
}
