using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal partial class ResourceElements
    {
        //Elements from 31 to 40

        public static readonly MyResource Gallium = new MyResource()
        {
            Name = "Gallium",
            NameDE = "Gallium",
            ID = "RawResources.Elements.Gallium",
            Symbol = "Ga",
            Description = "",
            Density = 5910.0f,
            BoilingPoint = 2673.0f,
            FreezingPoint = 302.91f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Germanium = new MyResource()
        {
            Name = "Germanium",
            NameDE = "Germanium",
            ID = "RawResources.Elements.Germanium",
            Symbol = "Ge",
            Description = "",
            Density = 5323.0f,
            BoilingPoint = 3106.0f,
            FreezingPoint = 1211.4f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Arsenic = new MyResource()
        {
            Name = "Arsenic",
            NameDE = "Arsen",
            ID = "RawResources.Elements.Arsenic",
            Symbol = "As",
            Description = "",
            Density = 5727.0f,
            BoilingPoint = 1000.0f,
            FreezingPoint = 1000.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Selenium = new MyResource()
        {
            Name = "Selenium",
            NameDE = "Selen",
            ID = "RawResources.Elements.Selenium",
            Symbol = "Se",
            Description = "",
            Density = 4810.0f,
            BoilingPoint = 958.0f,
            FreezingPoint = 494.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Bromine = new MyResource()
        {
            Name = "Bromine",
            NameDE = "Brom",
            ID = "RawResources.Elements.Bromine",
            Symbol = "Br",
            Description = "",
            Density = 3122.0f,
            BoilingPoint = 332.0f,
            FreezingPoint = 265.8f,
            Category = ResourceCategory.Liquid,
            Position = []
        };

        public static readonly MyResource Krypton = new MyResource()
        {
            Name = "Krypton",
            NameDE = "Krypton",
            ID = "RawResources.Elements.Krypton",
            Symbol = "Kr",
            Description = "",
            Density = 3.75f, // Gasdichte bei STP
            BoilingPoint = 119.93f,
            FreezingPoint = 115.79f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly MyResource Rubidium = new MyResource()
        {
            Name = "Rubidium",
            NameDE = "Rubidium",
            ID = "RawResources.Elements.Rubidium",
            Symbol = "Rb",
            Description = "",
            Density = 1532.0f,
            BoilingPoint = 961.0f,
            FreezingPoint = 312.46f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Strontium = new MyResource()
        {
            Name = "Strontium",
            NameDE = "Strontium",
            ID = "RawResources.Elements.Strontium",
            Symbol = "Sr",
            Description = "",
            Density = 2640.0f,
            BoilingPoint = 1655.0f,
            FreezingPoint = 1050.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Yttrium = new MyResource()
        {
            Name = "Yttrium",
            NameDE = "Yttrium",
            ID = "RawResources.Elements.Yttrium",
            Symbol = "Y",
            Description = "",
            Density = 4472.0f,
            BoilingPoint = 3609.0f,
            FreezingPoint = 1799.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Zirconium = new MyResource()
        {
            Name = "Zirconium",
            NameDE = "Zirconium",
            ID = "RawResources.Elements.Zirconium",
            Symbol = "Zr",
            Description = "",
            Density = 6520.0f,
            BoilingPoint = 4682.0f,
            FreezingPoint = 2128.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

    }
}
