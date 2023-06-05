# C# WebAPI MVC with a Postgres Database.

Use the MVC pattern with Entity Framework to communicate with a Postgres database Create an API which has a database behind it.  
Use Database Migrations and C# classes to create and model the database

Instructions Fork this repository Clone your fork to your machine Open the project in Visual Studio

# Core Exercise

Look at the OpenAPI schema below, your task is to set up a remote Postgres Database on ElephantSQL and connect to it from your code.
Your Swagger should have all CRUD functionality for the Employee Model.

The database table for Employees will be something like this:


| Field       | Type         | Information |
|-------------|--------------|-------------|
| id          | Serial       | PK          |
| name        | VARCHAR(250) |             |
| jobName     | VARCHAR(250) |             |
| salaryGrade | VARCHAR(10)  |             |
| department  | VARCHAR(50)  |             |



You should use C#, EntityFramework the Postgres ElephantSQL.

Add tests as usual to test the functionality of the Model layer, you do not need to test the repository code directly.

Here is the spec for the Core Criteria: [Core Spec](https://boolean-uk.github.io/java-api-mvc-with-postgres/)

# Extension Exercise

Add in the rest of the Schema based on the OpenAPI Spec linked below, modify the original Employee table to use Foreign Keys as appropriate based on the two new tables you will create, you can use EntityFramework to help run the migrations and populate the tables.

Add in models and other classes to enable API calls to be made which will match the endpoints specified in the schema.

Here is the spec for the Extension Criteria: [Extension Spec](https://boolean-uk.github.io/java-api-mvc-with-postgres/extensions.html)
