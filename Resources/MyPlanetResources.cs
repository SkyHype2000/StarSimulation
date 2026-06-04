using System;
using static Star_Simulation.Program;
using static Star_Simulation.Random;
using static Star_Simulation.Libary;
using Star_Simulation.Properties;

/*
 * ====================================================================================================================================================================================================================================================================
 * 
 * GOOGLE:
 * 
 * Bei einem prozedural (zufallsgenerierten) Planeten, besonders wenn man von terrestrischen (gesteinsbasierten) Planeten ausgeht, besteht der Kern am wahrscheinlichsten aus Eisen und Nickel.
 * 
 *  -> Eisen-Nickel-Kern: Ähnlich wie bei der Erde, Merkur, Venus und Mars, sind Eisen und Nickel die wahrscheinlichsten Hauptkomponenten im Kern eines terrestrischen Planeten.
 *  -> Andere schwere Elemente: Neben Eisen und Nickel können auch andere schwere Elemente wie Schwefel oder Silizium im Kern enthalten sein.
 *  -> Gestein/Metall-Mischung: Insgesamt bestehen terrestrische Planeten hauptsächlich aus Gestein und Metallen.
 * 
 * Bei größeren, gasreichen Planeten (Gasriesen oder Eisriesen) ist der Kern oft von einer dicken Schicht aus Wasser, Ammoniak oder anderen Stoffen umgeben, aber auch hier ist ein fester, metallischer Kern im Zentrum sehr wahrscheinlich.
 * 
 * ====================================================================================================================================================================================================================================================================
 */

