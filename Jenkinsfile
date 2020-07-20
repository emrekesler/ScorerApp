pipeline {


agent any
environment {
}
stages {

stage('Build') {
     steps {

     echo "dotnet build --configuration Release"

            bat (/dotnet build --configuration Release/)
      }
   }
}}