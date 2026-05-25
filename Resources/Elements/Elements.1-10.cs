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

        public static readonly MyResource Hydrogen = new MyResource()
        {
            Name = "Hydrogen",
            NameDE = "Wasserstoff",
            ID = "RawResources.Elements.Hydrogen",
            Symbol = "H",
            Description = "",
            Density = 0.0899f,
            FreezingPoint = 14.01f,
            BoilingPoint = 20.28f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere, ResourcePosition.Space]
        };

        public static readonly MyResource Helium = new MyResource()
        {
            Name = "Helium",
            NameDE = "Helium",
            ID = "RawResources.Elements.Helium",
            Symbol = "He",
            Description = "",
            Density = 0.1785f,
            FreezingPoint = 0.95f,
            BoilingPoint = 4.15f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Space, ResourcePosition.Atmosphere]
        };

        public static readonly MyResource Lithium = new MyResource()
        {
            Name = "Lithium",
            NameDE = "Lithium",
            ID = "RawResources.Elements.Lithium",
            Symbol = "Li",
            Description = "",
            Density = 534.0f,
            FreezingPoint = 453.61f,
            BoilingPoint = 1615.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Beryllium = new MyResource()
        {
            Name = "Beryllium",
            NameDE = "Beryllium",
            ID = "RawResources.Elements.Beryllium",
            Symbol = "Be",
            Description = "",
            Density = 1848.0f,
            FreezingPoint = 1560.0f,
            BoilingPoint = 2742.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Boron = new MyResource()
        {
            Name = "Boron",
            NameDE = "Boron",
            ID = "RawResources.Elements.Boron",
            Symbol = "B",
            Description = "",
            Density = 2460.0f,
            FreezingPoint = 2348.0f,
            BoilingPoint = 4000.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Carbon = new MyResource()
        {
            Name = "Carbon",
            NameDE = "Kohlenstoff",
            ID = "RawResources.Elements.Carbon",
            Symbol = "C",
            Description = "",
            Density = 2266,
            FreezingPoint = 3915.0f,
            BoilingPoint = 3915.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Nitrogen = new MyResource()
        {
            Name = "Nitrogen",
            NameDE = "Stickstoff",
            ID = "RawResources.Elements.Nitrogen",
            Symbol = "N",
            Description = "",
            Density = 1.2f,
            FreezingPoint = 63.23f,
            BoilingPoint = 77.355f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere]
        };

        public static readonly MyResource Oxygen = new MyResource()
        {
            Name = "Oxygen",
            NameDE = "Sauerstoff",
            ID = "RawResources.Elements.Oxygen",
            Symbol = "O",
            Description = "",
            Density = 1.429f,
            FreezingPoint = 54.36f,
            BoilingPoint = 90.19f,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere]
        };

        public static readonly MyResource Fluorine = new MyResource()
        {
            Name = "Fluorine",
            NameDE = "Fluor",
            ID = "RawResources.Elements.Fluorine",
            Symbol = "F",
            Description = "",
            Density = 1.696f,
            FreezingPoint = 53.48f,
            BoilingPoint = 85.03f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly MyResource Neon = new MyResource()
        {
            Name = "Neon",
            NameDE = "Neon",
            ID = "RawResources.Elements.Neon",
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
