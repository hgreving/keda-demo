FROM mcr.microsoft.com/azure-storage/azurite

# Blob Storage Port
EXPOSE 10000
# Queue Storage Port
EXPOSE 10001

CMD ["azurite", "-l", "/data", "--blobHost", "0.0.0.0", "--queueHost", "0.0.0.0"]
