# STAGE01 - Build application and its dependencies
FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app
COPY CI_CD_WebApp/*.csproj ./
COPY . ./
RUN dotnet restore 

# STAGE02 - Publish the application
FROM build-env AS publish
RUN dotnet publish -c Release -o /app

# STAGE03 - Create the final image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
LABEL Author="Suisyola"
LABEL Maintainer="Suisyola is the maintainer"
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CI_CD_WebApp.dll", "--server.urls", "http://*:80"]