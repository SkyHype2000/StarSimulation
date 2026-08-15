using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Xml.Linq;
using static Star_Simulation.GenerationTable;
using static Star_Simulation.Libary;
using static Star_Simulation.Random;
using static Star_Simulation.Spectral;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Systems;
using static Star_Simulation.LoggingOptions;

namespace Star_Simulation
{
    internal class Program
    {
        /// <summary>
        /// Star Generation Constant.<br/>
        /// Calculated using code I wrote what feels like around 9.2765 million years ago.<br/>
        /// Some Code was Copy-Paste from my olt Project, so i just Use this (Don't change a running System XD)
        /// </summary>
        public static readonly double STAR_GENERATION_CONSTANT = 1.0216388735543742521887522130876091683703957473078500310054178421533504358657415429775215553538366594d;
        public static bool RUNNING = false;

        public static SubspectralClass[] SubspectralClasses = [];

        public static readonly SeedRandom Global_Seed = new SeedRandom("Hallo");

        /*
         * Checkliste:
         * 
         * [EX] => Wird       Exportiert
         * [  ] => Wird Nicht Exportiert
         * 
         * ===========================================================================================================================================
         * 
         * =================== Essenziell ===================
         * 
         * ---------------------------------- Stern Generieren [EX] [Arbeite Dran]
         *    - Temperatur                                     [EX] [Fertig]
         *    - Watt-Leuchtstärke                              [EX] [Fertig]
         *    - Masse                                          [  ] [Momentan Fertig] [Abhängigkeit Fehlt: Zusammensetzung]
         *    - Zusammensetzung                                [  ] [Arbeite Dran]
         *    - Lum und Sub-/spektrale Klasse                  [EX] [Momentan Fertig] [Abhängigkeit Fehlt: Zusammensetzung & Masse & Alter]
         *    - Metalizität                                    [  ] [Zukunft] [Abhängigkeit Fehlt: Wissen & Zusammensetzung]
         *    - Alter/Lebenszeit                               [  ] [Zukunft] [Abhängigkeit Fehlt: Metalizität]
         * 
         * ----------------------------- Asteroiden Generieren [EX] [Fertig]
         *    - Radius                                         [EX] [Fertig]
         *    - Masse                                          [EX] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [EX] [Fertig]
         *    - Orbitale Informationen                         [EX] [Fertig]
         *    - Typ                                            [EX] [Fertig]
         *    - Alter                                          [  ] [Zukunft/Nicht Wichtig]
         * 
         * ----------------------- Asteroidengürtel Generieren [EX] [Fertig]
         *    - Innen und Außenradius                          [EX] [Fertig]
         *    - Theoretische Asteroidenanzahl                  [EX] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [EX] [Fertig] (Noch Verbesserungswürdig, aber es erreicht mein Standard, also wird es sich erstmal nicht Verändern.)
         *    - Alter                                          [  ] [Zukunft/Nicht Wichtig]
         * 
         * ------------------------------- Planeten Generieren [EX] [Arbeite Dran]
         *    - Orbitale Informationen                         [EX] [Fertig]
         *    - Radius                                         [EX] [Fertig]
         *    - Masse                                          [EX] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [EX] [Fertig]
         *    - Oberflächentemperatur                          [  ] [Zukunft] [Abhängigkeit Fehlt: Atmosphäre]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    - Monde                                          [  ] [Zukunft]
         *    - Magnetfelder                                   [  ] [Zukunft]
         *    - Strahlung (Oberfläche)                         [  ] [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [  ] [Zukunft]
         *    - Alter                                          [  ] [Zukunft/Nicht Wichtig]
         * 
         * -------------------------- Zwergplaneten Generieren [EX] [Arbeite Dran]
         *    - Orbitale Informationen                         [EX] [Fertig]
         *    - Radius                                         [EX] [Fertig]
         *    - Masse                                          [EX] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [EX] [Fertig]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    - Magnetfelder                                   [  ] [Zukunft]
         *    - Strahlung (Oberfläche)                         [  ] [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [  ] [Zukunft]
         *    - Alter                                          [  ] [Zukunft/Nicht Wichtig]
         * 
         * -------------------------- Protoplaneten Generieren [EX] [Arbeite Dran]
         *    - Orbitale Informationen                         [EX] [Fertig]
         *    - Radius                                         [EX] [Fertig]
         *    - Masse                                          [EX] [Fertig]
         *    - Ressourcen                                     [EX] [Fertig]
         *    - Oberflächentemperatur                          [  ] [Zukunft] [Abhängigkeit Fehlt: Atmosphäre]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    - Alter                                          [  ] [Zukunft/Nicht Wichtig]
         *    
         * ----------------------------- Ressourcen (Elemente) [EX] [Arbeite Dran]
         *    - Name                                           [EX] [Fertig]
         *    - Dichte                                         [EX] [Fertig]
         *    - Temperaturen                                   [EX] [Fertig]
         *    - Zustand & Typ                                  [EX] [Fertig]
         *    - Ressourcenverteilung                           [EX] [Fertig]
         *    
         * ---------------------------------------- Atmosphäre [  ] [Zukunft]
         *    - Druck                                          [  ] [Zukunft]
         *    - Farbe                                          [  ] [Zukunft] [Abhängigkeit Fehlt: Zusammensetzung]
         *    - Zusammensetzung                                [  ] [Zukunft]
         *    - Treibhauseffekt                                [  ] [Zukunft]
         * 
         * =================== Nicht Essenziell ===================
         * 
         * ---------------------------------- Monde Generieren [  ] [Zukunft] [Abhängigkeit Fehlt: Motivation]
         * => Die Generation von Monden ist Schwerer als die des Mutterobjektes(Planeten/etc.) weil er Platz in der SOI des Mutterobjektes finden muss,
         *    während seine eigene SOI nicht mit der Roche Grenze des Mutterobjektes Kollidieren Darf, aber auch nicht die SOI des Mutterobjektes überschreiten darf.
         *    The Generation of Moons are Harder than the Generation of the Main Object(Planets/etc.) because it has to find a Place in the SOI of the Main Object,
         *    while his own SOI cannot Collide with the Roche height of the Main Object, but the SOI of the Moon also can't collide or go Bejond the SOI of the Main Object.
         *    - Orbitale Informationen                         [  ] [Zukunft]
         *    - Masse                                          [  ] [Zukunft]
         *    - Radius                                         [  ] [Zukunft]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    - Ressourcen                                     [  ] [Zukunft]
         *    - Magnetfelder                                   [  ] [Zukunft]
         *    - Strahlung (Oberfläche)                         [  ] [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [  ] [Zukunft]
         * 
         * ---------------------------------------- Ressourcen [EX] [Fertig]
         *    - Dichte                                         [EX] [Fertig]
         *    - Vorkommen                                      [EX] [Fertig] (Zusammensetzung der Objekte Hart Einprogrammiert. Oberflächenvorkommen wie Ozeane oder Atmosphären kommen Später)
         *    - Wahrscheinlichkeit                             [EX] [Fertig]
         *    - Typ                                            [EX] [Fertig]
         * 
         * ---------------------------------------- Atmosphäre [  ] [Zukunft]
         *    - Bestandteile                                   [  ] [Zukunft]
         *    - Höhe                                           [  ] [Zukunft]
         *    - Dichte                                         [  ] [Zukunft]
         *    - Treibhauseffekt                                [  ] [Zukunft]
         *    - Temperatur                                     [  ] [Zukunft]
         *    - Farbe                                          [  ] [Zukunft] [Braucht Anzeige/Rendering, obwohl man es auch ohne Anzeige machen könnte, wäre dann aber nicht so Lustig.]
         * 
         * ----------------------------------- Stellare Events [  ] [Zukunft]
         *    - CME/CME-Wahrscheinlichkeit                     [  ] [Zukunft]
         *    - Anomalien                                      [  ] [Zukunft]
         *    - Interstellare Besucher                         [  ] [Zukunft]
         *    
         * ---------------------------------------- Eportieren
         *    - JSON                                           [Momentan Fertig]
         *    - CSV                                            [Zukunft]
         *    - NBT                                            [Zukunft]
         * 
         * =================== "Wenn" Ich Denke, dass ich alles Essenzielles Habe und bock drauf habe ===================
         * 
         * - Stellare QoL Dinge                                [Zukunft]
         *    - Distanzen Zwischen Planeten                    [Zukunft]
         *    - Transferinfos                                  [Zukunft]
         *    
         * - Anzeige / Rendering                               [Zukunft]
         * 
         * ===========================================================================================================================================
         */

        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            //ConsoleLog($"Global Seed: {Global_Seed.seed}");

