
Client/Server Hardware Components 
- Network: cabling, communication lines, network interface cards, hubs, routers, and other components that connect the clients and the server. 
- Server: a computer that has enough processor speed, memory, and disk storage to store the files and databases of the system and provide services to the clients of the system. 
- Local Area Network: LAN connects computers that are near each other. 
- Wide Area Network: At a high level, just connects computers that aren't near each other. 
- Cloud: a server that's available through the internet

Client/Server Software Components
- Database Management System (DBMS): manages databases that are stored on the server.
- Data Access API: something like SQL lets you access the database and work with it
- SQL Queries: commands for the DBMS in SQL

Client/Server System Architectures
- Windows Based System: the UI is on the client, but processing is done on an application server. 
- Web Based System: client using HTTP to send a request to a web server which uses SQL to send a request to the database server. 

Relational Database Model
- Relational databases store data in tables. Each table has rows and columns (also called records and fields). 
- If a table contains one or more columns that uniquely identify each row in the table, you can define these as the primary key of the table.
- Primary keys can consist of two or more columns, in which it's called a composite primary key.
- A foreign key is one or more columns in a table that refer to a primary key in another table. 
- When defining a column in a table, you must define its data type, whether it can store a null value, and if it has a default value. 
- There are four major relational databases
	- MySQL: runs on all major operating systems and is widely used for web applications. It's open-source. Free for most users.
	- SQL Server: runs on Windows and is used for many small and medium sized systems. Inexpensive and easy to use. 
	- Oracle: dominates the marketplace especially for servers on Unix / Linux. Extremely reliable. 
	- DB2: originally designed to run on IBM mainframe systems and continues to be the premier database for those systems. 