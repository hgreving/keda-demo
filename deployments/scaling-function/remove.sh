#!/bin/bash

# Install Keda on cluster
#.\apply-keda.sh

# Switch to local cluster
kubectl config use-context docker-desktop

# Delete KEDA queue trigger
kubectl delete -f keda-scaled-object.yaml

# Delete the scaling-function
kubectl delete -f deployment.yaml

# Delete configmap
kubectl delete -f configmap.yaml

# Delete demo namespace
kubectl delete namespace demo