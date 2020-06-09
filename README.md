# .NET Framework Continuous Deployment Sample
A containerized (Windows) .NET Framework sample application setup with continuous deployment through **GitHub Actions** to Azure App Service. Follow the directions below to get started.

## Fork this Repository
Fork this repository so you have your own copy that you can add your own GitHub secrets to. 

## Create Resources 
Create the following resources. You will need information from each resource detailed below that will be used in the file and stored in your secrets. Create your choice of registry (Azure Container Registry or Docker Hub) first since you will need information from there before you can create your App Service.  

1. Azure Container Registry OR Docker Hub 
- `CONTAINER_REGISTRY_USERNAME` = your registry name
- `CONTAINER_REGISTRY_PASSWORD` = your registry password
- `CONTAINER_REGISTRY_NAME` = azure container registry login server
2. App Service (Web App for Container) 
- `APP_NAME` = your web apps name
3. .NET Framework application with supporting dockerfile in a GitHub repository
4. Azure SQL Database (Optional)
- `AZURE_SQL_CONNECTION_STRING` = your database connection string
- `DATABASE_SERVER_NAME` = name of your server

## Create a Service Principal
Our workflow will use a Service Principal to authenticate with Azure when deploying the container to App Service. A service principal is an Active Directory Identity created for use with automation scenarios, such as GitHub Actions.

1. Run the following command in Azure CLI in powershell to get the credentials needed to run the login action.  The output of this command will be a collection of key value pairs that you'll need to add to your GitHub secrets. 
    ```shell
    az ad sp create-for-rbac --name "<appservice-name>" --role contributor \
                                --scopes /subscriptions/{subscription-id}/resourceGroups/{resource-group} \
                                --sdk-auth
    ```
2. Copy the output into your GitHub secrets to use as your AZURE_CREDENTIALS secret. 

    ```json
      {
        "clientId": "<GUID>",
        "clientSecret": "<GUID>",
        "subscriptionId": "<GUID>",
        "tenantId": "<GUID>" 
      }
    ```

## Secure Secrets
Since we are using sensitive information that you don't want others to access, we will use GitHub secrets to protect our information. Create a secret by following the directions [here](https://help.github.com/en/actions/configuring-and-managing-workflows/creating-and-storing-encrypted-secrets).  Add the github secrets variables below with your own secrets appropriate from each resource.  If you are not using Docker Hub, ignore the DOCKERHUB prefixed parameters and if you are not using ACR, ignore the REGISTRY prefixed variables. 

- `APP_NAME` = your web apps name
- `AZURE_CREDENTIALS` = your service principal output
- `IMAGE_NAME` = name of your image that will upload to your registry
- `CONTAINER_REGISTRY_NAME` = your registry username
- `CONTAINER_REGISTRY_PASSWORD` = your registry password
- `CONTAINER_LOGIN_SERVER` = azure container registry login server
- `AZURE_SQL_CONNECTION_STRING` = your database connection string
- `DATABASE_SERVER_NAME` = name of your server
  
## Commit Changes
The `main.yaml` file is set to trigger on any pushes to master, so when you commit your changes the build will run.  View the **Actions** tab in your repository to view the build and any potential errors.
