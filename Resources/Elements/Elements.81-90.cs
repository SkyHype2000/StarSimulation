using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal class Elements
    {
        // Alements from 81 to 90

        public static readonly IMyResource Thallium = new MyResource()
        {
            Name = "Thallium",
            ID = "Resources.Elements.Thallium",
            Symbol = "Tl",
            Description = "",
            Density = 11850.0f,
            BoilingPoint = 1746.0f,
            FreezingPoint = 577.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Lead = new MyResource()
        {
            Name = "Lead",
            ID = "Resources.Elements.Lead",
            Symbol = "Pb",
            Description = "",
            Density = 11340.0f,
            BoilingPoint = 2022.0f,
            FreezingPoint = 600.61f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Bismuth = new MyResource()
        {
            Name = "Bismuth",
            ID = "Resources.Elements.Bismuth",
            Symbol = "Bi",
            Description = "",
            Density = 9780.0f,
            BoilingPoint = 1837.0f,
            FreezingPoint = 544.7f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Polonium = new MyResource()
        {
            Name = "Polonium",
            ID = "Resources.Elements.Polonium",
            Symbol = "Po",
            Description = "",
            Density = 9196.0f,
            BoilingPoint = 1235.0f,
            FreezingPoint = 527.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Astatine = new MyResource()
        {
            Name = "Astatine",
            ID = "Resources.Elements.Astatine",
            Symbol = "At",
            Description = "",
            Density = 7000.0f,
            BoilingPoint = 610.0f,
            FreezingPoint = 575.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Radon = new MyResource()
        {
            Name = "Radon",
            ID = "Resources.Elements.Radon",
            Symbol = "Rn",
            Description = "",
            Density = 9.73f,
            BoilingPoint = 211.3f,
            FreezingPoint = 202.0f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly IMyResource Francium = new MyResource()
        {
            Name = "Francium",
            ID = "Resources.Elements.Francium",
            Symbol = "Fr",
            Description = "",
            Density = 1870.0f,
            BoilingPoint = 950.0f,
            FreezingPoint = 300.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Radium = new MyResource()
        {
            Name = "Radium",
            ID = "Resources.Elements.Radium",
            Symbol = "Ra",
            Description = "",
            Density = 5500.0f,
            BoilingPoint = 2013.0f,
            FreezingPoint = 973.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Actinium = new MyResource()
        {
            Name = "Actinium",
            ID = "Resources.Elements.Actinium",
            Symbol = "Ac",
            Description = "",
            Density = 10070.0f,
            BoilingPoint = 3471.0f,
            FreezingPoint = 1323.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly IMyResource Thorium = new MyResource()
        {
            Name = "Thorium",
            ID = "Resources.Elements.Thorium",
            Symbol = "Th",
            Description = "",
            Density = 11720.0f,
            BoilingPoint = 5061.0f,
            FreezingPoint = 2115.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };
    }
}
