# .NET Framework Sample w/ Continuous Deployment
A containerized (Windows) .NET Framework Task App setup with continuous deployment through **GitHub Actions** to Azure App Service.

## Directions
1. Fork the repository.
2. Replace the github secrets variables with your own appropriate secrets.<br/><br/>
    You will need to add the following secrets: 
      - APP_NAME = your web apps name
      - AZURE_CREDENTIALS = your service principal output
      - AZURE_SQL_CONNECTION_STRING = database connection string
      - DATABASE_SERVER_NAME = name of your server
      - IMAGE_NAME = name of your image that will upload to your registry
      - REGISTRY_NAME = name of your registry (docker hub or acr)
      - REGISTRY_USERNAME = your registry username
      - REGISTRY_PASSWORD = your registry password
  
3. Push up your changes to trigger changes in the master branch to run your build.
