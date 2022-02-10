# Digital_Accept
	It is a template api used as the basis for the C# backend course on Biopark Connect.

## Migrations

To initialize dotnet-ef
```
	dotnet tool install --global dotnet-ef
```

To create a migration
```	
	dotnet ef migrations add <aqui_um_nome_para_migration> --project .\Digital_Accept.Data --startup-project .\Digital_Accept.WebAPI --context ApplicationDbContext


	dotnet ef migrations add InitialLoading --project .\Digital_Accept.Data --startup-project .\Digital_Accept.WebApi --context ApplicationDbContext
```

To execute a migration
```
	dotnet ef database update --project .\Digital_Accept.Data --startup-project .\Digital_Accept.WebAPI --context ApplicationDbContext
```

# Digital_Accept
