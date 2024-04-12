FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS builder

COPY . .

WORKDIR /Company.Project

RUN dotnet restore

RUN dotnet publish /Web/Company.Project.Web/Company.Project.Web.csproj -c Release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "Company.Project.dll"]
