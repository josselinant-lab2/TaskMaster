# TaskMaster

# EF Core installation / Database setup

You should run you Docker container with:

```
docker compose up -d
```

Then apply the migrations:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```