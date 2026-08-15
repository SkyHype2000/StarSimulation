using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text.Json.Serialization;
using static Star_Simulation.Luminosity;
using static Star_Simulation.Random;
using static Star_Simulation.Resource;
using static Star_Simulation.Spectral;
using static Star_Simulation.Systems;
using static Star_Simulation.LoggingOptions;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public enum CelestialType
        { Terrestrial, Rocky, Gas, IceGas, Dwarf, Lava, Ocean, Desert, Carbon }
        public enum CelestialObjectType
        { Planet, Moon, DrawfPlanet, DrawfMoon, ProtoPlanet }
        public enum AsteroidType { None, C, S, M, D, V, E, A, X }
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

        // Fügen Sie hier die Klassen aus Ihren anderen Dateien (siehe Bild) hinzu:
        [JsonDerivedType(typeof(MyAsteroidBelt), typeDiscriminator: "MyAsteroidBelts")]
        [JsonDerivedType(typeof(MyAsteroid), typeDiscriminator: "MyAsteroid")]
        [JsonDerivedType(typeof(MyPlanet), typeDiscriminator: "MyPlanet")]
        [JsonDerivedType(typeof(MyDwarfPlanet), typeDiscriminator: "MyDwarfPlanet")]
        [JsonDerivedType(typeof(MyProtoPlanet), typeDiscriminator: "MyProtoPlanet")]
        public interface IMyStellarObject
        {
            public string Name { get; set; }
            public string ID { get; set; }
            public string Seed { get; set; }
            public double Mass { get; set; }
        }
        public interface IMyStellarEvent { }
        public class MyStellarSystem
        {
            public required List<IMyStellarObject> StellarObjects { get; set; }
            public required List<IMyStellarEvent> StellarEvents { get; set; }
        }

        public class MyOrbit
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

        public class MyStellarSystemList
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
