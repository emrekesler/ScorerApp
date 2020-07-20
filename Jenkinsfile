pipeline {


agent any
environment {
dotnet = 'path\\to\\dotnet.exe'

}
stages {

stage('Build') {
     steps {

     echo "dotnet build --configuration Release"

            bat (/dotnet build --configuration Release/)
      }
   }
}}