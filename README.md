#####################################
#									#
#			ALIZE PLATFORM			#
#									#
#####################################

## Branch strategy
- Create branch for develop with name feature/{clickup id}-{description-of-feature} (ex: feature/2qfk9xm-Crear-endpoint-para-modificar-password)
- Push to feature branch
- Create PR to develop branch from feature branch
- Wait to at least one approval from other developer

## Definition of Done
- Code has been written
- PR has been created from feature branch to develop
- Code has been pushed to develop
- Code has been tested and approved

## Environments
### Dev
-[API](https://alize-platform-api-dev.azurewebsites.net/)
-[Front End](https://lively-plant-0a9448f10.1.azurestaticapps.net/)

### Staging
-[API](https://alize-platform-api-staging.azurewebsites.net/)
-[Front End](https://gentle-desert-0e8e9a510.1.azurestaticapps.net/)
