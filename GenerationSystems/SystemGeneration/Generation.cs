using System.Xml.Linq;
using static Star_Simulation.Libary;
using static Star_Simulation.Program;
using static Star_Simulation.Random;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        public static readonly string[] syllables = [
            // Silben V1
            "ka" , "lo" , "ra" , "ze" , "tu" , "mi" , "xa" , "vi" , "no" ,
            "shi", "dra", "qu" , "ly" , "tor", "zan", "ny" , "fel", "vra",
            "zur", "kre", "tho", "bal", "ix" , "sy" , "jen", "kul", "orn",
            "nef", "ria", "sol", "mek", "tas", "lur", "xen", "cai", "vor",
            "hel", "ume", "zan", "tha", "py" , "rek", "gri", "yul", "zan",
            "eph", "ari", "zho", "the", "mur", "dax", "nix", "zor", "lim",
            // Silben V2
            "bri", "clo", "dre", "fen", "gla", "hro", "jor", "kli", "mar",
            "nel", "oph", "pra", "qua", "rin", "sha", "tre", "uln", "vex",
            "wra", "xis", "yra", "zor", "bex", "dru", "fla", "gra", "hul",
            "jum", "kor", "lek", "mip", "nox", "opl", "pru", "qui", "rax",
            "syl", "tri", "uvo", "vyn", "wex", "xil", "yan", "zep", "zor",
            "bax", "cro", "dav", "elx", "fra", "gyn", "hax", "jin", "kre",
            "lom", "myr", "nov", "oph", "plu", "qir", "rum", "syn", "tor",
            "urn", "vok", "wir", "xon", "yar", "zun"
        ];
        public static readonly string[] syllables2 = [
            // Vokal-lastig:
            "ae","io","eon","ua","ael",
            "ior","eia","ao","yre",
            // Harte Cluster:
            "kry","xth","drak","vyr",
            "zkr","thra","phor","qen",
            "skel","vrak",
            // Weiche Flows:
            "lira","mora","seli","vaen",
            "loru","nael","sira","thal",
            "reia","vuna",
        ];

        /// <summary>
        /// Anomaly Prefixes used for generating anomaly names.<br/><br/>
        /// <code>
        /// ANO (Normal Probability) (0.950): Normale Stellare Anomalie
        /// IOA (Rare Probability)   (0.049): Interstellare Anomalie
        /// ERB (Almost None)        (0.001): Einstein-Rosen Brücke
        /// </code>
        /// </summary>
        public static readonly string[] AnomalyPrefixes = new string[]
        {
            "ANO", "IOA", "ERB"
        };

        public enum CelestialObjectTypes
        {
            Star,
            Planet,
            Moon,
            AstroidBelt,
            Asteroid,
            Comet,
            Resource,
            Anomaly
        }

        /// <summary>
        /// Generates a Bad-Name string based on the specified type.
        /// </summary>
        /// <param name="type">The type of name to generate. If set to "anomaly", an anomaly-style name is generated.</param>
        /// <param name="seed">The Seed The Name is Generated For.</param>
        /// <returns>A generated name string corresponding to the specified type, or null if the type is not recognized.</returns>
        public static string GenerateName(CelestialObjectTypes type, SeedRandom seed)
        {
            if (type == CelestialObjectTypes.Anomaly)
            {
                seed.Push(0xF);
                string prefix = AnomalyPrefixes[seed.Next(syllables2.Length - 1)];
                string suffix = seed.Next(999, 0).ToString();

                return $"{prefix}-{suffix}";
            }
            else
            {
                seed.Push(0xF);
                string name = "";
                int length = 2 + seed.Next(2);
                for (int i = 0; i < length; i++)
                {
                    name += syllables2[seed.Next(syllables2.Length - 1)];
                }
                //ConsoleLog($"Name {type} length {length}");
                return char.ToUpper(name[0]) + name.Substring(1);
            }
        }

        public static readonly MinMax<int> GenerateName2_MinMaxPlanetDefault = new MinMax<int>(5, 12, false);
        public static readonly MinMax<int> GenerateName2_MinMaxStarDefault = new MinMax<int>(5, 10, false);
        public static readonly MinMax<int> GenerateName2_MinMaxMoonDefault = new MinMax<int>(5, 10, false);

        /// <summary>
        /// Generates a Name Using the Markov Algorythm.<br/>
        /// This Code was Assisted with AI. (I don't know if this sentence makes sense)
        /// </summary>
        /// <param name="seed"></param>
        /// <param name="names"></param>
        /// <param name="minMax"></param>
        /// <returns></returns>
        public static string GenerateNameMarkov(SeedRandom seed, string[] names, MinMax<int> minMax = null!)
        {
            if (minMax == null) minMax = new MinMax<int>(5, 10, false);
            int order = 3;
            var markov = new Dictionary<string, List<char>>();

            var existingNames = new HashSet<string>(names.Select(n => n.ToLower()));

            foreach (string name in names)
            {
                string padded = new string('_', order) + name.ToLower() + "_";
                for (int i = 0; i < padded.Length - order; i++)
                {
                    string key = padded.Substring(i, order);
                    char next = padded[i + order];

                    if (!markov.ContainsKey(key))
                        markov[key] = new List<char>();

                    markov[key].Add(next);
                }
            }

            string startKey = new string('_', order);

            if (!markov.ContainsKey(startKey))
            {
                string[] keys = markov.Keys.ToArray();
                startKey = keys[seed.Next(keys.Length, 0)];
            }

            int attempts = 0;
            while (attempts < 100)
            {
                attempts++;
                string currentKey = startKey;
                var result = new List<char>();

                while (true)
                {
                    if (!markov.ContainsKey(currentKey))
                        break;

                    var possible = markov[currentKey];
                    int index = seed.Next(possible.Count, 0);
                    char nextChar = possible[index];

                    if (nextChar == '_')
                        break;

                    result.Add(nextChar);
                    currentKey = currentKey.Substring(1) + nextChar;
                }

                string name = new string(result.ToArray());

                if (name.Length >= minMax.Min &&
                    name.Length <= minMax.Max &&
                    !existingNames.Contains(name))
                {
                    return char.ToUpper(name[0]) + name.Substring(1);
                }
            }

            return "NO NAME";
        }

    }
}
