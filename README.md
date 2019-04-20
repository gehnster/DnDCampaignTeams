# DnD Campaign Teams - A simple app for a simple purpose
[![Build status](https://dev.azure.com/pointyhatgames/FandomProject/_apis/build/status/FandomProject-ASP.NET%20Core-CI)](https://dev.azure.com/pointyhatgames/FandomProject/_build/latest?definitionId=5)

## Development Specs
- Visual Studio 2019 Professional
- .NET Core 2.2

## Notes
- Front-end is Razor Pages with Bootstrap 4
- Unit tests are using xUnit.
- EF Core is used with the provided in-memory database
- EF Core In-Memory is not a relational database and so doesn't follow referential integrity restraints and concurrency is not supported.