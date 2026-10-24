
How to code summary queries (146-147)
- You can code compound search conditions in a having clause just as you can in a WHERE clause.
- HAVING seems incredibly useful as an alternate for WHERE but with the ability to use aggregate functions

How to code subqueries (180-189)
- Use pseudocode for complex queries
- Common Table Expressions (CTE)
	- Allows you to code an expression that creates one or more temporary derived tables
	- Uses WITH
	- Separate multiple CTEs with commas
- Recursive CTEs
	- A recursive query loops through a result set and performs processing to return a final result set
	- A recursive CTE can be used to create a recursive query
	- A recursive CTE must contain at least two query definitions, an anchor member, and a recursive member, and these members must be connected by the UNION ALL operator
	- 

Example of CTE
```
WITH tableCTE AS
(
	SELECT column1, column2, column3
	FROM table1
		JOIN table2 ON table1.id = table2.id
)

SELECT t.column1, t.column2, t.column3
FROM tableCTE AS t
```

Example of Recursive CTE
![[SQL Week 6 Recursive CTE.png]]


### Functions
##### String Data

| Function                                          | Description                                                                                                                                                                                                                                                                                                                               |
| ------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| LEN(str)                                          | Returns number of characters                                                                                                                                                                                                                                                                                                              |
| LTRIM(str)                                        | Returns the string with no leading spaces                                                                                                                                                                                                                                                                                                 |
| RTRIM(str)                                        | Returns the string with no trailing spaces                                                                                                                                                                                                                                                                                                |
| TRIM(str)                                         | Returns the string with no leading or trailing spaces                                                                                                                                                                                                                                                                                     |
| LEFT(str, length)                                 | Returns the specified number of characters from the beginning of the string                                                                                                                                                                                                                                                               |
| RIGHT(str, length)                                | Returns the specified number of characters from the end of the string                                                                                                                                                                                                                                                                     |
| SUBSTRING(str, start, length)                     | Returns the specified number of characters from the string starting at teh specified position                                                                                                                                                                                                                                             |
| STRING_SPLIT(str, separator)                      | Splits the string on the passed separator                                                                                                                                                                                                                                                                                                 |
| REPLACE(search, find, replace)                    | Returns the search string with all occurrences of the find string replaced with the replace string                                                                                                                                                                                                                                        |
| TRANSLATE(search, find, replace)                  | Returns the search string with characters in the find string replaced with characters in the replace string                                                                                                                                                                                                                               |
| REVERSE(str)                                      | Returns the string with the characters in reverse order                                                                                                                                                                                                                                                                                   |
| CHARINDEX(find, search\[,start])                  | Returns an integer that represents the position of the first occurrence of the find string in the search string starting at the specified position. If the starting position isn't specified, the search starts at the beginning of the string. If the string isn't found, the function returns zero.                                     |
| PATINDEX(find, search)                            | Returns an integer that represents the position of the first occurrence of the find pattern in the search string. If the pattern isn't found, the function returns zero. The find pattern can include wildcard characters. IF the pattern begins with a wildcard, the value returned is the position of the first non-wildcard character. |
| CONCAT(value1, value2\[,value3]...)               |                                                                                                                                                                                                                                                                                                                                           |
| CONCAT_WS(delimiter, value1, value2\[,value3]...) |                                                                                                                                                                                                                                                                                                                                           |
| LOWER(str)                                        |                                                                                                                                                                                                                                                                                                                                           |
| UPPER(str)                                        |                                                                                                                                                                                                                                                                                                                                           |
| SPACE(int)                                        |                                                                                                                                                                                                                                                                                                                                           |

##### Numeric Data

| Function                          | Description |
| --------------------------------- | ----------- |
| ROUND(number, length\[,function]) |             |
| ISNUMERIC(expression)             |             |
| ABS(number)                       |             |
| CEILING(number)                   |             |
| FLOOR(number)                     |             |
| SQUARE(float_number)              |             |
| SQRT(float_number)                |             |
| RAND()                            |             |
If you're searching for floats, because they're approximate, you'll want to search for approximate values when retrieving values stored with the real and float data types.