            if (!Directory.Exists(LogFolderName)) Directory.CreateDirectory(LogFolderName);

            if (!Directory.Exists(ObjectGenerationLogFolderName)) Directory.CreateDirectory(ObjectGenerationLogFolderName);
            if (!Directory.Exists(LoggingFile_JSON_Folder)) Directory.CreateDirectory(LoggingFile_JSON_Folder);
            if (!Directory.Exists(StarLoggingFile_JSON_Folder)) Directory.CreateDirectory(StarLoggingFile_JSON_Folder);
            if (!Directory.Exists(PlanetLoggingFile_JSON_Folder)) Directory.CreateDirectory(PlanetLoggingFile_JSON_Folder);
            if (!Directory.Exists(ProtoPlanetLoggingFile_JSON_Folder)) Directory.CreateDirectory(ProtoPlanetLoggingFile_JSON_Folder);
            if (!Directory.Exists(DwarfPlanetLoggingFile_JSON_Folder)) Directory.CreateDirectory(DwarfPlanetLoggingFile_JSON_Folder);
            if (!Directory.Exists(AsteroidLoggingFile_JSON_Folder)) Directory.CreateDirectory(AsteroidLoggingFile_JSON_Folder);
            if (!Directory.Exists(AsteroidBeltLoggingFile_JSON_Folder)) Directory.CreateDirectory(AsteroidBeltLoggingFile_JSON_Folder);

