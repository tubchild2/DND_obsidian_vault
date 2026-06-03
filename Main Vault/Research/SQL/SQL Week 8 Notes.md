## CREATING DATABASES
Source: Murach's SQL Server 2022 p. 314-331
![[Pasted image 20260526142930.png]]


##### Creating Databases
```DB_SYNTAX
CREATE DATABASE db_name
	[ON [PRIMARY] (FILENAME = 'file_name')]
	[FOR ATTACH];
	
CREATE DATABASE test_db
	ON PRIMARY (FILENAME = 'C:\Napil\SQL Server 2022\Databases\test_db.mdf')
	FOR ATTACH;
```

CREATE DATABASE creates a new, empty database on the current server. Most of the time, default settings are fine, so you don't need any additional options. 

CREATE DATABASE creates a transaction log file, which records modifications to the database. Appends
 "\_log.ldf" to the end of the file. 

The FOR ATTACH clause attaches pre-existing files to the new ones you're creating, instead of creating a database entirely from scratch. 


##### Creating Tables
```TABLE_SYNTAX
CREATE TABLE table_name
	(column1_name datatype [column_attributes]
	[, table_attributes])

CREATE TABLE Vendors
	(VendorID INT, 
	VendorName VARCHAR(50));
	
CREATE TABLE Invoices (
	InvoiceID INT PRIMARY KEY IDENTITY,
	VendorID INT NOT NULL,
	InvoiceDate DATE NULL,
	InvoiceTotal MONEY NULL DEFAULT 0
);
```

Column Attributes
- NULL | NOT NULL. Indicates whether the column can accept null values. Defaults to NULL unless PRIMARY KEY is specified. 
- PRIMARY KEY | UNIQUE. Identifies the primary key or a unique key for the table. If PRIMARY is specified, the NULL attribute isn't allowed. 
- IDENTITY. Identifies an identity column. Only one can be made per table. 
- DEFAULT default_value. Sets a default value for the column.
- SPARSE. Optimizes storage of null values for the column.

Tables can contain 1-1024 columns. Each column must have a unique name and be assigned a data type. 
Constraints are special attributes such as NOT NULL, PRIMARY KEY, and UNIQUE that restrict the data of a column.


##### Creating Indices
```INDEX_SYNTAX
CREATE [CLUSTERED|NONCLUSTERED] INDEX index_name
	ON table_name (column1 [ASC|DESC] 
	WHERE filter_condition)
	
CREATE INDEX IX_VendorID
	ON Invoices (VendorID);
```

Indices improve performance when SQL Server searches for rows. By default, SQL Server creates a clustered index for a table's primary key. 

Each table can have 1 clustered index, and 249 non-clustered indices. SQL automatically creates a non-clustered index for each unique key other than the primary key. They're defaulted to ASC sequence.

A full-table index is an index that applies to every row in the table. A filtered index is a type of non-clustered index that includes a WHERE clause. Filtered indices can improve performance when the number of rows in the index is small compared to the total number of rows in the table. 


##### Constraints
Examples of Constraints
- NOT NULL. Prevents null values from being stored in a column.
- PRIMARY KEY. Requires that reach row have a unique value in that column, and no null values. If used on a table, each row in the table must have a unique set of values over one or more columns. Null values are not allowed. 
- UNIQUE. Requires that each row in the table have a unique value in the column. If used on a table, it requires that each row in the table have a unique set of values over one or more columns. 
- CHECK. Limits the values for a column, or limits the value for one or more columns. 
- \[FOREIGN KEY] REFERENCES. Enforces referential integrity between a column in the new table and a column in a related table. If used on a table, it enforces referential integrity between one or more columns in the new table and one or more columns in the related table. 
- CHECK (condition). Limits the values that can be stored in the columns of a table. Evaluated as a Boolean expression. If true, the insert or update operation proceeds. If coded at the table level, it can refer to any column in the table. 

Constraints enforce the integrity of the data in a table by defining rules about the values that can be stored in the columns of the table. Can be used to restrict one column or to restrict multiple columns (if used at the table-level).

Constraints are tested before a new row is added to a table or an existing row is updated. 

**Foreign Key**
You can use a FOREIGN KEY clause to define a foreign key constraint, also called a reference constraint. 
A foreign key constraint defines the relationship between two tables and enforces referential integrity. 
Typically, these refer to the primary key of the related table. It can also refer to a unique key. 
The ON DELETE and ON UPDATE clauses specify what happens to rows if the related table with the same key value is deleted or updated. 
The CASCADE keyword causes the rows to be deleted or updated to match the row in the related table. 
The NO ACTION keyword prevents rows in the related table from being deleted or updated and causes an error to be raised. 

```FOREIGN_KEY_SYNTAX
[FOREIGN KEY] REFERENCES referenced_table (referenced_column)
	[ON DELETE {CASCADE|NO ACTION}]
	[ON UPDATE {CASCADE|NO ACTION}]
```


##### Deleting Indices, Tables, or Databases
Index
`DROP INDEX index_name ON table_name`

Table
`DROP TABLE table_name`

Database
`DROP DATABASE database_name`

