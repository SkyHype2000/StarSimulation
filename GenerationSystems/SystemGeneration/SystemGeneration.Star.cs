using static Star_Simulation.Program;
using static Star_Simulation.Calculation;
using static Star_Simulation.Random;
using static Star_Simulation.Systems;
using static Star_Simulation.Spectral;
using static Star_Simulation.Luminosity;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Libary;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        public static ulong StarNum = 0;
        public static ulong AllObjectNum = 0;

        /// <summary>Generiert ein Stern</summary>
        public static IMyStar GenerateStar(SeedRandom seed)
        {
            IMyStarGeneration starGeneration = new MyStarGeneration();

            string name = GenerateNameMarkov(seed, StarNames, GenerateName2_MinMaxStarDefault);
            starGeneration.Name = name;
            string id = $"{(StarNum):X16}-{seed.NextIDL(2)}";
            starGeneration.ID = id;
            if (Logging) Console.WriteLine($"Generating the Star {id} \"{name}\" with the seed {seed.seed}.");
            LogWrite($"Generating the Star {id} \"{name}\" with the seed {seed.seed}.");

            double mass = GetStarMass(seed);
            starGeneration.Mass = mass;
            double radius = GetStarRadius(mass);
            starGeneration.Radius = radius;

            ISubspectralClass subspectralClass = GetSubspectral(mass);
            starGeneration.SubSpectralClass = subspectralClass;

            float norm = CalculateNorm(mass, subspectralClass);
            starGeneration.Norm = norm;

            float temperature = CalculateStarSurfaceTemperatureNorm(norm, subspectralClass);
            starGeneration.Temperature = temperature;

            double watt = CalculateStarWatt(temperature, radius);
            starGeneration.Watt = watt;

            ILuminosityClass luminosityClass = GetLuminosityClassByRadius(radius);
            starGeneration.LuminosityClass = luminosityClass;

            if (Logging)
            {
                ConsoleLog($"Mass:           {mass} kg");
                ConsoleLog($"Radius:         {radius} m");
                ConsoleLog($"Norm:           {norm}");
                ConsoleLog($"Temperature:    {temperature} °K");
                ConsoleLog($"Watt:           {watt} W");
                ConsoleLog($"Spectral-Class: {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass}");
                ConsoleLog($"Lum-Class:      {luminosityClass.Class}");
            }
            else
            {
                LogWrite($"Mass:           {mass} kg");
                LogWrite($"Radius:         {radius} m");
                LogWrite($"Norm:           {norm}");
                LogWrite($"Temperature:    {temperature} °K");
                LogWrite($"Watt:           {watt} W");
                LogWrite($"Spectral-Class: {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass}");
                LogWrite($"Lum-Class:      {luminosityClass.Class}");
            }

            IMyStellarSystem stellarSystem = GenerateStellarSystem(seed, starGeneration);
            starGeneration.StellarSystem = stellarSystem;

            if (Logging) ConsoleLog($"Generated the {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass} {subspectralClass.ParentSpectralClass.StarColorName} Star \"{name}\" with: {stellarSystem.StellarObjects.Count} Stellar Objects and {stellarSystem.StellarEvents.Count} Stellar Events;");
            else LogWrite($"Generated the {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass} {subspectralClass.ParentSpectralClass.StarColorName} Star \"{name}\" with: {stellarSystem.StellarObjects.Count} Stellar Objects and {stellarSystem.StellarEvents.Count} Stellar Events;");

            StarNum++;
            AllObjectNum += (ulong)stellarSystem.StellarObjects.Count;

            return ReturnStarInformation(starGeneration);
        }

        /// <summary>Generates A Stellar System</summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyStellarSystem GenerateStellarSystem(SeedRandom seed, IMyStarGeneration StarParent)
        {
            uint actualMax(uint v, uint c) { return ((int)c - (int)(v) <= 0) ? c : v; }

            if (StarParent.Radius == null) throw new MyObjectGenerationValueException("(IMyStellarSystem).GenerateStellarSystem.StarParent.Radius");

            uint ObjectNum = 0;

            IMyStellarSystem stellarObjects = new MyStellarSystem()
            {
                StellarObjects = [],
                StellarEvents = []
            };

            uint credits = 0;

            uint totalObjectAmount = GC_Settings.ObjectsStellarSystem ? seed.Next(GC_Star.RangeObjectsStellarSystem.Max, GC_Star.RangeObjectsStellarSystem.Min) : 0;
            credits = totalObjectAmount;
            credits -= (GC_Settings.AsteroidsStellarSystem && GC_Star.RangeAsteroidsStellarSystem.Min > 0) ? GC_Star.RangeAsteroidsStellarSystem.Min : 0;
            if (Logging) Console.WriteLine($"totalObjectAmount:   {totalObjectAmount.ToString().PadLeft(4, '0')}");
            if (Logging) Console.WriteLine($"Credits:             {credits.ToString().PadLeft(4, '0')}");

            uint asteroidFieldAmount = GC_Settings.AsteroidFieldsStellarSystem ? seed.Next(actualMax(GC_Star.RangeAsteroidFieldsStellarSystem.Max, credits), GC_Star.RangeAsteroidFieldsStellarSystem.Min, true) : 0;
            credits -= asteroidFieldAmount;
            if (Logging) Console.WriteLine($"asteroidFieldAmount: {asteroidFieldAmount.ToString().PadLeft(4, '0')}");

            uint planetAmount = GC_Settings.PlanetsStellarSystem ? seed.Next(actualMax(GC_Star.RangePlanetsStellarSystem.Max, credits), GC_Star.RangePlanetsStellarSystem.Min, true) : 0;
            credits -= planetAmount;
            if (Logging) Console.WriteLine($"planetAmount:        {planetAmount.ToString().PadLeft(4, '0')}");

            uint protoPlanetAmount = GC_Settings.ProtoPlanetsStellarSystem ? seed.Next(actualMax(GC_Star.RangeProtoplanetsStellarSystem.Max, credits), GC_Star.RangeProtoplanetsStellarSystem.Min, true) : 0;
            if (asteroidFieldAmount == 0) protoPlanetAmount = 0;
            credits -= protoPlanetAmount;
            if (Logging) Console.WriteLine($"protoPlanetAmount:   {protoPlanetAmount.ToString().PadLeft(4, '0')}");

            uint dwarfPlanetAmount = GC_Settings.DwarfPlanetsStellarSystem ? seed.Next(actualMax(GC_Star.RangeDwarfPlanetsStellarSystem.Max, credits), GC_Star.RangeDwarfPlanetsStellarSystem.Min, true) : 0;
            if (asteroidFieldAmount == 0) dwarfPlanetAmount = 0;
            credits -= dwarfPlanetAmount;
            if (Logging) Console.WriteLine($"dwarfPlanetAmount:   {dwarfPlanetAmount.ToString().PadLeft(4, '0')}");

            uint cometAmount = GC_Settings.CometsStellarSystem ? seed.Next(actualMax(GC_Star.RangeCometsStellarSystem.Max, credits), GC_Star.RangeCometsStellarSystem.Min, true) : 0;
            credits -= cometAmount;
            if (Logging) Console.WriteLine($"cometAmount:         {cometAmount.ToString().PadLeft(4, '0')}");

            // Astroids has to be enabled if you want to make sure, that the System is always using all Credits
            uint astroidAmount = GC_Settings.AsteroidsStellarSystem ? (credits + GC_Star.RangeAsteroidsStellarSystem.Min) : 0;
            credits -= astroidAmount;
            if (Logging) Console.WriteLine($"astroidAmount:       {astroidAmount.ToString().PadLeft(4, '0')}");

            double lastOrbitalHeight = (double)StarParent.Radius;

            MinMax<double> OrbitalRange = new MinMax<double>(GC_Planet.RangeDistanceBetweenPlanets.Min, 0, true);

            MinMax<double>[] AsteroidFieldRadiuseses = new MinMax<double>[asteroidFieldAmount];

            MinMax<double>[] PlanetSOIHeights = new MinMax<double>[planetAmount];

            double lastAsteroidOuterRadius = seed.Next(GC_SpaceRock.AsteroidBeltStartingDistance);

            for (int i = 0; i < asteroidFieldAmount; i++)
            {
                IMyAsteroidBelt astBelt = GenerateAsteroidBelt(StarParent, i, lastAsteroidOuterRadius, i == 0);
                stellarObjects.StellarObjects.Add(astBelt);
                AsteroidFieldRadiuseses[i] = new MinMax<double>(astBelt.InnerRadius, astBelt.OuterRadius);
                lastAsteroidOuterRadius = astBelt.OuterRadius;
                ObjectNum++;
            }

            for (int i = 0; i < protoPlanetAmount; i++)
            {
                if (i == 0 && Logging && ProtoPlanetLogging) ConsoleLog($"Generating {protoPlanetAmount} Proto Planets.");
                else LogWrite($"Generating {protoPlanetAmount} Proto Planets.");
                IMyProtoPlanet protoPlanet = GenerateProtoPlanet(StarParent, ObjectNum, AsteroidFieldRadiuseses);
                stellarObjects.StellarObjects.Add(protoPlanet);
                ObjectNum++;
            }

            for (int i = 0; i < dwarfPlanetAmount; i++)
            {
                if (i == 0 && Logging && DwarfPlanetLogging) ConsoleLog($"Generating {dwarfPlanetAmount} Dwarf Planets.");
                else LogWrite($"Generating {dwarfPlanetAmount} Dwarf Planets.");
                IMyDwarfPlanet dwarfPlanet = GenerateDwarfPlanet(StarParent, ObjectNum, AsteroidFieldRadiuseses);
                stellarObjects.StellarObjects.Add(dwarfPlanet);
                ObjectNum++;
            }

            for (int i = 0; i < planetAmount; i++)
            {
                lastPlanet = GeneratePlanet(StarParent, ObjectNum, lastOrbitalHeight, AsteroidFieldRadiuseses);
                stellarObjects.StellarObjects.Add(lastPlanet);
                lastOrbitalHeight = lastPlanet.Orbit.OrbitalRadiusApogee;

                if (lastPlanet.Orbit.OrbitalRadiusPerigee < OrbitalRange.Min || i == 0) OrbitalRange.Min = lastPlanet.Orbit.OrbitalRadiusPerigee - CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusPerigee);
                if (lastPlanet.Orbit.OrbitalRadiusApogee > OrbitalRange.Max) OrbitalRange.Max = lastPlanet.Orbit.OrbitalRadiusApogee + CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusApogee);

                MinMax<double> SOIHeight = new MinMax<double>(lastPlanet.Orbit.OrbitalRadiusPerigee - CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusPerigee),
                    lastPlanet.Orbit.OrbitalRadiusApogee + CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusApogee));
                PlanetSOIHeights[i] = SOIHeight;

                ObjectNum++;
            }
            lastPlanet = null;

            OrbitalRange.Min *= 1.01;
            OrbitalRange.Max *= 1.01;
            for (int i = 0; i < astroidAmount; i++)
            {
                stellarObjects.StellarObjects.Add(GenerateAsteroid(StarParent, i, OrbitalRange, PlanetSOIHeights));
                ObjectNum++;
            }

            return stellarObjects;

            throw new NotImplementedException();
        }
    }
}
