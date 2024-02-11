# Pandologic Assignment

A _Pandologic Assignment_ is a simple CRUD operations application, 
it utilizes the [three-tier architecture](https://www.ibm.com/topics/three-tier-architecture) which emphasizes the separation between UI and business tiers, \

The server side uses a .NET core built-in dependency injection mechanism, entityframework, generic repository pattern, unit-of-work pattern, and more... \

The UI's use [Angular 15](https://github.com/shlomielbaz/employee-management/blob/main/requirement.md)

### The Project Structure
- **PA.Api** - responsible for incoming HTTP messages.
    - _Controllers_ - contains classes that handle the RESTFul APIs.
- **PA.Data** - contains the DB context, repository, migration scripts and [SQLIte database](https://www.sqlite.org/index.html) file.
- **PA.Domain** - contains the "domain" app, which is an application abstraction.
  - _Entities_ - contains classes that reflect the DB schemas. 
  - _Enums_ - contains the application types. 
  - _General_ - contains classes for general use. 
  - _Interfaces_ - contains interfaces that represent the application abstraction. 
  - _Models_ contains classes representing data transfer objects with UI views reflection.
- **PA.Services** - represent the transformation tier which is a mediator between the messaging and business tiers, and transforms incoming messages from/to ViewModel's.
- **PA.Web** - contains the Angular (client-side) project

### A HTTP Message Flow Schema:
![app-diagram](https://user-images.githubusercontent.com/426076/220337080-ddf6706e-fbb2-4ce1-aede-105d4b973a5e.png)

## Build the project's
- The SQLIte database is already exist, if you want to fresh it, just delete the files `PA.Data/database.db`, `PA.Data/database.db-shm` and `PA.Data/database.db-wal` from PA.Data project run `update-database` or `dotnet ef database update` migration command
- Server Side - build the project by Visual Studio or from PA.Api project run the `dotnet build` CLI command.
- Client Side - from PA.Web run `npm install`

## Running the project's
- _**Using CLI's**_
- **Server** - from PA.Api project run `dotnet run`,
- **Client** - from PA.Web run `npm start`
- **Configure The Client** make sure the API end-point is set properly, please set the `apiUrl` in `PA.Web/src/app/app.config.ts`, for example the following is a snapshot from `dotnet run` command, the client URL is in the line `Now listening on: http://localhost:5218`

<img width="632" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/10547a92-eac5-41a2-a805-ea970e7536b1">


## The UI snapshots
<img width="1247" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/73ccf4a5-a03e-43fa-894b-04ca74de1013">

