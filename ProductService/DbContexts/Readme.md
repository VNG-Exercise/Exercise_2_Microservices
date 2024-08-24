# Step to create migration 
Reference https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
Upgrade command
```
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

- cd ProductService
- dotnet ef migrations add {InitialProject} --context ProductDbContext
dotnet ef migrations add InitialProject --context ProductDbContext
