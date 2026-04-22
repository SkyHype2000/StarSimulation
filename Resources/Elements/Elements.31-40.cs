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

        public static readonly IMyResource Gallium = new MyResource()
        {
            Name = "Gallium",
            ID = "Resources.Elements.Gallium",
            Symbol = "Ga",
            Description = "",
            Density = 5910.0f,
            BoilingPoint = 2673.0f,
            FreezingPoint = 302.91f,
            Category = ResourceCategory.Solid, // Schmilzt bei ca. 30°C
            Position = []
        };

        public static readonly IMyResource Germanium = new MyResource()
        {
            Name = "Germanium",
            ID = "Resources.Elements.Germanium",
            Symbol = "Ge",
            Description = "",
            Density = 5323.0f,
            BoilingPoint = 3106.0f,
            FreezingPoint = 1211.4f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Arsenic = new MyResource()
        {
            Name = "Arsenic",
            ID = "Resources.Elements.Arsenic",
            Symbol = "As",
            Description = "",
            Density = 5727.0f,
            BoilingPoint = 1000.0f,
            FreezingPoint = 1000.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Selenium = new MyResource()
        {
            Name = "Selenium",
            ID = "Resources.Elements.Selenium",
            Symbol = "Se",
            Description = "",
            Density = 4810.0f,
            BoilingPoint = 958.0f,
            FreezingPoint = 494.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Bromine = new MyResource()
        {
            Name = "Bromine",
            ID = "Resources.Elements.Bromine",
            Symbol = "Br",
            Description = "",
            Density = 3122.0f,
            BoilingPoint = 332.0f,
            FreezingPoint = 265.8f,
            Category = ResourceCategory.Liquid,
            Position = []
        };

        public static readonly IMyResource Krypton = new MyResource()
        {
            Name = "Krypton",
            ID = "Resources.Elements.Krypton",
            Symbol = "Kr",
            Description = "",
            Density = 3.75f, // Gasdichte bei STP
            BoilingPoint = 119.93f,
            FreezingPoint = 115.79f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly IMyResource Rubidium = new MyResource()
        {
            Name = "Rubidium",
            ID = "Resources.Elements.Rubidium",
            Symbol = "Rb",
            Description = "",
            Density = 1532.0f,
            BoilingPoint = 961.0f,
            FreezingPoint = 312.46f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Strontium = new MyResource()
        {
            Name = "Strontium",
            ID = "Resources.Elements.Strontium",
            Symbol = "Sr",
            Description = "",
            Density = 2640.0f,
            BoilingPoint = 1655.0f,
            FreezingPoint = 1050.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Yttrium = new MyResource()
        {
            Name = "Yttrium",
            ID = "Resources.Elements.Yttrium",
            Symbol = "Y",
            Description = "",
            Density = 4472.0f,
            BoilingPoint = 3609.0f,
            FreezingPoint = 1799.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Zirconium = new MyResource()
        {
            Name = "Zirconium",
            ID = "Resources.Elements.Zirconium",
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
