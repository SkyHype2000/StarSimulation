using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Random;
using static Star_Simulation.Resource;
using static Star_Simulation.PublicResources;
using static Star_Simulation.Program;

namespace Star_Simulation
{
    internal partial class Resource
    {
        /// <summary>The Resource Category. (What state of Matter it is normally in)</summary>
        public enum ResourceCategory
        { Solid, Liquid, Gas, Critical, Plasma }
        /// <summary>The Resource Type.</summary>
        /// <remarks>
        /// <b>None</b>: The Resource has no Type. (Can be Used for Resources in the Implementing-Phases)<br/>
        /// <b>Unknown</b>: Unknown Resource Type. Maybe there is something to Discover? :D<br/>
        /// <b>Metal</b>: A Metal Resource. (Like Iron, Copper, Titanium or Gadolinium)<br/>
        /// <b>Silicate</b>: A Silicate. (like Stone/SiO2)<br/>
        /// <b>Gas</b>: A Gas. (Like Hydrogen)<br/>
        /// <b>Organic</b>: A Organic Resource that contains Carbon or Water. (Like... Dihydrogenmonoxide)<br/>
        /// <b>Exotic</b>: A Exotic Element.<br/>
        /// <b>Special</b>: A Special Procedual Element that was Created by the Program.<br/>
        /// </remarks>
        public enum ResourceType
        { None, Unknown, Metal, Silicate, Gas, Organic, Exotic, Special }
        /// <summary>Where the Resource can Spawn.</summary>
        /// <remarks>
        /// <b>Surface</b>: It Spwans on the Surface of a Object. (Only Valid if Category is Solid or Liquid)<br/>
        /// <b>Subsurface</b>: It Spawns under the Surface of a Object. (Only Valid if Category is Solid or Liquid)<br/>
        /// <b>Atmospheric</b>: It Spawns in the Atmosphere of a Planet. (Only Valid if the Category is Gas)<br/>
        /// <b>AstroidBeld</b>: It Spawns on a Astroid or in a Astroid Belt. (Only Valid if the Category is Solid)<br/>
        /// <b>Comet</b>: It Spawns on a Comet. (Only Valid if the Category is Solid)<br/>
        /// <b>Space</b>: It Spawns in Space. (Only Valid if the Category is Solid, Gas or Plasma)<br/>
        /// </remarks>
        public enum ResourcePosition
        { Surface, Subsurface, Atmosphere, AsteroidBelt, Comet, Space }
        /// <summary>What the Surface has to Look Like for the Resource to Spawn (It will Only Spawn, if Temperature AND Position Requirements are Met)</summary>
        /// <remarks>
        /// <b>AnySurface</b>: There is no Requirement, it can Spawn Anywhere.<br/>
        /// <b>Normal</b>: The Surface has to be "Normal" (Perfect Climate)<br/>
        /// <b>Dry</b>: The Surface has to be Dry.<br/>
        /// <b>Wet</b>: The Surface has to be Wet.<br/>
        /// <b>Mountain</b>: It Will Spawn on Mountains.<br/>
        /// <b>Flat</b>: It will Spawn on Flat Terrain.<br/>
        /// <b>River</b>: It will Spawn on Rivers.<br/>
        /// <b>Ocean</b>: It will Spawn in the Ocean.<br/>
        /// <b>OceanDeep</b>: It will Spawn on Deep Ocean.<br/>
        /// <b>OceanFlat</b>: It will Spawn on Flat Ocean.<br/>
        /// </remarks>
        public enum ResourcePositionSurfaceConditionPosition
        { AnySurface, Normal, Dry, Wet, Mountain, Flat, River, Ocean, OceanDeep, OceanFlat }
        /// <summary>What the Surface Temperature has to be for the Resource to Spawn (It will Only Spawn, if Temperature AND Position Requirements are Met)</summary>
        /// <remarks>
        /// <b>All</b>: There is no Requirement, it can Spawn on any Temperature.<br/>
        /// <b>BlockOfIce</b>: The Surface has to be Extremly Cold (< -80 °C)<br/>
        /// <b>Freezing</b>: The Surface has to be Freezing Cold. (-10 to -80 °C)<br/>
        /// <b>Cold</b>: The Surface has to be Cold. (10 to -10 °C)<br/>
        /// <b>Normal</b>: The Temperature has to me "Normal" (30 to 10 °C).<br/>
        /// <b>Warm</b>: The Surface has to be Warm. (60 to 30 °C)<br/>
        /// <b>Hot</b>: The Surface has to be Hot. (200 to 60 °C)<br/>
        /// <b>Lava</b>: The Surface has to be Extremly Hot, like Lava. (>200 °C)<br/>
        /// </remarks>
        public enum ResourcePositionSurfaceConditionTemperature
        { All, BlockOfIce, Freezing, Cold, Normal, Warm, Hot, Lava }
        /// <summary>How Common a Resource is.</summary>
        /// <remarks>
        /// <b>None</b>: It dosn't spawn.<br/>
        /// <b>DEV</b>: It has to be Preplaced by a Dev.<br/>
        /// <b>VeryRare</b>: It is Very Rare and has a Spawn Probability of 1%<br/>
        /// <b>Rare</b>: It es Rare and has a Spawn Probability of 10%<br/>
        /// <b>Common</b>: It is Common and has a Spawn Probability of 25%<br/>
        /// <b>Frequent</b>: It is Frequent and has a Spawn Probability of 50%<br/>
        /// <b>VeryFrequent</b>: It is Very Frequent and has a Spawn Probability of 75%
        /// </remarks>
        public enum ResourceProbability
        { None, DEV, VeryRare, Rare, Common, Frequent, VeryFrequent }

