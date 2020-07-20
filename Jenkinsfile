pipeline {
agent any
environment {
}
stages {

stage('Build') {
     steps {
            bat (/dotnet build --configuration Release/)
      }
   }
stage('Pack') {
     steps {
           bat (/dotnet pack --no-build --output nupkgs/)
      }
   }

}