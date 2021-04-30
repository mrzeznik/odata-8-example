# Bicycle Store (Simple OData Example)
Simplest approach to create OData controller and run queries with latest OData 8.x in .NET 5 and .NET 6.

I couldn't find bare bones example, so here it is. 

## How to use OData 8
### Add OData package
```csharp
<PackageReference Include="Microsoft.AspNetCore.OData" Version="8.0.0-rc" />
```

### Configure OData service for WebHost
```csharp
services.AddOData(opt =>
{
    // specify EDM with "odata" prefix path
    opt.AddModel("odata", EdmModelBuilder.GetEdmModel();
    // enable features for OData 
    opt.Filter().Select().OrderBy().SetMaxTop(50).Count();
});
```

### Configure EDM (Entity Data Model)
EDM is used to describe exposed data in the OData (resources, their properties and relations).  
Each resource should have key defined. By default, property with name `Id` is taken, but one can use [Key] attribute with other property. Check Bicycle model for example. 

This is sample setup of EDM:
```csharp
internal static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    // "Bicycles" will be used as a OData resource path
    builder.EntitySet<Bicycle>("Bicycles");

    return builder.GetEdmModel();
}
```

### Create Controller and endpoint
```csharp
...
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

public class BicyclesController : ODataController
{ 
    // enable OData queries for this endpoint
    [EnableQuery()]
    public ActionResult<IEnumerable<Bicycle>> Get()
    {
        return Ok(_bicycleRepository.GetBicycles());
    }
}
```

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
* [Routing for OData 8](https://devblogs.microsoft.com/odata/routing-in-asp-net-core-8-0-preview/)
* [EnableQuery Attribute](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnet.odata.enablequeryattribute?view=odata-aspnetcore-7.0#constructors/) - applies to OData 7.x, but most Properties are suitable for OData 8