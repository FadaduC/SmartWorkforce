# Use .NET SDK image for build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj from the correct nested path
COPY ["Src/Services/EmployeeService/EmployeeService.Api/EmployeeService.Api/EmployeeService.Api.csproj", "EmployeeService.Api/"]

# Restore dependencies
RUN dotnet restore "EmployeeService.Api/EmployeeService.Api.csproj"

# Copy everything in the project
COPY . .

# Build the project
WORKDIR "/src/Src/Services/EmployeeService/EmployeeService.Api/EmployeeService.Api"
RUN dotnet build "EmployeeService.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "EmployeeService.Api.csproj" -c Release -o /app/publish

# Final stage - runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# 👇 Important: Make API listen on port 8080
ENV ASPNETCORE_URLS=http://+:8080

# 👇 Important: Expose 8080 for Azure
EXPOSE 8080

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.Api.dll"]