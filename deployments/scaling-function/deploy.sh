#!/bin/bash

# Install Keda on cluster
#.\apply-keda.sh

# Build docker image
# docker build -t scaling/queuetrigger-function .

# Switch to local cluster
#kubectl config use-context docker-desktop

# Create demo namespace
kubectl create namespace demo

# Use demo as the default namespace
#kubectl config set-context --current --namespace demo

# Apply configmap
kubectl apply -f configmap.yaml

# Install the scaling-function
kubectl apply -f deployment.yaml

# Install KEDA queue trigger
kubectl apply -f keda-scaled-object.yaml