namespace Star_Simulation
{
    internal partial class Resource
    {
        public class MyPlanetResources
        {
            public required MyResourceList CoreResourceList { get; set; }
            public required MyResourceList MantleResourceList { get; set; }
            public required MyResourceList CrustResourceList { get; set; }
            /// <summary>
            /// The Crust Size measured in Meters.
            /// </summary>
            public required float CrustHeight { get; set; }
        }
        /// <summary>
        /// Generates the RawResources of a Planet.
        /// </summary>
        /// <returns>Basic RawResources Of the Planet</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyPlanetResources GeneratePlanetResources(SeedRandom seed)
        {
            try
            {
                if (Logging && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Core RawResources");
                if (LoggingFile && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Starting to Generate Planet Core RawResources; seedstate={seed.pos}");
                MyResourceList core = GeneratePlanetCoreResources(seed);

                if (Logging && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Mantle RawResources");
                if (LoggingFile && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Starting to Generate Planet Mantle RawResources; seedstate={seed.pos}");
                MyResourceList mantle = GeneratePlanetMantleResources(seed);

                if (Logging && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Crust RawResources");
                if (LoggingFile && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Starting to Generate Planet Crust RawResources; seedstate={seed.pos}");
                MyResourceList crust = GeneratePlanetCrustResources(seed);

                float crustSize = seed.Next<float>(70000, 20000);

                return new()
                {
                    CoreResourceList = core,
                    MantleResourceList = mantle,
                    CrustResourceList = crust,
                    CrustHeight = crustSize
                };
            }
            catch (Exception e)
            {
                ConsoleLogWrite([e.Message, e.HelpLink!]);
                throw;
            }
        }

        /// <summary>
        /// Generates the RawResources in the Core of a Planet.
        /// </summary>
        /// <returns>MyResourceList</returns>
        public static MyResourceList GeneratePlanetCoreResources(SeedRandom seed, bool log = false, bool logWrite = false)
        {
            ulong valueFeNi = seed.Next<ulong>(800_000, 700_000);
            ulong valueFe = valueFeNi / 2;
            ulong valueNi = valueFeNi / 2;
            ulong valueFeS = 1_000_000 - valueFeNi;
            MyResourceValue core_iron = new() { Value = valueFe, Resource = ResourceElement.Iron };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Iron\" with {core_iron.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Iron\" with {core_iron.Value}ppm.");

            MyResourceValue core_nickel = new() { Value = valueNi, Resource = ResourceElement.Nickel };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Nickel\" with {core_nickel.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Nickel\" with {core_nickel.Value}ppm.");

            MyResourceValue core_Ironsulfide = new() { Value = valueFeS, Resource = ResourceElement.FeS };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Ironsulfide\" with {core_Ironsulfide.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Ironsulfide\" with {core_Ironsulfide.Value}ppm.");

            //throw new NotImplementedException();

            //core.BuildRealResources();

            return new([
                core_iron,
                core_nickel,
                core_Ironsulfide
            ]);
        }
        /// <summary>
        /// Generates the RawResources in the Mantle of a Planet.
        /// </summary>
        /// <returns>MyResourceList</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyResourceList GeneratePlanetMantleResources(SeedRandom seed, bool log = false, bool logWrite = false)
        {
            ulong valueSiO2 = seed.Next<ulong>(460_000);
            ulong valueMgO = seed.Next<ulong>(380_000);
            ulong valueFeO = seed.Next<ulong>(80_000);
            ulong valueAl2O3 = seed.Next<ulong>(40_000);
            ulong valueCaO = seed.Next<ulong>(30_000);
            ulong o = 1000000 - (valueSiO2 + valueMgO + valueFeO + valueAl2O3 + valueCaO);
            ulong valueNa2O = o / 3;
            ulong valueCr2O3 = o / 3;
            ulong valueTiO2 = o / 3;

            MyResourceValue mantle_SiO2 = new() { Value = valueSiO2, Resource = ResourceElement.SiO2 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Silicon dioxide\" with {mantle_SiO2.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Silicon dioxide\" with {mantle_SiO2.Value}ppm.");

            MyResourceValue mantle_MgO = new() { Value = valueMgO, Resource = ResourceElement.MgO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Magnesium oxide\" with {mantle_MgO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Magnesium oxide\" with {mantle_MgO.Value}ppm.");

            MyResourceValue mantle_FeO = new() { Value = valueFeO, Resource = ResourceElement.FeO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Iron(II) oxide\" with {mantle_FeO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Iron(II) oxide\" with {mantle_FeO.Value}ppm.");

            MyResourceValue mantle_Al2O3 = new() { Value = valueAl2O3, Resource = ResourceElement.Al2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Aluminium oxide\" with {mantle_Al2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Aluminium oxide\" with {mantle_Al2O3.Value}ppm.");

            MyResourceValue mantle_CaO = new() { Value = valueCaO, Resource = ResourceElement.CaO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Calcium oxide\" with {mantle_CaO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Calcium oxide\" with {mantle_CaO.Value}ppm.");

            MyResourceValue mantle_Na2O = new() { Value = valueNa2O, Resource = ResourceElement.Na2O };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Sodium dioxide\" with {mantle_Na2O.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Sodium dioxide\" with {mantle_Na2O.Value}ppm.");

            MyResourceValue mantle_Cr2O3 = new() { Value = valueCr2O3, Resource = ResourceElement.Cr2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Cromium(III) oxide\" with {mantle_Cr2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Cromium(III) oxide\" with {mantle_Cr2O3.Value}ppm.");

            MyResourceValue mantle_TiO2 = new() { Value = valueTiO2, Resource = ResourceElement.TiO2 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Titanium dioxide\" with {mantle_TiO2.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Core Resource \"Titanium dioxide\" with {mantle_TiO2.Value}ppm.");

            //mantle.BuildRealResources();

            return new([
                mantle_SiO2,
                mantle_MgO,
                mantle_FeO,
                mantle_Al2O3,
                mantle_CaO,
                mantle_Na2O,
                mantle_Cr2O3,
                mantle_TiO2
            ]);
        }
        /// <summary>
        /// Generates the RawResources in the Crust of a Planet. (The Crust Size has to be Generated Separatly)
        /// </summary>
        /// <returns>MyResourceList</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyResourceList GeneratePlanetCrustResources(SeedRandom seed, bool log = false, bool logWrite = false)
        {
            ulong valueSiO2 = seed.Next<ulong>(650_000);
            ulong valueAl2O3 = seed.Next<ulong>(150_000);
            ulong valueCaO = seed.Next<ulong>(40_000);
            ulong valueFeO = seed.Next<ulong>(30_000);
            ulong valueFe2O3 = seed.Next<ulong>(30_000);
            ulong o = 1_000_000 - (valueSiO2 + valueAl2O3 + valueCaO + valueFeO + valueFe2O3);
            ulong valueMgO = o / 3;
            ulong valueNa2O = o / 3;
            ulong valueK2O = o / 3;

            //$"core GeneratePlanetResource, seed={seed.pos}", log
            //$"mantle GeneratePlanetResource, seed={seed.pos}", log
            //$"crust GeneratePlanetResource, seed={seed.pos}", log

            MyResourceValue crust_SiO2 = new() { Value = valueSiO2, Resource = ResourceElement.SiO2 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Silicon dioxide\" with {crust_SiO2.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Silicon dioxide\" with {crust_SiO2.Value}ppm.");

            MyResourceValue crust_Al2O3 = new() { Value = valueAl2O3, Resource = ResourceElement.Al2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Aluminium oxide\" with {crust_Al2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Aluminium oxide\" with {crust_Al2O3.Value}ppm.");

            MyResourceValue crust_CaO = new() { Value = valueCaO, Resource = ResourceElement.CaO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Calcium oxide\" with {crust_CaO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Calcium oxide\" with {crust_CaO.Value}ppm.");

            MyResourceValue crust_FeO = new() { Value = valueFeO, Resource = ResourceElement.FeO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Iron(II) oxide\" with {crust_FeO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Iron(II) oxide\" with {crust_FeO.Value}ppm.");

            MyResourceValue crust_Fe2O3 = new() { Value = valueFe2O3, Resource = ResourceElement.Fe2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Iron(III) oxide\" with {crust_Fe2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Iron(III) oxide\" with {crust_Fe2O3.Value}ppm.");

            MyResourceValue crust_MgO = new() { Value = valueMgO, Resource = ResourceElement.MgO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Magnesium oxide\" with {crust_MgO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Magnesium oxide\" with {crust_MgO.Value}ppm.");

            MyResourceValue crust_Na2O = new() { Value = valueNa2O, Resource = ResourceElement.Na2O };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Sodium dioxide\" with {crust_Na2O.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Sodium dioxide\" with {crust_Na2O.Value}ppm.");

            MyResourceValue crust_K2O = new() { Value = valueNa2O, Resource = ResourceElement.Na2O };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Potassium oxide\" with {crust_K2O.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile || ForceLoggingFile) LogWrite($"Generated Crust Resource \"Potassium oxide\" with {crust_K2O.Value}ppm.");

            //crust.BuildRealResources();

            return new([
                crust_SiO2,
                crust_Al2O3,
                crust_CaO,
                crust_FeO,
                crust_Fe2O3,
                crust_MgO,
                crust_Na2O,
                crust_K2O
            ]);
        }
    }
}