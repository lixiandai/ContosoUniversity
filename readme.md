# Contoso University ASP.Net Core Tutorial

## Changes I made

### Azure SQL Server instead of LocalDB

In file `appsettings.json` I use the following connection string to connect to my Azure SQL Server Database:
### Without Migrations
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=tcp:fpmcontosouniversity.database.windows.net,1433;Initial Catalog=ContosoUniversity;Persist Security Info=False;User ID=DevAdmin;Password=Bulldog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
```
### With Migrations

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=tcp:fpmcontosouniversity.database.windows.net,1433;Initial Catalog=ContosoUniversity2;Persist Security Info=False;User ID=DevAdmin;Password=Bulldog1$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
```

### Azure Web + SQL Sever
In order to host both the ASP.Net Core Web and the SQL Database in Azure it performed the following steps.

### Azure Web Site + SQL Server Tempate
I could not locate the Web Site + SQL Server template in the Azure Portal GUI.
Instead, I had to paste the following into my browser:

```html
https://portal.azure.com/#create/Microsoft.WebSiteSQLDatabase
```

fpmContosoUniversity.azurewebsites.net

fpmcontosouniversity.database.windows.net
Uid=DevAdmin
Pwd=(normal)

#### Azure SQL Database connection string
Server=tcp:fpmcontosouniversity.database.windows.net,1433;Initial Catalog=ContosoUniversity;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

## 1 of 10
[Getting Started](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro)

## 2 of 10
[Create, Read, Update, and Delete](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud)

## 3 of 10
[Sorting, filtering, paging, and grouping](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page)

## 4 of 10
[Database Migrations in EF.Core](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations)

## 5 of 10
[Creating a complex data model](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model)
