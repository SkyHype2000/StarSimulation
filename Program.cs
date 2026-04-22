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

        public static readonly SeedRandom rng = new SeedRandom("wiesoooooooooooooooooooooo");

        /// <summary>Activates the Logging of Some Generation-Values (Seperate Logging-Functions are not Controlled by this)</summary>
        public static bool Logging = true;
        /// <summary>Activates the Logging of Proto Planet-Generation (There can be Many Proto Planets)</summary>
        public static bool ProtoPlanetLogging = false;
        /// <summary>Activates the Logging of Dwarf Planet-Generation (There can be Many Dwarf Planets, so deactivating this can be useful)</summary>
        public static bool DwarfPlanetLogging = false;
        /// <summary>Activates the Logging of Planet-Generation Test of avoiding SOI Collision of the Planet(or Dwarf Planet) with a Asteroid Belt (There can be Many Tests, so Deactivating may Help to keep the Console Readable)</summary>
        public static bool PlanetAsteroidBeltLogging = false;
        /// <summary>Activates the Logging of Astroid-Generation (Not Recommendet if you still wan't to see whats happening in the COnsole)</summary>
        public static bool AstroidLogging = false;

        /*
         * Checkliste:
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
         * 
         * - Asteroiden Generieren                             [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Masse                                          [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Radius                                         [Fertig]
         *    - Orbitale Informationen                         [Fertig]
         *    - Typ                                            [Arbeite Dran] [Abhängigkeit Fehlt: Ressourcen]
         *    - Ressourcen                                     [Zukunft]
         * 
         * - Asteroidengürtel Generieren                       [Arbeite Dran]
         *    - Innen und Außenradius                          [Fertig]
         *    - Theoretische Asteroidenanzahl                  [Fertig]
         *    - Ressourcen                                     [Zukunft]
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
         * Nicht So Essenziell
         * 
         * - Monde Generieren                                  [Zukunft]
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
         *    - Farbe?                                         [Zukunft]
         * 
         * - Stellare Events                                   [Zukunft]
         *    - CME                                            [Zukunft]
         *    - Anomalien                                      [Zukunft]
         *    - Interstellare Besucher                         [Zukunft]
         * 
         * - Stellare QoL Dinge                                [Zukunft]
         *    - Distanzen Zwischen Planeten                    [Zukunft]
         *    - Transferinfos                                  [Zukunft]
         *    
         * - Exportieren                                       [Zukunft]
         *    - JSON                                           [Zukunft]
         *    - Webseiten?                                     [Zukunft]
         *    - Komprimierte Version                           [Zukunft]
         * 
         * "Wenn" Ich Denke, dass ich alles Essenzielles Habe oder bock drauf habe
         * - Anzeige / Rendering                               [Zukunft]
         * 
         * ===========================================================================================================================================
         */

        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

            Console.WriteLine($"Global Seed: {rng.seed}");
            try
            {
                GenerateSubspectralClasses();
                GenerationTableMain();

                //GenerateOneStar();
                MassGenerateStars(10000);
            }
            catch (Exception ex) { Console.WriteLine("An error occurred because of my or your incompetence: " + ex); }
        }

        public static void GenerateOneStar()
        {
            //LogAllLuminosityClasses();

            while (true)
            {
                DateTime start = DateTime.Now;
                Console.Clear();
                Console.WriteLine("\x1b[3J");

                GenerationTableLog();
                GenerateStar(rng);

                DateTime end = DateTime.Now;
                Console.WriteLine($"It Took {(end - start)} Seconds to generate 1 System");
                Console.WriteLine("\nDrücke Irgendeine Taste für das Nächste System");
                Console.ReadKey();
            }
        }

        public static void MassGenerateStars(uint total)
        {
            DateTime start = DateTime.Now;

            Logging = false;
            ProtoPlanetLogging = false;
            DwarfPlanetLogging = false;
            PlanetAsteroidBeltLogging = false;
            AstroidLogging = false;

            for (int i = 0; i < total; i++)
            {
                if ((i % 100) == 0)
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");
                    Console.WriteLine($"Current: {i.ToString().PadLeft(10, '0')}/{total.ToString().PadLeft(10, '0')} ");
                }

                GenerateStar(rng);
            }

            Console.Clear();
            Console.WriteLine("\x1b[3J");
            GenerationTableLog();
            DateTime end = DateTime.Now;
            Console.WriteLine($"It Took {(end - start)} Seconds to generate {total} Systems  ({total / (end - start).TotalSeconds}/s); There are {AllObjectNum} Total Objects ({AllObjectNum / (end - start).TotalSeconds}/s)");
        }
    }
}