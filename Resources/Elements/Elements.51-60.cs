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
        // Elements from 51 to 60

        public static readonly IMyResource Antimony = new MyResource()
        {
            Name = "Antimony",
            ID = "Resources.Elements.Antimony",
            Symbol = "Sb",
            Description = "",
            Density = 6684.0f,
            BoilingPoint = 1860.0f,
            FreezingPoint = 903.78f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Tellurium = new MyResource()
        {
            Name = "Tellurium",
            ID = "Resources.Elements.Tellurium",
            Symbol = "Te",
            Description = "",
            Density = 6240.0f,
            BoilingPoint = 1261.0f,
            FreezingPoint = 722.66f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Iodine = new MyResource()
        {
            Name = "Iodine",
            ID = "Resources.Elements.Iodine",
            Symbol = "I",
            Description = "",
            Density = 4933.0f,
            BoilingPoint = 457.4f,
            FreezingPoint = 457.4f, // Sublimiert leicht, daher angeglichen
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Xenon = new MyResource()
        {
            Name = "Xenon",
            ID = "Resources.Elements.Xenon",
            Symbol = "Xe",
            Description = "",
            Density = 5.894f,
            BoilingPoint = 165.03f,
            FreezingPoint = 161.36f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly IMyResource Cesium = new MyResource()
        {
            Name = "Cesium",
            ID = "Resources.Elements.Cesium",
            Symbol = "Cs",
            Description = "",
            Density = 1873.0f,
            BoilingPoint = 944.0f,
            FreezingPoint = 301.59f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Barium = new MyResource()
        {
            Name = "Barium",
            ID = "Resources.Elements.Barium",
            Symbol = "Ba",
            Description = "",
            Density = 3594.0f,
            BoilingPoint = 2170.0f,
            FreezingPoint = 1000.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Lanthanum = new MyResource()
        {
            Name = "Lanthanum",
            ID = "Resources.Elements.Lanthanum",
            Symbol = "La",
            Description = "",
            Density = 6145.0f,
            BoilingPoint = 3737.0f,
            FreezingPoint = 1193.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Cerium = new MyResource()
        {
            Name = "Cerium",
            ID = "Resources.Elements.Cerium",
            Symbol = "Ce",
            Description = "",
            Density = 6770.0f,
            BoilingPoint = 3716.0f,
            FreezingPoint = 1068.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Praseodymium = new MyResource()
        {
            Name = "Praseodymium",
            ID = "Resources.Elements.Praseodymium",
            Symbol = "Pr",
            Description = "",
            Density = 6773.0f,
            BoilingPoint = 3793.0f,
            FreezingPoint = 1208.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Neodymium = new MyResource()
        {
            Name = "Neodymium",
            ID = "Resources.Elements.Neodymium",
            Symbol = "Nd",
            Description = "",
            Density = 7007.0f,
            BoilingPoint = 3347.0f,
            FreezingPoint = 1297.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };
    }
}
