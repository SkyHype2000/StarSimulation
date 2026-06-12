using System.Globalization;
using System.Threading;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Systems;
using static Star_Simulation.Spectral;
using static Star_Simulation.Random;
using static Star_Simulation.GenerationTable;
using static Star_Simulation.Libary;

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

        /// <summary>
        /// General Logging File
        /// </summary>
        public static string LogfileName = $"log/{DateTime.Now.ToString("dd_MM_yyyy HH;mm;ss").Replace(";", "")}.log";
        /// <summary>
        /// Logging File for Generation of Object Type, Name and General Data in a Single Line
        /// </summary>
        public static string ObjectGenerationLogfileName = $"log/objectGeneration/{DateTime.Now.ToString("dd_MM_yyyy HH;mm;ss").Replace(";", "")}-GEN.log";
        /// <summary>
        /// Logging File of the Name Generation
        /// </summary>
        public static string NameGenerationLogfileName = $"log/nameGeneration/{DateTime.Now.ToString("dd_MM_yyyy HH;mm;ss").Replace(";", "")}-NAMEGEN.log";

        public static readonly SeedRandom Global_Seed = new SeedRandom("456756456745674");

        /// <summary>Activates the Logging of Some Generation-Values (This is the Main Switch, if you turn this of => No Logging.)</summary>
        public static bool Logging = true;
        /// <summary>Activates the Logging of Star-Generation</summary>
        public static bool StarLogging = true;
        /// <summary>Activates the Logging of Planet-Generation</summary>
        public static bool PlanetLogging = true;
        /// <summary>Activates the Logging of Proto Planet-Generation (There can be Many Proto Planets)</summary>
        public static bool ProtoPlanetLogging = false;
        /// <summary>Activates the Logging of Dwarf Planet-Generation (There can be Many Dwarf Planets, so deactivating this can be useful)</summary>
        public static bool DwarfPlanetLogging = false;
        /// <summary>Activates the Logging of Planet-Generation Test of avoiding SOI Collision of the Planet(or Dwarf Planet) with a Asteroid Belt (There can be Many Tests, so Deactivating may Help to keep the Console Readable)</summary>
        public static bool PlanetAsteroidBeltIterationLogging = false;
        /// <summary>Activates the Logging of Astroid-Generation (Not Recommendet if you still wan't to see whats happening in the COnsole)</summary>
        public static bool AstroidLogging = false;
        /// <summary>Activates the Logging of Astroid-Belt-Generation</summary>
        public static bool AstroidBeltLogging = true;

        public static bool LoggingFile = true;
        public static bool GenerationLoggingFile = true;
        public static bool PlacingTrysLoggingFile = true;
        public static bool NameLoggingFile = false;
        public static bool StarLoggingFile = true;
        public static bool PlanetLoggingFile = true;
        public static bool ProtoPlanetLoggingFile = false;
        public static bool DwarfPlanetLoggingFile = false;
        public static bool PlanetAsteroidBeltIterationLoggingFile = false;
        public static bool AstroidLoggingFile = false;
        public static bool AstroidBeltLoggingFile = true;

        /// <summary>
        /// Ignores All File-Logging Settings and Forces File Logging.<br/>
        /// This will Of course make the log-file Large af.
        /// </summary>
        public static bool ForceLoggingFile = false;

        /// <summary>
        /// Loggs The Generation of RawResources.<br/>
        /// Be Careful: This can make the Console Output Very Very Very Big (It will only log if Logging is True)
        /// </summary>
        public static bool ResourceGeneration_Logging = false;
        public static bool ResourceGeneration_StarLogging = false;
        public static bool ResourceGeneration_ProtoPlanetLogging = false;
        public static bool ResourceGeneration_DwarfPlanetLogging = false;
        public static bool ResourceGeneration_PlanetLogging = false;
        public static bool ResourceGeneration_AsteroidBeltLogging = false;
        public static bool ResourceGeneration_AsteroidLogging = false;
        public static bool ResourceGeneration_BuildResourceLogging = false;
        public static bool ResourceGeneration_ResourceListLogging = false;
        /// <summary>
        /// Loggs The Generation of RawResources into the Log-File.<br/>
        /// Be Careful: This can make the Log File Very Large.
        /// </summary>
        public static bool ResourceGeneration_LoggingFile = true;
        public static bool ResourceGeneration_StarLoggingFile = false;
        public static bool ResourceGeneration_ProtoPlanetLoggingFile = true;
        public static bool ResourceGeneration_DwarfPlanetLoggingFile = false;
        public static bool ResourceGeneration_PlanetLoggingFile = true;
        public static bool ResourceGeneration_AsteroidBeltLoggingFile = true;
        public static bool ResourceGeneration_AsteroidLoggingFile = false;
        public static bool ResourceGeneration_BuildResourceLoggingFile = true;
        public static bool ResourceGeneration_ResourceListLoggingFile = true;

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
         * ---------------------------------- Stern Generieren [  ] [Fertig]
         *    - Temperatur                                     [  ] [Fertig]
         *    - Watt-Leuchtstärke                              [  ] [Fertig]
         *    - Masse                                          [  ] [Fertig]
         *    - Lum und Subspektrale Klasse                    [  ] [Fertig]
         *    - Metalizität                                    [  ] [Zukunft] [Abhängigkeit Fehlt: Wissen]
         *    - Alter/Lebenszeit                               [  ] [Zukunft] [Abhängigkeit Fehlt: Metalizität]
         * 
         * ----------------------------- Asteroiden Generieren [  ] [Fertig]
         *    - Radius                                         [  ] [Fertig]
         *    - Masse                                          [  ] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [  ] [Fertig]
         *    - Orbitale Informationen                         [  ] [Fertig]
         *    - Typ                                            [  ] [Fertig]
         * 
         * ----------------------- Asteroidengürtel Generieren [  ] [Fertig]
         *    - Innen und Außenradius                          [  ] [Fertig]
         *    - Theoretische Asteroidenanzahl                  [  ] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [  ] [Fertig] (Noch Verbesserungswürdig, aber es erreicht mein Standard, also wird es sich erstmal nicht Verändern.)
         * 
         * ------------------------------- Planeten Generieren [  ] [Arbeite Dran]
         *    - Orbitale Informationen                         [  ] [Fertig]
         *    - Radius                                         [  ] [Fertig]
         *    - Masse                                          [  ] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [  ] [Fertig]
         *    - Oberflächentemperatur                          [  ] [Zukunft] [Abhängigkeit Fehlt: Atmosphäre]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    - Monde                                          [  ] [Zukunft]
         *    - Magnetfelder                                   [  ] [Zukunft]
         *    - Strahlung (Oberfläche)                         [  ] [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [  ] [Zukunft]
         * 
         * -------------------------- Zwergplaneten Generieren [  ] [Arbeite Dran]
         *    - Orbitale Informationen                         [  ] [Fertig]
         *    - Radius                                         [  ] [Fertig]
         *    - Masse                                          [  ] [Fertig]
         *    - Ressourcen/Zusammensetzung                     [  ] [Fertig]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    - Magnetfelder                                   [  ] [Zukunft]
         *    - Strahlung (Oberfläche)                         [  ] [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [  ] [Zukunft]
         * 
         * -------------------------- Protoplaneten Generieren [  ] [Arbeite Dran]
         *    - Orbitale Informationen                         [  ] [Fertig]
         *    - Radius                                         [  ] [Fertig]
         *    - Masse                                          [  ] [Fertig]
         *    - Ressourcen                                     [  ] [Fertig]
         *    - Oberflächentemperatur                          [  ] [Zukunft] [Abhängigkeit Fehlt: Atmosphäre]
         *    - Typ / Oberflächentyp                           [  ] [Zukunft]
         *    - Atmosphäre                                     [  ] [Zukunft]
         *    - Habitabel und Lebensarten                      [  ] [Zukunft]
         *    
         * ----------------------------- Ressourcen (Elemente) [  ] [Arbeite Dran]
         *    - Name                                           [  ] [Fertig]
         *    - Dichte                                         [  ] [Fertig]
         *    - Temperaturen                                   [  ] [Fertig]
         *    - Zustand & Typ                                  [  ] [Fertig]
         *    - Ressourcenverteilung                           [  ] [Fertig]
         *    
         * ---------------------------------------- Atmosphäre [  ] [Zukunft]
         *    - Druck                                          [  ] [Zukunft]
         *    - Farbe                                          [  ] [Zukunft]
         *    - Bestandteile                                   [  ] [Zukunft]
         *    - Treibhauseffekt                                [  ] [Zukunft]
         * 
         * =================== Nicht Essenziell ===================
         * 
         * ---------------------------------- Monde Generieren [  ] [Zukunft] [Abhängigkeit Fehlt: Motivation]
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
         * ---------------------------------------- Ressourcen [  ] [Fertig]
         *    - Dichte                                         [  ] [Fertig]
         *    - Vorkommen                                      [  ] [Fertig] (Zusammensetzung der Objekte Hart Einprogrammiert. Oberflächenvorkommen wie Ozeane oder Atmosphären kommen Später)
         *    - Wahrscheinlichkeit                             [  ] [Fertig]
         *    - Typ                                            [  ] [Fertig]
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
         *    - JSON                                           [Arbeite Dran]
         *    - CSV                                            [Zukunft]
         *    - Komprimierte Version                           [Zukunft] (Noch Unklar, aber Ideen wie habe ich schon)
         * 
         * =================== "Wenn" Ich Denke, dass ich alles Essenzielles Habe und bock drauf habe ===================
         * 
         * - Stellare QoL Dinge                                [  ] [Zukunft]
         *    - Distanzen Zwischen Planeten                    [  ] [Zukunft]
         *    - Transferinfos                                  [  ] [Zukunft]
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

            RUNNING = true;

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

                //GenerateOneStar();

                MassGenerateStars(1000, 100);
            }
            catch (Exception e)
            {
                ConsoleLogWrite([e.Message, e.HelpLink!]);

                RUNNING = false;
            }

            RUNNING = false;
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
                DateTime start = DateTime.Now;

                MyStar star = GenerateStar(Global_Seed);

                Export.ExportJSON<MyStar> export = new(star.Name, [star]);
                export.WriteJSON();

                DateTime end = DateTime.Now;
                ConsoleLogWrite($"It Took {(end - start)} Seconds to generate 1 System");
                ConsoleLogWrite("\nPress Any key for the next Star System. Or Q, C or ESC to stop the Program");

                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Q || key == ConsoleKey.C || key == ConsoleKey.Escape) break;
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
            DateTime start = DateTime.Now;

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

                GenerationLoggingFile = false;
                PlacingTrysLoggingFile = false;

                LoggingFile = false;
                StarLoggingFile = false;
                PlanetLoggingFile = false;
                ProtoPlanetLoggingFile = false;
                DwarfPlanetLoggingFile = false;
                PlanetAsteroidBeltIterationLoggingFile = false;
                AstroidLoggingFile = false;
                AstroidBeltLoggingFile = false;
                ForceLoggingFile = false;

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
                SeedRandom seed = new(Global_Seed.NextID(2));
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
            DateTime end = DateTime.Now;
            ConsoleLogWrite($"It Took {(end - start)} Seconds to generate {total * seedIterations} Systems ({total / (end - start).TotalSeconds}/s) with {seedIterations} Seed Changes; There are {AllObjectNum} Total Objects ({AllObjectNum / (end - start).TotalSeconds}/s)");
        }
    }
}