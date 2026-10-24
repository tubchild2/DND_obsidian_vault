### Aggregate Function
- Operate on a series of values and return a single summary value
- Also called column functions

Syntax
```
SELECT Aggregate_Function() AS ColumnName
```

| Function Syntax                 | Result                                               |
| ------------------------------- | ---------------------------------------------------- |
| AVG(ALL\|DISTINCT expression)   | The average of the non-null values in the expression |
| SUM(ALL\|DISTINCT expression)   | The total                                            |
| MIN(ALL\|DISTINCT expression)   | The lowest                                           |
| MAX(ALL\|DISTINCT expression)   | The highest                                          |
| COUNT(ALL\|DISTINCT expression) | The number of non-null values                        |
| COUNT(\*)                       | The number of rows selected by the query             |
### Group By and Having
- The group by clause groups the rows of a result set based on one or more columns or expressions
- If you include aggregate functions in the select clause, the aggregate is calculated for each group named in the group by clause
- If you include two or more columns or expressions in the group by clause, they form a hierarchy where each group is a subordinate to the previous one
- When a select statement includes a group by clause, the select clause can include aggregate  functions, the columns used for grouping, and expressions that result in a constant value
- A group-by list typically consists of the names of one or more columns separated by commas

TLDR
- Group by collapses all rows that share the same state into a single row
- So, if you want to see one row per state, do group by state
- It invisibly splits the table into groups that the aggregate functions can do stuff to

HAVING
- The Having clause specifies a search condition for a group or an aggregate
- This condition is applied after the rows that satisfy the search condition in the where clause are grouped
- When an aggregate function is applied to all rows in the result set, it returns a single value and is known as a scalar aggregate
- When an aggregate function is applied to groups within a result set, such as the groups created by a GROUP BY clause, it returns multiple values known as a vector aggregate
- When you have a having clause in a select statement that uses grouping and aggregates, the search condition in the having clause is applied after the rows are grouped and the aggregates are calculated
- When you include a where clause in a select statement that uses grouping and aggregates, the search condition in the where clause is applied before the rows are grouped and the aggregates are clacuulated. That way, only the rows that satisfy the search condition are grouped and summarized
- A having clause can only refer to a column included in the select or group by clause. A where clause can refer to any column in the base tables
- Aggregate functions can be coded in the having clause. A where clause can't contaoin aggregate functions.

### SQL Server Extensions
##### ROLLUP
- Add one or more summary rows to a result set that uses grouping and aggregates
- Summarizes each group specified
- ORDER BY is applied after hte summary rows are added. Sort grouping columns in descending sequence
- When you use the ROLLUP operator, you can't use DISTINCT
- You can use the GROUPING function with the ROLLUP operator to determine if a summary row has a null value assigned to a given column

##### CUBE
- Adds summary rows for every combination of groups
- Can't use with DISTINCT
- You can use  the GROUPING function wiht the CUBE operator to determien if a summary row has a null value assigned to a given column

##### GROUPING SETS
- Creates a summary row for each specified group
- Within the parentheses after the GROUPING SETS operator, you can add additional sets of parentheses to create composite groups
- Within the parentheses after the GROUPING sets operator, you can add an empty set of parentheses to add a summary row that summarizes the entire result set
- For a coposite group,  yyou can add the rollup or cube operator to add additional summary rows

##### OVER
- When used with aggregate functions, the OVER clause lets you summarize the data in a result set while still returning the rows used to calculate the summary
