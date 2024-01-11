# ATM Machine

## Description

An .NET Core api for a ATM Machine software, to deal with CLients, Bills and Withdraws registers.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Setting Up the Database](#setting-up-the-database)
3. [Applying Migrations](#applying-migrations)
4. [Running the Application](#running-the-application)

## Prerequisites

Before starting, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Setting Up the Database

1. **Create Database**: On your local Sql Server create a new database called 'ATMMachine' and on the Infrastructure layer execute 'update-database' , this will execute the migration script and create the tables on your local environment, the database is set up to start with 10 bills registered

2. **Connection String**: Update the connection string in `appsettings.json` or `appsettings.Development.json` with your SQL Server details.

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=.;Initial Catalog=ATMMachine;Integrated Security=True;"
      },
      // ...
    }
    ```


