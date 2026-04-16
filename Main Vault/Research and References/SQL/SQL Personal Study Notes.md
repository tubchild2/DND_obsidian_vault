# CREATE
CREATE TABLE \[NAME] (
	column1 datatype PRIMARY KEY,
	column2 datatype NOT NULL
);

# SELECT
SELECT column1, column2
FROM table_name;
`returns the first two columns as a table`

SELECT \*
FROM table_name
`returns the entire table`

SELECT name, gpa
FROM student
WHERE gpa >= 3;
`returns table of students of GPA 3 or greater`

# ALTER TABLE
ALTER TABLE table_name
ADD column_name datatype \[constraint];

ALTER TABLE table_name
MODIFY column_name datatype \[constraint];

ALTER TABLE table_name
DROP COLUMN column_name;

INSERT INTO table_name VALUES
	('info 1', 'info 2', 'info 3'),
	('info 1', 'info 2', 'info 3'),
	('info 1', 'info 2', 'info 3');
`NOTE: Numbers don't require single quotes`

UPDATE table_name
SET column_name = value, column_name = value
WHERE condition

DELETE FROM table_name
WHERE condition

# MATH FUNCTIONS
COUNT()
MIN()
MAX()
SUM()
AVG()

ABS(n)
LOG(n)
POW(x, y)
RAND() `returns random from 0 to 1`
ROUND(n, d) `rounds n to d decimal places`
SQRT(n)

# STRING FUNCTIONS
CONCAT(s1, s2, s3...)
LOWER(s)
REPLACE(s, from, to) `returns the string s with all occurences of from replaced with to`
SUBSTRING(s, pos, len)
TRIM(s)
UPPER(s)

# TIME FUNCTIONS
CURDATE()
CURTIME()
NOW()
DATE(expr)
TIME(expr)
DAY(d)
MONTH(d)
YEAR(d)
HOUR(t)
MINUTE(t)
SECOND(t)
DATEDIFF(expr1, expr2)
TIMEDIFF(expr1, expr2)

# JOIN
SELECT column1, column2, colume3
FROM left_table
INNER JOIN right_table
ON \[condition]

LEFT OUTER JOIN clause
	Joins all rows from the left table along with rows from the right table where the join condition is met.

RIGHT OUTER JOIN clause
	Joins all rows from the right table along with rows from the left table where the join condition is met.

FULL OUTER JOIN clause
	Joins all rows from the left and right tables regardless if the join condition is met.

