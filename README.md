# .NET Framework Continuous Deployment Sample
A containerized (Windows) .NET Framework Task App setup with continuous deployment through **GitHub Actions** to Azure App Service.

## Directions
1. To use this repository, *fork the repo* 
2. *Provision appropriate resources* in Azure and/or Docker Hub
3. *Add/replace the github secrets variables with your own secrets* appropriate from each resource:<br/>

      - APP_NAME = your web apps name
      - AZURE_CREDENTIALS = your service principal output
      - AZURE_SQL_CONNECTION_STRING = database connection string
      - DATABASE_SERVER_NAME = name of your server
      - IMAGE_NAME = name of your image that will upload to your registry
      - REGISTRY_NAME = name of your registry (docker hub or acr)
      - REGISTRY_USERNAME = your registry username
      - REGISTRY_PASSWORD = your registry password
  
3. *Commit changes to your master branch* that will trigger your build
