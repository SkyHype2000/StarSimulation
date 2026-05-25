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
        public static MyPlanetResources GeneratePlanetResources(SeedRandom seed, bool log = false, bool logWrite = false)
        {
            try
            {
                if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Core RawResources");
                if (logWrite && ResourceGeneration_LoggingFile) ConsoleLog($"Starting to Generate Planet Core RawResources");
                MyResourceList core = GeneratePlanetCoreResources(seed, log);

                if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Mantle RawResources");
                if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Starting to Generate Planet Mantle RawResources");
                MyResourceList mantle = GeneratePlanetMantleResources(seed, log);

                if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Starting to Generate Planet Crust RawResources");
                if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Starting to Generate Planet Crust RawResources");
                MyResourceList crust = GeneratePlanetCrustResources(seed, log);

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
            MyResourceList core = new MyResourceList() { RawResources = [] };

            int valueFeNi = seed.Next<int>(800_000, 700_000);
            int valueFe = seed.Next<int>(800_000);
            int valueNi = valueFeNi - valueFe;
            int valueFeS = 1000 - valueFeNi;
            MyResourceValue core_iron = new() { Value = valueFe, Resource = ResourceElements.Iron };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Iron\" with {core_iron.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Iron\" with {core_iron.Value}ppm.");

            MyResourceValue core_nickel = new() { Value = valueNi, Resource = ResourceElements.Nickel };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Nickel\" with {core_nickel.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Nickel\" with {core_nickel.Value}ppm.");

            MyResourceValue core_Ironsulfide = new() { Value = valueFeS, Resource = ResourceElements.FeS };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Ironsulfide\" with {core_Ironsulfide.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Ironsulfide\" with {core_Ironsulfide.Value}ppm.");

            //throw new NotImplementedException();

            core.RawResources.Add(core_iron);
            core.RawResources.Add(core_nickel);
            core.RawResources.Add(core_Ironsulfide);

            core.BuildRealResources();

            return core;
        }
        /// <summary>
        /// Generates the RawResources in the Mantle of a Planet.
        /// </summary>
        /// <returns>MyResourceList</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyResourceList GeneratePlanetMantleResources(SeedRandom seed, bool log = false, bool logWrite = false)
        {
            MyResourceList mantle = new MyResourceList() { RawResources = [] };

            int valueSiO2 = seed.Next<int>(460_000);
            int valueMgO = seed.Next<int>(380_000);
            int valueFeO = seed.Next<int>(80_000);
            int valueAl2O3 = seed.Next<int>(40_000);
            int valueCaO = seed.Next<int>(30_000);
            int o = 1000000 - (valueSiO2 + valueMgO + valueFeO + valueAl2O3 + valueCaO);
            int valueNa2O = o / 3;
            int valueCr2O3 = o / 3;
            int valueTiO2 = o / 3;

            MyResourceValue mantle_SiO2 = new() { Value = valueSiO2, Resource = ResourceElements.SiO2 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Silicon dioxide\" with {mantle_SiO2.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Silicon dioxide\" with {mantle_SiO2.Value}ppm.");

            MyResourceValue mantle_MgO = new() { Value = valueMgO, Resource = ResourceElements.MgO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Magnesium oxide\" with {mantle_MgO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Magnesium oxide\" with {mantle_MgO.Value}ppm.");

            MyResourceValue mantle_FeO = new() { Value = valueFeO, Resource = ResourceElements.FeO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Iron(II) oxide\" with {mantle_FeO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Iron(II) oxide\" with {mantle_FeO.Value}ppm.");

            MyResourceValue mantle_Al2O3 = new() { Value = valueAl2O3, Resource = ResourceElements.Al2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Aluminium oxide\" with {mantle_Al2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Aluminium oxide\" with {mantle_Al2O3.Value}ppm.");

            MyResourceValue mantle_CaO = new() { Value = valueCaO, Resource = ResourceElements.CaO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Calcium oxide\" with {mantle_CaO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Calcium oxide\" with {mantle_CaO.Value}ppm.");

            MyResourceValue mantle_Na2O = new() { Value = valueNa2O, Resource = ResourceElements.Na2O };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Sodium dioxide\" with {mantle_Na2O.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Sodium dioxide\" with {mantle_Na2O.Value}ppm.");

            MyResourceValue mantle_Cr2O3 = new() { Value = valueCr2O3, Resource = ResourceElements.Cr2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Cromium(III) oxide\" with {mantle_Cr2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Cromium(III) oxide\" with {mantle_Cr2O3.Value}ppm.");

            MyResourceValue mantle_TiO2 = new() { Value = valueTiO2, Resource = ResourceElements.TiO2 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Core Resource \"Titanium dioxide\" with {mantle_TiO2.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Core Resource \"Titanium dioxide\" with {mantle_TiO2.Value}ppm.");

            mantle.RawResources.Add(mantle_SiO2);
            mantle.RawResources.Add(mantle_MgO);
            mantle.RawResources.Add(mantle_FeO);
            mantle.RawResources.Add(mantle_Al2O3);
            mantle.RawResources.Add(mantle_CaO);
            mantle.RawResources.Add(mantle_Na2O);
            mantle.RawResources.Add(mantle_Cr2O3);
            mantle.RawResources.Add(mantle_TiO2);

            mantle.BuildRealResources();

            return mantle;
        }
        /// <summary>
        /// Generates the RawResources in the Crust of a Planet. (The Crust Size has to be Generated Separatly)
        /// </summary>
        /// <returns>MyResourceList</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyResourceList GeneratePlanetCrustResources(SeedRandom seed, bool log = false, bool logWrite = false)
        {
            MyResourceList crust = new() { RawResources = [] };

            int valueSiO2 = seed.Next<int>(650_000);
            int valueAl2O3 = seed.Next<int>(150_000);
            int valueCaO = seed.Next<int>(40_000);
            int valueFeO = seed.Next<int>(30_000);
            int valueFe2O3 = seed.Next<int>(30_000);
            int o = 1_000_000 - (valueSiO2 + valueAl2O3 + valueCaO + valueFeO + valueFe2O3);
            int valueMgO = o / 3;
            int valueNa2O = o / 3;
            int valueK2O = o / 3;

            MyResourceValue crust_SiO2 = new() { Value = valueSiO2, Resource = ResourceElements.SiO2 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Silicon dioxide\" with {crust_SiO2.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Silicon dioxide\" with {crust_SiO2.Value}ppm.");

            MyResourceValue crust_Al2O3 = new() { Value = valueAl2O3, Resource = ResourceElements.Al2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Aluminium oxide\" with {crust_Al2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Aluminium oxide\" with {crust_Al2O3.Value}ppm.");

            MyResourceValue crust_CaO = new() { Value = valueCaO, Resource = ResourceElements.CaO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Calcium oxide\" with {crust_CaO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Calcium oxide\" with {crust_CaO.Value}ppm.");

            MyResourceValue crust_FeO = new() { Value = valueFeO, Resource = ResourceElements.FeO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Iron(II) oxide\" with {crust_FeO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Iron(II) oxide\" with {crust_FeO.Value}ppm.");

            MyResourceValue crust_Fe2O3 = new() { Value = valueFe2O3, Resource = ResourceElements.Fe2O3 };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Iron(III) oxide\" with {crust_Fe2O3.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Iron(III) oxide\" with {crust_Fe2O3.Value}ppm.");

            MyResourceValue crust_MgO = new() { Value = valueMgO, Resource = ResourceElements.MgO };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Magnesium oxide\" with {crust_MgO.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Magnesium oxide\" with {crust_MgO.Value}ppm.");

            MyResourceValue crust_Na2O = new() { Value = valueNa2O, Resource = ResourceElements.Na2O };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Sodium dioxide\" with {crust_Na2O.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Sodium dioxide\" with {crust_Na2O.Value}ppm.");

            MyResourceValue crust_K2O = new() { Value = valueNa2O, Resource = ResourceElements.Na2O };
            if (Logging && log && ResourceGeneration_Logging) ConsoleLog($"Generated Crust Resource \"Potassium oxide\" with {crust_K2O.Value}ppm.");
            if (logWrite && ResourceGeneration_LoggingFile) LogWrite($"Generated Crust Resource \"Potassium oxide\" with {crust_K2O.Value}ppm.");

            crust.RawResources.Add(crust_SiO2);
            crust.RawResources.Add(crust_Al2O3);
            crust.RawResources.Add(crust_CaO);
            crust.RawResources.Add(crust_FeO);
            crust.RawResources.Add(crust_Fe2O3);
            crust.RawResources.Add(crust_MgO);
            crust.RawResources.Add(crust_Na2O);
            crust.RawResources.Add(crust_K2O);

            crust.BuildRealResources();

            return crust;
        }
    }
}