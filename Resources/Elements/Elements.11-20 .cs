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
        // Elements from 11 to 20

        public static readonly MyResource Sodium = new MyResource()
        {
            Name = "Sodium",
            NameDE = "Natrium",
            ID = "Resources.Elements.Sodium",
            Symbol = "Na",
            Description = "",
            Density = 968.8f,
            BoilingPoint = 1156.090f,
            FreezingPoint = 370.944f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Magnesium = new MyResource()
        {
            Name = "Magnesium",
            NameDE = "Magnesium",
            ID = "Resources.Elements.Magnesium",
            Symbol = "Mg",
            Description = "",
            Density = 1.737f * 1000f,
            BoilingPoint = 1363.0f,
            FreezingPoint = 923.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Aluminium = new MyResource()
        {
            Name = "Aluminium",
            NameDE = "Aluminium",
            ID = "Resources.Elements.Aluminium",
            Symbol = "Al",
            Description = "",
            Density = 2.699f * 1000f,
            BoilingPoint = 2743.0f,
            FreezingPoint = 933.47f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Silicon = new MyResource()
        {
            Name = "Silicon",
            NameDE = "Silizium",
            ID = "Resources.Elements.Silicon",
            Symbol = "Si",
            Description = "",
            Density = 2.329085f * 1000f,
            BoilingPoint = 3538.0f,
            FreezingPoint = 1687.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Phosphorus = new MyResource()
        {
            Name = "Phosphorus",
            NameDE = "Phosphor",
            ID = "Resources.Elements.Phosphorus",
            Symbol = "P",
            Description = "",
            Density = 2.5f * 1000f,
            BoilingPoint = 791.4f,
            FreezingPoint = 791.4f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Sulfur = new MyResource()
        {
            Name = "Sulfur",
            NameDE = "Schwefel",
            ID = "Resources.Elements.Sulfur",
            Symbol = "S",
            Description = "",
            Density = 2070.0f,
            BoilingPoint = 717.8f,
            FreezingPoint = 388.4f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Chlorine = new MyResource()
        {
            Name = "Chlorine",
            NameDE = "Chlor",
            ID = "Resources.Elements.Chlorine",
            Symbol = "Cl",
            Description = "",
            Density = 3.2f,
            BoilingPoint = 239.1f,
            FreezingPoint = 171.6f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly MyResource Argon = new MyResource()
        {
            Name = "Argon",
            NameDE = "Argon",
            ID = "Resources.Elements.Argon",
            Symbol = "Ar",
            Description = "",
            Density = 1.8f,
            BoilingPoint = 87.3f,
            FreezingPoint = 83.8f,
            Category = ResourceCategory.Gas,
            Position = []
        };

        public static readonly MyResource Potassium = new MyResource()
        {
            Name = "Potassium",
            NameDE = "Kalium",
            ID = "Resources.Elements.Potassium",
            Symbol = "K",
            Description = "",
            Density = 890.0f,
            BoilingPoint = 1032.0f,
            FreezingPoint = 336.5f,
            Category = ResourceCategory.Solid,
            Position = []
        };

        public static readonly MyResource Calcium = new MyResource()
        {
            Name = "Calcium",
            NameDE = "Kalzium",
            ID = "Resources.Elements.Calcium",
            Symbol = "Ca",
            Description = "",
            Density = 1550.0f,
            BoilingPoint = 1757.0f,
            FreezingPoint = 1115.0f,
            Category = ResourceCategory.Solid,
            Position = []
        };
    }
}
