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

* clone the project to local drive using visualstudio
* make sure ContactData is the start up project and run comands in console visualstudio
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

## Help

if for some reason you are missing add-migration or update-database
```
Install-Package Microsoft.Entity.FrameworkCore.Tools
```

### Executing program

* ensure Contactweb is your startup program in visualstudio
* press f5 or the run icon on top