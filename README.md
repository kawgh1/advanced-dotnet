# Advanced Dotnet
- Covering Dotnet, Kubernetes, Docker, Azure DevOps integration
- Course [link](https://www.udemy.com/course/dot-net-microservices-ecommerce-project-azure-devops-kubernetes-aks/)


- .NET Backend + Angular Client
    - I mostly copied this as the goal is not to re-learn how to build a .NET API and Angular front end.


- ### User Service
  - .NET8 Backend w/ Postgres DB 
  - using Dapper (instead of Entity Framework) and AutoMapper
  - Swagger
  - ### localhost: https://localhost:7186/swagger/index.html
  - Routes
    - `/api/auth/login`
    - `/api/auth/register`
  - ### User Service API
    - Nuget Packages:
      - `<PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />`
      - `<PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.21.0" />`
      - `<PackageReference Include="AutoMapper" Version="13.0.1" />`
      - `<PackageReference Include="Swashbuckle.AspNetCore" Version="6.7.3" />`
    - #### Core
      - Nuget Packages:
        - `<PackageReference Include="AutoMapper" Version="13.0.1" />`
        - `<PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />`
        - `<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.1" />`
    - #### Infrastructure
      - Nuget Packages:
        - `<PackageReference Include="Dapper" Version="2.1.35" />`
        - `<PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="8.0.0" />`
        - `<PackageReference Include="Npgsql" Version="8.0.4" />`
        - `<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="9.0.1" />`

- ### Angular Client
  - Basic Angular frontend
  - User Register and Login
  - Products - Create, Read, Update, Delete
  - Orders - Create, Read, Update, Delete
  - ### localhost:4200

- ### Product Service
  - .NET8 Backend w/ MySQL DB
  - using Entity Framework and AutoMapper
  - Swagger
  - ### localhost: https://localhost:7260/swagger/index.html
  - Routes
    - `/api/auth/login`
    - `/api/auth/register`
  - ### Product Service API
    - Nuget Packages:
      - `<PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />`
      - `<PackageReference Include="Microsoft.VisualStudio.Azure.Containers.Tools.Targets" Version="1.21.0" />`
      - `<PackageReference Include="MySql.Data" Version="9.0.0" />`
      - `<PackageReference Include="MySql.EntityFrameworkCore" Version="8.0.5" />`
      - `<PackageReference Include="Swashbuckle.AspNetCore" Version="6.7.3" />`
    - #### Business Logic Layer
      - Nuget Packages:
        - `<PackageReference Include="AutoMapper" Version="13.0.1" />`
        - `<PackageReference Include="FluentValidation.AspNetCore" Version="11.3.0" />`
        - `<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.1" />`
    - #### Data Access Layer
      - `<PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="8.0.1" />`
      - `<PackageReference Include="MySql.Data" Version="9.0.0" />`
      - `<PackageReference Include="MySql.EntityFrameworkCore" Version="8.0.5" />`
      - `<PackageReference Include="System.Text.Json" Version="8.0.4" />`