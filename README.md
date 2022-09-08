# Tariff Comparison

This project is developed to complete a tech challenge.

## Installation 

I developed this in.Net 6 with Visual Studio 2022.
	
I implemented Onion Architecture to design the clean & logical layers by considering the SOLID principle.

I designed the Rich domain model.

I used an in-memory database so don't need any RDBMS or NoSql on the machine. But if we want to use the 
SQL Server database then we can modify the **DependencyInjection.cs** file into the Infrastructure layer.

## Testing

I created an **IntegrationTest** project under the tests solution folder to test the RESTful product api.
	
I also created a **UnitTest** project to test the different tariffs that calculates the annual cost.

I fully tested the code and working without any error.



 
