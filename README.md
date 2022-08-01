# Stuntman-Blazor

A blazor application to manage stuntman

![image](https://raw.githubusercontent.com/JeroenBl/Stuntman/main/assets/logo.png)

__Stuntman__ can be used to create -well; stuntman_ who are always happy to test-drive your applications or HelloID connectors.

> __Stuntman__ can be used as an _HR_ source in HelloID. The HelloID source connector can be found at: https://github.com/JeroenBL/HIDStuntman

## Used nuget packages

- EntityFrameworkCore.Sqlite
- EntityFrameworkCore.Tools
- Bogus
- FluentValidation
- MudBlazor
- SwashBuckle.AspNetCore.Swagger
- SwashBuckle.AspNetCore.SwaggerGen
- SwashBuckle.AspNetCore.SwaggerUI

## Table of contents

* [Prerequisites](#Prerequisites)
* [Installation](#Installation)
* [UI](#UI)
* [RESTapi](#RESTapi)
* [Release history](#Release-history)
* [Contributing](#Contributing)

## Prerequisites

- .NET 6

## Installation

An installation script / package is currently not available. Installation can only be done manually by building the source project.

## UI

The UI is -hopefully- self-explanatory. By default an empty database is provided. You can 'fill' the database from the application. (Settings -> Manage database). There you will find the option 'Fill database'. This will create both persons/contract and departments. The number of contracts created for each person can be specified in the appsettings.json. Default this value is set to a max. of 3.

![UI](https://raw.githubusercontent.com/JeroenBL/Stuntman-Blazor/main/assets/app.png)

## RESTapi
The application comes with an RESTapi. The RESTapi can be used to integrate the application with other systems.