##### Date/Time Data
| Function                               | Description                                                                                                           |
| -------------------------------------- | --------------------------------------------------------------------------------------------------------------------- |
| GETDATE()                              | Returns the current local date and time as **datetime** (no timezone awareness)                                       |
| GETUTCDATE()                           | Returns the current UTC date and time as **datetime**                                                                 |
| SYSDATETIME()                          | Returns the current local date and time as **datetime2** (higher precision than GETDATE)                              |
| SYSUTCDATETIME()                       | Returns the current UTC date and time as **datetime2**                                                                |
| SYSDATETIMEOFFSET()                    | Returns the current date and time as **datetimeoffset**, including the local timezone offset                          |
| DAY(date)                              | Extracts the **day number** (1–31) from a date                                                                        |
| MONTH(date)                            | Extracts the **month number** (1–12) from a date                                                                      |
| YEAR(date)                             | Extracts the **4-digit year** from a date                                                                             |
| DATENAME(datepart, date)               | Returns the specified datepart as a **string** (e.g. `DATENAME(month, ...)` → `'January'`)                            |
| DATEPART(datepart, date)               | Returns the specified datepart as an **integer** (e.g. `DATEPART(month, ...)` → `1`)                                  |
| DATETRUNC(datepart, date)              | Truncates a date down to the start of the specified datepart (e.g. truncating to `month` gives the 1st of that month) |
| DATEADD(datepart, number, date)        | Adds (or subtracts if negative) a number of the specified datepart units to a date                                    |
| DATEDIFF(datepart, startdate, enddate) | Returns the difference between two dates in the specified datepart units (integer result)                             |
| TODATETIMEOFFSET(datetime2, tzoffset)  | Converts a **datetime2** value into a **datetimeoffset** by attaching a timezone offset (e.g. `'-05:00'`)             |
| SWITCHOFFSET(datetimeoffset, tzoffset) | Adjusts a **datetimeoffset** value to a different timezone offset while keeping the same point in time                |
| EOMONTH(startdate [, months])          | Returns the last day of the month of the given date; optional second argument offsets by that many months             |
| DATEFROMPARTS(year, month, day)        | Constructs a **date** value from separate integer year, month, and day components                                     |
| ISDATE(expression)                     | Returns **1** if the expression is a valid date/time value, **0** if not                                              |

| Argument    | Abbreviations |
| ----------- | ------------- |
| Year        | yy, yyyy      |
| quarter     | qq, q         |
| Month       | mm, m         |
| dayofyear   | dy, y         |
| day         | dd, d         |
| week        | wk, ww        |
| weekday     | dw            |
| hour        | hh            |
| minute      | mi, n         |
| second      | ss, s         |
| millisecond | ms            |
| microsecond | mcs           |
| nanosecond  | ns            |
| tzoffset    | tz            |

EXAMPLE: `DAY('2023-04-30')` RETURNS 30
EXAMPLE: `MONTH('2023-04-30')` RETURNS 4
EXAMPLE: `YEAR('2023-04-30')` RETURNS 2023

DATE_BUCKET

##### Other
CASE
- For conditional logic
- `CASE WHEN salary > 100000 THEN 'High' ELSE 'LOW' END`

IIF
- Shorthand for a simple two-outcome CASE
- `IIF(salary > 100000, 'High', 'Low')`

CHOOSE
- Returns a value from a list by index position
- `CHOOSE(2, 'Red', 'Blue', 'Green'` Returns Blue

COALESCE
- Returns the first non-NULL value from a list of expressions
- COALESCE(middle_name, nickname, 'N/A')

ISNULL
- SQL Server specific two argument version of COALESCE. Replaces NULL with a fallback
- ISNULL(middle_name, 'N/A')

GROUPING
- Used with GROUP BY ROLLUP/CUBE. Returns 1 if the column is aggregated, 0 if not. 

GREATEST
- Returns the largest value across a list of columns or expressions

LEAST
- Returns the smallest value across a list of columns or expressions

Ranking Functions
- They all use OVER(ORDER BY ... ) and assign a rank to each row within a partition
	- ROW_NUMBER() unique sequential number, no ties
	- RANK() Tied rows get the same rank, next rank skips
	- DENSE_RANK() tied rows get the same rank, next rank does not skip
	- NTILE(n) Divides rows into n roughly equal buckets

Analytic Functions
- Like aggregates, but returns a value per row without collapsing the result set
- They all use OVER(PARTITION BY ... ORDER BY ... )
	- SUM / AVG / COUNT
