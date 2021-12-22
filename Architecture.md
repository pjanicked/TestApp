![image](https://user-images.githubusercontent.com/36558161/147088547-e7751b04-7481-4472-8795-41ae08130368.png)

## Communication with Other Services
- We use Azure API Management and JWT token based authentication to manage our APIs, hence we will use the same flow for any other external system.
- Ideally, there should be a separate role for external systems. For now, following roles are sufficient – User, Admin, ThirdParty
- Each of our API checks the validity of the JWT token and then only authorizes the request

## Deployment
- As good practices go, we use CI/CD style of deployments. Each of the new feature developed goes to a series of deployments in the environments we have configured.
- We shall have following environments – CI(Dev), QA, Staging and Prod. Deploying to each environment requires an approval. For eg: Deploying to QA environment requires an approval from a SQA
- We may have 4 Azure resource groups for each of the enviroment. Good naming consistency also helps. Ideally we name our Azure resources as 
        rg                    -   app         - ci              - uksouth  -  dev1
        resourcegroup – appname – env name – location - instance
- Manually creating resource in Azure may become overwhelming as we grow in resources and thus managing them may become cumbersome and inconsistent too. Hence, we use Azure ARM templates based deployments to ensure consistency and managing Azure resources efficiently.
- Each feature request (Pull Request) triggers a deployment to CI environment wherein a developer can check and ensure his feature works as expected.
- When the PR gets approved as per guidelines, the developer merges his code in master/main branch which then triggers automatic deployments in QA -> Staging -> Prod environments.
- The pipeline code uses the pre defined ARM templates which deploy the artificat/build/api to the destined enviroment
- Meanwhile Databases, EventHubs and APIM are deployed from a common Infrastructure CI/CD pipeline which contains the ARM templates for them
- Thus, this ensures automatic deployments and efficient management of Azure resources

## Roadblocks, Questions and Unclear Requirements
- Cost effecieny of using Azure messaging system or if archived data should use some sort of messaging system
- Is it per customer basis? Are we going to do multi-tanancy?
- Market competition, USPs?
- If we are going to archive data, is that gonna be used for insights?
- We havent decided on any logging system. Will ELK be too much of a load or will Azure App insights be sufficient?

## Shortcomings
- Can go with Monolith instead of Micoroservices as cost may increase with having each App service and databases in Azure
- Could use CQRS (MediatR) 
