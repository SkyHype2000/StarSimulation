using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Resource;
using static Star_Simulation.Systems;
using static Star_Simulation.Libary;
using static Star_Simulation.Export;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public class MyProtoPlanet : IMyStellarObject, IExport
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required MyPlanetResources Composition { get; set; }
            public required double Radius { get; set; }
            public required MyOrbit Orbit { get; set; }
            public required MinMax<float> SurfaceTemperature { get; set; }
            public required CelestialType Type { get; set; }
            public required CelestialSurfaceType SurfaceType { get; set; }
            public required CelestialSpecialProperties[] SpecialProperties { get; set; }
            public required MyResourceList ResourceList { get; set; }
            public required string Seed { get; set; }
        }
    }
}
