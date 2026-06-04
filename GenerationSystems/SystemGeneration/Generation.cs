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

        /// <summary>
        /// Name List for Stars<br/>
        /// Most Names where Generated with AI.
        /// </summary>
        public static readonly string[] StarNames = new string[]
        {
            "Sirius", "Vega", "Rigel", "Betelgeuse", "Procyon", "Altair",
            "Deneb", "Polaris", "Antares", "Aldebaran", "Spica", "Fomalhaut",
            "Canopus", "Arcturus", "Capella", "Bellatrix", "Regulus",
            "Achernar", "Mira", "Mintaka", "Saiph", "Alnitak",

            "Nexus", "Mailo", "Atrox", "Kerbol",

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

        /// <summary>
        /// Name List for Planets<br/>
        /// </summary>
        /// <remarks>
        /// Almost All Names where Generated with AI.<br/>
        /// But Some Names were Removed because they were Sounding weird.
        /// </remarks>
        public static readonly string[] PlanetNames = new string[]
        {
            // --- IRGENDWELCHE ---
            // --- RANDOM ---
            "Thyra",   "Korune",  "Zelith",  "Arvion",  "Nythera", "Polaris", "Minor",   "Drentha",
            "Solune",  "Kythera", "Velis",   "Orthis",  "Xandor",  "Belora",  "Cyris",   "Luneth",
            "Tarex",   "Zyra",    "Morin",   "Elyndra", "Vorth",   "Kaelis",  "Syrune",  "Avaris",
            "Tylor",   "Orinex",  "Valis",   "Zethra",  "Myron",   "Helis",   "Dorex",   "Vireth",
            "Xyraxis", "Theris",  "Lorana",  "Zereth",  "Koralis", "Nyra",    "Eronis",  "Talix",
            "Vendra",  "Oryth",   "Sylar",   "Kethis",  "Ylora",   "Drayth",  "Velune",  "Aelyra",
            "Vorune",  "Kethra",  "Syphor",  "Zalara",  "Orveth",  "Taryx",   "Velora",  "Nyris",
            "Calyra",  "Dorelia", "Xanthis", "Belune",  "Korath",  "Elyon",   "Virelia", "Zyrene",
            "Mythra",  "Oryxis",  "Thyrel",  "Kaedon",  "Vexora",  "Lyrune",  "Solarae", "Nexora",
            "Ydris",   "Valora",  "Zethis",  "Morune",  "Helora",  "Tyrelis", "Arveth",  "Xylar",
            "Cyrune",  "Velith",  "Dranor",  "Koreth",  "Avarune", "Nyxis",   "Talyra",  "Oranis",
            "Zyphra",  "Kelune",  "Myronis", "Voreth",  "Elaris",  "Syrath",  "Lunara",  "Xandis",
            "Therune", "Aelira",  "Voryna",  "Syrara",  "Liora",   "Vaeruna", "Zyphora", "Nexis",
            "Myrelis", "Elarune", "Velorae", "Koruna",  "Ilyra",   "Vexis",   "Kalon",
        
            // --- MEIN LIEBLINGS FINGER ---
            // --- MY FAVORITE FINGER ---
            "Mittelfinger",
            // --- Mein Kater ---
            // --- MY CAT ---
            "Mailo",
            // --- MEIN LAND ---
            // --- MY COUNTRY ---
            "Deutschland",

            // --- SOL SYSTEM ---
            "Mercury", "Merkur", "Venus", "Earth", "Erde", "Mars", "Jupiter", "Saturn", "Neptune", "Uranus", "Pluto",
            // --- KSP ---
            "Moho", "Eve", "Kerbin", "Duna", "Dres", "Jool", "Eeloo",
            // --- ASTRONEER ---
            "Atrox", "Calidor", "Sylva", "Vesania", "Glacio",
        
            // --- Reale Exoplaneten & Sterne ---
            // --- Real Exo-Planets and Stars
            "Proxima",   "Centauri",  "Trappist", "Gliese",   "Osiris",   "Bellerophon", "Methuselah", "Sirius",
            "Pegasi",    "Cancri",    "Eridani",  "Zosma",    "Arcturus", "Betelgeuse",  "Rigel",      "Deneb",
            "Antares",   "Aldebaran", "Vega",     "Altair",   "Pollux",   "Castor",      "Fomalhaut",  "Alnath",
            "Cygnus",    "Andromeda", "Orion",    "Capella",  "Procyon",  "Regulus",     "Spica",      "Algol",
            "Bellatrix", "Mira",      "Canopus",  "Achernar", "Hadar",    "Acrux",       "Shaula",
        
            // --- Mythologische & Antike Namen ---
            // --- Mythology and Acient Names
            "Anubis",   "Thoth",    "Horus",      "Isis",      "Odin",         "Thor",       "Loki",       "Freya",
            "Asgard",   "Midgard",  "Hyperion",   "Iapetus",   "Enceladus",    "Mimas",      "Tethys",     "Dione",
            "Phobos",   "Deimos",   "Amalthea",   "Himalia",   "Elara",        "Pasiphae",   "Sinope",     "Lysithea",
            "Ares",     "Hermes",   "Athena",     "Apollo",    "Artemis",      "Hephaestus", "Aphrodite",  "Poseidon",
            "Hades",    "Dionysus", "Demeter",    "Hestia",    "Zeus",         "Hera",       "Chronos",    "Galatia",
            "Amun",     "Ra",       "Bastet",     "Sobek",     "Pontus",       "Bithynia",   "Lycia",      "Pamphylia",
            "Frigg",    "Baldur",   "Heimdall",   "Tyr",       "Cyprus",       "Cilicia",    "Cappadocia", "Achaea",
            "Valhalla", "Helheim",  "Jotunheim",  "Alfheim",   "Svartalfheim", "Vanaheim",   "Creta",      "Cyrene",
            "Numidia",  "Thracian", "Iberia",     "Lusitania", "Helvetia",     "Raetia",     "Noricum",    "Pannonia",
            "Dacia",    "Dalmatia", "Moesia",     "Macedon",   "Epirus",
            
            // --- Harte Sci-Fi & Alien-Klingende Namen ---
            // --- More Sci-Fi and Alien Names
            "Krypton",  "Vulcan",  "Romulus",  "Remus",  "Kronos",    "Tatooine", "Coruscant", "Naboo",
            "Dagobah",  "Endor",   "Mustafar", "Kamino", "Geonosis",  "Utapau",   "Yavin",     "Hoth",
            "Arrakis",  "Caladan", "Giedi",    "Salusa", "Secundus",  "Kaitain",  "Ix",        "Richese",
            "Nostromo", "Acheron", "Sulu",     "Skaro",  "Gallifrey", "Mondas",   "Cyberform",
        
            // --- Exotische Silbenkombinationen ---
            // --- Exotic syllable combinations ---
            "Xenon",   "Quasar",  "Nebula",   "Phantasm",   "Zion",      "Babylon", "Gorgon",  "Kraken",
            "Tiamat",  "Bahamut", "Behemoth", "Leviathan",  "Chimera",   "Hydra",   "Pegasus", "Phoenix",
            "Gryphon", "Wyvern",  "Basilisk", "Cockatrice", "Manticore", "Sphinx",  "Minotaur",
            
            // --- SUBTILES SCI-FI & KLASSISCHE UTOPIDEN ---
            // --- Subtile SCI-FI and Classic Utopia ---
            "Sulaco",   "Terminus", "Trantor", "Anacreon", "Helicon", "Kalgan", "Serenity", "Destiny",
            "Synnax",   "Elysium",  "Avalon",  "Eden",     "Arcadia", "Utopia", "Aurora",   "Eternity",
            "Solaria",  "Gaia",     "Terra",   "Nova",     "Apex",    "Zenith", "Nadir",    "Horizon",
            "Vanguard", "Pioneer",  "Voyager", "Odyssey",  "Infinity",
            
            // --- ELEGANTE NEOLOGISMEN ---
            "Sargon",  "Taranis",  "Belisama", "Camulos", "Epona",   "Lugus",     "Maponos", "Ogmios",
            "Thallia", "Melite",   "Calypso",  "Circe",   "Scylla",  "Charybdis", "Medusa",  "Centaur",
            "Griffin", "Cerberus", "Orthrus",  "Typhon",  "Echidna", "Ladon",     "Siren",   "Harpy",
            "Satyr",   "Faun",     "Nymph",    "Dryad",   "Oread",   "Nereid",    "Oceanid",
        
            // --- HISTORISCHE ENTDECKER & WISSENSCHAFTLER ---
            // --- Historic Guys that saw thing and Scientist ---
            "Copernicus", "Galileo",  "Cassini", "Huygens", "Brahe",  "Herschel", "Messier", "Halley",
            "Newton",     "Einstein", "Sagan",   "Hawking", "Hubble", "Webb",     "Keck",    "Subaru",
            "Chandra",    "Spitzer",  "Fermi",   "Compton", "Jansky", "Penzias",  "Wilson",  "Lovell",
            
            // --- GEOLOGISCHE & TOPOGRAFISCHE BEGRIFFE ---
            // --- Geological and Topography Name
            "Caldera",  "Canyon",    "Craton", "Basalt",  "Granite",  "Obsidian", "Olivine", "Quartz",
            "Magma",    "Mantle",    "Tundra", "Savanna", "Steppe",   "Plateau",  "Glacier", "Iceberg",
            "Borealis", "Australis", "Zodiac", "Eclipse", "Solstice", "Equinox",

            // --- UNREALISTISCHE DEUTSCHE BEGRIFFE (Deutschland JAAAA!) ---
            // --- Random Unrealistic German Names with Special Characters so English People Start having Problems to Pronaunce them. + Real but Stupid Words ---
            "Götterdämmerung",   "Schloßberg",            "Weißensee",        "Großglockner",  "Grünwald",        "Jägerndorf",
            "Störtebeker",       "Rübezahl",              "Eisengießer",      "Drosselbart",   "Rumpelstilzchen", "Brünhild",
            "Siegfried",         "Kriemhild",             "Hagen",            "Tristan",       "Fafnir",          "Rheingold",
            "Walküre",           "Alberich",              "Glücksstern",      "Mondkrater",    "Sternenstaub",    "Feldgänger",
            "Nachtwächter",      "Drachenblut",           "Königsstein",      "Glühwürmchen",  "Zwergenkönig",    "Riesenrad",
            "Frühlingserwachen", "Herbstwind",            "Knabenkraut",      "Schmiedefeuer", "Donnerkeil",      "Zauberkraft",
            "Irrlicht",          "Wolkenbruch",           "Geisterstunde",    "Glücklich",     "Kraterwüste",     "Großstron",
            "Tränennebel",       "Sonnenschwärze",        "Götterzone",       "Königsstern",   "Dämmersphäre",    "Rheinland",
            "Zwergenreich",      "Glühkern",              "Flugbahn",         "Eiswüste",      "Staubströmung",   "Nachtjunge",
            "Zauberschleier",    "Dunkelgrün",            "Weißfeuer",        "Blauglühen",    "Schmiedewelt",    "Nibelungen",
            "Spähtrupp",         "Fluchtgeschwindigkeit", "Zeitkrümmung",     "Himmelskörper", "Sternenjäger",    "Furchterregend",
            "Trümmerfeld",       "Geisterlicht",          "Röntgenstrahl",    "Südpol",        "Riesenwelle",     "Dunstschicht",
            "Schattenhauch",     "Quellschacht",          "Gletscherschlund", "Schmiedeglut",  "Wirbelschweif",   "Goldschatz",
            "Staubschleier",     "Schreckensfels",        "Nachtschimmer",    "Mondscheibe",   "Zwielichtgänger", "Rostschicht",
            "Fluchtscholle",     "Zwillingsbruder",       "Kranichflug",      "Schwachstrom",  "Schallwelle",     "Pfeilschuss",
            "Knochengerüst",     "Brückenpfeiler",        "Krümmerwand",      "Sumpfblüte",    "Frühlingsknoten",
            "Rinderkennzeichnungsfleischetikettierungsüberwachungsaufgabenübertragungsgesetz",
            "Grundstücks­verkehrs­genehmigungs­zuständigkeits­übertragungs­verordnung"
        };

        /// <summary>
        /// Name List for Moons<br/>
        /// Most Names where Generated with AI.
        /// </summary>
        public static readonly string[] MoonNames = new string[]
        {
            "Ceres", "Pallas", "Juno", "Vesta", "Astraea", "Hebe",
            "Iris", "Flora", "Metis", "Hygieia", "Parthenope",
            "Victoria", "Egeria", "Irene", "Eunomia", "Psyche",
            "Thetis", "Melpomene", "Fortuna", "Massalia", "Lutetia",
            "Kalliope", "Thalia", "Themis", "Phocaea", "Proserpina",
            "Euterpe", "Bellona", "Amphitrite", "Urania","Euphrosyne",
            "Pomona", "Polyhymnia", "Circe", "Leukothea", "Atalanta",
            "Fides", "Leda", "Laetitia", "Harmonia","Daphne", "Isis",
            "Ariadne", "Nysa", "Eugenia", "Hestia", "Aglaia", "Doris",
            "Pales", "Virginia","Nemesis", "Europa", "Kalypso",
            "Alexandra", "Pandora", "Melete", "Mnemosyne", "Concordia",
            "Olympia", "Echo","Danae", "Erato", "Ausonia", "Angelina",
            "Cybele", "Maia", "Asia", "Leto", "Hesperia", "Panopaea",
            "Niobe", "Feronia", "Clytie", "Galatea", "Eurydice", "Freia",
            "Frigga", "Diana", "Eurynome", "Sappho","Terpsichore",
            "Alcmene", "Beatrix", "Clio", "Julia", "Aegle", "Clotho",
            "Ianthe", "Antiope", "Aegina","Silvia", "Thisbe", "Aurora",
            "Gerda", "Clymene", "Artemis", "Dione", "Hera", "Althaea",
            "Felicitas","Obsidian", "Silic", "Ferrum", "Cuprum",
            "Stannum", "Aurum", "Argent", "Cobalt", "Nickel", "Pyrit",
            "Regolith", "Chondrit", "Pallasit", "Siderit", "Beryll",
            "Quarz", "Basalt", "Olivin", "Pyroxen", "Titan",
            "Vandenberg", "Kepler", "Huygens", "Cassini", "Brahe",
            "Halley", "Kuiper", "Oort", "Herschel", "Messier",

            "Gilly", "Mun", "Minmus", "Ike", "Pol", "Bop", "Tylo", "Vall", "Laythe"
        };

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
