# Bicycle Store (Simple OData Example)
Simplest approach to add OData controller and run queries with latest OData 8.x in .NET 5.

## Example queries
**Get top 5 lightest bikes**  
`/odata/Bicycles?$top=5&$orderby=Weight`

**Get Red bicycles only**  
`/odata/Bicycles?$filter=Color eq 'Red'`

**Get bicycles lighter or equal 9 (kg)**  
`/odata/Bicycles?$filter=Weight le 9`

## Resources
* [OData official repo](https://github.com/OData/aspnetcoreodata/)
* [OData nuget package](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/)
* [OData documentation](https://www.odata.org/documentation/)