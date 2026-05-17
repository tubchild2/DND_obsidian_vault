Subqueries
- A query within another query
- You code a query, put it in parentheses, and then any results from the inner query will be used by the outer query

```
SELECT 
	first_name, 
	last_name, 
	hourly_pay, 
	(SELECT AVG(hourly_pay) FROM employees) AS avg_pay
FROM employees;


SELECT first_name, last_name, hourly_pay
FROM employees;
WHERE hourly_pay > (SELECT AVG(hourly_pay) FROM employees)
```

```
SELECT 
	first_name, 
	last_name
FROM customers
WHERE customer_id IN 
	(SELECT DISTINCT customer_id
	FROM transactions
	WHERE customer_id IS NOT NULL;)
```


Where to use them
- WHERE clause as search condition
- HAVING clause as search condition
- FROM clause as a table specification
- SELECT clause as a column specification
	- Must return a single value
	- Typically a correlated subquery

Description
- A query within another query isolated by parentheses
- Can't include ORDER BY unless the TOP phrase is used
- Subquery in a WHERE or HAVING clause is called a subquery search condition or subquery predicate

ALL
- Repeats a comparison for every element in a list
- `X > ALL (1, 2)`
- Particularly useful when working with the lists returned by subqueries
- If nothing is returned by a subquery, then the result is always true

ANY/SOME
- Similar to ALL, but returns true if one or more of the values fulfills the condition
- ANY also works and is more commonly used

Correlated subqueries
- Subqueries that are executed once for each row that's processed by the outer query
- Similar to using a loop to do repetitive processing in a procedural programming language
```
SELECT VendorID, InvoiceNumber, InvoiceTotal
FROM invoices i
WHERE InvoiceTotal >
	(SELECT AVG(InvoiceTotal)
	FROM Invoices AS i_sub
	WHERE i_sub.VendorID = i.VendorID)
```

EXISTS
- Used to test that one or more rows are returned by the subquery
- Most often used with correlated subqueries; it's usually better to use a join than a noncorrelated subquery with EXISTS

Derived Tables
- Subqueries in the FROM clause return derived tables