# StockMicroservices-CleanArchitecture

## Description

A project demonstrating various web technologies and techniques. This StockMicroservices application takes the Stock application and implements it with clean architecture. This application is comprised of Identity Server for authentication, a React-based web client and a web-api all running on containers. It leverages Docker, Ocelot API Gateway, RabbitMq for messaging. It also uses Mongo Db for database persistence as well as Mongo-Express. The API from the Stock application has been re-implemented with a backing store of Mongo-Db. 

## List of projects

### StockMicroservices.IdentityServer

* An ASP.Net Core server for authentication using Identity Server 4. Protects the API resources defined

### StockMicroservices.API

* An ASP.Net Core Web API project. Contains all stock data 

### StockMicroservices.Domain

* A .Net 6.0 project. Contains the domain models as well as business rules

### StockMicroservices.Infrastructure

* A .NET 6.0 project. Implements the Infrastructure layer and all the external services

### StockMicroservices.Application

* A .Net 6.0 project. Implements the Application Layer and orchestrates the use cases

### StockMicroservices.Abstractions

* A .Net 6.0 project. Defines the data transfer objects

### StockMicroservices.EventBus.Common

* A .Net 2.0 Standard. Common EventBus definitions 

### StockMicroservices.WebClient

* A React based web client that authenticates the user using the Stock.IdentityServer and retrieves data from the Stock.API

### StockMicroservices.StockMarketUpdater

* A c# console application that periodically updates the Stocks data.


## How to Run

Ensure that you have .NET 6.0, Node js and Docker Desktop installed. 

* Select docker-compose from the 'Startup Projects' toolbar and run 'Docker Compose' or within the solution directory, open a command prompt and run 'docker-compose up'.
* Navigate to a browser window and go to the address 'http://localhost:44100'. This opens the React web client.
