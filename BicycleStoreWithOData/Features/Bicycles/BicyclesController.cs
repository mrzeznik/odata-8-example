using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

using BicycleStore.Repositories;
using BicycleStore.Repositories.Models;

namespace BicycleStore.Features.Bicycles
{
    public class BicyclesController : ODataController
    {
        private readonly IBicycleRepository _bicycleRepository;

        public BicyclesController(IBicycleRepository bicycleRepository)
        {
            _bicycleRepository = bicycleRepository;
        }

        /// <summary>OData queryable endpoint, lookup through bicycle list, eg. /odata/Bicycles?$top=5</summary>
        [EnableQuery(PageSize = 10)]
        public ActionResult<IEnumerable<Bicycle>> Get()
        {
            return Ok(_bicycleRepository.GetBicycles());
        }

        /// <summary>Query for single bicycle, eg. /odata/Bicycles(5)</summary>
        [EnableQuery]
        public ActionResult<Bicycle> Get(int key)
        {
            var bicycle = _bicycleRepository.GetBicycle(key);

            if (bicycle == null)
            {
                return NotFound($"Bicycle with key = {key} not found.");
            }

            return Ok(bicycle);
        }
    }
}
