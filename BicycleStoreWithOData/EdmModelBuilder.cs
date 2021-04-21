using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

using BicycleStore.Features.Bicycles;

namespace BicycleStore
{
    internal class EdmModelBuilder
    {
        internal static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Bicycle>("Bicycles");
            return builder.GetEdmModel();
        }
    }
}