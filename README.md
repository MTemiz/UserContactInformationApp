                																		
**Person Contact Information Application**

Adding/removing person, adding/removing contact information to person, listing person, getting details for a person and creating a report containing people is aimed.

You would use PersonContact.API to do person business.

When you triggered generate report method in Report.API,  the report request creating to database by report api and sends the message to RabbitMQ for location report informations.
Then PersonContactInfo.API reads message from RabbitMQ, selecting counts from database and sends back message to RabbitMQ take for Report.API.
Report.API reads the message, updates report request state and saves report result.

**PersonContactInfo Api**

* Adding/removing person
* adding/removing contact information to person
* listing person
* getting details for a person

**Report Api**

* creating a report containing people
* listing reports
* getting details for a report

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
Install Docker or Install PostreSQL and RabbitMQ

**Database Configuration**

if you would like to update connection string you will need to update PersonContactInfo.API/Report.API appsettings.json ConnectionStrings/DatabaseConnection section. Every project has a migration file, when you would run applications, databases will automatically created.

**Message Queue Bağlantısı**

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
