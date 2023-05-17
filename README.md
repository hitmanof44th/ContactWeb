# Project Title

Contact List.

## Description

a simple contact manager and list display program

## Getting Started

### Dependencies

* entityFrameworkCore
* entityFrameworkCore.Design
* entityFrameworkCore.Tools
* entityFrameworkCore.SqlServer
* Newtonsoft.Json
* .net7

### Installing

* clone the project to local drive
* make sure ContactData is the start up project and run comands in console
```
Add-Migration InitialCreate
Update-Database
```
* add appsetting.json file
* add Appsettings to appsetting.json file
* add ConnectionsSTrings to appsetting.json file

```
{
  "AppSettings": {
    "ApiKey": "googlekeygoeshere"
  },
  "ConnectionStrings": {
    "Connectionstring": "Server=(localdb)\\mssqllocaldb;Database=ExampleDb;Trusted_Connection=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Executing program

* ensure Contactweb is your startup program
* Step-by-step bullets
```
code blocks for commands
```

