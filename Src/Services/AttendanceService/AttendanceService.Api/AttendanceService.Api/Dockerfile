# Use .NET SDK image for build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the .csproj file from correct nested path
COPY ["Src/Services/AttendanceService/AttendanceService.Api/AttendanceService.Api/AttendanceService.Api.csproj", "AttendanceService.Api/"]

# Restore dependencies
RUN dotnet restore "AttendanceService.Api/AttendanceService.Api.csproj"

# Copy everything in the project
COPY . .

# Build the project
WORKDIR "/src/Src/Services/AttendanceService/AttendanceService.Api/AttendanceService.Api"
RUN dotnet build "AttendanceService.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "AttendanceService.Api.csproj" -c Release -o /app/publish

# Final stage - runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AttendanceService.Api.dll"]