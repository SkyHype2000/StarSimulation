using System.Globalization;
using System.Threading;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Spectral;
using static Star_Simulation.Random;
using static Star_Simulation.GenerationTable;
using static Star_Simulation.Luminosity;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal class Program
    {
        /// <summary>
        /// Star Generation Constant.<br/>
        /// Calculated using code I wrote what feels like around 9.2765 million years ago.
        /// </summary>
        public static readonly double STAR_GENERATION_CONSTANT = 1.0216388735543742521887522130876091683703957473078500310054178421533504358657415429775215553538366594d;

        public static ISubspectralClass[] SubspectralClasses = [];

        public static readonly SeedRandom Global_Seed = new SeedRandom("512351234");

        /// <summary>Activates the Logging of Some Generation-Values (This is the Main Switch, if you turn this of => No Logging.)</summary>
        public static bool Logging = true;
        /// <summary>Activates the Logging of Proto Planet-Generation (There can be Many Proto Planets)</summary>
        public static bool ProtoPlanetLogging = false;
        /// <summary>Activates the Logging of Dwarf Planet-Generation (There can be Many Dwarf Planets, so deactivating this can be useful)</summary>
        public static bool DwarfPlanetLogging = false;
        /// <summary>Activates the Logging of Planet-Generation Test of avoiding SOI Collision of the Planet(or Dwarf Planet) with a Asteroid Belt (There can be Many Tests, so Deactivating may Help to keep the Console Readable)</summary>
        public static bool PlanetAsteroidBeltLogging = false;
        /// <summary>Activates the Logging of Astroid-Generation (Not Recommendet if you still wan't to see whats happening in the COnsole)</summary>
        public static bool AstroidLogging = false;
        /// <summary>Activates the Logging of Astroid-Belt-Generation</summary>
        public static bool AstroidBeltLogging = true;

        /*
         * Checkliste:
         * 
         * Momentan:
         * Ressourcen
         * (Stellare) Ressourcenverteilung für Dichten der Schichten eines Stellaren Objekts
         * 
         * ===========================================================================================================================================
         * 
         * Essenziell
         * 
         * - Stern Generieren                                  [Fertig]
         *    - Temperatur                                     [Fertig]
         *    - Watt-Leuchtstärke                              [Fertig]
         *    - Masse                                          [Fertig]
         *    - Lum und Subspektrale Klasse                    [Fertig]
         *    - Metalizität                                    [Zukunft] [Abhängigkeit Fehlt: Ressourcen]
         *    - Alter/Lebenszeit                               [Zukunft] [Abhängigkeit Fehlt: Metalizität]
         * 
         * - Asteroiden Generieren                             [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Masse                                          [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Radius                                         [Fertig]
         *    - Orbitale Informationen                         [Fertig]
         *    - Typ                                            [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Ressourcen                                     [Zukunft] [Abhängigkeit Fehlt: Ressourcen]
         * 
         * - Asteroidengürtel Generieren                       [Arbeite Dran]
         *    - Innen und Außenradius                          [Fertig]
         *    - Theoretische Asteroidenanzahl                  [Fertig]
         *    - Ressourcen                                     [Zukunft] [Abhängigkeit Fehlt: Ressourcen]
         * 
         * - Planeten Generieren                               [Arbeite Dran]
         *    - Orbitale Informationen                         [Fertig]
         *    - Masse                                          [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Radius                                         [Fertig]
         *    - Oberflächentemperatur                          [Arbeite Dran] [Abhängigkeit Fehlt: Atmosphäre]
         *    - Typ / Oberflächentyp                           [Zukunft]
         *    - Atmosphäre                                     [Zukunft]
         *    - Habitabel und Lebensarten                      [Zukunft]
         *    - Monde                                          [Zukunft]
         *    - Ressourcen                                     [Zukunft]
         *    - Magnetfelder                                   [Zukunft]
         *    - Strahlung (Oberfläche)                         [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [Zukunft]
         * 
         * - Zwergplaneten Generieren                          [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Orbitale Informationen                         [Fertig]
         *    - Masse                                          [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Radius                                         [Zukunft]
         *    - Typ / Oberflächentyp                           [Zukunft]
         *    - Atmosphäre                                     [Zukunft]
         *    - Habitabel und Lebensarten                      [Zukunft]
         *    - Ressourcen                                     [Zukunft]
         *    - Magnetfelder                                   [Zukunft]
         *    - Strahlung (Oberfläche)                         [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [Zukunft]
         * 
         * - Protoplaneten Generieren                          [Arbeite Dran]
         *    - Orbitale Informationen                         [Fertig]
         *    - Masse                                          [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Radius                                         [Fertig]
         *    - Oberflächentemperatur                          [Arbeite Dran] [Abhängigkeit Fehlt: Atmosphäre]
         *    - Typ / Oberflächentyp                           [Fertig]
         *    - Atmosphäre                                     [Zukunft]
         *    - Habitabel und Lebensarten                      [Zukunft]
         *    - Ressourcen                                     [Zukunft]
         *    
         * - Ressourcen (Elemente)                             [Arbeite Dran]
         *    - Name                                           [Fertig]
         *    - Dichte                                         [Fertig]
         *    - Temperaturen                                   [Fertig]
         *    - Zustand & Typ                                  [Fertig]
         *    - Ressourcenverteilung                           [Arbeite Dran]
         *    
         * - Atmosphäre                                        [Zukunft]
         *    - Druck                                          [Zukunft]
         *    - Farbe                                          [Zukunft] [Abhängigkeit Fehlt: Ressourcen]
         *    - Bestandteile                                   [Zukunft] [Abhängigkeit Fehlt: Ressourcen]
         *    - Treibhauseffekt                                [Zukunft] [Abhängigkeit Fehlt: Ressourcen]
         * 
         * Nicht So Essenziell
         * 
         * - Monde Generieren                                  [Zukunft] [Abhängigkeit Fehlt: Motivation]
         *    - Orbitale Informationen                         [Zukunft]
         *    - Masse                                          [Zukunft]
         *    - Radius                                         [Zukunft]
         *    - Typ / Oberflächentyp                           [Zukunft]
         *    - Atmosphäre                                     [Zukunft]
         *    - Habitabel und Lebensarten                      [Zukunft]
         *    - Ressourcen                                     [Zukunft]
         *    - Magnetfelder                                   [Zukunft]
         *    - Strahlung (Oberfläche)                         [Zukunft]
         *    - Strahlung (Strahlungsgürtel)                   [Zukunft]
         * 
         * - Ressourcen                                        [Zukunft]
         *    - Dichte                                         [Zukunft]
         *    - Vorkommen                                      [Zukunft]
         *    - Wahrscheinlichkeit                             [Zukunft]
         *    - Eigenschaften                                  [Zukunft]
         *    - Typ                                            [Zukunft]
         * 
         * - Atmosphäre                                        [Zukunft]
         *    - Bestandteile                                   [Zukunft]
         *    - Höhe                                           [Zukunft]
         *    - Dichte                                         [Zukunft]
         *    - Treibhauseffekt                                [Zukunft]
         *    - Temperatur                                     [Zukunft]
         *    - Farbe                                          [Zukunft] [Braucht Anzeige/Rendering]
         * 
         * - Stellare Events                                   [Zukunft]
         *    - CME                                            [Zukunft]
         *    - Anomalien                                      [Zukunft]
         *    - Interstellare Besucher                         [Zukunft]
         *    
         * - Exportieren                                       [Zukunft]
         *    - JSON                                           [Zukunft]
         *    - CSV                                            [Zukunft]
         *    - Komprimierte Version                           [Zukunft]
         * 
         * "Wenn" Ich Denke, dass ich alles Essenzielles Habe und bock drauf habe
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

            Console.WriteLine($"Global Seed: {Global_Seed.seed}");
            try
            {
                GenerateSubspectralClasses();
                GenerationTableMain();

                GenerateOneStar();
                //MassGenerateStars(1000, 10);
            }
            catch (Exception ex) { Console.WriteLine("An error occurred because of my or your incompetence: " + ex); }
        }

        /// <summary>
        /// Generates one Star.
        /// </summary>
        public static void GenerateOneStar()
        {
            //LogAllLuminosityClasses();

            while (true)
            {
                DateTime start = DateTime.Now;
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                GenerationTableLog();
                GenerateStar(Global_Seed);

                DateTime end = DateTime.Now;
                Console.WriteLine($"It Took {(end - start)} Seconds to generate 1 System");
                Console.WriteLine("\nDrücke Irgendeine Taste für das Nächste System");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Wie Viele Sterne Generiert werden Sollen (Performance-Test und nix Praktisches)
        /// </summary>
        /// <param name="total"></param>
        public static void MassGenerateStars(uint total = 1000, uint seedIterations = 1, bool overwriteLogging = true)
        {
            DateTime start = DateTime.Now;

            if (overwriteLogging)
            {
                Logging = false;
                ProtoPlanetLogging = false;
                DwarfPlanetLogging = false;
                PlanetAsteroidBeltLogging = false;
                AstroidLogging = false;
            }

            for (int i = 0; i < seedIterations; i++)
            {
                SeedRandom seed = new SeedRandom(Global_Seed.NextID(4));

                for (int j = 0; j < total; j++)
                {
                    if ((j % 25) == 0 && overwriteLogging)
                    {
                        Console.Clear();
                        Console.WriteLine("\x1b[3J");
                        Console.WriteLine($"Seed: {seed.seed}");
                        Console.WriteLine($"Current: {(j+(i * total)).ToString().PadLeft(10, '0')}/{(total*seedIterations).ToString().PadLeft(10, '0')}");
                    }

                    GenerateStar(seed);
                }
            }

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            GenerationTableLog();
            DateTime end = DateTime.Now;
            Console.WriteLine($"It Took {(end - start)} Seconds to generate {total*seedIterations} Systems ({total / (end - start).TotalSeconds}/s) with {seedIterations} Seed Changes; There are {AllObjectNum} Total Objects ({AllObjectNum / (end - start).TotalSeconds}/s)");
        }
    }
}