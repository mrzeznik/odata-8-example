using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BicycleStore.Features.Bicycles
{
    public class BicyclesController : ODataController
    {
        private static readonly string[] Brands = new[]
        {
            "Alpha", "Beta", "Chilly", "Molly", "Hot Wheelz", "Butcher"
        };
        private static readonly string[] Colors = new[]
        {
            "Green", "Yellow", "Red", "Black", "White", "Pink", "Blue", "Navy"
        };

        private readonly ILogger<BicyclesController> _logger;

        public BicyclesController(ILogger<BicyclesController> logger)
        {
            _logger = logger;
        }

        [EnableQuery]
        [Route("Bicycles")]
        public IEnumerable<Bicycle> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 100).Select(index => new Bicycle
            {
                Id = index,
                Weight = rng.Next(80, 160) / 10f,
                Brand = Brands[rng.Next(Brands.Length)],
                Color = Colors[rng.Next(Colors.Length)],
                Drivetrain = string.Concat(rng.Next(1, 3), "x", rng.Next(6, 11)),
                ReleaseDate = DateTime.UtcNow.AddMonths(-index).AddDays(index),
                Available = rng.Next() > (Int32.MaxValue / 2)
            })
            .ToArray();
        }

    }
}
