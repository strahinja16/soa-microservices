FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY DataMicroservice/DataMicroservice.csproj DataMicroservice/
RUN dotnet restore DataMicroservice/DataMicroservice.csproj
COPY . .
WORKDIR /src/DataMicroservice
RUN dotnet build DataMicroservice.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DataMicroservice.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY DataMicroservice/data /app/data
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataMicroservice.dll"]
