# dotnet CLI

## Create project

```CMD -- The instructions here assumed you are in the solution root folder.
dotnet new web -o Argus.IdentityServer
mkdir Argus.IdentityServer\_docs_
ECHO # Overview  > Argus.IdentityServer\_docs\01-overview.md
ECHO # dotnet CLI  > Argus.IdentityServer\_docs\02-dotnet-cli.md
dotnet sln add Argus.IdentityServer
dotnet add Argus.IdentityServer package IdentityServer4 --version 2.5.0
dotnet add Argus.IdentityServer package Serilog.AspNetCore --version 3.2.0
dotnet add Argus.IdentityServer package Serilog.Sinks.RollingFile --version 3.3.0
```

## Running using a different url

```CMD
dotnet run --urls "http://localhost:50090"
```