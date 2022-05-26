## Implementation Web API(BlogSN project)
---
[![ci/cd](https://github.com/GiaSoPas/BlogSN.Backend/actions/workflows/aws.yml/badge.svg?branch=master&event=push)](https://github.com/GiaSoPas/BlogSN.Backend/actions/workflows/aws.yml)

Frontend: https://github.com/t-eldar/blog-sn

---
### Demo

[![Demo](https://img.shields.io/badge/DEMO-not--available-red?style=for-the-badge)](http://blogsn-lb-438498043.eu-central-1.elb.amazonaws.com/)

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
