
using static Star_Simulation.Libary;
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
        /// ERB (Almost None)        (0.001): Einstein-Rosen Brücke (It is still a game-thing i'am programming here)
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
        /// Generates a name string based on the specified type.
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
                //Console.WriteLine($"Name {type} length {length}");
                return char.ToUpper(name[0]) + name.Substring(1);
            }
        }

        public static readonly string[] starNames = new string[]
        {
            "Sirius", "Vega", "Rigel", "Betelgeuse", "Procyon", "Altair",
            "Deneb", "Polaris", "Antares", "Aldebaran", "Spica", "Fomalhaut",
            "Canopus", "Arcturus", "Capella", "Bellatrix", "Regulus",
            "Achernar", "Mira", "Mintaka", "Saiph", "Alnitak",

            "Layla", "Jeans", "Mailo", "Calidus",

            "Aurexion","Velkaris","Therynox","Zyphar","Korellan",
            "Mystryx","Vandoril","Helionyx","Xathir","Eldraxis",
            "Nemorath","Kalystron","Orvexis","Tychoran",
            "Zeraphis","Lumirax","Vaelthor","Dravion","Nyxaris",
            "Solthera","Cryndor","Virellos","Axiondra","Beltharix",
            "Syrenox","Tormyra","Zaltheron","Kyralis","Morveth",
            "Yllaris","Theraxon","Velmora","Arkanis","Drexalon",
            "Sylvaris","Krythar","Nexoria","Valtheris","Zorynth",
            "Helvaron","Myralon","Xerethis","Talyxar","Vorenth",
            "Lysandrax","Zenthora","Kaelith","Orvannis","Myraxor",
            "Thalorien",

            "Aetheron","Pyralis","Voltyra","Caelion","Ryxalon",
            "Thalorix","Vaeryn","Zylaris","Quenthar","Draeven",
            "Mytheon","Solvyr","Keraith","Orlyx","Zerionyx",
            "Baelthor","Calystrix","Nytherion","Voryxis","Elarion",
            "Typheros","Xandriel","Vaelion","Korvaxis","Lunatrix",
            "Sylphaen","Ardoryx","Zekarion","Velarix","Morvion",
            "Heliovar","Crysalon","Xythera","Tyranor","Aurethys",
            "Zalvion","Kaedrix","Nemorix","Vexalion","Thoryn",
            "Ylthera","Draconis Minor","Virexion","Aelythor",
            "Zorvane","Myxaris","Opheryn","Kelvaris","Vaelorin",
            "Zyphion",

            "Kaedrion","Zorvax","Thyrex","Vaeloron","Krythar",
            "Xyphon","Draexor","Velkyr","Morveth","Zenthrix",
            "Aetheron","Kaldrax","Tyvorn","Vexarion","Orlix",
        };

        public static readonly string[] planetNames = new string[]
        {
            "Earth", "Mars", "Venus", "Jupiter", "Saturn", "Mercury",
            "Neptune", "Uranus", "Kepler", "Rhea", "Titan", "Ariel",
            "Oberon", "Triton", "Charon", "Europa", "Ganymede",
            "Callisto", "Io", "Ceres", "Makemake", "Haumea",

            "Rhodi", "Nubis", "Mailo", "Deutschland",

            "Ilyra","Vexis","Thyra","Korune","Zelith","Arvion",
            "Nythera","Polaris Minor","Drentha","Solune",
            "Kythera Prime","Velis","Orthis","Xandor","Belora",
            "Cyris","Luneth","Tarex","Zyra","Morin","Elyndra",
            "Vorth","Kaelis","Syrune","Avaris","Nexis","Tylor",
            "Orinex","Valis","Zethra","Myron","Helis","Dorex",
            "Vireth","Kalon","Xyraxis","Theris","Lorana","Zereth",
            "Koralis","Nyra Prime","Eronis","Talix","Vendra",
            "Oryth","Sylar","Kethis","Ylora","Drayth","Velune",

           "Aelyra","Vorune","Kethra","Syphor","Zalara","Orveth",
            "Taryx","Velora","Nyris","Calyra","Dorelia","Xanthis",
            "Belune","Korath","Elyon","Virelia","Zyrene","Mythra",
            "Oryxis","Thyrel","Kaedon","Vexora","Lyrune","Solarae",
            "Nexora","Ydris","Valora","Zethis","Morune","Helora",
            "Tyrelis","Arveth","Xylar","Cyrune","Velith","Dranor",
            "Koreth","Avarune","Nyxis","Talyra","Oranis","Zyphra",
            "Kelune","Myronis","Voreth","Elaris","Syrath","Lunara",
            "Xandis","Therune",

            "Aelira","Voryna","Kelune","Syrara","Nythera","Liora",
            "Vaeruna","Oranis","Zyphora","Myrelis","Talyra","Elarune",
            "Cyrune","Velorae","Koruna",
        };

        public static readonly MinMax<int> GenerateName2_MinMaxPlanetDefault = new MinMax<int>(4, 10, false);
        public static readonly MinMax<int> GenerateName2_MinMaxStarDefault = new MinMax<int>(4, 12, false);

        public static string GenerateName2(SeedRandom seed, string[] names, MinMax<int> minMax = null!)
        {
            if (minMax == null) minMax = new MinMax<int>(2, 10, false);
            int order = 2;
            var markov = new Dictionary<string, List<char>>();

            foreach (var name in names)
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

            string[] keys = new string[markov.Keys.Count];
            markov.Keys.CopyTo(keys, 0);
            string currentKey = keys[seed.Next(keys.Length, 0)];
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

            if (result.Count == 0 || !(result.Count >= minMax.Min && result.Count < minMax.Max)) return GenerateName2(seed, names);
            string finalName = new string(result.ToArray());
            finalName = char.ToUpper(finalName[0]) + finalName.Substring(1);

            return finalName;
        }
    }
}
