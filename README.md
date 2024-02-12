# Pandologic Assignment

A _Pandologic Assignment_ is a simple CRUD operations application, 
it utilizes the [three-tier architecture](https://www.ibm.com/topics/three-tier-architecture) which emphasizes the separation between UI and business tiers, 

The server side uses a .NET core built-in dependency injection mechanism, entity framework, generic repository pattern, unit-of-work pattern, and more... 

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

## Running the project's
- **Database** - The SQLIte database already exists, and is located in the `PA.Data` project, if you want to fresh it, just delete the files `PA.Data/database.db` from PA.Data project and then run migrations commands such as `update-database` (PowerShell) or `dotnet ef database update` (bash terminal) 
- **Server Side** - build the project by Visual Studio or from PA.Api project performe the `dotnet build` CLI command. <img width="379" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/06733a20-2d80-4b97-9cf7-13f4730f117b">
- **Client Side** - from PA.Web run `npm install`
  
### Using CLI's:
- **Server** - from PA.Api project run `dotnet run`,
- **Client** - from PA.Web run `npm start`
- **Configure The Client** make sure the API end-point is set properly, please set the `apiUrl` in `PA.Web/src/app/app.config.ts`, for example, the following is a snapshot from `dotnet run` command, the client URL is in the line `Now listening on: http://localhost:5218`

## Snapshots
#### CLI logs snapshots
<img width="632" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/10547a92-eac5-41a2-a805-ea970e7536b1"> \
`dotnet run` command log

<img width="824" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/5e138120-fef9-4341-a8bb-fe01f73b3982"> \
`npm start` command log

#### UI snapshots
<img width="1247" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/73ccf4a5-a03e-43fa-894b-04ca74de1013">

#### DB snapshots
<img width="1070" alt="image" src="https://github.com/shlomielbaz/pandologic-assignment/assets/426076/369c6eba-b40e-4657-87ee-4219bd6dbbde"> \
The table fields follow the entity attribute declarations

```C#
[Table("jobs")]
public class Job : BaseEntity
{
    [Column("date")]
    public DateTime Date { get; set; }

    [Column("total_jobs")]
    public int TotalJobs { get; set; }

    [Column("total_views")]
    public int TotalViews { get; set; }

    [Column("predicted_views")]
    public int PredictedViews { get; set; }
}
```
