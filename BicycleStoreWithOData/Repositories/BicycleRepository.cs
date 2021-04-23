using System;
using System.Linq;
using System.Collections.Generic;

using BicycleStore.Repositories.Models;

namespace BicycleStore.Repositories
{
    public interface IBicycleRepository
    {
        IEnumerable<Bicycle> GetBicycles();
        Bicycle GetBicycle(int key);
    }

    public class BicycleFakeRepository : IBicycleRepository
    {
        private static IEnumerable<Bicycle> _bicycles;

        public BicycleFakeRepository()
        {
            _bicycles ??= GenerateData();
        }

        public IEnumerable<Bicycle> GetBicycles()
        {
            return _bicycles;
        }

        public Bicycle GetBicycle(int key)
        {
            return _bicycles.SingleOrDefault(b => b.Id == key);
        }

        private static IEnumerable<Bicycle> GenerateData(int count = 100)
        {
            var rng = new Random();

            return Enumerable.Range(1, count).Select(index => new Bicycle
            {
                Id = index,
                Weight = rng.Next(80, 160) / 10f,
                Brand = BicycleProperties.Brands[rng.Next(BicycleProperties.Brands.Length)],
                Color = BicycleProperties.Colors[rng.Next(BicycleProperties.Colors.Length)],
                Drivetrain = string.Concat(rng.Next(1, 3), "x", rng.Next(6, 11)),
                ReleaseDate = DateTime.Today.AddMonths(-index).AddDays(index),
                Available = rng.Next() > (Int32.MaxValue / 2)
            }).ToArray();

        }
    }
}