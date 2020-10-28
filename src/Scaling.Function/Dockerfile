FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS installer-env

COPY . .

CMD dotnet build -c Release -o linux-x64

COPY ./linux-x64 /published-function

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:3.1-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:3.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/published-function", "/home/site/wwwroot"]
