using System;
using static Star_Simulation.Program;
using static Star_Simulation.Random;
using static Star_Simulation.Libary;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Systems;
using Star_Simulation.Properties;

namespace Star_Simulation
{
    internal partial class Resource
    {
        public class AsteroidTypeInfo : SeedRandomList
        {
            public required AsteroidType ClassType { get; init; }
            public required MyResourceList Resources { get; init; }
            public required float Probability { get; init; }
        }

        public static AsteroidTypeInfo[] AsteroidTypes =
        [
            new() {
                ClassType = AsteroidType.C,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=600},
                    new() {Resource=ResourceElement.H2O        , Value=120},
                    new() {Resource=ResourceElement.Carbon     , Value=100},
                    new() {Resource=ResourceElement.CH4        , Value=15},
                    new() {Resource=ResourceElement.NH3        , Value=5},
                    new() {Resource=ResourceElement.Iron       , Value=90},
                    new() {Resource=ResourceElement.Magnesium  , Value=50},
                    new() {Resource=ResourceElement.Sulfur     , Value=20}
                ]),
                Probability = 0.45f
            },
            new() {
                ClassType = AsteroidType.S,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=550},
                    new() {Resource=ResourceElement.Iron       , Value=250},
                    new() {Resource=ResourceElement.Nickel     , Value=35},
                    new() {Resource=ResourceElement.Cobalt     , Value=3},
                    new() {Resource=ResourceElement.Magnesium  , Value=120},
                    new() {Resource=ResourceElement.Aluminium  , Value=20},
                    new() {Resource=ResourceElement.Calcium    , Value=15},
                    new() {Resource=ResourceElement.Chromium   , Value=7}
                ]),
                Probability = 0.28f
            },
            new() {
                ClassType = AsteroidType.M,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=40},
                    new() {Resource=ResourceElement.Gold       , Value=1},
                    new() {Resource=ResourceElement.Platinum   , Value=1},
                    new() {Resource=ResourceElement.Iron       , Value=850},
                    new() {Resource=ResourceElement.Nickel     , Value=95},
                    new() {Resource=ResourceElement.Cobalt     , Value=10},
                    new() {Resource=ResourceElement.Phosphorus , Value=3}
                ]),
                Probability = 0.08f
            },
            new() {
                ClassType = AsteroidType.D,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=450},
                    new() {Resource=ResourceElement.H2O        , Value=150},
                    new() {Resource=ResourceElement.Carbon     , Value=250},
                    new() {Resource=ResourceElement.CH4        , Value=20},
                    new() {Resource=ResourceElement.Iron       , Value=70},
                    new() {Resource=ResourceElement.Nitrogen   , Value=10},
                    new() {Resource=ResourceElement.Sulfur     , Value=50},
                ]),
                Probability = 0.07f
            },
            new() {
                ClassType = AsteroidType.V,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=720},
                    new() {Resource=ResourceElement.Iron       , Value=60},
                    new() {Resource=ResourceElement.Magnesium  , Value=40},
                    new() {Resource=ResourceElement.Aluminium  , Value=90},
                    new() {Resource=ResourceElement.Calcium    , Value=80},
                    new() {Resource=ResourceElement.Titanium   , Value=8},
                    new() {Resource=ResourceElement.Manganese  , Value=2},
                ]),
                Probability = 0.04f
            },
            new() {
                ClassType = AsteroidType.E,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=750},
                    new() {Resource=ResourceElement.Iron       , Value=8},
                    new() {Resource=ResourceElement.Magnesium  , Value=180},
                    new() {Resource=ResourceElement.Calcium    , Value=20},
                    new() {Resource=ResourceElement.Sulfur     , Value=40},
                    new() {Resource=ResourceElement.Sodium     , Value=2},
                ]),
                Probability = 0.04f
            },
            new() {
                ClassType = AsteroidType.A,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=420},
                    new() {Resource=ResourceElement.Iron       , Value=180},
                    new() {Resource=ResourceElement.Magnesium  , Value=380},
                    new() {Resource=ResourceElement.Aluminium  , Value=3},
                    new() {Resource=ResourceElement.Calcium    , Value=5},
                    new() {Resource=ResourceElement.Chromium   , Value=12},
                ]),
                Probability = 0.02f
            },
            new() {
                ClassType = AsteroidType.X,
                Resources = new([
                    new() {Resource=ResourceElement.SiO2       , Value=260},
                    new() {Resource=ResourceElement.Platinum   , Value=1},
                    new() {Resource=ResourceElement.Iron       , Value=450},
                    new() {Resource=ResourceElement.Nickel     , Value=55},
                    new() {Resource=ResourceElement.Cobalt     , Value=3},
                    new() {Resource=ResourceElement.Magnesium  , Value=230},
                    new() {Resource=ResourceElement.Phosphorus , Value=1},
                ]),
                Probability = 0.02f
            }
        ];

        public class MyAsteroidResources
        {
            public required AsteroidType Type { get; init; }
            public required MyResourceList ResourceList { get; init; }
        }
        /// <summary>
        /// Generates the RawResources of a Planet.
        /// </summary>
        /// <returns>Basic RawResources Of the Planet</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyAsteroidResources GenerateAsteroidResources(SeedRandom seed)
        {
            try
            {
                //if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Core RawResources");
                //if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Starting to Generate Planet Core RawResources");
                //MyResourceList core = GeneratePlanetCoreResources(seed, log);
                //core.BuildRealResources($"core GeneratePlanetResource, seed={seed.pos}");

                if (Logging && ResourceGeneration_AsteroidLogging) ConsoleLog($"Starting to Generate Asteroid RawResources");
                if (LoggingFile && ResourceGeneration_AsteroidLoggingFile || ForceLoggingFile) LogWrite($"Starting to Generate Asteroid RawResources; seedstate={seed.pos}");

                AsteroidTypeInfo asteroidType = seed.GetItem(AsteroidTypes);

                if (Logging && ResourceGeneration_AsteroidLogging) ConsoleLog($"Asteroidtype => {asteroidType.ClassType.ToString()}");
                if (LoggingFile && ResourceGeneration_AsteroidLoggingFile || ForceLoggingFile) LogWrite($"Asteroidtype => {asteroidType.ClassType.ToString()}");
                asteroidType.Resources.RealResources.ForEach((e) =>
                {
                    if (Logging && ResourceGeneration_AsteroidLogging) ConsoleLog($"Generated Resource: \"{e.Resource.Name}\" with {e.Value}ppm/{e.Percent*100}%");
                    if (LoggingFile && ResourceGeneration_AsteroidLoggingFile || ForceLoggingFile) LogWrite($"Generated Resource: \"{e.Resource.Name}\" with {e.Value}ppm/{e.Percent*100}%");
                });

                return new() { Type=asteroidType.ClassType, ResourceList = asteroidType.Resources };
            }
            catch (Exception e)
            {
                ConsoleLogWrite([e.Message, e.HelpLink!]);
                throw;
            }
        }
    }
}