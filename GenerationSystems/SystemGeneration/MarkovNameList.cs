using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        /// <summary>
        /// Name List for Stars<br/>
        /// Most Names where Generated with AI.
        /// </summary>
        public static readonly string[] StarNames = new string[]
        {
            "Sirius",   "Vega",     "Rigel",   "Betelgeuse", "Procyon", "Altair",
            "Deneb",    "Polaris",  "Antares", "Aldebaran",  "Spica",   "Fomalhaut",
            "Canopus",  "Arcturus", "Capella", "Bellatrix",  "Regulus",
            "Achernar", "Mira",     "Mintaka", "Saiph",      "Alnitak",

            "Aurexion",  "Velkaris",  "Therynox",  "Zyphar",    "Korellan",
            "Mystryx",   "Vandoril",  "Helionyx",  "Xathir",    "Eldraxis",
            "Nemorath",  "Kalystron", "Orvexis",   "Tychoran",  "Thalorien",
            "Zeraphis",  "Lumirax",   "Vaelthor",  "Dravion",   "Nyxaris",
            "Solthera",  "Cryndor",   "Virellos",  "Axiondra",  "Beltharix",
            "Syrenox",   "Tormyra",   "Zaltheron", "Kyralis",   "Morveth",
            "Yllaris",   "Theraxon",  "Velmora",   "Arkanis",   "Drexalon",
            "Sylvaris",  "Krythar",   "Nexoria",   "Valtheris", "Zorynth",
            "Helvaron",  "Myralon",   "Xerethis",  "Talyxar",   "Vorenth",
            "Lysandrax", "Zenthora",  "Kaelith",   "Orvannis",  "Myraxor",

            "Aetheron", "Pyralis",   "Voltyra",   "Caelion",  "Ryxalon",
            "Thalorix", "Vaeryn",    "Zylaris",   "Quenthar", "Draeven",
            "Mytheon",  "Solvyr",    "Keraith",   "Orlyx",    "Zerionyx",
            "Baelthor", "Calystrix", "Nytherion", "Voryxis",  "Elarion",
            "Typheros", "Xandriel",  "Vaelion",   "Korvaxis", "Lunatrix",
            "Sylphaen", "Ardoryx",   "Zekarion",  "Velarix",  "Morvion",
            "Heliovar", "Crysalon",  "Xythera",   "Tyranor",  "Aurethys",
            "Zalvion",  "Kaedrix",   "Nemorix",   "Vexalion", "Thoryn",
            "Ylthera",  "Draconis",  "Virexion",  "Aelythor", "Zyphion",
            "Zorvane",  "Myxaris",   "Opheryn",   "Kelvaris", "Vaelorin",

            "Kaedrion", "Zorvax",  "Thyrex", "Vaeloron", "Krythar",
            "Xyphon",   "Draexor", "Velkyr", "Morveth",  "Zenthrix",
            "Aetheron", "Kaldrax", "Tyvorn", "Vexarion", "Orlix",

            "Nexus", "Mailo", "Atrox", "Kerbol",
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
        };

        /// <summary>
        /// Name List for Moons<br/>
        /// Most Names where Generated with AI.
        /// </summary>
        public static readonly string[] MoonNames = new string[]
        {
            "Ceres",      "Pallas",     "Juno",       "Vesta",     "Astraea",
            "Iris",       "Flora",      "Metis",      "Hygieia",   "Parthenope",
            "Victoria",   "Egeria",     "Irene",      "Eunomia",   "Psyche",
            "Thetis",     "Melpomene",  "Fortuna",    "Massalia",  "Lutetia",
            "Kalliope",   "Thalia",     "Themis",     "Phocaea",   "Proserpina",
            "Euterpe",    "Bellona",    "Amphitrite", "Urania",    "Euphrosyne",
            "Pomona",     "Polyhymnia", "Circe",      "Leukothea", "Atalanta",
            "Fides",      "Leda",       "Laetitia",   "Harmonia",  "Daphne",
            "Ariadne",    "Nysa",       "Eugenia",    "Hestia",    "Aglaia",
            "Pales",      "Virginia",   "Nemesis",    "Europa",    "Kalypso",
            "Alexandra",  "Pandora",    "Melete",     "Mnemosyne", "Concordia",
            "Olympia",    "Echo",       "Danae",      "Erato",     "Ausonia",
            "Cybele",     "Maia",       "Asia",       "Leto",      "Hesperia",
            "Niobe",      "Feronia",    "Clytie",     "Galatea",   "Eurydice",
            "Frigga",     "Diana",      "Eurynome",   "Sappho",    "Terpsichore",
            "Alcmene",    "Beatrix",    "Clio",       "Julia",     "Aegle",
            "Ianthe",     "Antiope",    "Aegina",     "Silvia",    "Thisbe",
            "Gerda",      "Clymene",    "Artemis",    "Dione",     "Hera",
            "Felicitas",  "Obsidian",   "Silic",      "Ferrum",    "Cuprum",
            "Stannum",    "Aurum",      "Argent",     "Cobalt",    "Nickel",
            "Regolith",   "Chondrit",   "Pallasit",   "Siderit",   "Beryll",
            "Quarz",      "Basalt",     "Olivin",     "Pyroxen",   "Titan",
            "Vandenberg", "Kepler",     "Huygens",    "Cassini",   "Brahe",
            "Halley",     "Kuiper",     "Oort",       "Herschel",  "Messier",
            "Isis",       "Hebe",       "Doris",      "Angelina",  "Panopaea",
            "Freia",      "Clotho",     "Aurora",     "Althaea",   "Pyrit",

            "Gilly", "Mun", "Minmus", "Ike", "Pol", "Bop", "Tylo", "Vall", "Laythe"
        };
    }
}
