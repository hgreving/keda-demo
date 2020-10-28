#!/bin/bash

set -ex

# keda 2 instead of old 1.4
kubectl apply -f https://github.com/kedacore/keda/releases/download/v2.0.0-rc/keda-2.0.0-rc.yaml

# Deploy KEDA to the cluster
#kubectl apply -f ./keda/crds
#kubectl apply -f ./keda/