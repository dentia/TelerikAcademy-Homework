
--4. Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT d.Name, e.FirstName + ' ' + e.LastName as Manager
FROM Departments d, Employees e
WHERE d.ManagerID = e.EmployeeID

--5. Write a SQL query to find all department names.
SELECT Name
FROM Departments

--6. Write a SQL query to find the salary of each employee.
SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees

--7. Write a SQL to find the full name of each employee.
SELECT FirstName + ' ' + LastName AS FullName
FROM Employees

--8. Write a SQL query to find the email addresses of each employee (by his first and last name). 
--Consider that the mail domain is telerik.com. Emails should look like "John.Doe@telerik.com". 
--The produced column should be named "Full Email Addresses".
SELECT FirstName + '.' + LastName + '@telerik.com' AS [Full Email Addresses]
FROM Employees

--9. Write a SQL query to find all different employee salaries.
SELECT DISTINCT Salary
FROM Employees
ORDER BY Salary DESC


--10. Write a SQL query to find all information about the employees whose job title is "Sales Representative"
SELECT e1.FirstName + ' ' + e1.LastName AS FullName, e1.JobTitle, d.Name, 
	e2.FirstName + ' ' + e2.LastName AS Manager, 
	e1.HireDate, e1.Salary, 
	a.AddressText
FROM Employees e1, Employees e2, Addresses a, Departments d
WHERE e1.JobTitle = 'Sales Representative' 
	AND a.AddressID = e1.AddressID 
	AND d.DepartmentID = e1.DepartmentID 
	AND e1.ManagerID = e2.EmployeeID
	
--11. Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE FirstName LIKE 'SA%'

--12. Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE LastName LIKE '%ei%'

--13. Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
ORDER BY Salary DESC

--14. Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
ORDER BY Salary DESC

--15. Write a SQL query to find all employees that do not have manager.
SELECT FirstName + ' ' + LastName AS FullName
FROM Employees
WHERE ManagerID IS NULL

--16. Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

--17. Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5 FirstName + ' ' + LastName AS FullName, Salary
FROM Employees
ORDER BY Salary DESC

--18. Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText
FROM Employees e 
INNER JOIN Addresses a
ON e.AddressID = a.AddressID

--19. Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName + ' ' + e.LastName AS FullName, a.AddressText
FROM Employees e, Addresses a
WHERE e.AddressID = a.AddressID

--20. Write a SQL query to find all employees along with their manager.
SELECT e1.FirstName + ' ' + e1.LastName AS Employee, 
e2.FirstName + ' ' + e2.LastName AS Manager
FROM Employees e1, Employees e2
WHERE e1.ManagerID = e2.EmployeeID

--21. Write a SQL query to find all employees, along with their manager and their address. 
--Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT e.FirstName + ' ' + e.LastName AS Employee, 
m.FirstName + ' ' + m.LastName AS Manager,
a.AddressText
FROM Employees e, Employees m, Addresses a
WHERE e.ManagerID = m.EmployeeID 
	AND e.AddressID = a.AddressID

--22. Write a SQL query to find all departments and all town names as a single list. Use UNION
SELECT Name AS [Town/Department]
FROM Departments 
	UNION 
SELECT Name AS [Town/Department]
FROM Towns

--23. Write a SQL query to find all the employees and the manager for each of them 
--along with the employees that do not have manager. 
--Use right outer join. Rewrite the query to use left outer join.

--left outer join
SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'not responsible enought') AS Employee,
m.FirstName + ' ' + m.LastName AS Manager
FROM Employees e
RIGHT JOIN Employees m
ON e.ManagerID = m.EmployeeID

--right outer join
SELECT e.FirstName + ' ' + e.LastName AS Employee,
ISNULL(m.FirstName + ' ' + m.LastName, 'Unmanageable') AS Manager
FROM Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

--24. Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" 
--whose hire year is between 1995 and 2005.
SELECT e.FirstName + ' ' + e.LastName AS Employee, e.HireDate,
d.Name
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name IN ('Sales', 'Finance')
AND e.HireDate BETWEEN '1995-01-01 00:00:00' AND '2005-12-31 00:00:00'
