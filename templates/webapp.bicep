param skuName string = 'F1'
param skuCapacity int = 1
param location string = resourceGroup().location
param appName string = uniqueString(resourceGroup().id)

var appServicePlanName = toLower('asp-${appName}')
var webSiteName = appName

resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: appServicePlanName // app serivce plan name
  location: location // Azure Region
  sku: {
    name: skuName
    capacity: skuCapacity
  }
  tags: {
    displayName: 'HostingPlan'
    ProjectName: appName
  }
}

resource appService 'Microsoft.Web/sites@2020-06-01' = {
  name: webSiteName // Globally unique app service name
  location: location
  identity: {
    type: 'SystemAssigned'
  }
  tags: {
    displayName: 'Website'
    ProjectName: appName
  }
  properties: {
    serverFarmId: appServicePlan.id
    httpsOnly: true
    siteConfig: {
      minTlsVersion: '1.2'
    }
  }
}

output webappname string = webSiteName

