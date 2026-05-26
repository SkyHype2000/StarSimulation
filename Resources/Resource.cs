using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Random;
using static Star_Simulation.Resource;
using static Star_Simulation.Libary;
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
        /// <b>None</b>: The Resource has no Type. (Can be Used for RawResources in the Implementing-Phases)<br/>
        /// <b>Unknown</b>: Unknown Resource Type. Maybe there is something to Discover? :D<br/>
        /// <b>Metal</b>: A Metal Resource. (Like Iron, Copper, Titanium or Gadolinium)<br/>
        /// <b>Silicate</b>: A Silicate. (like Stone/SiO2)<br/>
        /// <b>Gas</b>: A Gas. (Like Hydrogen)<br/>
        /// <b>Organic</b>: A Organic Resource that contains Carbon or Water. (Like... Dihydrogenmonoxide)<br/>
        /// <b>Exotic</b>: A Exotic Element.<br/>
        /// <b>SpecialOrExotic</b>: A Special or Exotic Procedual Element that was Created by the Program.<br/>
        /// </remarks>
        public enum ResourceType
        { None, Unknown, Metal, Silicate, Gas, Organic, Exotic, SpecialOrExotic }
        /// <summary>Where the Resource can Spawn.</summary>
        /// <remarks>
        /// <b>Surface</b>: It Spwans on the Surface of a Object. (Only Valid if Category is Solid or Liquid)<br/>
        /// <b>SubsurfaceCrust</b>: It Spawns under the Surface of a Object. (Only Valid if Category is Solid)<br/>
        /// <b>SubsurfaceMantle</b>: It Spawns under the Surface of a Object. (Only Valid if Category is Solid)<br/>
        /// <b>SubsurfaceCore</b>: It Spawns under the Surface of a Object. (Only Valid if Category is Solid)<br/>
        /// <b>Atmospheric</b>: It Spawns in the Atmosphere of a Planet. (Only Valid if the Category is Gas)<br/>
        /// <b>AstroidBeld</b>: It Spawns on a Astroid or in a Astroid Belt. (Only Valid if the Category is Solid)<br/>
        /// <b>Comet</b>: It Spawns on a Comet. (Only Valid if the Category is Solid)<br/>
        /// <b>Space</b>: It Spawns in Space. (Only Valid if the Category is Solid or Gas)<br/>
        /// </remarks>
        public enum ResourcePosition
        { Surface, SubsurfaceCrust, SubsurfaceMantle, SubsurfaceCore, Atmosphere, AsteroidBelt, Comet, Space }
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
        /// <b>DEV</b>: It dosn't spawn naturally.<br/>
        /// <b>VeryRare</b>: It is Very Rare and has a Spawn Probability of 1%<br/>
        /// <b>Rare</b>: It es Rare and has a Spawn Probability of 10%<br/>
        /// <b>Common</b>: It is Common and has a Spawn Probability of 25%<br/>
        /// <b>Frequent</b>: It is Frequent and has a Spawn Probability of 50%<br/>
        /// <b>VeryFrequent</b>: It is Very Frequent and has a Spawn Probability of 75%
        /// </remarks>
        public enum ResourceProbability
        { None, DEV, VeryRare, Rare, Common, Frequent, VeryFrequent }

        /// <summary>
        /// Interface for Compatibility and Basic-Requirement Reasons.
        /// </summary>
        public interface IMyResource
        {
            public string Name { get; set; }
            public string NameDE { get; set; }
            public string ID { get; set; }
            public string Symbol { get; set; }
            public string Description { get; set; }
            public float FreezingPoint { get; set; }
            public float BoilingPoint { get; set; }
            public float Density { get; set; }
        }

        public class MyResource : IMyResource
        {
            public required string Name { get; set; }
            public required string NameDE { get; set; }
            public required string ID { get; set; }
            public required string Symbol { get; set; }
            public string Description { get; set; } = "";
            public required float FreezingPoint { get; set; }
            public required float BoilingPoint { get; set; }
            public required float Density { get; set; }
            public required ResourceCategory Category { get; set; }
            public ResourcePosition[] Position { get; set; } = [];
        }

        public class MyMolecule : IMyResource
        {
            public required string Name { get; set; }
            public required string NameDE { get; set; }
            public required string ID { get; set; }
            public required string Symbol { get; set; }
            public string Description { get; set; } = "";
            public required float Density { get; set; }
            public required float BoilingPoint { get; set; }
            public required float FreezingPoint { get; set; }
            public bool SolidFormExists { get; set; } = true;
            public bool LiquidFormExists { get; set; } = true;
            public bool GasFormExists { get; set; } = true;
            public required ResourceCategory Category { get; set; }
            public ResourcePosition[] Position { get; set; } = [];
        }

        public class MyResourceValue
        {
            /// <summary>How many are Present in PPM(Parts Per Million)<br/>
            /// But you can also just add everything in pph, ppt, ppm, etc., just be careful, that everything is in the same Ratio.</summary>
            public required ulong Value { get; set; }
            public required IMyResource Resource { get; set; }
        }
        public class MyResourceListValue
        {
            /// <summary>How many are Present in PPM(Parts Per Million)<br/>
            /// At the End it will not be Important if the Value is PPM, because of BuildRealResources() in MyResourceList.</summary>
            public required int Value { get; init; }
            public required float Percent { get; init; }
            public required IMyResource Resource { get; init; }
        }

        /// <summary>
        /// MyResourceList Class Used for Actual Generation.<br/>
        /// For Generation ALWAYS Use the MyResourceListValue RealResources because i said so.
        /// </summary>
        public class MyResourceList
        {
            public List<MyResourceValue> RawResources { get; private set; }
            public List<MyResourceListValue> RealResources { get; private set; } = [];
            public float AverageDensity { get; private set; } = 0.0f;


            /// <summary>
            /// Builds the Values so it will reach 1PPM-accuracy and saves it as MyResourceListValue into RealResources
            /// </summary>
            public MyResourceList(List<MyResourceValue> rawResources)
            {
                RawResources = rawResources;

                if (rawResources.Count == 0 && Logging && ResourceGeneration_Logging) ConsoleLog("MyResourceList was Generated without any Resource. This may cause so issues...");
                if (rawResources.Count == 0 && (LoggingFile && ResourceGeneration_ResourceListLogging || ForceLoggingFile)) ConsoleLog("MyResourceList was Generated without any Resource. This may cause so issues...");
                if (rawResources.Count == 0) return;

                try
                {
                    AverageDensity = 0.0f;

                    ulong allResourcesCount = rawResources.Sum(e => e.Value);
                    if (allResourcesCount == 0) return;

                    RawResources.ForEach((e) =>
                    {
                        float p = (float)e.Value / (float)allResourcesCount;

                        RealResources.Add(new()
                        {
                            Resource = e.Resource,
                            Value = (int)MathF.Round(p * 1_000_000.0f),
                            Percent = p
                        });
                    });

                    AverageDensity = RealResources.Sum(e => e.Resource.Density * e.Percent);

                    if (ResourceGeneration_BuildResourceLogging && ResourceGeneration_Logging && Logging) ConsoleLog($"Build {RealResources.Count} Resources with an Average Density of {AverageDensity} kg/m^3");
                    if (ResourceGeneration_BuildResourceLoggingFile && ResourceGeneration_LoggingFile) LogWrite($"Build {RealResources.Count} Resources with an Average Density of {AverageDensity} kg/m^3");
                }
                catch (Exception e)
                {
                    ConsoleLogWrite([e.Message, e.HelpLink!]);
                    throw;
                }
            }
        }
    }

    internal class PublicResources
    {
        public static List<MyResource> Resources = [];
    }
}
