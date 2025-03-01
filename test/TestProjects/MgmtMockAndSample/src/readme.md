# MgmtMockAndSample

## Generated code configuration

Run `dotnet build /t:GenerateCode` to generate code.

``` yaml
azure-arm: true
title: MgmtMockAndSample
library-name: MgmtMockAndSample
require: $(this-folder)/../../../../readme.md
input-file:
- $(this-folder)/../specification/mockSwagger/keyvault.json
- $(this-folder)/../specification/mockSwagger/managedHsm.json
- $(this-folder)/../specification/mockSwagger/providers.json
- $(this-folder)/../specification/mockSwagger/authorization.json
- $(this-folder)/../specification/mockSwagger/tenantActivityLogs_API.json
clear-output-folder: true
namespace: MgmtMockAndSample
modelerfour:
  lenient-model-deduplication: true

generate-arm-resource-extensions:
- /{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}

list-exception:
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedVaults/{vaultName}
- /subscriptions/{subscriptionId}/providers/Microsoft.KeyVault/locations/{location}/deletedManagedHSMs/{name}
format-by-name-rules:
  'tenantId': 'uuid'
  'resourceType': 'resource-type'
  'location': 'azure-location'
  'ETag': 'etag'
  '*Uri': 'Uri'
  '*Uris': 'Uri'

rename-mapping:
  Type: EncryptionType

directive:
  - from: swagger-document
    where: $.paths
    transform: delete $['/subscriptions/{subscriptionId}/resources']
  - from: swagger-document
    where: $['definitions']['Sku']['properties']['family']
    transform: delete $['x-ms-client-default']
  - from: swagger-document
    where: $['definitions']['ManagedHsmSku']['properties']['family']
    transform: delete $['x-ms-client-default']
```
