using System;

namespace BicycleStore.Repositories.Models
{
    public class Bicycle
    {
        // OData takes property with name Id as a default key. To use other property name decorate it with [Key] attribute.
        public int Id { get; set; }
        public string Color { get; set; }
        public float Weight { get; set; }
        public string Brand { get; set; }
        public string Drivetrain { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Available { get; set; }
    }
}