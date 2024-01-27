#USE THE OFFICIAL IMAGES AS A PARENT IMAGE

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# set the working directory

WORKDIR /app

#copy the file from yout host to your current location

COPY . ./

# RUN the command inside your image filesystem
RUN dotnet restore

RUN dotnet build "MenuApi/MenuApi.csproj" -c Release -o /app/build

#BUILD the application
RUN dotnet publish "MenuApi/MenuApi.csproj" -c Release -o /app/publish

#BUILD runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY --from=build-env /app/publish .

EXPOSE 7008

#RUN the specified command with the container
ENTRYPOINT [ "dotnet","MenuApi.dll" ]