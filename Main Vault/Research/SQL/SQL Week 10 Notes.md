Murarch's SQL Server 2022 for Developers c17

### How to Work with SQL Server login IDs
Typically you need login ID and password. Usually Windows login, otherwise custom SQL Server login.
Permissions determine the actions a user can take.
A role is a collection of permissions 
You can create a collection of users called a group
Users, groups, logins, and roles have that have access to a server are called principals

To change authentication mode, click on the server in the object explorer, select properties to display the server properties box, and display the security page.

```CREATE_LOGIN
### Windows Auth
CREATE LOGIN login_name FROM WINDOWS
	[WITH [DEFAULT_DATABASE = database]
	[, DEFAULT_LANGUAGE = language]]

### FROM WINDOWS
CREATE LONGIN [Accounting\SusanRoberts] FROM WINDOWS

### SQL Server Auth
CREATE LOGIN login_name WITH PASSWORD = 'password' [MUST_CHANGE]
	[, DEFAULT_DATABASE = database]
	[, DEFAULT_LANGUAGE = language]
	[, CHECK_EXPIRATION = {ON|OFF}]
	[, CHECK_POLICY = {ON|OFF}]
```

If you don't specify a default database, it's set to master. 
If you don't specify a default language, it defaults to the server's default language. The server's default language is English.
If you include MUST CHANGE the user will have to make a new password the first time they log in. Requires check policy and check expiration. 
CHECK POLICY is for whether to enforce password policies

``` ALTERING_LOGIN
DROP LOGIN login_name
ALTER LOGIN login_name {{ENABLE|DISABLE} | WITH [NAME = login_name]}
```

Enable or disable a login, change the name for a login, change the default database or language.
For SQL Server logins, you can also change the password. 

```CREATE_USER
CREATE USER user_name
	[{FOR|FROM} LOGIN login_name]
	[WITH DEFAULT_SCHEMA = schema_name]

ALTER USER user_name WITH
	[NAME = new_user_name]

DROP USER user_name
```


```CREATE_SCHEMA
CREATE SCHEMA schema_name [AUTHORIZATION owner_name]
	[table_definition]
	[view_definition]
	[grant_statement]
	[revoke_statement]
	[deny_statement]

ALTER SCHEMA Accounting TRANSFER Marketing.Contacts

DROP SCHEMA Marketing
```

After you create a schema, you can create any object within that schema by qualifying the object name with the schema name. 


### How to Work with Permissions
You can use the GRANT statement format to give a user permission to work with a database object. 
This format of of the REVOKE statement takes object permissions away. 

```GRANT
GRANT permission
ON object_name [(column [, ...])]
TO database_principal [, ...]

GRANT SELECT 
ON Invoices
TO SusanRoberts
```

```REVOKE
REVOKE permission
ON object_name
FROM database_principal
[CASCADE]

REVOKE SELECT
ON Invoices
FROM SusanRoberts
```

Standard Permissions
- SELECT
	- Read data from a table or view
- UPDATE
	- Modify existing rows in a table
- INSERT
	- Add new rows to a table
- DELETE
	- Remove rows from a table
- EXECUTE
	- Run a stored procedure, function, or other executable database object
- REFERENCES
	- Create a foreign key constraint that points to another table
- ALTER
	- Modify the structure of a database object
	- Add/drop columns
	- Change datatypes
	- Etc
	- DDL permission





### How to Work with Roles
```
ALTER SERVER ROLE role_name
{
	ADD MEMBER server_principal
	DROP MEMBER server_principal
	WITH NAME = new_role_name
}

ALTER SERVER ROLE sysadmin ADD MEMBER JohnDoe;
```

Fixed Roles
- sysadmin
	- Can perform any activity on the server
	- All members of the Windows BUILTIN\Administrations group are members of this role
- securityadmin
	- Can manage login IDs and passwords for the server and can grant, deny, and revoke database permissions
- dbcreator
	- Can create, alter, drop, and restore databases

```
CREATE SERVER ROLE role_name [AUTHORIZATION server_principal]
DROP SERVER ROLE role_name

GRANT ALTER ANY LOGIN TO consultant
ALTER SERVER ROLE dbcreator ADD MEMBER consultant
```

You can display information for any server role
```
SELECT name, principal_id, is_fixed_role
FROM sys.server_princpals
WHERE type = 'R';
```

Fixed SQL Server roles
- db_owner
- db_accessadmin
- db_securityadmin
- ab_ddladmin
- db_datawriter
- db_datareader
- db_denydatawriter
- db_denydatareader
- db_backupoperator


### How to Manage Security Using Management Studio
Managing Login IDs
	Use the object explorer to expand the security folder and then the logins folder
	New ID: Right click in the logins folder and select new login
	Mod ID: Right click the login ID and select properties to display the login properties dialog box
	The general page lets you change all the settings for the login ID but some options such as login name and authentication type are disabled when you're modifying a login ID
	The status page allows you to deny or grant a login ID permission to connect to SQL Server and it allows you to disable or enable a login ID

Managing Server IDs
	Object Explorer >> Logins >> Login ID >> Properties >> Server Roles

