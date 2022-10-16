# NETPCTest

This project was made for recruitment proccess for netPC. 
Its bassically CRUD project with angular frontend. Its implementing clean architecture concept. So there is no logic in api controllers and CQRS + mediatR is implemented. For most, validation is taking place in pipeline. There are comments on each of more interesting classes. If there are multiple classes that are the same, comment is on one of them.

It consists of three library projects and one .net core webApi with angular project. Its devided with clean architecture in mind. 

So, Infrastructure is project where most of dependecies and nugets are. There is startupSetup file to setup all of needed services, in here i also have data and dataaccess classes, so implementation of interfaces defined in core, middlware for exception handling and so on. 
In Core project, there are defined Db entites, exceptions and interfaces, it has no external dependecies and is not referecing any other project. 
In application project there are commandHandler and validator for all of the needed entites. 
In Web project, there are api controllers and angular application. 

In order to run it: 

Clone repo and open it in visual studio. 
Used db is sql, connection string is named "ContactsConnectionString"and its in the appsettings.development.json, you might need to change it to yours. Db is seed with one row of data, so after you change connection string to appropriate one, naviagate to Infrastructure project and open PM console, type in update-database command. 
Default applicationUrl is set to https://localhost:7061 and SPA proxy is run by default.
Youan navigate to swagger at https://localhost:7061/swagger. 
In angular app there is authorizaiton for contacts page, so in order to view it you must register, click to confirm email address and log in. Only view list and view for specific contact is working for now, no update nor delete. 
