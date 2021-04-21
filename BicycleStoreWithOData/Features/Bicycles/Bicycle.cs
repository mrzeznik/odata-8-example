using System;

namespace BicycleStore.Features.Bicycles
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public float Weight { get; set; }
        public string Brand { get; set; }
        public string Drivetrain { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Available { get; set; }
    }
}