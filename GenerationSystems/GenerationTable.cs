global using GC_Settings = Star_Simulation.GenerationTable.GenerationConstant_Setting;
global using GC_Star = Star_Simulation.GenerationTable.GenerationConstant_Star;
global using GC_Planet = Star_Simulation.GenerationTable.GenerationConstant_Planet;
global using GC_SpaceRock = Star_Simulation.GenerationTable.GenerationConstant_SpaceRock;
global using GC_DwarfPlanet = Star_Simulation.GenerationTable.GenerationConstant_DwarfPlanet;
global using GC_Moon = Star_Simulation.GenerationTable.GenerationConstant_Moon;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Libary;
using static Star_Simulation.Program;
using static Star_Simulation.Random;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Calculation;
using static Star_Simulation.LoggingOptions;

namespace Star_Simulation
{
    internal class GenerationTable
    {
        public static class GenerationConstant_Setting
        {
            /// <summary>If a Stellar System can have Objects<br/>If False: Any Object-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool ObjectsStellarSystem = true;
            /// <summary>If a Stellar System can have Planets<br/>If False: Any Planet-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool PlanetsStellarSystem = true;
            /// <summary>If a Stellar System can have Dwarf Planets<br/>If False: Any Dwarf Planet-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool DwarfPlanetsStellarSystem = true;
            /// <summary>If a Stellar System can have Proto Planets<br/>If False: Any Proto Planet-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool ProtoPlanetsStellarSystem = true;
            /// <summary>If a Stellar System can have Asteroids<br/>If False: Any Asteroid-Settings, will be Ignored and not Tested for Errors<br/><br/>
            /// WARNING! If this is False, there will sometimes not be enough Objects to reach the Stellar Object Count, because normally at the End Asteroids will be placed until the final Stellar Object Count is Reached.</summary>
            public static readonly bool AsteroidsStellarSystem = true;
            /// <summary>If a Planetary System can have Moons<br/>If False: Any Moon-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool MoonPlanetSystem = false;
            /// <summary>If a Stellar System can have Comets<br/>If False: Any Comet-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool CometsStellarSystem = false;
            /// <summary>If a Stellar System can have Asteroid Fields<br/>If False: Any Asteroid Field-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool AsteroidFieldsStellarSystem = true;

            /// <summary>If a Stellar System can have Events<br/>If False: Any Event-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool EventsStellarSystem = false;
            /// <summary>If a Stellar System can have Anomalys<br/>If False: Any Anomaly-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool AnomalysStellarSystem = false;
            /// <summary>If a Stellar System can have CMEs<br/>If False: Any CME-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool CMEStellarSystem = false;
            /// <summary>If a Stellar System can have Interstellar Visitors<br/>If False: Any Interstellar Visitor-Settings, will be Ignored and not Tested for Errors</summary>
            public static readonly bool InterstellarVisitorsStellarSystem = false;
        }

        public static class GenerationConstant_Star
        {
            /// <summary>The Amount of Total Objects in a Stellar System</summary>
            public static readonly MinMax<uint> RangeObjectsStellarSystem = new MinMax<uint>(0, 256);
            /// <summary>The Amount of Planets in a Stellar System (Stellar Objects)</summary>
            public static readonly MinMax<uint> RangePlanetsStellarSystem = new MinMax<uint>(0, 8);
            /// <summary>The Amount of Dwarf Planets in a Stellar System (Stellar Objects)</summary>
            public static readonly MinMax<uint> RangeDwarfPlanetsStellarSystem = new MinMax<uint>(0, 8);
            /// <summary>The Amount of Protoplanets in a Stellar System (Stellar Objects)</summary>
            public static readonly MinMax<uint> RangeProtoplanetsStellarSystem = new MinMax<uint>(0, 48);

            /// <summary>The Amount of Asteroids in a Stellar System (Stellar Objects)</summary>
            public static readonly MinMax<uint> RangeAsteroidsStellarSystem = new MinMax<uint>(0, 0, true);
            /// <summary>The Amount of Comets in a Stellar System (Stellar Objects)</summary>
            public static readonly MinMax<uint> RangeCometsStellarSystem = new MinMax<uint>(0, 16);
            /// <summary>The Amount of Asteroid Fields in a Stellar System (Stellar Objects)</summary>
            public static readonly MinMax<uint> RangeAsteroidFieldsStellarSystem = new MinMax<uint>(0, 4);

