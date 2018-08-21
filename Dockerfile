FROM microsoft/dotnet:2.1.2-aspnetcore-runtime

WORKDIR /app

COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet MvcMovie.dll