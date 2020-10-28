#!/bin/bash

# Build docker image
# docker build -t azurite-k8s .

# Azurite
# start with
#docker run -p 10000:10000 -p 10001:10001 mcr.microsoft.com/azure-storage/azurite

# Switch to local cluster
kubectl config use-context docker-desktop

# Remove azurite service 
kubectl delete -f service.yaml

# Remove azurite 
kubectl delete -f deployment.yaml
