# dotnet CLI

## Create project

```CMD -- The instructions here assumed you are in the solution root folder.
dotnet new web -o Argus.IdentityServer
mkdir Argus.IdentityServer\_docs_
ECHO # Overview  > Argus.IdentityServer\_docs\01-overview.md
ECHO # dotnet CLI  > Argus.IdentityServer\_docs\02-dotnet-cli.md
dotnet sln add Argus.IdentityServer
dotnet add Argus.IdentityServer package IdentityServer4 --version 2.5.0
```

dotnet run --urls "http://localhost:50090"