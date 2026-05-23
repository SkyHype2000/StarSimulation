using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public enum AsteroidBeltType
        { Belt, InnerBelt, MiddleBelt, OuterBelt, TrojanBelt, CentaurBelt, OortCloud }
        
        public interface IMyAsteroidBelt : IMyStellarObject
        {
            public string Name { get; }
            public string ID { get; }
            public double InnerRadius { get; }
            public double OuterRadius { get; }
            public double AsteroidDensity { get; }
            public double Volume { get; }
            public double Asteroids { get; }
            public AsteroidBeltType Type { get; }
            public MyResourceList ResourceList { get; }
        }
        public class MyAsteroidBelt : IMyAsteroidBelt
        { public required string Name { get; set; } public required string ID { get; set; } public required double InnerRadius { get; set; } public required double OuterRadius { get; set; } public required double AsteroidDensity { get; set; } public required double Volume { get; set; } public required double Asteroids { get; set; } public required AsteroidBeltType Type { get; set; } public required MyResourceList ResourceList { get; set; } }

        public interface IMyAsteroid : IMyStellarObject
        {
            public string Name { get; }
            public string ID { get; }
            public double Radius { get; }
            public double Mass { get; }
            public IMyOrbit Orbit { get; }
            public AstroidType Type { get; }
            public MyResourceList ResourceList { get; }
        }
        public class MyAsteroid : IMyAsteroid
        { public required string Name { get; set; } public required string ID { get; set; } public required double Radius { get; set; } public required double Mass { get; set; } public required IMyOrbit Orbit { get; set;  } public required AstroidType Type { get; set; } public required MyResourceList ResourceList { get; set; } }
    }
}
