### Inner Join
- A join combines columns from two or more tables into a result set
- For an inner join, only those rows that satisfy the join condition are included in the result set
- A join condition names a column in each of the two tales involved in the join and indicates how the two columns should be compared. In most cases, you use the equal operator to retrieve rows with matching columns. However, you can also use any of the other comparison operators in a join condition.
- In most cases, you'll join two tables based on the relationship between the primary key in one table and a foreign key in the other table. 
- If the two columns in a join condition have the same name, you have to qualify them with the table name so that SQL Server can distinguish between them.
- Essentially, combines both lists, but only keeps rows where there's a match in both lists

**Example**
- Table 1
	- Customer ID
	- Name
- Table 2
	- Order ID
	- Customer ID
	- Item

`SELECT Customers.name, Orders.Item`
`FROM Customers`
`INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID`

- This creates a new table with the the data from both tables, but only where there's a match.
- JOIN can include two or more conditions connected by AND or OR operators



### Table Aliases
- A table alias is essentially a temporary name for a table used in an SQL Statement
- Table aliases are temporary table names assigned in the FROM clause. They make your queries shorter and easier to read
- When you code a table alias, you can use the AS keyword like you do for a column. It's a common practice not to do that though.
- If you assign an alias to a table, you must use that name.

**SYNTAX**
```
SELECT select_list
FROM table_1 [AS] n1
	[INNER] JOIN table_2 [AS] n2
		ON n1.column_name operator n2.column_name
	[INNER] JOIN table_3 [AS] n3
		ON n2.column_name operator n3.column_name
```



### Tables from Different Databases
- You use dots to indicate source
- The syntax for a fully-qualified object name is database.schema.object
- A fully qualified object name is made up of three parts: the database name, the schema name (typically dbo), and the name of the object (typically a table).
- If the server or database name is the same as the current server or database name, or if the schema is dbo or the name of the user's default schema, you can omit that part of the name to create a partially qualified object name. If the omitted name falls between two other parts of the name, code two periods to indicate that the name is omitted. 

```
SELECT VendorName, CustListName, CustFirstName, VendorState AS State, VendorCity AS City
FROM AP.dbo.Vendors v
	JOIN ProductOrders.dbo.Customers c
		ON v.VendorZipCode = c.CustZip
ORDER BY State, City;
```



### How to Use a Self Join
- A self join joins a table within itself
- When you code a self-join, you must use aliases for the tables, and you must qualify each column name with the table alias
- Self-joins frequently include the DISTINCT keyword to eliminate duplicate rows



### Implicit Inner Join Syntax
- This syntax uses the join condition in the WHERE clause
- Explicit syntax is the best practice

```
SELECT select_list
FROM table_1, table_2, ...
WHERE table_1.column_name operator table_2.column_name
	AND ... ;
```



### Outer Joins
- Unlike an inner join, an outer join returns all of the rows from one or both tables, regardless of whether the join condition is true.
- An outer join retrieves all rows that satisfy the join condition, plus unmatched rows in one or both tables
- In most cases, you use the equal operator to retrieve rows with matching columns. However, you can also use any of the other comparison operators.
- When a row with unmatched columns is retrieved, any columns from the other table that are included in the result set are given null values. 
- LEFT keeps unmatched rows from the first (left) table
- RIGHT keeps unmatched rows from the second (right) table
- FULL keeps unmatched rows from both tables

```
SELECT DeptName, d.DeptNo, LastName
FROM Departments d
	LEFT JOIN Employees e
		ON d.DeptNo = e.DeptNo
```

- You can combine both inner and outer joins
```
SELECT DeptName, LastName, ProjectNo
FROM Departments d
	JOIN Employees e
		ON d.DeptNo = e.DeptNo
	LEFT JOIN Projects p
		ON e.EmployeeID = p.EmployeeID
ORDER BY DeptName;
```



### Cross Joins
- A cross join produces a result set that includes each row from the first table joined with each row from the second table. The result set is known as the Cartesian product of the tables. 
- To use the explicit syntax, you include the CROSS JOIN keywords between the two tables in the FROM clause. Because of the way a cross join works, you don't include a join condition. The same is true when you use the implicit condition form the WHERE clause. 
- Joins each row from the first table with each row from the second table

**Explicit Syntax**
```
SELECT d.DeptNo, DeptName, EmployeeID, LastName
FROM Departments d
	CROSS JOIN Employees e
ORDER BY d.DeptNo;
```

**Implicit Syntax**
```
SELECT d.DeptNo, DeptName, EmployeeID, LastName
FROM Departments d, Employees e
ORDER BY d.DeptNo;
```



### Unions
Syntax
```
	SELECT_statement_1
UNION [ALL]
	SELECT_statement_2
[UNION [ALL]]
	SELECT_statement_3
[ORDER BY order_by_list]
```

Purpose
- Combines the result sets of two or more select statements into one result set.
- Each result set must return the same number of columns and the corresponding columns in each result set must have compatible data types.
- By default a union eliminates duplicate rows. Include ALL to prevent that.
- The column names in the final result set are taken from the first SELECT clause. Column aliases assigned by the other SELECT clauses have no effect on the final result set.
- To sort the rows in the final result set, code an ORDER BY clause after the last SELECT statement. This clause must refer to the column names assigned in the first SELECT clause.
- To assign a literal value to a column, code the literal value where you would normally code the column name.



### EXCEPT and INTERSECT
Syntax
```
	SELECT_statement_1
{EXCEPT|INTERSECT}
	SELECT_statement_2
[ORDER BY order_by_list]
```

Purpose
- Work with two or more result sets
- EXCEPT returns everything except something that fulfills a condition
- INTERSECT returns everything that matches both tables I believe
- Both statements that are connected must return the same number of columns and the data types must be compatible

EX: Excludes rows from the first query if they also occur in the second query
```
	SELECT CustomerFirst, CustomerLast
	FROM Customers
EXCEPT
	SELECT FirstName, LastName
	FROM Employees
```



