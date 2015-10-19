---Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--Use a nested SELECT statement.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)


--Write a SQL query to find the names and salaries of the employees that have a salary 
---that is up to 10% higher than the minimal salary for the company.
SELECT FirstName, LastName, Salary
FROM Employees
WHERE Salary < (SELECT MIN(Salary) * 1.1 FROM Employees)


---Write a SQL query to find the full name, salary and department of the 
---employees that take the minimal salary in their department.
---Use a nested SELECT statement.
SELECT e.FirstName + ' ' + e.LastName AS FullName, d.Name, e.Salary
FROM Employees e, Departments d
WHERE Salary = (SELECT MIN(Salary) FROM Employees s
   WHERE s.DepartmentID = d.DepartmentID)
ORDER BY d.DepartmentID


---Write a SQL query to find the average salary in the department #1.
SELECT AVG(Salary) AS AverageSalary
FROM Employees
WHERE DepartmentID = 1


---Write a SQL query to find the average salary in the "Sales" department.
SELECT AVG(e.Salary) AS AverageSalary
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'


---Write a SQL query to find the number of employees in the "Sales" department.
SELECT COUNT(e.FirstName) AS SalesEmployeesCount
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'

---Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.FirstName)
FROM Employees e
WHERE EXISTS (SELECT EmployeeID
   FROM Employees m
   WHERE m.EmployeeID = e.ManagerID)


---Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.FirstName)
FROM Employees e
WHERE e.ManagerID IS NULL


---Write a SQL query to find all departments and the average salary for each of them.
SELECT ROUND(AVG(e.Salary), 2) AS AverageSalary, d.Name AS Department
FROM Employees e, Departments d
WHERE  e.DepartmentID = d.DepartmentID
GROUP BY  d.Name
ORDER BY AverageSalary


---Write a SQL query to find the count of all employees in each department and for each town.
SELECT COUNT(e.LastName) AS EmployeesCount, d.Name AS Department, t.Name AS Town
FROM Employees e, Departments d, Towns t, Addresses a
WHERE  e.DepartmentID = d.DepartmentID
	AND e.AddressID = a.AddressID
	AND a.TownID = t.TownID
GROUP BY   t.Name, d.Name


---Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName, m.LastName
FROM Employees m, Employees e
WHERE e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(*) = 5


---Write a SQL query to find all employees along with their managers. 
---For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName, e.LastName, ISNULL(m.FirstName + ' ' + m.LastName, ('(no manager)')) AS Manager
FROM Employees e
LEFT OUTER JOIN Employees m
ON e.ManagerID = m.EmployeeID


---Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. 
---Use the built-in LEN(str) function.
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5
ORDER BY LastName


---Write a SQL query to display the current date and time in the following format 
---"day.month.year hour:minutes:seconds:milliseconds".
---Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(VARCHAR, GETDATE(), 104) + ' ' + CONVERT(VARCHAR, GETDATE(), 114) AS DateTime


---Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
------Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
------Define the primary key column as identity to facilitate inserting records.
------Define unique constraint to avoid repeating usernames.
------Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
	[Username] VARCHAR(50) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[FullName] NVARCHAR(150) NOT NULL,
	[LastLogin] DATETIME NOT NULL,
	CONSTRAINT [Password] CHECK (LEN(Password) >= 5)
)
GO


---Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
---Test if the view works correctly.
CREATE VIEW [Visitors Today] AS 
SELECT Username 
FROM Users 
WHERE CONVERT(date, LastLogin) = CONVERT(DATE, GETDATE())
GO

---Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
---Define primary key and identity column.
CREATE TABLE Groups
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
	[Name] VARCHAR(50) NOT NULL UNIQUE,
)
GO


