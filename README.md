# Tariff Comparison

This project was developed to calculate tariffs based on the consumption of different electricity providers. The goal of this project is to implement this scenario using 
Clean Architecture, and adhering to the SOLID principles.

- Implemented Onion Architecture and adhered to SOLID principles to create a clean and maintainable architecture.

- Designed a rich domain model to encapsulate business logic effectively.

- Correlation logging is added to track a request as it moves through various parts of the application especially when unhandled exceptions occur.

## Testing

- Created an **IntegrationTest** project in the Xunit test framework under the tests solution folder to test the E2E RESTful APIs.
	
- Created a **UnitTest** project in the Xunit test framework to test the different tariffs that calculate the annual cost.

## Installation

- Developed this in .Net 6 with Visual Studio 2022.

- Used an in-memory database so don't need any RDBMS or NoSql on the local machine. But if you want to use the 
SQL Server database then you can modify the **DependencyInjection.cs** file into the Service project.


 