            /// <summary>The Amount of Total Events in a Stellar System seperated from the Total Objects</summary>
            public static readonly MinMax<uint> RangeEventsStellarSystem = new MinMax<uint>(0, 64);
            /// <summary>The Amount of Total Anomalys in a Stellar System (Stellar Events)</summary>
            public static readonly MinMax<uint> RangeAnomalysStellarSystem = new MinMax<uint>(0, 8);
            /// <summary>The Amount of Total CME/Year in a Stellar System (Stellar Events)</summary>
            public static readonly MinMax<uint> RangeCMEStellarSystem = new MinMax<uint>(0, 4);
            /// <summary>The Amount of Total Interstellar Visitors in a Stellar System (Stellar Events)</summary>
            public static readonly MinMax<uint> RangeInterstellarVisitorsStellarSystem = new MinMax<uint>(0, 32);
        }

        public static class GenerationConstant_Planet
        {
            /// <summary>The distance between 2 Planets SOI, measured in Meters.</summary>
            public static readonly MinMax<double> RangeDistanceBetweenPlanets = new MinMax<double>(AU * 0.25f, AU * 5f, false);

            /// <summary>If it can Spawn Behind the Same Object or if the Object has to be separated by another object.</summary>
            public static readonly bool CanPlanetSpawnAfterSameObject = true;
            /// <summary>When canSpawnAfterSameObject=true, how many can Spawn in a row. (0 at Max means Infinit)</summary>
            public static readonly MinMax<int> RangePlanetRowOfSameObject = new MinMax<int>(0, 0, true);
            /// <summary>The Radius a Planet Must have</summary>
            public static readonly MinMax<double> RangePlanetRadius = new MinMax<double>(EarthRadius*0.4, EarthRadius* 2.5, true);
            /// <summary>The Range of the Albedo a Planet can have</summary>
            public static readonly MinMax<float> RangeAlbedo = new MinMax<float>(0.1f, 0.4f);

            /// <summary>The Radius a Dwarf Planet must have</summary>
            public static readonly MinMax<double> RangeDwarfPlanetRadius = new MinMax<double>(2500000, EarthRadius * 0.4, false);

            /// <summary> The Average Size of the Core of the Planet </summary>
            public static readonly float PlanetCoreSize = 0.50f;

            /// <summary>If Atmospheric Calculation are Done (like Greenhouseeffect, Color, etc.)</summary>
            public static readonly bool AtmosphereCalculation = false;
        };

        public static class GenerationConstant_SpaceRock
        {
            /// <summary>The Radius a Proto Planet must have</summary>
            public static readonly MinMax<double> RangeProtoPlanetRadius = new MinMax<double>(100000, 2500000);
            /// <summary>The Radius a Asteroid must have</summary>
            public static readonly MinMax<double> RangeAsteroidRadius = new MinMax<double>(100, 100000);
            /// <summary>The Minimum Distance that Proto Planets must Have from the Center of the Star System</summary>
            public static readonly double MinDistanceFromStar = 10 * AU;

            /// <summary>If it can Spawn Behind the Same Object or if the Object has to be separated by another object.</summary>
            public static readonly bool CanAsteroidBeltSpawnAfterSameObject = true;
            /// <summary>When canSpawnAfterSameObject=true, how many can Spawn in a row. (0 at Max means Infinit)</summary>
            public static readonly MinMax<int> RangeAsteroidBeltRowOfSameObject = new MinMax<int>(0, 0, true);
            /// <summary>The Range of the Distance Between the Outher Radius Of Belt One and Inner Radius of Belt Two</summary>
            public static readonly MinMax<double> RangeDistanceBetweenAsteroidBelt = new MinMax<double>(10*AU, 25*AU);
            /// <summary>The Starting Distance from the Star</summary>
            public static readonly MinMax<double> AsteroidBeltStartingDistance = new MinMax<double>(3*AU, 10*AU);
            /// <summary>The Range of the Length of a Asteroid Belt in Meters</summary>
            public static readonly MinMax<double> RangeAsteroidBeltLength = new MinMax<double>(0.75*AU, 4*AU);
            /// <summary>The Range of the Thickness of a Asteroid Belt in Meters</summary>
            public static readonly MinMax<double> RangeAsteroidBeltHeight = new MinMax<double>(112.2e9, 598.4e9);

            /// <summary>The Average Astroid Amount Per m^3 in a Astroid Belt.</summary>
            public static readonly MinMax<double> DensityAsteroidBelt = new MinMax<double>(1e-15, 4e-14);

