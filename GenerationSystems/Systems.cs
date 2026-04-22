using System.Numerics;
using static Star_Simulation.Luminosity;
using static Star_Simulation.Spectral;
using static Star_Simulation.Resource;
using static Star_Simulation.Systems;
using static Star_Simulation.Random;
using System.Runtime.Intrinsics;
using System.ComponentModel.DataAnnotations;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public enum CelestialType
        { Terrestrial, Rocky, Gas, IceGas, Dwarf, Lava, Ocean, Desert, Carbon }
        public enum CelestialObjectType
        { Planet, Moon, DrawfPlanet, DrawfMoon, ProtoPlanet }
        /// <summary>
        /// Asteroiden werden in verschiedene Klassen eingeteilt, basierend auf ihrer chemischen Zusammensetzung und ihren optischen Eigenschaften. Die wichtigsten Klassen sind:<br/>
        /// C-Klasse(kohlenstoffreich) : Diese Klassen umfassen etwa 75 % aller Asteroiden und sind sehr dunkle Körper mit einem Albedo von weniger als 0,065. Sie ähneln kohligen<br/>
        /// Chondriten und befinden sich hauptsächlich in den äußeren Regionen des Asteroidengürtels.Ein Beispiel ist Ceres, der größte Körper im Asteroidengürtel.<br/>
        /// S-Klasse (silikatreich): Diese Klassen machen etwa 15 % aller Asteroiden aus und besitzen eine hellere, rötliche Oberfläche mit einem Albedo von 0,10 bis 0,22.<br/>
        /// Sie enthalten Silikatmineralien wie Pyroxen und Olivin sowie Eisen und ähneln Siderolithen und gewöhnlichen Chondriten.Sie sind typischerweise in den inneren<br/>
        /// Regionen des Asteroidengürtels zu finden, wie beispielsweise der Asteroid 3 Juno.<br/>
        /// M-Klasse (metallisch): Diese Asteroiden enthalten große Anteile metallischen Eisens und haben ein Albedo von 0,10 bis 0,18. Sie befinden sich hauptsächlich in der<br/>
        /// mittleren Region des Asteroidengürtels und könnten Bruchstücke von differenzierten Planetesimalen sein, die ein metallisches Kern- und Mantel-System hatten.<br/>
        /// V-Klasse (Vestoid): Diese Klassen sind besonders selten und ähneln basaltischen Lavas.Sie sind typischerweise mit dem Asteroiden Vesta verbunden, der als Quelle von Vesta-Meteoriten gilt.<br/>
        /// D-Klasse: Diese Klassen sind reich an organischen Verbindungen und Eis und finden sich hauptsächlich bei den Jupiter-Trojanern.Ein Beispiel ist der Asteroid Hektor.<br/>
        /// X-Klasse: Diese Klassen sind Mischungen aus metallischen und silikatigen Materialien mit variabler Zusammensetzung und Albedo zwischen 0,05 und 0,35.<br/>
        /// Darüber hinaus gibt es auch spezielle Klassen wie die G-Klasse (kohlenstoffreich mit Phyllosilikaten), die F-Klasse(dunkel kohlenstoffreich mit hydratisierten Mineralien)<br/>
        /// und die P-Klasse(primitiv organisch mit Silikaten), die jeweils spezifische chemische und optische Eigenschaften aufweisen.<br/><br/>
        /// 
        /// Einige Asteroiden, wie beispielsweise 1 Ceres, 4 Vesta oder 16 Psyche, sind nicht nur nach ihrer Zusammensetzung klassifiziert, sondern auch als Zwergplaneten<br/>
        /// oder besondere Objekte von wissenschaftlichem Interesse anerkannt.<br/><br/>
        /// 
        /// (Antwort von Leo Brave Search KI)
        /// </summary>
        /// <remarks>
        /// Aber nochmal in Kurzform:<br/>
        /// C: Kohlenstoffreich<br/>
        /// S: Silikatreich<br/>
        /// M: Metallisch<br/>
        /// V: Vestoid (basaltisch)<br/>
        /// D: Organisch und eisreich<br/>
        /// X: Mischung aus metallisch und silikatisch<br/>
        /// G: Kohlenstoff mit Phyllosilikaten<br/>
        /// F: Dunkel kohlenstoffreich mit "hydratisierten Mineralien"(Was auch immer das bedeuten soll.)<br/>
        /// P: "Primitiv"(Was auch immer das bedeutet) mit Silikaten. (Okay nach mehr googeln, habe ich herausgefunden, dass die als "Primitiv" Gelten, weil sie in ihrer Geschichte Kaum Erhitzt wurden?)<br/>
        /// </remarks>
        public enum AstroidType { None, C, S, M, V, D, X, G, F, P }
        /// <summary>
        /// Der Atmosphärentyp wird anhand seiner Zusammensetzung Bestimmt, nicht Umgekehrt.
        /// </summary>
        public enum CelestialAtmosphereType
        { None, Thin, Breathable, Thick, Toxic, Corrosive, Exotic }
        /// <summary>
        /// Der Zustand der Oberfläche eines Planeten, Mondes oder so.
        /// </summary>
        public enum CelestialSurfaceType
        { Rocky, Icy, Gaseous, Volcanic, Oceanic, Desert, Forested, Urban }
        /// <summary>
        /// Der Wert wird Basierend auf der Atmosphäre, Wassergehalt und Oberfläche Bestimmt. (So ist der Plan zumindest)
        /// </summary>
        public enum CelestialHabitability
        { Uninhabitable, MarginallyHabitable, Habitable, HighlyHabitable }
        /// <summary>
        /// Die Lebenstypen auf einem Planeten (Es können Mehrere Geben)<br/>
        /// Exotisches Leben ist Flexibler weil es anders Aufgebaut ist.
        /// </summary>
        public enum CelestialLifeType 
        { Cellular, Multicellular, Intelligent, Synthetic, ExoticCellular, ExoticMulticellular, ExoticIntelligent }

        /// <summary>
        /// Spezielle Attributen die ein Planet haben kann.
        /// </summary>
        /// <remarks>
        /// PlagueWorld: Auf diesem Objekt herrscht eine Plage die alles Tötet, was auf dem Planeten kommt.<br/>
        /// Radioactive: Auf dem Objekt ist es Hochradioaktiv, entweder durch Solarer Strahlung, Radioaktiven Materialien oder eines Atomkriegs, vielleicht gibt es hier etwas zu erkunden :D.<br/>
        /// ResourceRich: Auf dem Objekt gibt es Große und Wertvolle Ressourcen.<br/>
        /// AncientRuins: Auf dem Objekt gibt es Große Ruinen, die vermutlich von einer Ehemaligen Zivilisation stammt, vielleicht gibt es auch hier etwas zu erkunden :D.<br/>
        /// ExtremeWeather: Auf dem Objekt herrschen Extreme Temperaturschwankungen und Instabile Wetterbedingungen. (Braucht eine Atmosphäre)<br/>
        /// HighGravity: Das Objekt hat eine hohe Oberflächengravitation (&gt; 2.0 g).<br/>
        /// LowGravity: Das Objekt hat eine niedrige Oberflächengravitation (&lt; 0.1 g).<br/>
        /// TidalLocked: Das Objekt ist zum Stern/Planeten Rotationsgebunden und wird (wie zb. Luna) immer zum Mutterobjekt Zeigen.<br/>
        /// MagneticStorms: Das Objekt wird von Regelmäßigen Starken Magnetischen Stürmen des Heimmatsterns.<br/>
        /// FrequentMeteorShowers: Auf dem Objekt Schlagen Regelmäßig Meteore ein.<br/>
        /// </remarks>
        public enum CelestialSpecialProperties
        { PlagueWorld, Radioactive, ResourceRich, AncientRuins, ExtremeWeather, HighGravity, LowGravity, TidalLocked, MagneticStorms, FrequentMeteorShowers }

        public interface IMyStellarObject { }
        public interface IMyStellarEvent { }
        public interface IMyStellarSystem
        {
            List<IMyStellarObject> StellarObjects { get; }
            List<IMyStellarEvent> StellarEvents { get; }
        }
        public class MyStellarSystem : IMyStellarSystem
        { public required List<IMyStellarObject> StellarObjects { get; set; } public required List<IMyStellarEvent> StellarEvents { get; set; } }
        
        public interface IMyOrbit
        {
            public string ID { get; set; }
            /// <summary>
            /// The Up-Down Acial Rotation Around the Parents Center of Rotation.<br/>
            /// -90 to 90°  (seed.Next(-90, 90))
            /// </summary>
            public int AxialRotationUD { get; set; }
            /// <summary>
            /// The Left-Right Acial Rotation Around the Parents Center of Rotation.<br/>
            /// 0 to 360° (seed.Next(360, 0))
            /// </summary>
            public int AxialRotationLR { get; set; }
            /// <summary>
            /// The Orbital Height on the Perigee, Measured in Meters
            /// </summary>
            public double OrbitalRadiusPerigee { get; set; }
            /// <summary>
            /// The Orbital Speed at Perigee, Measored in Meters per Second
            /// </summary>
            public double OrbitalSpeedPerigee { get; set; }
            /// <summary>
            /// The Orbital Height on the Apogee, Measured in Meters
            /// </summary>
            public double OrbitalRadiusApogee { get; set; }
            /// <summary>
            /// The Orbital Speed at Apogee, Measored in Meters per Second
            /// </summary>
            public double OrbitalSpeedApogee { get; set; }
            /// <summary>
            /// The Orbital Period, Measored in Seconds
            /// </summary>
            public double OrbitalPeriod { get; set; }
            /// <summary>
            /// The Offset of the Planets Starting Orbit (in Seconds)
            /// </summary>
            public double OrbitalOffset { get; set; }
        }
        public class MyOrbit : IMyOrbit
        {
            public required string ID { get; set; }
            /// <summary>
            /// The Up-Down Acial Rotation Around the Parents Center of Rotation.<br/>
            /// -90 to 90°  (seed.Next(-90, 90))
            /// </summary>
            public required int AxialRotationUD { get; set; }
            /// <summary>
            /// The Left-Right Acial Rotation Around the Parents Center of Rotation.<br/>
            /// 0 to 360° (seed.Next(360, 0))
            /// </summary>
            public required int AxialRotationLR { get; set; }
            /// <summary>
            /// The Orbital Height on the Perigee, Measured in Meters
            /// </summary>
            public required double OrbitalRadiusPerigee { get; set; }
            /// <summary>
            /// The Orbital Speed at Perigee, Measored in Meters per Second
            /// </summary>
            public required double OrbitalSpeedPerigee { get; set; }
            /// <summary>
            /// The Orbital Height on the Apogee, Measured in Meters
            /// </summary>
            public required double OrbitalRadiusApogee { get; set; }
            /// <summary>
            /// The Orbital Speed at Apogee, Measored in Meters per Second
            /// </summary>
            public required double OrbitalSpeedApogee { get; set; }
            /// <summary>
            /// The Orbital Period, Measored in Seconds
            /// </summary>
            public required double OrbitalPeriod { get; set; }
            /// <summary>
            /// The Offset of the Planets Starting Orbit (in Seconds)
            /// </summary>
            public required double OrbitalOffset { get; set; }
        }
        public interface IMyStellarSystemList
        {
            public uint Object_Stars { get; set; }
            public uint Object_Planets { get; set; }
            public uint Object_AstroidBelts { get; set; }
            public uint Object_Comets { get; set; }
            public uint Object_ProtoPlanets { get; set; }
            public uint Object_DrawfPlanets { get; set; }
            public uint Object_Astroids { get; set; }
            public uint Event_Anomalies { get; set; }
            public uint Event_CME { get; set; }
            public uint Event_InterstellarVisitors { get; set; }
        }
        public class MyStellarSystemList : IMyStellarSystemList
        {
            public required uint Object_Stars { get; set; }
            public required uint Object_Planets { get; set; }
            public required uint Object_AstroidBelts { get; set; }
            public required uint Object_Comets { get; set; }
            public required uint Object_ProtoPlanets { get; set; }
            public required uint Object_DrawfPlanets { get; set; }
            public required uint Object_Astroids { get; set; }
            public required uint Event_Anomalies { get; set; }
            public required uint Event_CME { get; set; }
            public required uint Event_InterstellarVisitors { get; set; }
        }
    }
}
