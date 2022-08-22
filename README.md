# Table of Contents

1. [Final Project](#final-project)
2. [Unit test](#unit-test)
3. [Sonarqube](#sonarqube)
4. [Kubernetes](#kubernetes)
5. [Jenkins](#jenkins)


# Final Project

It is the source code of my final project at ABB - Software Engineering 2 course.

The main goal of this project was to develop a unit test for the application that we have created on the step project, using Sonarqube to get line coverage, deploying the application using Kubernetes, and automating the process with the Jenkins pipeline.

# Unit test
In order to carry out unit test I have wrote 11 test. As you can see all of these tests passed succesfully.
<p align="center">
  <img src="screenshots/unittest.PNG" style="width:500px"/>
</p>

# Sonarqube
I have download Sonarqube server to my local machine. Then after following the steps I got following result:
<p align="center">
  <img src="screenshots/sonarqube.PNG" style="width:500px"/>
</p>

# Kubernetes
I have created deployment and service file for both my backend and frontend inside the k8s folder. After creating file first i have started my minikube cluster.
<p align="center">
  <img src="screenshots/minikube_start.png" style="width:500px"/>
</p>
Then I have applied my deployment and service files for backend and frontend
<br/>
<br/>
<p align="center">
  <img src="screenshots/kubectl_back.png" style="width:500px"/>
</p>
<p align="center">
  <img src="screenshots/kubectl_front.png" style="width:500px"/>
</p>
After those steps my pods are like this:

<p align="center">
  <img src="screenshots/kubectl_pods.png" style="width:500px"/>
</p>

Kubectl services:
<p align="center">
  <img src="screenshots/kubectl_services.png" style="width:500px"/>
</p>

Kubectl namespaces:
<p align="center">
  <img src="screenshots/kubectl_namespace.png" style="width:500px"/>
</p>

Now let's get minikube cluster ip for frontend
<br/>
<p align="center">
  <img src="screenshots/minikube_service_front.png" style="width:500px"/>
</p>
When we click the IP we get our front-end app:
<p align="center">
  <img src="screenshots/tablepage.png" style="width:500px"/>
</p>
<p align="center">
  <img src="screenshots/statuspage.png" style="width:500px"/>
</p>

My Minikube dashboard:
<p align="center">
  <img src="screenshots/minikube_dashboard.png" style="width:500px"/>
</p>

# Jenkins
I have created Jenkinsfile in order to automate process.  
My Jenkins pipeline output is like following:
<p align="center">
  <img src="screenshots/jenkinsfile.png" style="width:500px"/>
</p>

My Sonarqube quality gate:
<p align="center">
  <img src="screenshots/qualitygates.png" style="width:500px"/>
</p>
