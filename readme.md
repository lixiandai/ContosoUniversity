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
In order to host both the ASP.Net Core Web and the SQL Database in Azure I performed the steps shown below.

### Create Azure Web Site + SQL Server
I created a combination of Azure Web Site plus Azure SQL Server using a special template.

1. Login to your subscription on the [Azure Portal GUI](http://portal.azure.com).

1. Click on the large green + symbol with the word `New` after it.

1. In the search box, type `Web App + SQL` and press Enter

1. In the screen that opens up, click on `Web App + SQL`.

1. In the screen that opens up, click on the `Create` button.

1. Click on the `See all` link that appears slightly to the right of the words `FEATURED APPS`.
If you do not perform this step, you will have trouble finding the correct Azure template.

1. In the `Web Apps` setion, click on `Web App + SQL`.

1. Follow the instructions to create both the Web App and the Azure SQL Database.

If you cannot find the template or want to navigate directly to it, paste the following URL into your browser:

```html
https://portal.azure.com/#create/Microsoft.WebSiteSQLDatabase
```

I used the following to define the Azure web:

fpmContosoUniversity.azurewebsites.net

I used the following to define the Azure SQL Server:
fpmcontosouniversity.database.windows.net
Uid=DevAdmin
Pwd=(normal)

#### Azure SQL Database connection string

```json
Server=tcp:fpmcontosouniversity.database.windows.net,1433;Initial Catalog=ContosoUniversity;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

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

Example of using PowerShell cmdlets intead of ef cmd prompt:

```powershell
Add-Migration ColumnFirstName -StartupProject ContosoUniversity -Verbose
Update-Database
```

## 6 of 10

[Reading related data](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/read-related-data)

## 7 of 10

[Updating related data](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/update-related-data)
