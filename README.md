                																		
**Person Contact Information Application**

Adding/removing person, adding/removing contact information to person, listing person, getting details for a person and creating a report containing persons is aimed.

You would use PersonContact.API to do person business.

When you triggered generate report method in Report.API,  the report request creating to database by report api and sends the message to RabbitMQ for location report informations.
Then PersonContactInfo.API reads message from RabbitMQ, selecting counts from database and sends back message to RabbitMQ take for Report.API.
Report.API reads the message, updates report request state and saves report result.

**PersonContactInfo Api**

http://localhost:5051/swagger/index.html

* Add/remove person
* Add/remove contact information to person
* Lists persons
* Provides details for a person

**Report Api**

http://localhost:5095/swagger/index.html

* Creates a report containing people
* Lists reports
* Provides details for a report

![image](https://user-images.githubusercontent.com/43716821/173297766-dff32fce-2fba-463e-9ee6-744b7c0a4195.png)


**Technologies**

[ASP.Net Core 6](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0)

[EntityFramework Core 6](https://docs.microsoft.com/en-us/ef/core/)

[MediatR](https://github.com/jbogard/MediatR)

[AutoMapper](https://automapper.org/)

[RabbitMQ](https://www.rabbitmq.com/)

[PostgreSQL](https://www.postgresql.org/)

[Polly](http://www.thepollyproject.org/)

[XUnit](https://xunit.net/)

[Moq](https://github.com/moq)

[Shouldly](https://github.com/shouldly/shouldly)

[Swagger](https://swagger.io/)

**Getting Started**

Install the latest .NET 6 SDK

Install Docker / Install PostreSQL and RabbitMQ

**Database Configuration**

if you would like to update connection string you will need to update PersonContactInfo.API/Report.API appsettings.json ConnectionStrings/DatabaseConnection section. Every project has a migration file, when you would run applications, databases will automatically created.

**Message Queue Configuration**

if you would like to update rabbitmq connection string you will need to update PersonContactInfo.API/Report.API appsettings.json RabbitMQConnection section.


**Overview**

**Domain**

* Database Entities

**Application**

* Mapping profiles
* Extensions,
* Custom exceptions,
* Integration Dtos,
* Integration Events,
* Interfaces,
* Commands, Queries, Command  Query Handlers
* Dtos

**Infrastructure**

* Database entity configurations,
* Database context,
* Repositories,
* Migration

**Api**

* Services,
* Middlewares,
* Global exception handling
* Controllers

**Code Coverage %62,06**
![image](https://user-images.githubusercontent.com/43716821/173254827-fe91a406-2ffb-449b-a959-001f771fdb5c.png)

