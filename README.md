# Introduction 
The solution contains the APIs:
- Tenant admin: expose APIs for front-end to manage all the tenant information and settings.
- Tenant specific app: expose APIs for front-end to manage the single tenant.


# Project structure
The project consists of 3 seperate sections located inside src folder:

## 1. tenant

### Api:

Project Api to expose APIs for front-end containing all the logic to manage all the tenant database connectionstring, azure tenant Id, infrastructure,...

Configurations in appsettings.json include some section of AzureAd to input keys/values for the app running with Azure Active Directory. Note that TenantId is always 'organizations' to support for multitenant app. AuthorizationUrl and TokenUrl are for Swagger authorization. There is TenantSettings section to provide the database connection string template for each user tenant to be created.

### Core:

Project includes all things that need to support for Api project including: persistance with EntityFramework Core, bussiness logic, swagger, automapper configurations,...

The migrations locates in Persistance/Migrations. For each change to domain entites, please add new migration using .NET Core CLI or Package Manager Console


## 2. app

### Api

Project Api to expose APIs for front-end containig all the logic to manage the single tenant data and logic: matter,...

Configurations in appsettings.json include some section of AzureAd to input keys/values for the app running with Azure Active Directory. Note that TenantId is always 'organizations' to support for multitenant app. AuthorizationUrl and TokenUrl are for Swagger authorization. There is TenantSettings section to provide the database connection string template for each user tenant to be created. There are Tenant setting to store the admin tenant api urls.

### Application

Project contains all the interfaces to be implemented by Infrastructure and DTOs, mapping between domain entities and DTOs.

### Common

Project contains all common functions to be used accross projects in solution including some helper functions, logging, configurations, guards,...

### Domain

Project contains domain entities to be used as a data mapping with database.

### Infrastructure

Project contains all the business logic, persistance, securities, configurations for the Api.

The migrations locates in Persistance/Migrations. For each change to domain entites, please add new migration using .NET Core CLI or Package Manager Console

### Security

Project contains the common authentication / authorization functions for Api project to consume.

## 3. test

There are 2 projects in this section and still pending. This needs to be implemented with unit tests and integration tests later.
