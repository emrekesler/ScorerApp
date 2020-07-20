pipeline {


agent any
environment {
dotnet = 'path\\to\\dotnet.exe'

}
stages {

stage('Build') {
     steps {

            bat (/dotnet restore ScorerApp.sln/)
            echo "Restore OK"
            bat (/dotnet build ScorerApp.sln -c Release/)
            echo "Build OK"
            bat (/dotnet publish ScorerApp.API\ScorerApp.API.csproj -c Release --output APIPublish/)
            echo "Publish OK"
            
      }
   }
}}