            if (!Directory.Exists(NameGenerationLogFolderName)) Directory.CreateDirectory(NameGenerationLogFolderName);

            RUNNING = true;
            LogWriteStart();

            Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    ConsoleLogWrite("Shutdown requested (Ctrl+C)...");

                    Environment.Exit(0);
                };

            try
            {
                ConsoleLogWrite($"Global Seed: {Global_Seed.seed}");
                GenerateSubspectralClasses();
                GenerationTableMain();

                GenerateOneStar();

                //MassGenerateStars(1000, 100);
            }
            catch (Exception e)
            {
                ConsoleLogWrite([e.Message, e.HelpLink!]);

                RUNNING = false;
            }

            RUNNING = false;
            while (!LogValues.IsEmpty) { }
            Environment.Exit(0);
        }

        /// <summary>
        /// Generates one Star.
        /// </summary>
        public static void GenerateOneStar()
        {
            //LogAllLuminosityClasses();

            ConsoleLogWrite("Creating One Star");

            GenerationTableLog();

            while (true)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                MyStar star = GenerateStar(Global_Seed);

                stopwatch.Stop();
                ConsoleLogWrite($"It Took {stopwatch.Elapsed.TotalSeconds} Seconds to generate 1 System");
                ConsoleLogWrite("\nPress Any key for the next Star System, Press Q, C or ESC to stop the Program");

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q || key == ConsoleKey.C || key == ConsoleKey.Escape) break;
                if (LoggingFile_JSON && StarLoggingFile_JSON)
                {
                    string stellarSystemJSON = JsonSerializer.Serialize(star, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles,
                        MaxDepth = 128,
                        WriteIndented = true,
                        IncludeFields = true,
                        NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                    });
                    LogWrite(stellarSystemJSON, $"{StarLoggingFile_JSON_Folder}/{star.Name}-{star.ID}.json", true, true);
                }
                Console.Clear();
                ConsoleLog("\x1b[3J");
            }
        }

        /// <summary>
        /// Wie Viele Sterne Generiert werden Sollen (Performance-Test und nix Praktisches)
        /// </summary>
        /// <param name="total"></param>
        public static void MassGenerateStars(uint total = 1000, uint seedIterations = 1, bool overwriteLogging = true)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            ConsoleLogWrite("Mass Generating Stars");

            if (overwriteLogging)
            {
                Logging = false;
                StarLogging = false;
                PlanetLogging = false;
                ProtoPlanetLogging = false;
                DwarfPlanetLogging = false;
                PlanetAsteroidBeltIterationLogging = false;
                AstroidLogging = false;
                AstroidBeltLogging = false;

                ObjectGenerationLogging = false;
                ObjectGenerationPlacingTrysLoggingFile = false;

                LoggingFile = false;
                ObjectGenerationStarLoggingFile = false;
                ObjectGenerationPlanetLoggingFile = false;
                ObjectGenerationProtoPlanetLoggingFile = false;
                ObjectGenerationDwarfPlanetLoggingFile = false;
                ObjectGenerationPlanetAsteroidBeltIterationLoggingFile = false;
                ObjectGenerationAsteroidLoggingFile = false;
                ObjectGenerationAsteroidBeltLoggingFile = false;
                ForceLoggingFile = false;

                LoggingFile_JSON = false;
                StarLoggingFile_JSON = false;
                PlanetLoggingFile_JSON = false;
                ProtoPlanetLoggingFile_JSON = false;
                DwarfPlanetLoggingFile_JSON = false;
                AsteroidLoggingFile_JSON = false;
                AsteroidBeltLoggingFile_JSON = false;

                ResourceGeneration_Logging = false;
                ResourceGeneration_StarLogging = false;
                ResourceGeneration_ProtoPlanetLogging = false;
                ResourceGeneration_DwarfPlanetLogging = false;
                ResourceGeneration_PlanetLogging = false;
                ResourceGeneration_AsteroidBeltLogging = false;
                ResourceGeneration_AsteroidLogging = false;
                ResourceGeneration_BuildResourceLogging = false;
                ResourceGeneration_ResourceListLogging = false;

                ResourceGeneration_LoggingFile = false;
                ResourceGeneration_StarLoggingFile = false;
                ResourceGeneration_ProtoPlanetLoggingFile = false;
                ResourceGeneration_DwarfPlanetLoggingFile = false;
                ResourceGeneration_PlanetLoggingFile = false;
                ResourceGeneration_AsteroidBeltLoggingFile = false;
                ResourceGeneration_AsteroidLoggingFile = false;
                ResourceGeneration_BuildResourceLoggingFile = false;
                ResourceGeneration_ResourceListLoggingFile = false;
            }

            for (int i = 0; i < seedIterations; i++)
            {
                SeedRandom seed = new(Global_Seed.NextID(2, 8));
                for (int j = 0; j < total; j++)
                {
                    if ((j % 25) == 0 && overwriteLogging)
                    {
                        Console.Clear();
                        ConsoleLog("\x1b[3J");
                        ConsoleLog($"Seed: {seed.seed}");
                        ConsoleLogWrite($"Current: {(j + (i * total)).ToString().PadLeft(10, '0')}/{(total * seedIterations).ToString().PadLeft(10, '0')}");
                    }

                    GenerateStar(seed);
                }
            }

            Console.Clear();
            ConsoleLog("\x1b[3J");
            GenerationTableLog();
            stopwatch.Stop();
            ConsoleLogWrite($"It Took {stopwatch.Elapsed.TotalSeconds} Seconds to generate {total * seedIterations} Systems ({total / stopwatch.Elapsed.TotalSeconds}/s) with {seedIterations} Seed Changes; There are {AllObjectNum} Total Objects ({AllObjectNum / stopwatch.Elapsed.TotalSeconds}/s)");
        }
    }
}