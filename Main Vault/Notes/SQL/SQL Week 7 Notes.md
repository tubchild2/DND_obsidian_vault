#### Reading
SQL Server 2022 Murach 2022 284-299
DDfMM Chapter 3 50-59
DDfMM Chapter 10 292-312, 323-348

#### Designing Data Structures
Steps
1. Identify the data elements
2. Subdivide each element into its smallest useful components
3. Identify the tables and assign columns
4. Identify the primary and foreign keys
5. Review whether the data structure is normalized
6. Identify the indexes

Identifying the Data Elements
- Interview users, analyze existing systems, and evaluate comparable systems
- The documents used by a real-world system, such as the invoice shown above, can often help you identify the data elements of the system. 
- As you identify the data elements of a system, you should begin thinking about the entities that those elements are associated with. That will help you identify the tables of the database later on. 

Subdivision
- If a data element contains two or more components, you should consider subdividing the element into those components so you won't have to parse the element. 
- The extent to which you subdivide depends on how it will be used. 

Identifying Tables
- After you identity all of the data elements, you should group them by the entities with which they're associated. These will later become the tables of the database. 
- If a data element relates to more than one entity, you can include it under all of the entities it relates to. Then, when you normalize the database, you may be able to remove the duplicate elements. 
- Omit elements that aren't needed.

Identifying the Primary and Foreign Keys
- Most tables should have a primary key that uniquely identifies each row
- IF necessary, you could use a composite key that uses two ore more columns to uniquely identify each row
- Primary keys should seldom (if ever) change. They should be short and easy to enter correctly. 
- If a suitable column doesn't exist, make one. 
- If two tables have a one-to-many relationship, you may need to add a foreign key column to the table on the many side. The foreign key column must have the same data type as the primary key column it's related to.  
- If two tables have a many to many relationship, you'll need a linking table to relate them. Linking tables usually don't need a primary key. 
- If two tables have a one-to-one relationship, they should be related by their primary keys.

Referential Integrity
- Referential integrity means that the relationships between tables are maintained correctly. 
- In SQL Server, you can enforce referential integrity by using declarative referential integrity or by defining triggers
- To use DRI, you can define foreign key constraints
- The three types of errors that can occur when referential integrity isn't enforced are called the deletion anomaly, the insertion anomaly, and the update anomaly. 
- Examples
	- Deleting a row from the primary key table violates integrity if the foreign key table contains one or more rows related to the deleted row
	- Inserting a row in the foreign key table violates integrity if the foreign key value doesn't have a matching primary key value in the related table
	- Updating the value of a foreign key violates integrity if the new foreign key value doesn't have a matching primary key value in the related table
	- Updating the value of a primary key violates integrity if the foreign key table contains one or more rows related to the row that's changed. 

Normalization
- Check for repeating columns, redundant data, tables that contain information about two or more entities,, repeating values.
- Apply the normal forms in sequence. There are 7, but a table is generally considered normalized if the first three normal forms are applied. 

Identifying Indexes
- An index provides a way for SQL Server to locate information more quickly. It allows SQL Server to go to the desired row immediately instead of searching all the rows until it finds what you want. 
- Indexes can be clustered or nonclustered. Each table can have one clustered index, and up to 249 nonclustered indexes. 
- The rows of a table are stored in the sequence of the clustered index. If you don't make a primary key, the rows of the table are stored in the order in which they're entered.
- Indexes speed performance when ssearching and joining tables. However, they can't be used in search conditions that used the LIKE operator with a pattern that starts with a wildcard. 
- Composite indexes include two or more columns. Helpful when data isn't updated very often. 
- Don't create more than you need. 
- Create an index when
	- When the column is a foreign key
	- When the column is used frequently in search conditions or joins
	- When the column contains a large number of distinct values
	- When the column is updated frequently
- When to reassign the clustered index
	- When the column is used in almost every search condition
	- When the column contains mostly distinct values
	- When the column is small
	- When the column values seldom, if ever, change
	- When most queries against the column will return large result sets

#### Terminology
Indexes
- Structures RDBMS provide to improve data processing.
- Index and key are often confused. Keys are logical structures, while indexes are physical structures.

Relationships
- A relationship exists between two tables when you can in some way associate the records of the first table with the second. 
- Three types of relationships (traditionally known as cardinality) can exist between a pair of tables: one-to-one, one-to-many, and many-to-many. 
- One to One
	- Exactly one instance in entity A relates to exactly one instance in entity B
	- Each Person has one Driver's License
- One to Many
	- Exactly one instance in entity A relates to many instances in entity B
	- Each Customer can place many Orders, but each Order has one Customer
- Many to Many
	- Many instances in entity A relate to many instances in entity B
	- Students can take many Classes, and Classes can have many Students
	- Commonly uses linking tables

Participation
- A table's participation within a relationship can be either mandatory or optional
- The degree of participation determines the minimum number of records that a given table must have associated with a single record in the related table, and the maximum number of records that a given table is allowed to have associated with a single record in the related table. 

Integrity Terms
- Field Specification. Represents all of the elements of the field.
- General elements are the most fundamental information about the field and include items like field man, description, and parent table
- Physical elements determine how a field is built and how it is represented to the person using it. This category includes items such as Data Type, Length, and Character Support
- Logical elements describe the values stored in a field and include items such as Required Value, Range of Values, and Null Support
- Data Integrity refers to the validity, consistency, and accuracy of the data in a database. 



#### Table Relationships
