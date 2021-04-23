using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

using BicycleStore.Repositories.Models;

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