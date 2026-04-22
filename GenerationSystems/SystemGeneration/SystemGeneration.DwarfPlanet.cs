using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Calculation;
using static Star_Simulation.Libary;
using static Star_Simulation.Program;
using static Star_Simulation.Random;
using static Star_Simulation.Systems;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        /// <summary>
        /// Generates a Dwarf Planet.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyDwarfPlanet GenerateDwarfPlanet(IMyStarGeneration StarParent, uint objectNum, MinMax<double>[] AsteroidBeltsOrbitalRadius)
        {
            if (StarParent.Mass == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanetGeneration).GenerateDwarfPlanet.StarParent.Mass");
            if (StarParent.Watt == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanetGeneration).GenerateDwarfPlanet.StarParent.Watt");
            if (AsteroidBeltsOrbitalRadius.Length == 0) throw new MyObjectGenerationValueException("(IMyProtoPlanet).GenerateProtoPlanet.AsteroidBeltsOrbitalRadius.Length");

            SeedRandom seed = new SeedRandom(StarParent.ID + "-" + objectNum);
            IMyDwarfPlanetGeneration dwarfPlanet = new MyDwarfPlanetGeneration();

            string name = GenerateName2(seed, planetNames, GenerateName2_MinMaxPlanetDefault);
            dwarfPlanet.Name = name;
            string id = seed.NextID();
            dwarfPlanet.ID = id;

            if (Logging && DwarfPlanetLogging) Console.WriteLine($"Generating the Dwarf Planet {id} \"{name}\" of {StarParent.ID} \"{StarParent.Name}\" with the seed {seed.seed}.");

            int beltNum = seed.Next(AsteroidBeltsOrbitalRadius.Length);
            MinMax<double> beltRange = AsteroidBeltsOrbitalRadius[beltNum];

            double PeriapsisRadius = 0;
            double PeriapsisSpeed = 0;
            double ApoapsisRadius = beltRange.Max + 1d;
            double ApoapsisSpeed = 0;

            int trys = 0;

            while (ApoapsisRadius >= beltRange.Max)
            {
                trys++;
                PeriapsisRadius = seed.Next(beltRange.Max, beltRange.Min);
                PeriapsisSpeed = OrbitalCalculation.CalculateOrbitalVelocity(PeriapsisRadius, (double)StarParent.Mass) * seed.Next(1.005, 1);
                ApoapsisRadius = OrbitalCalculation.OrbitalRadius_ApWithPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
                ApoapsisSpeed = OrbitalCalculation.OrbitalVelocity_ApWithPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
            }
            MinMax<double> orbitalRange = new MinMax<double> { Min = PeriapsisRadius, Max = ApoapsisRadius };

            if (Logging & DwarfPlanetLogging) Console.WriteLine($"Dwarf Planet {name} from {StarParent.Name} Attemps:{trys} - AstBelt:{beltRange.Floor()} m DwarfPlanetOrbit:{orbitalRange.Floor()} m");

            double radius = seed.Next(GC_SpaceRock.RangeProtoPlanetRadius);
            dwarfPlanet.Radius = radius;
            double mass = ((4d / 3d) * Math.PI * Math.Pow(radius, 3)) * EarthDensity;
            dwarfPlanet.Mass = mass;

            double orbitalPeriod = OrbitalCalculation.OrbitalPeriod_WithApPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
            float albedo = seed.Next(0.4f, 0.1f);

            MinMax<float> surfaceTemperature = new MinMax<float>()
            {
                Min = CalculateObjectSurfaceTemperature(albedo, ApoapsisRadius, (double)StarParent.Watt),
                Max = CalculateObjectSurfaceTemperature(albedo, PeriapsisRadius, (double)StarParent.Watt)
            };
            dwarfPlanet.SurfaceTemperature = surfaceTemperature;

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
            dwarfPlanet.Orbit = myOrbit;

            dwarfPlanet.Type = CelestialType.Dwarf;
            dwarfPlanet.SurfaceType = CelestialSurfaceType.Rocky;
            dwarfPlanet.AtmosphereType = CelestialAtmosphereType.None;
            dwarfPlanet.Habitability = CelestialHabitability.Uninhabitable;
            dwarfPlanet.LifeType = [];
            dwarfPlanet.SpecialProperties = [];
            dwarfPlanet.ResourceList = new MyResourceList() { Resources = [] };
            dwarfPlanet.Moons = [];

            if (Logging & DwarfPlanetLogging) Console.WriteLine($"Generated Dwarf Planet {name} from \"{StarParent.Name}\"({StarParent.ID})");
            return ReturnDwarfPlanetInformation(dwarfPlanet);
            throw new NotImplementedException();
        }
    }
}
