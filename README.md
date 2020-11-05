# KEDA  Azure Storage Queue demo

## Prerequisites
- Working K8s cluster
- Microsoft Storage Emulator
- Local docker registry: https://www.quickdevnotes.com/hosting-first-private-docker-registry/

## Apply Keda on your K8s cluster
- Use deployments/scaling-function/apply-keda.sh to install KEDA on your K8s cluster.

## Build docker image
Go to the folder Scaling.Function and run: `docker build -t scaling/queuetrigger-function .`

## Publish the docker image 
I used a local docker repo (), but you can also use your Docker Hub, but then you needs to change the image tag in: deployments/scaling-function/deployment.yaml
Go to the folder Scaling.Function and run: 
`docker build -t scaling:demo-v4 .`
`docker tag scaling:demo-v4 localhost:5000/scaling/demo-v4`
`docker push localhost:5000/scaling/demo-v4`

## Deploy the demo scaling function to your K8s cluster
- Use deployments/scaling-function/deploy.sh to install the scaling-function on your K8s cluster.

## Check that there is deployment
`kubectl get deploy -n demo`

## Check that there are no pods yet
`kubectl get pods -n demo`

## Add messages to Azure storage queue: 'demo-scaling-items'
Go to the folder Scaling.QueueFillApp and run `dotnet run 10 20`
This command will add 10 message to the queue with. Each message durations is 20 seconds. The default duration is 5 seconds. 

## Check that there are pods active
`kubectl get pods -n demo`

## Remove the demo scaling function from your K8s cluster
- Use deployments/scaling-function/remove.sh to remove the scaling-function from your K8s cluster.

## Remove Keda on your K8s cluster
- Use deployments/scaling-function/remove-keda.sh to remove KEDA from your K8s cluster.
