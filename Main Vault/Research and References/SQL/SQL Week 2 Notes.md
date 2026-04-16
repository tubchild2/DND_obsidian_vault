
| Syntax       | Meaning                                                                |
| ------------ | ---------------------------------------------------------------------- |
| KEYWORD      | Keywords have each letter capitalized                                  |
| element_name | Words in lowercase should be replaced with the appropriate element     |
| {A\|B\|C}    | Choose only one of the elements in the brackets separated by the pipes |
| \[A]         | The element in brackets is optional                                    |
| ~~DEFAULT~~  | Default elements are underlined                                        |
| ...          | More elements can be added to the clause                               |


### SELECT Syntax
```
SELECT select_list
[FROM table_source]
[WHERE search_condition]
[ORDER BY order_by_list]
```

| Clause   | Description                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| SELECT   | Describes the columns that will be included in the result set.<br>     SELECT \*<br>	 SELECT column1, column2, column3<br>	 SELECT column1 + column2 AS new_column<br>	 SELECT TOP n PERCENT<br>	 SELECT TOP n<br>	 SELECT TOP n WITH TIES<br>	 SELECT str1 + ' ' + str2<br>	 SELECT GETDATE() AS 'Today''s Date'<br>	 SELECT DISTINCT city                                                                                                             |
| FROM     | Names the table from which the query will retrieve the data. This clause is optional for SQL Server but required by some other databases<br>     FROM table<br>	 FROM table, table2                                                                                                                                                                                                                                                                     |
| WHERE    | Specifies the conditions that must be met for a row to be included in the result set. This clause is optional. This clause uses *Boolean Expressions*.<br>     WHERE value = x<br>	 WHERE x > y<br>	 WHERE value IN (list_element1, list_element2, list_element3)<br>	 WHERE value NOT IN (list_element1, list_element2, list_element3)<br>	 WHERE value BETWEEN x AND y<br>	 WHERE str LIKE 'S_N%'                                                     |
| ORDER BY | Specifies how the rows in the result set will be sorted. This clause is optional. When not included, the results will typically be sorted by Primary Key value. Ascending order by default. Use DESC for descending order.<br>    ORDER BY column1<br>	ORDER BY column1, column2 DESC<br>	ORDER BY alias1 DESC, column2<br>	ORDER BY column1 + column2<br>	ORDER BY column1 DESC OFFSET n<br>	ORDER BY column1 OFFSET n FETCH {FIRST\|NEXT} n ROWS ONLY |
Arithmetic Operators
- \* Multiplication
- / Division
- % Modulo
- + Addition
- - Subtraction
- () Parenthesis

Boolean Operators
- = Equal
- > Greater Than
- < Less Than
- <= Less Than or Equal To
- >= Greater Than or Equal To
- <> Not Equal
- AND
- NOT
- OR
- () Parenthesis ?
- BETWEEN x AND y
- IN
- LIKE
- IS NULL
- IS NOT NULL

| Wildcard Symbols for LIKE | Description                                           |
| ------------------------- | ----------------------------------------------------- |
| %                         | Matches any string of zero or more characters         |
| _                         | Matches any single character                          |
| \[]                       | Matches a single character listed within the brackets |
| \[ - ]                    | Matches a single character within the given range     |
| \[ ^ ]                    | Matches a single character not listed after the caret |

### DATATYPES

| Data Type Category | Description                                                                                                  |
| ------------------ | ------------------------------------------------------------------------------------------------------------ |
| String             | Strings of character data                                                                                    |
| Numeric            | Integers, floating point numbers, currency, and other numeric data                                           |
| Temporal           | Dates, times, or both                                                                                        |
| Other              | Large character and binary values, XML, JSON, geometric data, geographic data, hierarchical data, and so on. |

| ANSI Standard         | SQL Server Equivalent |
| --------------------- | --------------------- |
| binary varying        | varbinary             |
| char varying          | varchar               |
| character varying     |                       |
| character             | char                  |
| dec                   | decimal               |
| double precision      | float                 |
| float                 | real \| float         |
| integer               | int                   |
| national char         | nchar                 |
| national character    |                       |
| national char varying | nvarchar              |
| national text         | ntext                 |
| timestamp             | rowversion            |

| Datatype          | Category | Bytes  | Description                                                                                                                                                  |
| ----------------- | -------- | ------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| bigint            | Numeric  | 8      | Large Integers                                                                                                                                               |
| int               |          | 4      | Integers                                                                                                                                                     |
| smallint          |          | 2      | Small Integers                                                                                                                                               |
| tinyint           |          | 1      | Very Small Integers                                                                                                                                          |
| decimal           |          | 5-17   | Decimal numbers with a precision of p and a scale of s                                                                                                       |
| numeric           |          | 5-17   | Same as decimal                                                                                                                                              |
| money             |          | 8      | Monetary values                                                                                                                                              |
| smallmoney        |          | 4      | Smaller monetary values                                                                                                                                      |
| float             |          | 4/8    | Precise decimals                                                                                                                                             |
| real              |          | 4      | Single precision floating point numbers                                                                                                                      |
| char(n)           | String   | n      | Fixed length string of characters where n is the number of bytes ranging from 1 - 8000                                                                       |
| varchar(n)        |          | n + 2  | Variable length string of characters where n is the maximum number of bytes ranging from 1 - 8000                                                            |
| nchar(n)          |          | 2n     | Fixed-length string of unicode characters where n is the number of byte pairs ranging from 1 - 4000                                                          |
| nvarchar(n)       |          | 2n + 2 | Variable length string of unicode characters where n is the maximum number of byte pairs ranging from 1 - 4000                                               |
| varchar(max)      |          |        | Works the same as the varchar type, but it can store up to 2,147,483,648 bytes                                                                               |
| nvarchar(max)     |          |        | Works the same, but can store 2 gigabytes of data                                                                                                            |
| datetime          | Temporal | 8      | Dates and times from January 1, 1753 through December 31st 9999                                                                                              |
| smalldatetime     |          | 4      | Dates and times from January 1, 1900 through June 6, 2079                                                                                                    |
| date              |          | 3      | Dates (not time part) from January 1, 0001 through December 31, 9999                                                                                         |
| time(n)           |          | 3-5    | Times (no date part) from 00:00:00.00000000 through 23:59:59:99999999. n is the number of digits used for fractional second precision. n can range from 0-7. |
| datetime2(n)      |          | 6-8    | Dates from January 1, 0001 through December 31, 9999 with time values from 00:00:00.00000000 through 23:59:59:99999999.                                      |
| datetimeoffset(n) |          | 8-10   | An extension of the datetime2 type that also includes a time zone offset of -14 to +14                                                                       |
| varbinary         | Other    |        | Stores variable length binary data up to a maximum of 2 gigabytes.                                                                                           |
| bool              |          | 1      | stores a true or false value                                                                                                                                 |
| bit               |          | 1      | Values of 0 or 1                                                                                                                                             |
**Datatype Conversion**
- CAST(value AS DATATYPE)
- CONVERT(DATATYPE, expression \[, style])