        /// <summary>The Main Interface for the Resource Spawn Conditions</summary>
        public interface IMyResource
        {
            string Name { get; }
            string ID { get; }
            string Symbol { get; }
            string Description { get; }
            float FreezingPoint { get; }
            float BoilingPoint { get; }
            float Density { get; }
            ResourceCategory Category { get; }
            ResourcePosition[] Position { get; }
        }
        public class MyResource : IMyResource
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required string Symbol { get; set; }
            public required string Description { get; set; }
            public required float FreezingPoint { get; set; }
            public required float BoilingPoint { get; set; }
            public required float Density { get; set; }
            public required ResourceCategory Category { get; set; }
            public required ResourcePosition[] Position { get; set; }
        }

        public interface IMyResourceValue
        {
            /// <summary>The ID of the Resource Value</summary>
            string ID { get; }
            /// <summary>Wieviel Einheiten Pro 100 Vorhanden sind</summary>
            int Value { get; }
            IMyResource Resource { get; }
        }

        public class MyResourceValue : IMyResourceValue
        {
            /// <summary>The ID of the Resource Value</summary>
            public required string ID { get; set; }
            /// <summary>Wieviel Einheiten Pro 100 Vorhanden sind</summary>
            public required int Value { get; set; }
            public required IMyResource Resource { get; set; }
        }

        public interface IMyResourceList
        {
            IMyResourceValue[] Resources { get; }
        }
        public class MyResourceList : IMyResourceList
        {
            public required IMyResourceValue[] Resources { get; set; }
        }

        /// <summary>
        /// Für Optionale Zufällige Generierung von Ressourcenlisten<br/>
        /// Aber die Listen werden vordefiniert und festgelegt in der finalen Version.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyResourceList GenerateResourceList()
        {
            throw new NotImplementedException();
        }

        /// <summary>Generates a Random List of Planetary Resources.</summary>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyResourceList GeneratePlanetResourceList()
        {
            return new MyResourceList() { Resources = [] };

            throw new NotImplementedException();
        }
    }

    internal class PublicResources
    {
        public static List<IMyResource> Resources = [];
    }
}
