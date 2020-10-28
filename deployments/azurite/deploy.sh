#!/bin/bash

# Build docker image
# docker build -t azurite-k8s .

# Azurite
# start with
#docker run -p 10000:10000 -p 10001:10001 mcr.microsoft.com/azure-storage/azurite

# Switch to local cluster
kubectl config use-context docker-desktop

# Install azurite 
kubectl apply -f deployment.yaml

# Install azurite service 
kubectl apply -f service.yaml