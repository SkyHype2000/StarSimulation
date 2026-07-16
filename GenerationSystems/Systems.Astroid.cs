using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Resource;
using static Star_Simulation.Export;
using System.Text.Json.Serialization;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public enum AsteroidBeltType
        { Belt, InnerBelt, MiddleBelt, OuterBelt, TrojanBelt, CentaurBelt, OortCloud }

        public class MyAsteroidBelt : IMyStellarObject, IExport
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required double InnerRadius { get; set; }
            public required double OuterRadius { get; set; }
            public required double AsteroidDensity { get; set; }
            public required double Volume { get; set; }
            public required double Asteroids { get; set; }
            public required AsteroidBeltType Type { get; set; }
            public required MyResourceList Composition { get; set; }
            public required string Seed { get; set; }
        }
        public class MyAsteroid : IMyStellarObject, IExport
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Radius { get; set; }
            public required double Mass { get; set; }
            public required MyOrbit Orbit { get; set; }
            public required AsteroidType Type { get; set; }
            public required MyResourceList Composition { get; set; }
            public required string Seed { get; set; }
        }
    }
}
