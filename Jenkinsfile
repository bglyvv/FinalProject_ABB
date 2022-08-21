pipeline {
    agent any
    environment {
        dockerhub=credentials('dockerhub')
    }
    stages {
        stage('Clone Git repository') {
            steps {
                git branch: 'main', credentialsId: 'github', url: 'https://github.com/bglyvv/FinalProject_ABB.git'
            }
        }
        stage('Unit Testing') {
            steps {
                dir('Backend') {
                    dir('FinalProject.UnitTests'){
                        sh 'dotnet test'
                    }
                }
                
            }
        }
        stage('Sonar Coverage'){
            steps{
                dir('Backend'){
                    
                    dir('FinalProject'){
                        withSonarQubeEnv('SonarQube'){
                            sh 'dotnet sonarscanner begin /k:"jenkins" /d:sonar.host.url="http://localhost:9000" /d:sonar.coverageReportPaths="./sonarqubecoverage/SonarQube.xml"'
                            sh 'dotnet build'
                            sh 'dotnet test "../FinalProject.UnitTests/FinalProject.UnitTests.csproj" --no-build --collect:"XPlat Code Coverage" -- DataCollectionRunSettings.DataCollectors.DataCollector.Configuration.Format=opencover'
                            sh 'reportgenerator "-reports:../FinalProject.UnitTests/TestResults/*/coverage.opencover.xml" "-targetdir:./sonarqubecoverage" "-reporttypes:SonarQube"'
                            sh 'dotnet sonarscanner end'
                        }
                    }
                }
            }
        }
        stage('Quality check'){
            steps{
                waitForQualityGate abortPipeline: true
            }
        }
        stage('Login to DockerHub') {
            steps {
                sh 'echo $dockerhub_PSW | docker login -u $dockerhub_USR --password-stdin'
            }
        }
        stage('Build Docker Compose file'){
            steps{
                sh 'docker-compose build'
            }
        }
        stage('Tag Docker images'){
            steps{
                sh 'docker tag final-backend bglyvv/final-backend'
                sh 'docker tag final-frontend bglyvv/final-frontend'
            }
        }
        stage('Push Backend image'){
            steps{
                dir('Backend'){
                    dir('FinalProject'){
                        sh 'docker push bglyvv/final-backend'
                    }
                }
            }
        }
        stage('Push Frontend image'){
            steps{
                dir('Frontend'){
                    sh 'docker push bglyvv/final-frontend'
                }
            }
        }
        stage('Start minikube'){
            steps{
                sh 'minikube start'
            }
        }
        stage('Update k8s for both Backend and Frontend'){
            steps{
                dir('k8s'){
                    sh 'kubectl apply -f backend.yml'
                    sh 'kubectl apply -f frontend.yml'
                }
            }
        }
    }
}