            /// <summary>The Average Density of all Asteroid Types in kg/m^3.<br/><br/>
            /// 
            /// More Realistic: Every Asteroid-Type has Different Densitys, but this is for the Beginning simplefied, it will be Updated in the Future.<br/>
            /// (But it will be Always Used for Astroid Belts)</summary>
            public static readonly double AsteroidDensity = 3500;
        }

        public static class GenerationConstant_DwarfPlanet
        {
            /// <summary>The Mass a Dwarf Planet must have</summary>
            public static readonly MinMax<double> RangeDwarfPlanetMass = new MinMax<double>(1e18, 1e20);
        }

        public static class GenerationConstant_Moon
        {
            /// <summary>The Spawn Distance From Center in Meters.</summary>
            public static readonly MinMax<double> RangeSpawnDistanceFromCenter = new MinMax<double>(0, 0, true);
            /// <summary>The Minimum distance of Moons from the Edge of the Parent Sphere Sphere of Influence, measured in Meters. (0 Means, that any Position is Valid, but it can't go Above the SOI. And the Value Cannot be Negative)</summary>
            public static readonly double MinMoonDistanceFromSOI = 0;
            /// <summary>The Minimum distance between 2 Moons SOI or the Parent Planet SOI, measured in Meters.</summary>
            public static readonly int MinDistanceBetweenMoons = 150000000;
            /// <summary>The Radius a Moon Must have</summary>
            public static readonly MinMax<int> RangeMoonRadius = new MinMax<int>(0, 0, true);
        };

        public static void GenerationTableMain()
        {
            if (GC_Settings.ObjectsStellarSystem == true)
            {
                if (GC_Settings.PlanetsStellarSystem == true && GC_Star.RangePlanetsStellarSystem.Max > GC_Star.RangeObjectsStellarSystem.Max)
                    throw new GenerationConstantValueException("GenerationConstant_Star.RangePlanetsStellarSystem.Max cannot be larger than GenerationConstant_Star.RangeObjectsStellarSystem.Max.");
                if (GC_Settings.AsteroidsStellarSystem == true && GC_Star.RangeAsteroidsStellarSystem.Min > GC_Star.RangeObjectsStellarSystem.Max)
                    throw new GenerationConstantValueException("GenerationConstant_Star.RangeAsteroidsStellarSystem.Min cannot be lager thatn GenerationConstant_Star.RangeObjectStellarSystem.Max.");
            }
        }
        
