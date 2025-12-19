### **WHAT IS SQL LITE**
SQLite is a SQL wrapper for C# .net

### **INSTALLATION**
Guide:
https://www.youtube.com/watch?v=8bpYHCKdZno

Step 1: SQLite Home Page
https://sqlite.org/
Download precompiled binaries for windows x64

Step 2: Plugins
Create "plugins" folder in assets
Drag extracted contents from precompiled binaries into plugins folder

Step 3: Mono.Data.Sqlite.dll
1. C:
2. Program files
3. Unity
4. Hub
5. Editor
6. Version you're working with
7. Editor
8. Data
9. MonoBleedingEdge
10. Lib
11. Mono
12. UnityJIT
13. Mono.Data.Sqlite.dll
Drag that dll into the plugins folder.
It's not going to be that easy to find, this might take a while

### **SCRIPTING**
Step 1: Using Statement
```using Mono.Data.Sqlite```

Step 2: Declare database name
```private string dbName = "URI=file:NAME.db";```

Step 3: Creating a database
```
// This method creates a table if it doesn't already exist
public void CreateDB()
{
	// Create the db connection
	using (var connection = new SqliteConnection(dbName))
	{
		connection.Open();
		
		// Set up an object called command to allow db control	
		using (var command = connection.CreateCommand())
		{
			// create a table called weapons if it doesn't exist already
			// it has 2 fields: name (up to 20 characters) and damage (an integer)
			command.CommandText= "CREATE TABLE IF NOT EXISTS weapons (name VARCHAR(20), damage INT);";
			command.ExecuteNonQuery();
		}
		
		connection.Close();
	}
}
```

Step 4: Adding to the Database
