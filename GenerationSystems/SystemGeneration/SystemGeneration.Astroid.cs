using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Systems;
using static Star_Simulation.Random;
using static Star_Simulation.Resource;
using static Star_Simulation.Libary;
using static Star_Simulation.Calculation;
using static Star_Simulation.Program;
using static Star_Simulation.CExceptions;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        /// <summary>
        /// Generates a Astroid.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyAsteroid GenerateAsteroid(IMyStarGeneration StarParent, int ObjectNumber, MinMax<double> RangeOrbitalHeight, MinMax<double>[] PlanetSOIHeights)
        {
            // Placeholder for astroid generation logic
            // Actually i have no idea how to generate astroids and i'am too lazy to research it, so... I will just write trash.

            if (StarParent.Mass == null) throw new MyObjectGenerationValueException("(IMyAsteroid).GenerateAsteroid.StarParent.Mass");

            string id = StarParent.ID + "-A" + ObjectNumber.ToString().PadLeft(3, '0');
            SeedRandom seed = new SeedRandom(id);
            string name = GenerateName(CelestialObjectTypes.Asteroid ,seed);

            double PeriapsisRadius = 0;
            double PeriapsisSpeed = 0;
            double ApoapsisRadius = 0;
            double ApoapsisSpeed = 0;

            bool validOrbit = false;
            while (!validOrbit)
            {
                PeriapsisRadius = seed.Next(RangeOrbitalHeight);
                PeriapsisSpeed = OrbitalCalculation.CalculateOrbitalVelocity(PeriapsisRadius, (double)StarParent.Mass) * seed.Next(1.10, 1);
                ApoapsisRadius = OrbitalCalculation.OrbitalRadius_ApWithPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);
                ApoapsisSpeed = OrbitalCalculation.OrbitalVelocity_ApWithPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);

                if (PlanetSOIHeights.Length == 0) { validOrbit = true; break; }
                for (int i = 0; i < PlanetSOIHeights.Length; i++)
                {
                    MinMax<double> SOI = PlanetSOIHeights[i];

                    if (PeriapsisRadius >= SOI.Min && PeriapsisRadius <= SOI.Max) { validOrbit = false; break; }
                    else if (ApoapsisRadius >= SOI.Min && ApoapsisRadius <= SOI.Max) { validOrbit = false; break; }
                    else if (PeriapsisRadius <= SOI.Min && ApoapsisRadius >= SOI.Min) { validOrbit = false; break; }
                    else if (PeriapsisRadius <= SOI.Max && ApoapsisRadius >= SOI.Max) { validOrbit = false; break; }
                    else { validOrbit = true; }
                }
            }

            double orbitalPeriod = OrbitalCalculation.OrbitalPeriod_WithApPe(PeriapsisSpeed, PeriapsisRadius, (double)StarParent.Mass);

            IMyOrbit myOrbit = new MyOrbit()
            {
                ID = id + "-O",
                AxialRotationUD = seed.Next(10, -10),
                AxialRotationLR = seed.Next(360),
                OrbitalRadiusPerigee = PeriapsisRadius,
                OrbitalSpeedPerigee = PeriapsisSpeed,
                OrbitalRadiusApogee = ApoapsisRadius,
                OrbitalSpeedApogee = ApoapsisSpeed,
                OrbitalPeriod = orbitalPeriod,
                OrbitalOffset = seed.NextOne<double>() * orbitalPeriod,
            };

            double radius = seed.Next(GC_SpaceRock.RangeAsteroidRadius);
            double mass = radius * GC_SpaceRock.AsteroidDensity;

            IMyAsteroid astroid = new MyAsteroid()
            {
                Name = name,
                ID = id,
                Radius = radius,
                Mass = mass,
                Orbit = myOrbit,
                Type = AstroidType.None,
                ResourceList = new MyResourceList() { Resources = [] },
            };

            if (Logging && AstroidLogging) Console.WriteLine($"Generated Asteroid: {name}");

            return astroid;

            throw new NotImplementedException();
        }

        public static IMyAsteroidBelt GenerateAsteroidBelt(IMyStarGeneration Parent, int ObjectNumber, double LastBeltOuterRadius, bool IsStartingRadius = false)
        {
            string id = "AB-" + Parent.ID + "-" + ObjectNumber.ToString();
            SeedRandom seed = new SeedRandom(id);
            string name = GenerateName2(seed, planetNames, GenerateName2_MinMaxPlanetDefault);

            double innerRadius = LastBeltOuterRadius + seed.Next(GC_SpaceRock.RangeDistanceBetweenAsteroidBelt.Max, GC_SpaceRock.RangeDistanceBetweenAsteroidBelt.Min);
            if (IsStartingRadius) innerRadius = LastBeltOuterRadius;
            double outerRadius = innerRadius + seed.Next(GC_SpaceRock.RangeAsteroidBeltLength.Max, GC_SpaceRock.RangeAsteroidBeltLength.Min);
            double height = seed.Next(GC_SpaceRock.RangeAsteroidBeltHeight);

            double asteroidDensity = seed.Next(GC_SpaceRock.DensityAsteroidBelt);

            double volume = Math.PI * height * (Math.Pow(outerRadius, 2) - Math.Pow(innerRadius, 2));
            double astroids = Math.Round(volume * asteroidDensity);

            AsteroidBeltType type = AsteroidBeltType.Belt;
            
            IMyResourceList resourceList = new MyResourceList() { Resources = [] };

            IMyAsteroidBelt myAsteroidBelt = new MyAsteroidBelt()
            {
                Name = name,
                ID = id,
                InnerRadius = innerRadius,
                OuterRadius = outerRadius,
                AsteroidDensity = asteroidDensity,
                Volume = volume,
                Asteroids = astroids,
                Type = type,
                ResourceList = resourceList,
            };

            if (Logging) Console.WriteLine($"Generating Asteroid Belt: {name} ({id}) of {Parent.Name} ({Parent.ID})");
            if (Logging) Console.WriteLine($"innerRadius:              {innerRadius} ({innerRadius / AU} AU)");
            if (Logging) Console.WriteLine($"outerRadius:              {outerRadius} ({outerRadius / AU} AU)");
            if (Logging) Console.WriteLine($"astroids:                 {astroids} ({asteroidDensity} Ast/m^3) total: {volume} m^3");

            return myAsteroidBelt;

            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates a Comet
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyAsteroid GenerateComet(IMyStarGeneration Parent, int ObjectNumber) { throw new NotImplementedException(); }
    }
}