        public static void GenerationTableLog()
        {
            ConsoleLogWrite("If You See This Message Here, then i means that all Generation COnstants are Valid. (At least the ones that will be tested.)\n");

            ConsoleLogWrite($"Generation COnstants Settings.");
            ConsoleLogWrite($"Setting.ObjectsStellarSystem                      = {GC_Settings.ObjectsStellarSystem}");
            ConsoleLogWrite($"Setting.PlanetsStellarSystem                      = {GC_Settings.PlanetsStellarSystem}");
            ConsoleLogWrite($"Setting.ProtoPlanetsStellarSystem                 = {GC_Settings.ProtoPlanetsStellarSystem}");
            ConsoleLogWrite($"Setting.AsteroidsStellarSystem                    = {GC_Settings.AsteroidsStellarSystem}{((GC_Settings.AsteroidsStellarSystem) ? "" : " (!)")}");
            ConsoleLogWrite($"Setting.CometsStellarSystem                       = {GC_Settings.CometsStellarSystem}");
            ConsoleLogWrite($"Setting.AsteroidFieldsStellarSystem               = {GC_Settings.AsteroidFieldsStellarSystem}");
            ConsoleLogWrite($"Setting.EventsStellarSystem                       = {GC_Settings.EventsStellarSystem}");
            ConsoleLogWrite($"Setting.AnomalysStellarSystem                     = {GC_Settings.AnomalysStellarSystem}");
            ConsoleLogWrite($"Setting.CMEStellarSystem                          = {GC_Settings.CMEStellarSystem}");
            ConsoleLogWrite($"Setting.InterstellarVisitorsStellarSystem         = {GC_Settings.InterstellarVisitorsStellarSystem}");
            ConsoleLogWrite($"Setting.MoonPlanetSystem                          = {GC_Settings.MoonPlanetSystem}\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (GC_Settings.AsteroidsStellarSystem == false) ConsoleLogWrite(
                " => Small warning: Because AsteroidsStellarSystem is False, there will sometimes not be enough\n" +
                "    Objects to reach the Stellar Object Count, because normally at the End Asteroids will be\n" +
                "    placed until the final Stellar Object Count is Reached\n ");
            Console.ForegroundColor = ConsoleColor.White;

            ConsoleLogWrite($"Star.RangeObjectStellarAmount                     = {GC_Star.RangeObjectsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangePlanetsStellarSystem                    = {GC_Star.RangePlanetsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeDwarfPlanetsStellarSystem               = {GC_Star.RangeDwarfPlanetsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeProtoplanetsStellarSystem               = {GC_Star.RangeProtoplanetsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeAsteroidsStellarSystem                  = {GC_Star.RangeAsteroidsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeCometsStellarSystem                     = {GC_Star.RangeCometsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeAsteroidFieldsStellarSystem             = {GC_Star.RangeAsteroidFieldsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeEventsStellarSystem                     = {GC_Star.RangeEventsStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeAnomalysStellarSystem                   = {GC_Star.RangeAnomalysStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeCMEStellarSystem                        = {GC_Star.RangeCMEStellarSystem.ToString()}");
            ConsoleLogWrite($"Star.RangeInterstellarVisitorsStellarSystem       = {GC_Star.RangeInterstellarVisitorsStellarSystem.ToString()}\n");
            ConsoleLogWrite($"Planet.RangeDistanceBetweenPlanets                = {GC_Planet.RangeDistanceBetweenPlanets.ToString()}");
            ConsoleLogWrite($"Planet.CanPlanetSpawnAfterSameObject              = {GC_Planet.CanPlanetSpawnAfterSameObject}");
            ConsoleLogWrite($"Planet.RangePlanetRowOfSameObject                 = {GC_Planet.RangePlanetRowOfSameObject.ToString()}");
            ConsoleLogWrite($"Planet.RangePlanetRadius                          = {GC_Planet.RangePlanetRadius.ToString()}");
            ConsoleLogWrite($"Planet.RangeDwarfPlanetRadius                     = {GC_Planet.RangeDwarfPlanetRadius.ToString()}");
            ConsoleLogWrite($"Planet.AtmosphereCalculation                      = {GC_Planet.AtmosphereCalculation.ToString()}\n");
            ConsoleLogWrite($"SpaceRock.RangeProtoPlanetRadius                  = {GC_SpaceRock.RangeProtoPlanetRadius.ToString()}");
            ConsoleLogWrite($"SpaceRock.RangeAsteroidRadius                     = {GC_SpaceRock.RangeAsteroidRadius.ToString()}");
            ConsoleLogWrite($"SpaceRock.MinDistanceFromStar                     = {GC_SpaceRock.MinDistanceFromStar}");
            ConsoleLogWrite($"SpaceRock.CanAsteroidBeltSpawnAfterSameObject     = {GC_SpaceRock.CanAsteroidBeltSpawnAfterSameObject}");
            ConsoleLogWrite($"SpaceRock.RangeAsteroidBeltRowOfSameObject        = {GC_SpaceRock.RangeAsteroidBeltRowOfSameObject.ToString()}");
            ConsoleLogWrite($"SpaceRock.RangeDistanceBetweenAsteroidBelt        = {GC_SpaceRock.RangeDistanceBetweenAsteroidBelt.ToString()}");
            ConsoleLogWrite($"SpaceRock.RangeAsteroidBeltLength                 = {GC_SpaceRock.RangeAsteroidBeltLength.ToString()}");
            ConsoleLogWrite($"SpaceRock.RangeAsteroidBeltHeight                 = {GC_SpaceRock.RangeAsteroidBeltHeight.ToString()}");
            ConsoleLogWrite($"SpaceRock.DensityAsteroidBeltPerKKM               = {GC_SpaceRock.DensityAsteroidBelt.ToString()}");
            ConsoleLogWrite($"SpaceRock.AsteroidDensity                         = {GC_SpaceRock.AsteroidDensity}\n");
            ConsoleLogWrite($"DwarfPlanet.RangeDwarfPlanetMass                  = {GC_DwarfPlanet.RangeDwarfPlanetMass.ToString()}\n");
            ConsoleLogWrite($"Moon.RangeSpawnDistanceFromCenter                 = {GC_Moon.RangeSpawnDistanceFromCenter.ToString()}");
            ConsoleLogWrite($"Moon.MinMoonDistanceFromSOI                       = {GC_Moon.MinMoonDistanceFromSOI}");
            ConsoleLogWrite($"Moon.MinDistanceBetweenMoons                      = {GC_Moon.MinDistanceBetweenMoons}");
            ConsoleLogWrite($"Moon.RangeMoonRadius                              = {GC_Moon.RangeMoonRadius.ToString()}\n");
        }
    }
}