---Write a SQL statement to add a column GroupID to the table Users.
---Fill some data in this new column and as well in the `Groups table.
---Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.
---FIRST:
ALTER TABLE Users
ADD GroupId INT
GO

---THEN:
ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups
FOREIGN KEY (GroupId)
REFERENCES Groups(Id)
GO

---Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups
VALUES 
(1),
(2),
(3)
GO

INSERT INTO Users
values 
('JohnD', 'johny_bravo', 'John Doe', GetDate(), 1),
('JaneD', 'janeIsInsane', 'Jane Doe', GetDate(), 2),
('JimmyD', 'hendrix4Life', 'Jimmy Doe', GetDate(), 3)
GO


---Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users 
SET [Password] = 'JaneIsNOTInsane'
WHERE Username = 'JaneD'
GO


---Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE Users 
WHERE Username = 'JaneD'
GO


---Write SQL statements to insert in the Users table the names of all employees from the Employees table.
------Combine the first and last names as a full name.
------For username use the first letter of the first name + the last name (in lowercase).
------Use the same for the password, and NULL for last login time.
INSERT INTO  Users
([FullName], [Username], [Password], [LastLogin])
SELECT e.FirstName + e.LastName, 
e.FirstName + LEFT(e.LastName, 1) + CONVERT(VARCHAR, e.HireDate), 
e.LastName + 'DB4Evaaaa',
GETDATE()
FROM Employees e
GO


---Write a SQL statement that changes the password to NULL for 
---all users that have not been in the system since 10.03.2010.
ALTER TABLE Users
ALTER COLUMN [Password] NVARCHAR(50) NULL
GO
---This is needed because the column was not nullable.
UPDATE Users
SET [Password] = NULL
WHERE DATEDIFF(DAY, LastLogin, '03.10.2010 00:00:00:000') > 0
GO


---Write a SQL statement that deletes all users without passwords (NULL password).
DELETE Users
WHERE [Password] IS NULL
GO


---Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(e.Salary) AS AverageSalary, d.Name AS Department, e.JobTitle
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle
ORDER BY d.Name, e.JobTitle


---Write a SQL query to display the minimal employee salary by department and job title 
---along with the name of some of the employees that take it.
SELECT e.FirstName, e.LastName, MIN(e.Salary) AS MinimalSalary, d.Name AS Department, e.JobTitle
FROM Employees e
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName
ORDER BY d.Name, e.JobTitle


---Write a SQL query to display the town where maximal number of employees work.
SELECT TOP 1 t.Name AS Town, COUNT(*) AS EmployeesCount
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY EmployeesCount DESC


---Write a SQL query to display the number of managers from each town.
SELECT t.Name AS Town, COUNT(DISTINCT e.ManagerID) AS ManagersCount
FROM Employees e
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON a.TownID = t.TownID
GROUP BY t.Name
ORDER BY ManagersCount DESC


---Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
------Don't forget to define identity, primary key and appropriate foreign key.
------Issue few SQL statements to insert, update and delete of some data in the table.
------Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
---------For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TABLE WorkHours
(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[Date] DATETIME,
	[Task] NVARCHAR(50),
	[Hours] INT,
	[Comments] VARCHAR(250),
	CONSTRAINT FK_WorkHours_Employees 
		FOREIGN KEY (EmployeeId) 
		REFERENCES Employees(EmployeeID)
)
GO

INSERT INTO WorkHours
VALUES (1, GETDATE(), 'Task1', 10, NULL),
	   (2, GETDATE(), 'Task2', 9, NULL),
	   (3, GETDATE(), 'Task3', 8, 'TODO')
GO

UPDATE WorkHours
SET [Comments] = 'Did bad work'
WHERE [EmployeeId] = 1
GO

DELETE FROM WorkHours
WHERE [Hours] = 9
GO

CREATE TABLE ReportsLogs(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[Date] DATETIME,
	[Task] NVARCHAR(50),
	[Hours] INT,
	[Comments] VARCHAR(250),
	[For] VARCHAR(50)
)
GO

CREATE TRIGGER trg_WorkHours_Insert ON WorkHours
FOR INSERT 
AS
INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
    SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'INSERT'
    FROM INSERTED
GO

CREATE TRIGGER trg_WorkHours_Delete ON WorkHours
FOR DELETE 
AS
INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
    SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'DELETE'
    FROM DELETED
GO

CREATE TRIGGER trg_WorkHours_Update ON WorkHours
FOR UPDATE 
AS
INSERT INTO ReportsLogs([EmployeeId], [Date], [Task], [Hours], [Comments], [For])
    SELECT [EmployeeId], [Date], [Task], [Hours], [Comments], 'UPDATE'
    FROM INSERTED
GO

INSERT INTO WorkHours
VALUES(2, GETDATE(), 'Task2', 9, NULL)
GO

DELETE FROM  WorkHours 
WHERE [Hours] = 9
GO

UPDATE WorkHours
SET Comments = 'Done'
WHERE Comments = 'TODO'


---Start a database transaction, delete all employees from the 'Sales' 
---department along with all dependent records from the pother tables.
---At the end rollback the transaction.
BEGIN TRAN
	ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE WorkHours
	DROP CONSTRAINT FK_WorkHours_Employees

	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT FK_EmployeesProjects_Employees

	DELETE FROM Employees
	SELECT d.Name
	FROM Employees e
		JOIN Departments d
			ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	GROUP BY d.Name
ROLLBACK TRAN


---Start a database transaction and drop the table EmployeesProjects.
---Now how you could restore back the lost table data?
USE TelerikAcademy

BEGIN TRAN
	DROP TABLE EmployeesProjects
ROLLBACK TRAN


---Find how to use temporary tables in SQL Server.
---Using temporary tables backup all records from EmployeesProjects and restore them back 
---after dropping and re-creating the table.
USE TelerikAcademy

BEGIN TRAN
SELECT *  INTO  #TempEmployeesProjects
FROM EmployeesProjects

DROP TABLE EmployeesProjects

SELECT * INTO EmployeesPRojects
FROM #TempEmployeesProjects

ROLLBACK TRAN