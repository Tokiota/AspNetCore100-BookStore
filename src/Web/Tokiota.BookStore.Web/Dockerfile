FROM microsoft/aspnetcore:1.0.1
ENTRYPOINT ["dotnet", "Tokiota.BookStore.Web.dll"]
ARG source=.
WORKDIR /app
EXPOSE 5000
COPY $source .