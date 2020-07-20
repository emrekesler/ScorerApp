pipeline {
agent any
environment {
dotnet = 'path\\to\\dotnet.exe'
}
stages {

stage('Build') {
     steps {
            bat 'dotnet build --configuration Release'
      }
   }
stage('Pack') {
     steps {
           bat 'dotnet pack --no-build --output nupkgs'
      }
   }

}