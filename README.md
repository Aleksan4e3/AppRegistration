# AppRegistration

Get Started
1. Run AppRegistration.sln
2. Select "DAL" project, set this one as Startup Project. 
Change the connectionString in "appsettings.json" according the connection type you will use.
3. Open package manager console and create database by running "update-database CompanySetNullWhenDelete"
4. Select "Presentation" project, change the connectionString in "appsettings.json" as before
5. Right click on "libman.json" and choose "Restore Client-Side Libraries"

That's all! You can run the project
