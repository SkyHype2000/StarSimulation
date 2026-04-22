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
        // Elements from 1 to 10

        public static readonly IMyResource Hydrogen = new MyResource()
        {
            Name = "Hydrogen",
            ID = "Resources.Elements.Hydrogen",
            Symbol = "H",
            Description = "",
            Density = 0.0899f,
            FreezingPoint = 14.01f,
            BoilingPoint = 20.28f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere, ResourcePosition.Space]
        };

        public static readonly IMyResource Helium = new MyResource()
        {
            Name = "Helium",
            ID = "Resources.Elements.Helium",
            Symbol = "He",
            Description = "",
            Density = 0.1785f,
            FreezingPoint = 0.95f,
            BoilingPoint = 4.15f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Space, ResourcePosition.Atmosphere]
        };

        public static readonly IMyResource Lithium = new MyResource()
        {
            Name = "Lithium",
            ID = "Resources.Elements.Lithium",
            Symbol = "Li",
            Description = "",
            Density = 534.0f,
            FreezingPoint = 453.61f,
            BoilingPoint = 1615.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Beryllium = new MyResource()
        {
            Name = "Beryllium",
            ID = "Resources.Elements.Beryllium",
            Symbol = "Be",
            Description = "",
            Density = 1848.0f,
            FreezingPoint = 1560.0f,
            BoilingPoint = 2742.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Boron = new MyResource()
        {
            Name = "Boron",
            ID = "Resources.Elements.Boron",
            Symbol = "B",
            Description = "",
            Density = 2460.0f,
            FreezingPoint = 2348.0f,
            BoilingPoint = 4000.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Carbon = new MyResource()
        {
            Name = "Carbon",
            ID = "Resources.Elements.Carbon",
            Symbol = "C",
            Description = "",
            Density = 2266,
            FreezingPoint = 3915.0f,
            BoilingPoint = 3915.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Nitrogen = new MyResource()
        {
            Name = "Nitrogen",
            ID = "Resources.Elements.Nitrogen",
            Symbol = "N",
            Description = "",
            Density = 1.2f,
            FreezingPoint = 63.23f,
            BoilingPoint = 77.355f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere]
        };

        public static readonly IMyResource Oxygen = new MyResource()
        {
            Name = "Oxygen",
            ID = "Resources.Elements.Oxygen",
            Symbol = "O",
            Description = "",
            Density = 1.429f,
            FreezingPoint = 54.36f,
            BoilingPoint = 90.19f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere]
        };

        public static readonly IMyResource Fluorine = new MyResource()
        {
            Name = "Fluorine",
            ID = "Resources.Elements.Fluorine",
            Symbol = "F",
            Description = "",
            Density = 1.696f,
            FreezingPoint = 53.48f,
            BoilingPoint = 85.03f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly IMyResource Neon = new MyResource()
        {
            Name = "Neon",
            ID = "Resources.Elements.Neon",
            Symbol = "Ne",
            Description = "",
            Density = 0.83f,
            FreezingPoint = 24.56f,
            BoilingPoint = 27.07f,
            Category = ResourceCategory.Gas,
            Position = []
        };
    }
}
