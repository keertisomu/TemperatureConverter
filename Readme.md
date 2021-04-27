# Dev Framework versions
 - Angular v8
 - Backend (ASP.NET Core) v3.1
 - Unit tests (xUnit - v2.4.0)
 - VS 2019

# git 
 - git clone https://github.com/keertisomu/TemperatureConverter.git

# Solution structure
 - TemperatureConverter.WebApp: This is the main .Net Core / Angular Spa project. ClientApp folder within this project contains the Angular code.
 - TermperatureConverter.Core: Contains the Temperature conversion logic
 - TemperatureConverter.UnitTests: xUnit tests for the temperature conversion

# Build setup
 - cd ...\TemperatureConverter\TemperatureConverter.WebApp\ClientApp
 - npm install
 - Build TemperatureConverter.sln
 - Set TemperatureConverter.WebApp as the startUp project in VS2019
 - Verify .Net Core app starts on both http://localost:5000 and https://localhost:5001
 - Verify TemperatureConverter page shows up in browser tab.  

# (Note) : Its not required to run ng serve on Angular as the .NetCore/AngularSpa starts the angular as well.

# Troubleshooting:
 - If you encounter a error "Failed to bind to address localhost:5000" , please check what other application is listening on this port(netstat -ano | findstr :5000) and kill these processes.

# Static code analysis in angular
 - tsLint is used for static code analysis
