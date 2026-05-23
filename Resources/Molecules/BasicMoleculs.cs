using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal partial class ResourceElements
    {
        public class Moleculs : IMyResource
        {
            public required string Name { get; set; }
            public required string NameDE { get; set; }
            public required string ID { get; set; }
            public required string Symbol { get; set; }
            public required string Description { get; set; }
            public required float Density { get; set; }
            public required float BoilingPoint { get; set; }
            public required float FreezingPoint { get; set; }
            public required bool SolidFormExsists { get; set; }
            public required bool LiquidFormExsists { get; set; }
            public required bool GasFormExsists { get; set; }
            public required ResourceCategory Category { get; set; }
            public required ResourcePosition[] Position { get; set; }
        }

        public static readonly Moleculs Ironsulfide = new Moleculs()
        {
            Name = "Ironsulfide",
            NameDE = "Eisensulfid",
            ID = "Resources.Moleculs.Ironsulfide",
            Symbol = "FeS",
            Description = "",
            Density = 4840.0f,
            BoilingPoint = 0,
            FreezingPoint = 0,
            SolidFormExsists = true,
            LiquidFormExsists = true,
            GasFormExsists = false,
            Category = ResourceCategory.Solid,
            Position = []
        };
    }
}
