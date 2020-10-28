#!/bin/bash

set -ex

# Remove KEDA from the cluster
kubectl delete -f ./keda/
kubectl delete -f ./keda/crds
