using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Random;
using static Star_Simulation.Calculation;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Resource;
using static Star_Simulation.Libary;
using static Star_Simulation.Program;
using static Star_Simulation.Systems;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        public static IMyPlanet? lastPlanet = null;
        /// <summary>A Planet Object</summary>
        /// <remarks>
        /// The Rules are soooo simple, that i can't remember thoose.<br/><br/>
        /// (Or more Likley: i never made any XD)
        /// </remarks>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static IMyPlanet GeneratePlanet(IMyStarGeneration StarParent, uint ObjectNumber, double lastOrbitalRadius, MinMax<double>[] AsteroidBeltsOrbitalHeights)
        {
            IMyPlanetGeneration planet = new MyPlanetGeneration();

            if (StarParent.Mass == null) throw new MyObjectGenerationValueException("(IMyPlanet).GeneratePlanet.StarParent.Mass");
            if (StarParent.Watt == null) throw new MyObjectGenerationValueException("(IMyPlanet).GeneratePlanet.StarParent.Watt");

            SeedRandom seed = new SeedRandom((StarParent.ID + "-" + ObjectNumber).ToString());

            string name = GenerateName2(seed, planetNames, GenerateName2_MinMaxPlanetDefault);
            planet.Name = name;
            string id = $"{StarParent.ID}-{ObjectNumber.ToString().PadLeft(2, '0')}";
            planet.ID = id;

            if (Logging) Console.WriteLine($"Generating the Planet {id} \"{name}\" of {StarParent.ID} \"{StarParent.Name}\" with the seed {seed.seed}.");

            double radius = seed.Next(GC_Planet.RangePlanetRadius.Max, GC_Planet.RangePlanetRadius.Min);
            planet.Radius = radius;

            double mass = CalculateBasicObjectMass(radius, EarthDensity);
            planet.Mass = mass;

            double orbitalRadiusPe = 0;
            if (lastPlanet == null)
                orbitalRadiusPe = (double)(seed.Next(GC_Planet.RangeDistanceBetweenPlanets.Max, GC_Planet.RangeDistanceBetweenPlanets.Min) + StarParent.Radius + seed.Next(GC_Planet.RangeDistanceBetweenPlanets.Min))!;
            else
                orbitalRadiusPe = OrbitalCalculation.GetOrbitalRadiusPlanet(seed, mass, (double)StarParent.Mass!, lastOrbitalRadius, CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusPerigee), GC_Planet.RangeDistanceBetweenPlanets, false);

            double orbitalSpeedPe = 0;
            double orbitalRadiusAp = 0;
            double orbitalSpeedAp = 0;

            double orbitalPeriod = 0;

            bool validOrbit = false;

            long validOrbitSearchIterations = 0;
            while (!validOrbit)
            {
                lastOrbitalRadius = orbitalRadiusPe;

                validOrbitSearchIterations++;
                orbitalRadiusPe = OrbitalCalculation.GetOrbitalRadiusPlanet(seed, mass, (double)StarParent.Mass!, lastOrbitalRadius, CalculateSOI(mass, (double)StarParent.Mass!, orbitalRadiusPe), GC_Planet.RangeDistanceBetweenPlanets, true);
                orbitalSpeedPe = OrbitalCalculation.CalculateOrbitalVelocity(orbitalRadiusPe, (double)StarParent.Mass) * seed.Next(1.005, 1);
                orbitalRadiusAp = OrbitalCalculation.OrbitalRadius_ApWithPe(orbitalSpeedPe, orbitalRadiusPe, (double)StarParent.Mass!);
                orbitalSpeedAp = OrbitalCalculation.OrbitalVelocity_ApWithPe(orbitalSpeedPe, orbitalRadiusPe, (double)StarParent.Mass!);

                orbitalPeriod = OrbitalCalculation.OrbitalPeriod_WithApPe(orbitalSpeedPe, orbitalRadiusPe, (double)StarParent.Mass!);

                double SOIPE = CalculateSOI(mass, (double)StarParent.Mass!, orbitalRadiusPe);
                MinMax<double> SOIPE_RANGE = new MinMax<double>(orbitalRadiusPe - SOIPE, orbitalRadiusPe + SOIPE);
                double SOIAP = CalculateSOI(mass, (double)StarParent.Mass!, orbitalRadiusAp);
                MinMax<double> SOIAP_RANGE = new MinMax<double>(orbitalRadiusAp - SOIAP, orbitalRadiusAp + SOIAP);

                if (PlanetAsteroidBeltLogging) Console.WriteLine($"Asteroid Belt Testing Iteration {validOrbitSearchIterations.ToString().PadLeft(5, '0')}:");
                if (PlanetAsteroidBeltLogging) Console.WriteLine($"SOIPE_RANGE: {SOIPE_RANGE.Floor()} ({SOIPE_RANGE.Floor() / MinMaxAU} AU)");
                if (PlanetAsteroidBeltLogging) Console.WriteLine($"SOIAP_RANGE: {SOIAP_RANGE.Floor()} ({SOIAP_RANGE.Floor() / MinMaxAU} AU)");

                MinMax<double> av = new MinMax<double>(orbitalRadiusPe - SOIPE, orbitalRadiusAp + SOIAP);

                if (AsteroidBeltsOrbitalHeights.Length == 0) { validOrbit = true; break; }
                for (int i = 0; i < AsteroidBeltsOrbitalHeights.Length; i++)
                {
                    MinMax<double> AstBeltRadius = AsteroidBeltsOrbitalHeights[i];
                    if (PlanetAsteroidBeltLogging) Console.WriteLine($"Asteroid Belt: AstBeltRadius: {AstBeltRadius.ToString()} ({(AstBeltRadius / MinMaxAU).ToString()} AU)");
                    if (SOIPE_RANGE.Min >= AstBeltRadius.Min && SOIPE_RANGE.Max <= AstBeltRadius.Max) { validOrbit = false; break; }
                    else if (SOIAP_RANGE.Min >= AstBeltRadius.Min && SOIAP_RANGE.Max <= AstBeltRadius.Max) { validOrbit = false; break; }
                    else { validOrbit = true; }
                }
                if (PlanetAsteroidBeltLogging) Console.WriteLine();
            }

            string orbitID = id + "-O";
            IMyOrbit myOrbit = new MyOrbit()
            {
                ID = orbitID,
                AxialRotationUD = seed.Next(-5, 5),
                AxialRotationLR = seed.Next(360, 0),
                OrbitalRadiusPerigee = orbitalRadiusPe,
                OrbitalSpeedPerigee = orbitalSpeedPe,
                OrbitalRadiusApogee = orbitalRadiusAp,
                OrbitalSpeedApogee = orbitalSpeedAp,
                OrbitalPeriod = orbitalPeriod,
                OrbitalOffset = seed.Next(orbitalPeriod, 0)
            };
            planet.Orbit = myOrbit;

            float albedo = seed.Next(0.4f, 0.1f);
            MinMax<float> surfaceTemperature = new MinMax<float>()
            {
                Min = CalculateObjectSurfaceTemperature(albedo, orbitalRadiusAp, (double)StarParent.Watt),
                Max = CalculateObjectSurfaceTemperature(albedo, orbitalRadiusPe, (double)StarParent.Watt)
            };
            float surfaceTemperatureAverage = (surfaceTemperature.Min + surfaceTemperature.Max) / 2;

            planet.SurfaceTemperature = surfaceTemperature;

            if (Logging) Console.WriteLine($"Sun Watt:               {StarParent.Watt} W");
            if (Logging) Console.WriteLine($"Orbital Radius PE:      {Math.Round(orbitalRadiusPe)} m ({orbitalRadiusPe / AU} AU)");
            if (Logging) Console.WriteLine($"Orbital Radius AP:      {Math.Round(orbitalRadiusAp)} m ({orbitalRadiusAp / AU} AU)");
            if (Logging) Console.WriteLine($"Orbital Radius:         {Math.Round((orbitalRadiusPe + orbitalRadiusAp) / 2)} m ({((orbitalRadiusPe + orbitalRadiusAp) / 2) / AU} AU)");
            if (Logging) Console.WriteLine($"Orbital Speed PE:       {Math.Round(orbitalSpeedPe)} m/s");
            if (Logging) Console.WriteLine($"Orbital Speed AP:       {Math.Round(orbitalSpeedAp)} m/s");
            if (Logging) Console.WriteLine($"Orbital Speed:          {Math.Round((orbitalSpeedPe + orbitalSpeedAp) / 2)} m/s");
            if (Logging) Console.WriteLine($"Surface Albedo:         {albedo}");
            if (Logging) Console.WriteLine($"Surface Temperature PE: {surfaceTemperature.Max} °K ({CelciusOffset + surfaceTemperature.Max} °C)");
            if (Logging) Console.WriteLine($"Surface Temperature AP: {surfaceTemperature.Min} °K ({CelciusOffset + surfaceTemperature.Min} °C)");
            if (Logging) Console.WriteLine($"Surface Temperature:    {surfaceTemperatureAverage} °K ({CelciusOffset + surfaceTemperatureAverage} °C)");
            if (Logging) Console.WriteLine($"Orbital Period:         {orbitalPeriod} s ({orbitalPeriod / Year} Years)");

            planet.Type = CelestialType.Terrestrial;
            planet.AtmosphereType = CelestialAtmosphereType.None;
            planet.SurfaceType = CelestialSurfaceType.Desert;
            planet.Habitability = CelestialHabitability.Uninhabitable;
            planet.LifeType = [];
            planet.SpecialProperties = [];
            planet.ResourceList = new MyResourceList() { Resources = [] };
            planet.Moons = [];

            return ReturnPlanetInformation(planet);

            throw new NotImplementedException();
        }
    }
}
