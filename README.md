## 1. Rodar os migrations e os seeders
```csharp
dotnet ef database update
```

## 2. Build da aplicação para rodar os seeders
``` csharp
dotnet run
```

## 3. Desabilitar os seeders para não popular novamente
Abrir o arquivo startup.cs e comentar as linhas: 100, 101 e 102


## 4. Build com Watch
```csharp
dotnet watch run
```

## Api endpoints
[https://www.getpostman.com/collections/5b653ce28aaf4b81c38f](https://www.getpostman.com/collections/5b653ce28aaf4b81c38f)