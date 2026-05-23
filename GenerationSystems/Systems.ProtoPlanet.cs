using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Resource;
using static Star_Simulation.Systems;
using static Star_Simulation.Libary;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public interface IMyProtoPlanet : IMyStellarObject
        {
            string Name { get; }
            string ID { get; }
            double Mass { get; }
            double Radius { get; }
            IMyOrbit Orbit { get; }
            MinMax<float> SurfaceTemperature { get; }
            CelestialType Type { get; }
            CelestialSurfaceType SurfaceType { get; }
            CelestialSpecialProperties[] SpecialProperties { get; }
            MyResourceList ResourceList { get; }
        }
        public class MyProtoPlanet : IMyProtoPlanet
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required double Radius { get; set; }
            public required IMyOrbit Orbit { get; set; }
            public required MinMax<float> SurfaceTemperature { get; set; }
            public required CelestialType Type { get; set; }
            public required CelestialSurfaceType SurfaceType { get; set; }
            public required CelestialSpecialProperties[] SpecialProperties { get; set; }
            public required MyResourceList ResourceList { get; set; }
        }
    }
}
