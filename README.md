## Implementation Web API(BlogSN project)
---
---
### Toolset
- .Net Core
- PostgreSQL
- Swagger for automated API documentation
- EntityFramework
___
### Usage
- Update `appsettings.json` for appropriate database
    ```json
    "ConnectionStrings": {
        "ConnectionString": "Host=hostname;Database=dbname;Port=port;Username=username;Password=password"
    }
    ```
- Add migration
    ```
    dotnet ef migrations add Initial
    ```
- For updating database use this command:
    ``` 
    dotnet ef database update
    ```