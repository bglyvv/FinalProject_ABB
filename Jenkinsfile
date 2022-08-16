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
                        sh 'docker push bglyvv/final-backend:latest'
                    }
                }
            }
        }
        stage('Push Frontend image'){
            steps{
                dir('Frontend'){
                    sh 'docker push bglyvv/final-frontend:latest'
                }
            }
        }
        stage('Start minikube'){
            steps{
                sh 'minikube start'
            }
        }
        stage('Update k8s for Backend'){
            steps{
                dir('k8s'){
                    dir('backend'){
                        sh 'kubectl apply -f deployment.yml'
                        sh 'kubectl apply -f service.yml'
                    }
                }
            }
        }
        stage('Update k8s for Frontend'){
            steps{
                dir('k8s'){
                    dir('frontend'){
                        sh 'kubectl apply -f deployment.yml'
                        sh 'kubectl apply -f service.yml'
                    }
                }
            }
        }
    }
}