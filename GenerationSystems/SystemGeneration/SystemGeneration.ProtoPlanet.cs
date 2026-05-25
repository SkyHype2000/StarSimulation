using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Systems;
using static Star_Simulation.Libary;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Random;
using static Star_Simulation.Calculation;
using static Star_Simulation.Resource;
using static Star_Simulation.Program;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        /// <summary>
        /// Generates a Proto Planet Object.<br/><br/>
        /// 
        /// They will be Placed into a Astroid Belt.<br/>
        /// If there are no Astroid Belt, no Proto Planet will be Generated.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"/>
        public static IMyProtoPlanet GenerateProtoPlanet(IMyStarGeneration StarParent, uint ObjectNumber, MinMax<double>[] AsteroidBeltsOrbitalRadius)
        {
            if (StarParent.Mass == null) throw new MyObjectGenerationValueException("(IMyProtoPlanet).GenerateProtoPlanet.StarParent.Mass");
            if (StarParent.Watt == null) throw new MyObjectGenerationValueException("(IMyProtoPlanet).GenerateProtoPlanet.StarParent.Watt");
            if (AsteroidBeltsOrbitalRadius.Length == 0) throw new MyObjectGenerationValueException("(IMyProtoPlanet).GenerateProtoPlanet.AsteroidBeltsOrbitalRadius.Length");
            SeedRandom seed = new SeedRandom(StarParent.ID + ObjectNumber);
            string name = GenerateNameMarkov(seed, PlanetNames, GenerateName2_MinMaxPlanetDefault);
            string id = seed.NextID();

            int beltNum = seed.Next(AsteroidBeltsOrbitalRadius.Length);
            MinMax<double> beltRange = AsteroidBeltsOrbitalRadius[beltNum];

            double PeriapsisRadius = 0;
            double PeriapsisSpeed =  0;
            double ApoapsisRadius =  beltRange.Max + 1d;
            double ApoapsisSpeed = 0;

            int trys = 0;

            while(ApoapsisRadius >= beltRange.Max)
            {
                trys++;
                PeriapsisRadius = seed.Next(beltRange.Max, beltRange.Min);
                PeriapsisSpeed = OrbitalCalculation.CalculateOrbitalVelocity(PeriapsisRadius, (double)StarParent.Mass) * seed.Next(1.005, 1);
                ApoapsisRadius = OrbitalCalculation.OrbitalRadius_ApWithPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
                ApoapsisSpeed = OrbitalCalculation.OrbitalVelocity_ApWithPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
            }
            MinMax<double> orbitalRange = new MinMax<double> { Min=PeriapsisRadius, Max=ApoapsisRadius };

            if (ProtoPlanetLogging) ConsoleLog($"Protoplanet {name} from {StarParent.Name} Attemps:{trys} - AstBelt:{beltRange.Floor()} m ProtoPlanetOrbit:{orbitalRange.Floor()} m");

            double radius = seed.Next(GC_SpaceRock.RangeProtoPlanetRadius);
            double mass = ((4d / 3d) * Math.PI * Math.Pow(radius, 3)) * EarthDensity;
            double orbitalPeriod = OrbitalCalculation.OrbitalPeriod_WithApPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
            float albedo = seed.Next(0.4f, 0.1f);
            MinMax<float> surfaceTemperature = new MinMax<float>()
            {
                Min = CalculateObjectSurfaceTemperature(albedo, ApoapsisRadius, (double)StarParent.Watt),
                Max = CalculateObjectSurfaceTemperature(albedo, PeriapsisRadius, (double)StarParent.Watt)
            };

            IMyOrbit myOrbit = new MyOrbit()
            {
                ID = id + "-O",
                AxialRotationUD = seed.Next(5, -5),
                AxialRotationLR = seed.Next(360, 0),
                OrbitalRadiusPerigee = PeriapsisRadius,
                OrbitalSpeedPerigee = PeriapsisSpeed,
                OrbitalRadiusApogee = ApoapsisRadius,
                OrbitalSpeedApogee = ApoapsisSpeed,
                OrbitalPeriod = orbitalPeriod,
                OrbitalOffset = seed.Next(orbitalPeriod, 0)
            };

            IMyProtoPlanet myProtoPlanet = new MyProtoPlanet()
            {
                Name = name,
                ID = id,
                Mass = mass,
                Radius = radius,
                Orbit = myOrbit,
                SurfaceTemperature = surfaceTemperature,
                Type = CelestialType.Dwarf,
                SurfaceType = CelestialSurfaceType.Rocky,
                SpecialProperties = [],
                ResourceList = new MyResourceList() { RawResources = [] }
            };

            return myProtoPlanet;

            throw new NotImplementedException();
        }
    }
}