You can delete multiple indices, tables, or databases at a time using these statements. 
You can qualify a source of the index or table. 
Foreign Key constraints can prevent deleting a table
You can't delete an index that's based on a primary key or a unique key constraint. To do that, you ened to use the ALTER TABLE statement. 

#### Altering a Table
```ALTER_SYNTAX
ALTER TABLE table_name
ADD column_name DATATYPE COLUMN_ATTRIBUTES;

ALTER TABLE table_name
DROP COLUMN column_name;

ALTER TABLE table_name WITH NOCHECK
ADD CHECK (column_value >= 1);

ALTER TABLE table_name WITH CHECK
ADD FOREIGN KEY (FK) REFERENCES table_name(FK)

ALTER TABLE table_name
ALTER COLUMN column_name VARCHAR(200);
```


## INSERT, UPDATE, DELETE
Source: Murach's SQL Server 2022 p. 192-209

##### How to Create Test Tables
**SELECT INTO statement**
Forms a table based on the result set defined by the SELECT statement. It doesn't copy some definitions, like PK, FK, and default values. It won't work if the table name is already taken. 
```
SELECT select_list
INTO table_name
FROM table_source;

// EXAMPLE
SELECT *
INTO InvoiceCopy
FROM Invoices;
```


##### How to Insert New Rows
**INSERT statement**
You specify the values to be inserted into the VALUES clause. 
The INTO keyword is optional


```
INSERT [INTO] table_name [(column_list)]
[DEFAULT] VALUES (expression_1 [, expression_2]...)


// EXAMPLE
INSERT INTO Invoices
	(VendorID, InvoiceNumber, InvoiceTotal, PaymentTotal, CreditTotal, TermsID, InvoiceDate, InvoiceDueDate)
VALUES
	(97, '456789', 8344.50, 0, 0, 1, '2023-03-01', '2023-03-31');


// EXAMPLE (Default Value)
INSERT INTO ColorSample
VALUES (DEFAULT, 'Orange');


// EXAMPLE (Other Table)
INSERT [INTO] table_name [(column_list)]
SELECT column_list
FROM table_source
[WHERE search_condition]

INSERT INTO InvoiceArchive
SELECT *
FROM Invoices
WHERE InvoiceTotal - PaymentTotal - CreditTotal = 0;

```

##### How to Modify Existing Rows
**UPDATE statement**
Modifies one or more rows in a table. 
The SET clause lets you specify what column and what new value to each column.
WHERE can be used to specify what conditions to update rows under
You can use a subquery in the SET, FROM, or WHERE clauses.

```
UPDATE table_name
SET column_name = expression [, column_name_2 = expression_2...]
[FROM table_source [[AS] table_alias]
[WHERE search_condition]


// Example
UPDATE Invoices
SET PaymentDate = '2023-03-21',
	PaymentTotal = 19351.18
WHERE InvoiceNumber = '97/522';


// Example w/ Subquery
UPDATE Invoices
SET CreditTotal = CreditTotal + 100,
	InvoiceDueDate = (SELECT MAX(InvoiceDueDate) FROM Invoices)
WHERE InvoiceNUmber = '97/522';


// Example w/ join
UPDATE Invoices
SET TermsID = 1
FROM Invoices i
	JOIN Vendors v
		ON i.VendorID = v.VendorID
WHERE VendorName = 'Pacific Bell';

```


##### How to Delete Existing Rows
**DELETE statement**
Lets you delete one or more rows from the table you specify in the DELETE clause. 

```
DELETE [FROM] table_name
[FROM table_source]
[WHERE search_condition]


// Example
DELETE Invoices
WHERE InvoiceID = 115;


// Example w/ Subquery
DELETE Invoices
WHERE VendorID = 
(
	SELECT VendorID
	FROM Vendors
	WHERE VendorName = 'Blue Cross');
)
```

## Views
Source: Murach's SQL Server 2022 p. 378-389

##### Views
A view is a select statement stored within the database. The query on which it's based is optimized by SQL Server before it's saved in the database. It doesn't store any data, rather it references current data from other tables. It's like a pointer. 

You can change the design of a database and modify the view as necessary so that the queries that use it don't need to be changed.
You can create views that provide access only to the data that specific users are allowed to see
You can create custom views to accommodate different needs
You can create views that hide the complexity of retrieval operations. 
Within certain restrictions, a view can be used to update, insert, and delete data from a base table.

##### Create and Manage Views
**CREATE VIEW statement**
Used to create a view. 
You can make views based on other views (nested view).
Can't include INTO or ORDER BY (actually it can include ORDER BY but only if TOP or OFFSET/FETCH are used)
To make an updatable view, it can't include DISTINCT or TOP, an aggregate, GROUP BY, HAVING, or UNION

```
CREATE VIEW view_name [(column_list)]
[WITH {ENCRYPTION|SCHEMABINDING|ENCRYPTION,SCHEMABINDING}]
AS 
	select_statement
[WITH CHECK OPTION]


// EXAMPLE
CREATE VIEW VendorsMin AS 
	SELECT VendorName, VendorState, VendorPhone
	FROM Vendors;

```

**DROP VIEW statement**
Deletes a view

```
DROP VIEW view_name
```


**ALTER VIEW statement**
Lets you update a view's definition
