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
        // Elements from 91 to 100

        public static readonly IMyResource Protactinium = new MyResource()
        {
            Name = "Protactinium",
            ID = "Resources.Elements.Protactinium",
            Symbol = "Pa",
            Description = "",
            Density = 15370.0f,
            BoilingPoint = 4300.0f,
            FreezingPoint = 1841.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Uranium = new MyResource()
        {
            Name = "Uranium",
            ID = "Resources.Elements.Uranium",
            Symbol = "U",
            Description = "",
            Density = 19050.0f,
            BoilingPoint = 4404.0f,
            FreezingPoint = 1405.3f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Neptunium = new MyResource()
        {
            Name = "Neptunium",
            ID = "Resources.Elements.Neptunium",
            Symbol = "Np",
            Description = "",
            Density = 20450.0f,
            BoilingPoint = 4273.0f,
            FreezingPoint = 917.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Plutonium = new MyResource()
        {
            Name = "Plutonium",
            ID = "Resources.Elements.Plutonium",
            Symbol = "Pu",
            Description = "",
            Density = 19840.0f,
            BoilingPoint = 3501.0f,
            FreezingPoint = 912.5f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Americium = new MyResource()
        {
            Name = "Americium",
            ID = "Resources.Elements.Americium",
            Symbol = "Am",
            Description = "",
            Density = 13670.0f,
            BoilingPoint = 2880.0f,
            FreezingPoint = 1449.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Curium = new MyResource()
        {
            Name = "Curium",
            ID = "Resources.Elements.Curium",
            Symbol = "Cm",
            Description = "",
            Density = 13510.0f,
            BoilingPoint = 3383.0f,
            FreezingPoint = 1613.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Berkelium = new MyResource()
        {
            Name = "Berkelium",
            ID = "Resources.Elements.Berkelium",
            Symbol = "Bk",
            Description = "",
            Density = 14780.0f,
            BoilingPoint = 2900.0f,
            FreezingPoint = 1259.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Californium = new MyResource()
        {
            Name = "Californium",
            ID = "Resources.Elements.Californium",
            Symbol = "Cf",
            Description = "",
            Density = 15100.0f,
            BoilingPoint = 1743.0f,
            FreezingPoint = 1173.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Einsteinium = new MyResource()
        {
            Name = "Einsteinium",
            ID = "Resources.Elements.Einsteinium",
            Symbol = "Es",
            Description = "",
            Density = 8840.0f,
            BoilingPoint = 1269.0f,
            FreezingPoint = 1133.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Fermium = new MyResource()
        {
            Name = "Fermium",
            ID = "Resources.Elements.Fermium",
            Symbol = "Fm",
            Description = "",
            Density = 9700.0f,
            BoilingPoint = 1800.0f, // Schätzwert
            FreezingPoint = 1800.0f, // Schätzwert
            Category = ResourceCategory.Solid,
            Position = []
        };

    }
}
