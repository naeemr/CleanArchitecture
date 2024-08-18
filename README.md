# Tariff Comparison

This project is developed to calculate different tariffs for electricity providers using clean architecture.

## Installation 

Developed this in .Net 6 with Visual Studio 2022.
	
Implemented Onion Architecture and SOLID principle to design the clean architecture.

Designed a Rich domain model.

Used an in-memory database so don't need any RDBMS or NoSql on the machine. But if you want to use the 
SQL Server database then you can modify the **DependencyInjection.cs** file into the Service project.

## Testing

Created an **IntegrationTest** project under the tests solution folder to test the RESTful product API.
	
Created a **UnitTest** project to test the different tariffs that calculate the annual cost.



 
