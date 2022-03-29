# Urlhandling-Short-Url
 This Repository is to project API UrlHandling that create short URLs, the project Urlhandling
 was developer in .net core 3.1 on the Visual Studio 2019 and SQL Server 2012+
 

Instructions to run this API project

1 - Load this project in local repository

2 - Open the projet no Visual Studio 2019

3 - Set up the connection string from your SQL Server data base in file appsettings.Development.json to run in development environment.

4 - Execute o script  CREATE_TABLE_UrlLink.sql in scripts paste or Execute o command Update-DataBase in Package Manager Console Visual Studio
with default project UrlHandling.Data 

5 - Check if the table UrlLink was created on your SQL Server DataBase

6 - Execute the project in Development Environment(ISS Dev)

7 - Use the page https://localhost:44399/swagger/index.html but check if local port is really 44399

7 - Use the project react front-end https://github.com/edmarssk/UrlShortLinkReactFront and run together with this API project.
