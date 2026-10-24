
### How to Design a Database
p. 296-297, 300-309
Murach's SQL Server 2022

**Normalization**
Normalization is a formal process you can use to separate the data in a data structure into related tables. 
It reduces data redundancy, which can cause problems. 

In an unnormalized data structure, a table can contain information about two or more entities, and repeating information. 

In a normalized data structure, each table contains information about a single entity, and each piece of information is stored in exactly one place. 

To normalize, apply the normal forms in sequence. Although there are 7, you only need the first 3. 

**The Seven Normal Forms**
1NF
	The value stored at the intersection of each row and column must be a scalar value, and a table must not contain any repeating columns. 
	The table can't contain repeating columns that represent a set of values. 
2NF
	Every non key column must depend on the primary key. If a column doesn't depend on the entire key, it indicates the table contains information for more than one entity. Move columns that don't depend on the entire primary key to another table and then establish a relationship between the two tables using a foreign key. 
3NF
	Every non key column must depend only on the primary key. If a column doesn't depend only on the primary key, it implies that the column is assigned to the wrong table or that it can be computed from other columns.
BCNF
	Any non key column can't be dependent on another non-key column. This prevents transitive dependencies.
4NF
	A table must not have more than one multivalued dependency, where the primary key has a one-to-many relationship to non-key columns. This gets rid of misleading many-many relationships.
5NF
	The data structure is split into smaller and smaller tables until all redundancy has been eliminated. If further splitting would result in tables that couldn't be joined to recreate the original table, teh structure is in fifth normal form.
DKNF/6NF
	Every constraint on the relationship is dependent only on key contraints and domain constraints where a domain is the set of allowable values for a column. This form prevents the insertion of any unacceptable data by enforcing constraints at the level of a relationship. 

**Denormalization**
	Going beyond the first 3 normal forms can make things actually harder to use because of the reliance on joins and searches. If performance will be greatly improved by denormalizing, go for it. 
	Denormalize 
		When a column from a joined table is used repeatedly in search criteria.
		When a table is updated infrequently and is relatively constant. 
		When a column is frequently used in search conditions.


### Keys
p. 233-249
Database Design for Mere Mortals by Michael Hernandez

**Why Keys are Important**
Keys ensure that each record in a table is precisely identified. 
They help establish and enforce various types of integrity. 
They serve to establish table relationships. 

**Candidate Keys**
The candidate key is the first type of key you establish for a table. It's a field or set of fields that uniquely identifies a single instance of the table's subject. Eventually, you designate one as the primary key. 
Make sure the candidate key:
- Isn't a multipart field
- Contains unique values
- Doesn't contain nulls
- Can't cause a breach of security
- Isn't optional in whole or in part
- Comprises a minimum number of fields necessary to define uniqueness
- Its values must uniquely and exclusively identify each record in the table
- Its value must exclusively identify the value of each field within a given record
- It's value can only be modified in rare or extreme cases. You shouldn't ever change the value of a candidate key or a primary key unless you have an absolute and compelling reason to do so. 
Or you can just add a primary key ID field

Candidate keys that  require combinations are called composite candidate keys (CCK). 

**Artificial Candidate Keys**
When you determine a table doesn't have a candidate key, you can create an artificial (or surrogate) candidate key. It didn't occur naturally. 
I personally don't see any reason why you wouldn't just do this. I guess to reduce bloat but come on this is just way simpler. Denoramlize for this. 

**Primary Keys**
Exclusively identifies the table throughout the database and helps establish relationships with other tables. 
Uniquely identifies a given record within a table and exclusively represents that record throughout the entire database. 
Elements of a primary key
- Can't be a multipart field
- Must contain unique values
- Can't contain nulls
- Can't risk security or privacy
- Not optional in whole or in part
- Comprises minimum number of fields necessary to define uniqueness
- Uniquely and exclusively identify each record in the table
- Exclusively identify the value of each field within a given record
- Can only be modified in rare cases. Don't change it.

Rules
- Each table must have one and only one primary key
- Each primary key within the databse must be unique
- 