# Stock.Companies

# DataBase
This application uses User-Secrets to store the connection string with the database name "StockCompany".
Migration

# Migration
The Data project has the class "MSSQLContextFactory" that is used to execute Entity Framework Migrations, 
to use it is necessary to configure the ConnectionString on the appsettings on the same project for SQL Server.
Alternatively, the SQL Script available at "StockCompany.sql" can be executed to create the database
