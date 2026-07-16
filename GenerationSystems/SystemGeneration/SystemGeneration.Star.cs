using static Star_Simulation.Program;
using static Star_Simulation.Calculation;
using static Star_Simulation.Random;
using static Star_Simulation.Systems;
using static Star_Simulation.Spectral;
using static Star_Simulation.Luminosity;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Libary;
using static Star_Simulation.Export;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        public static ulong StarNum = 0;
        public static ulong AllObjectNum = 0;

        /// <summary>Generiert ein Stern</summary>
        public static MyStar GenerateStar(SeedRandom startseed)
        {
            MyStarGeneration starGeneration = new MyStarGeneration();

            string id = $"{(StarNum):X16}-{startseed.NextID(2, 4)}";
            starGeneration.ID = id;

            SeedRandom seed = new SeedRandom($"{StarNum:X16}-{startseed.pos}");

            string name = GenerateNameMarkov(seed, StarNames, GenerateName2_MinMaxStarDefault);
            starGeneration.Name = name;
            if (Logging) ConsoleLog($"Generating the Star {id} \"{name}\" with the seed {seed.seed}.");
            LogWrite($"Generating the Star {id} \"{name}\" with the seed {seed.seed}.");

            double mass = GetStarMass(seed);
            starGeneration.Mass = mass;
            double radius = GetStarRadius(mass);
            starGeneration.Radius = radius;

            SubspectralClass subspectralClass = GetSubspectral(mass);
            starGeneration.SubSpectralClass = subspectralClass;

            float norm = CalculateNorm(mass, subspectralClass);
            starGeneration.Norm = norm;

            float temperature = CalculateStarSurfaceTemperatureNorm(norm, subspectralClass);
            starGeneration.Temperature = temperature;

            double watt = CalculateStarWatt(temperature, radius);
            starGeneration.Watt = watt;

            ILuminosityClass luminosityClass = GetLuminosityClassByRadius(radius);
            starGeneration.LuminosityClass = luminosityClass;

            if (Logging && StarLogging)
            {
                ConsoleLog($"Mass:           {mass} kg");
                ConsoleLog($"Radius:         {radius} m");
                ConsoleLog($"Norm:           {norm}");
                ConsoleLog($"Temperature:    {temperature} °K");
                ConsoleLog($"Watt:           {watt} W");
                ConsoleLog($"Spectral-Class: {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass}");
                ConsoleLog($"Lum-Class:      {luminosityClass.Class}");
            }
            if (LoggingFile && StarLoggingFile || ForceLoggingFile)
            {
                LogWrite($"Mass:           {mass} kg");
                LogWrite($"Radius:         {radius} m");
                LogWrite($"Norm:           {norm}");
                LogWrite($"Temperature:    {temperature} °K");
                LogWrite($"Watt:           {watt} W");
                LogWrite($"Spectral-Class: {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass}");
                LogWrite($"Lum-Class:      {luminosityClass.Class}");
            }

            MyStellarSystem stellarSystem = GenerateStellarSystem(seed, starGeneration);
            starGeneration.StellarSystem = stellarSystem;

            if (Logging && StarLogging) ConsoleLog($"Generated the {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass} {subspectralClass.ParentSpectralClass.StarColorName} Star \"{name}\" with: {stellarSystem.StellarObjects.Count} Stellar Objects and {stellarSystem.StellarEvents.Count} Stellar Events;");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"Generated the {subspectralClass.ParentSpectralClass.Class}{subspectralClass.SubClass} {subspectralClass.ParentSpectralClass.StarColorName} Star \"{name}\" with: {stellarSystem.StellarObjects.Count} Stellar Objects and {stellarSystem.StellarEvents.Count} Stellar Events;");

            if (NameLoggingFile) stellarSystem.StellarObjects.ForEach((e) =>
                {
                    LogWrite($"[{e.Seed.PadRight(80)}] {e.Name}", NameGenerationLogfileName);
                });
            if (GenerationLoggingFile) stellarSystem.StellarObjects.ForEach((e) =>
            {
                LogWrite($"[{e.Seed.PadRight(80)}] {e.Name} m={e.Mass}", ObjectGenerationLogfileName);
            });

            StarNum++;
            AllObjectNum += (ulong)stellarSystem.StellarObjects.Count;

            return ReturnStarInformation(starGeneration);
        }

        /// <summary>Generates A Stellar System</summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyStellarSystem GenerateStellarSystem(SeedRandom seed, MyStarGeneration StarParent)
        {
            uint actualMax(uint v, uint c) { return ((int)c - (int)(v) <= 0) ? c : v; }

            if (StarParent.Radius == null) throw new MyObjectGenerationValueException("(MyStellarSystem).GenerateStellarSystem.StarParent.Radius");

            uint ObjectNum = 0;

            MyStellarSystem stellarSystem = new MyStellarSystem()
            {
                StellarObjects = new List<IMyStellarObject>(),
                StellarEvents = new List<IMyStellarEvent>()
            };

            uint credits = 0;

            uint totalObjectAmount = GC_Settings.ObjectsStellarSystem ? seed.Next(GC_Star.RangeObjectsStellarSystem.Max, GC_Star.RangeObjectsStellarSystem.Min) : 0;
            credits = totalObjectAmount;
            credits -= (GC_Settings.AsteroidsStellarSystem && GC_Star.RangeAsteroidsStellarSystem.Min > 0) ? GC_Star.RangeAsteroidsStellarSystem.Min : 0;
            if (Logging && StarLogging) ConsoleLog($"totalObjectAmount:   {totalObjectAmount.ToString().PadLeft(4, '0')}");
            if (Logging && StarLogging) ConsoleLog($"Credits:             {credits.ToString().PadLeft(4, '0')}");

            uint asteroidFieldAmount = GC_Settings.AsteroidFieldsStellarSystem ? seed.Next(actualMax(GC_Star.RangeAsteroidFieldsStellarSystem.Max, credits), GC_Star.RangeAsteroidFieldsStellarSystem.Min, true) : 0;
            credits -= asteroidFieldAmount;
            if (Logging && StarLogging) ConsoleLog($"asteroidFieldAmount: {asteroidFieldAmount.ToString().PadLeft(4, '0')}");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"asteroidFieldAmount: {asteroidFieldAmount.ToString().PadLeft(4, '0')}");

            uint planetAmount = GC_Settings.PlanetsStellarSystem ? seed.Next(actualMax(GC_Star.RangePlanetsStellarSystem.Max, credits), GC_Star.RangePlanetsStellarSystem.Min, true) : 0;
            credits -= planetAmount;
            if (Logging && StarLogging) ConsoleLog($"planetAmount:        {planetAmount.ToString().PadLeft(4, '0')}");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"planetAmount:        {planetAmount.ToString().PadLeft(4, '0')}");

            uint protoPlanetAmount = GC_Settings.ProtoPlanetsStellarSystem ? seed.Next(actualMax(GC_Star.RangeProtoplanetsStellarSystem.Max, credits), GC_Star.RangeProtoplanetsStellarSystem.Min, true) : 0;
            if (asteroidFieldAmount == 0) protoPlanetAmount = 0;
            credits -= protoPlanetAmount;
            if (Logging && StarLogging) ConsoleLog($"protoPlanetAmount:   {protoPlanetAmount.ToString().PadLeft(4, '0')}");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"protoPlanetAmount:   {protoPlanetAmount.ToString().PadLeft(4, '0')}");

            uint dwarfPlanetAmount = GC_Settings.DwarfPlanetsStellarSystem ? seed.Next(actualMax(GC_Star.RangeDwarfPlanetsStellarSystem.Max, credits), GC_Star.RangeDwarfPlanetsStellarSystem.Min, true) : 0;
            if (asteroidFieldAmount == 0) dwarfPlanetAmount = 0;
            credits -= dwarfPlanetAmount;
            if (Logging && StarLogging) ConsoleLog($"dwarfPlanetAmount:   {dwarfPlanetAmount.ToString().PadLeft(4, '0')}");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"dwarfPlanetAmount:   {dwarfPlanetAmount.ToString().PadLeft(4, '0')}");

            uint cometAmount = GC_Settings.CometsStellarSystem ? seed.Next(actualMax(GC_Star.RangeCometsStellarSystem.Max, credits), GC_Star.RangeCometsStellarSystem.Min, true) : 0;
            credits -= cometAmount;
            if (Logging && StarLogging) ConsoleLog($"cometAmount:         {cometAmount.ToString().PadLeft(4, '0')}");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"cometAmount:         {cometAmount.ToString().PadLeft(4, '0')}");

            // Astroids has to be enabled if you want to make sure, that the System is always using all Credits
            uint astroidAmount = GC_Settings.AsteroidsStellarSystem ? (credits + GC_Star.RangeAsteroidsStellarSystem.Min) : 0;
            credits -= astroidAmount;
            if (Logging && StarLogging) ConsoleLog($"astroidAmount:       {astroidAmount.ToString().PadLeft(4, '0')}");
            if (LoggingFile && StarLoggingFile || ForceLoggingFile) LogWrite($"astroidAmount:       {astroidAmount.ToString().PadLeft(4, '0')}");

            double lastOrbitalHeight = (double)StarParent.Radius;

            MinMax<double> OrbitalRange = GC_Planet.RangeDistanceBetweenPlanets.Clone();

            MinMax<double>[] AsteroidFieldRadiuseses = new MinMax<double>[asteroidFieldAmount];

            MinMax<double>[] PlanetSOIHeights = new MinMax<double>[planetAmount];

            double lastAsteroidOuterRadius = seed.Next(GC_SpaceRock.AsteroidBeltStartingDistance);

            for (int i = 0; i < asteroidFieldAmount; i++)
            {
                MyAsteroidBelt astBelt = GenerateAsteroidBelt(StarParent, i, lastAsteroidOuterRadius, i == 0);
                stellarSystem.StellarObjects.Add(astBelt);
                AsteroidFieldRadiuseses[i] = new MinMax<double>(astBelt.InnerRadius, astBelt.OuterRadius);
                lastAsteroidOuterRadius = astBelt.OuterRadius;
                ObjectNum++;
            }

            for (int i = 0; i < protoPlanetAmount; i++)
            {
                MyProtoPlanet protoPlanet = GenerateProtoPlanet(StarParent, ObjectNum, AsteroidFieldRadiuseses);
                if (GenerationLoggingFile) File.WriteAllText("lastDwarfPlanet.stellarSystemJSON", JsonSerializer.Serialize(protoPlanet));
                stellarSystem.StellarObjects.Add(protoPlanet);
                if (i == 0 && Logging && ProtoPlanetLogging) ConsoleLog($"Generated the Proto Planet {protoPlanet.ID} \"{protoPlanet.Name}\" of {StarParent.ID} \"{StarParent.Name}\" with the seed {protoPlanet.ID}.");
                if (i == 0 && (LoggingFile && ProtoPlanetLoggingFile || ForceLoggingFile)) LogWrite($"Generated the Proto Planet {protoPlanet.ID} \"{protoPlanet.Name}\" of {StarParent.ID} \"{StarParent.Name}\" with the seed {protoPlanet.ID}.");
                ObjectNum++;
            }

            for (int i = 0; i < dwarfPlanetAmount; i++)
            {
                MyDwarfPlanet dwarfPlanet = GenerateDwarfPlanet(StarParent, ObjectNum, AsteroidFieldRadiuseses);
                if (GenerationLoggingFile) File.WriteAllText("lastDwarfPlanet.stellarSystemJSON", JsonSerializer.Serialize(dwarfPlanet));
                stellarSystem.StellarObjects.Add(dwarfPlanet);
                ObjectNum++;
                if (i == 0 && Logging && DwarfPlanetLogging) ConsoleLog($"Generated the Dwarf Planet {dwarfPlanet.ID} \"{dwarfPlanet.Name}\" of {StarParent.ID} \"{StarParent.Name}\" with the seed {dwarfPlanet.ID}.");
                if (i == 0 && (LoggingFile && DwarfPlanetLoggingFile || ForceLoggingFile)) LogWrite($"Generated the Dwarf Planet {dwarfPlanet.ID} \"{dwarfPlanet.Name}\" of {StarParent.ID} \"{StarParent.Name}\" with the seed {dwarfPlanet.ID}.");
            }

            for (int i = 0; i < planetAmount; i++)
            {
                lastPlanet = GeneratePlanet(StarParent, ObjectNum, lastOrbitalHeight, AsteroidFieldRadiuseses);
                if (GenerationLoggingFile) File.WriteAllText("lastDwarfPlanet.stellarSystemJSON", JsonSerializer.Serialize(lastPlanet));
                stellarSystem.StellarObjects.Add(lastPlanet);
                lastOrbitalHeight = lastPlanet.Orbit.OrbitalRadiusApogee;

                if (lastPlanet.Orbit.OrbitalRadiusPerigee < OrbitalRange.Min || i == 0) OrbitalRange.Min = lastPlanet.Orbit.OrbitalRadiusPerigee - CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusPerigee);
                if (lastPlanet.Orbit.OrbitalRadiusApogee > OrbitalRange.Max) OrbitalRange.Max = lastPlanet.Orbit.OrbitalRadiusApogee + CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusApogee);

                MinMax<double> SOIHeight = new MinMax<double>(lastPlanet.Orbit.OrbitalRadiusPerigee - CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusPerigee),
                    lastPlanet.Orbit.OrbitalRadiusApogee + CalculateSOI(lastPlanet.Mass, (double)StarParent.Mass!, lastPlanet.Orbit.OrbitalRadiusApogee));
                PlanetSOIHeights[i] = SOIHeight;

                ObjectNum++;
            }
            lastPlanet = null;

            OrbitalRange *= 1.01;
            for (int i = 0; i < astroidAmount; i++)
            {
                stellarSystem.StellarObjects.Add(GenerateAsteroid(StarParent, i, OrbitalRange, PlanetSOIHeights));
                ObjectNum++;
            }

            return stellarSystem;

            throw new NotImplementedException();
        }
    }
}
