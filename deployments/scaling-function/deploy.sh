#!/bin/bash

# Install Keda on cluster
#.\apply-keda.sh

# Build docker image
# docker build -t scaling/queuetrigger-function .

# Azurite
# start with
#docker run -p 10000:10000 -p 10001:10001 mcr.microsoft.com/azure-storage/azurite

# Switch to local cluster
kubectl config use-context docker-desktop

# Create demo namespace
kubectl create namespace demo

# Use demo as the default namespace
#kubectl config set-context --current --namespace demo

# Create environment var STORAGE_CONNECTIONSTRING
#export STORAGE_CONNECTIONSTRING=DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://192.168.2.12:9999/devstoreaccount1;

# Create storage connection string secret
# kubectl -n demo create secret generic demo-secrets --from-literal="StorageConnectionString=UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://host.docker.internal"
#kubectl -n demo create secret generic demo-secrets --from-literal="DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;QueueEndpoint=http://host.docker.internal:9999/devstoreaccount1"
#or with secret string instead of stringData: RGVmYXVsdEVuZHBvaW50c1Byb3RvY29sPWh0dHA7QWNjb3VudE5hbWU9ZGV2c3RvcmVhY2NvdW50MTtBY2NvdW50S2V5PUVieTh2ZE0wMnhOT2NxRmxxVXdKUExsbUV0bENEWEoxT1V6RlQ1MHVTUlo2SUZzdUZxMlVWRXJDejRJNnRxL0sxU1pGUFRPdHIvS0JIQmVrc29HTUd3PT07UXVldWVFbmRwb2ludD1odHRwOi8vMTkyLjE2OC4yLjEyOjk5OTkvZGV2c3RvcmVhY2NvdW50MQ==
# Apply configmap
kubectl apply -f configmap.yaml

# Install the scaling-function
kubectl apply -f deployment.yaml

# Install KEDA queue trigger
kubectl apply -f keda-scaled-object.yaml