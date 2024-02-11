# Pandologic Assignment

A _Pandologic Assignment_ is a simple CRUD operations application, 
it utilizes the [three-tier architecture](https://www.ibm.com/topics/three-tier-architecture) which emphasizes the separation between UI and business tiers, \
The server side uses a .NET core built-in dependency injection mechanism, entityframework, generic repository pattern, unit-of-work pattern, and more... \
The UI's use [Angular 15](https://github.com/shlomielbaz/employee-management/blob/main/requirement.md)

The project requirements can be found in [requirments.md](https://github.com/shlomielbaz/employee-management/blob/db073e2158e8816dd8e849e1cdc481ab5e8a35c0/requirement.md)

### The Project Structure
- **PA.Api** - responsible for incoming HTTP messages.
    - _Controllers_ - contains classes that handle the RESTFul APIs.
- **PA.Data** - contains the DB context, repository, migration scripts and [SQLIte database](https://www.sqlite.org/index.html) file.
- **PA.Domain** - contains the "domain" app, which is an application abstraction.
  - _Entities_ - contains classes that reflect the DB schemas. 
  - _Enums_ - contains the application types. 
  - _General_ - contains classes for general use. 
  - _Helpers_ - contains helpers classes.
  - _Interfaces_ - contains interfaces that represent the application abstraction. 
  - _ViewModels_ contains classes representing data transfer objects with UI views reflection.
- **PA.Services** - represent the transformation tier which is a mediator between the messaging and business tiers, and transforms incoming messages from/to ViewModel's.
- **PA.Site** - contains the Angular (client-side) project

### A HTTP Message Flow Schema:
![app-diagram](https://user-images.githubusercontent.com/426076/220337080-ddf6706e-fbb2-4ce1-aede-105d4b973a5e.png)

## Build the project's
- From PA.Data project run `update-database` migration command
- Server Side - build the project by Visual Studio or from PA.Api project run the `dotnet build` CLI command.
- Client Side - from PA.Site run `npm install`

## Running the project's
- Using CLI's - from PA.Api project run `dotnet run`, from PA.Site run `npm start`

## Some snap-shots from the UI
