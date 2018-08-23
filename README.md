# mvcmovie - Introduction to .NET Core 2.1 (MVC)

Live demo is available here: https://dotnetmvc.azurewebsites.net/

This is an examaple project to be introduced to .NET, it used Entity Framework, LINQ & MVC. It uses packages from NuGet and is created in Visual Studio Community for MacOS.

It's based on the following tutorial:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app-xplat/?view=aspnetcore-2.1

## Configuration
It's imported to configure these application settings in order to get a working watchlist:

    "tmdb" : {
        "api_key": "",
        "session_id": "",
        "account_id": ""
    }

These can be configured in Azure under Application settings. They need to be in this format:

    tmdb:api_key


## How to run local
- Install visual studio with brew or using browser
    - `brew install visual-studio`
    - https://visualstudio.microsoft.com/vs/mac/
- `git clone https://github.com/TimvdEijnden/mvcmovie.git`
- `cd mvcmovie`
- `dotnet run`
- browse to http://localhost:5000

## How to run on Heroku
- create a Heroku app
- login to Heroku & Heroku container from console
    - heroku login
    - heroku container:login
- `git clone https://github.com/TimvdEijnden/mvcmovie.git`
- `cd mvcmovie`
- `dotnet publish -c Release`
- `cp Dockerfile ./bin/Release/netcoreapp2.1/publish/`
- `docker build -t mvcmovie_netcore2.1 ./bin/Release/netcoreapp2.1/publish/`
- `docker tag mvcmovie_netcore2.1 registry.heroku.com/<heroku_app_name>/web`
- `docker push registry.heroku.com/<heroku_app_name>/web`
- `heroku container:release web -a <heroku_app_name>`

