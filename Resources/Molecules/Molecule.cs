using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static Star_Simulation.Resource;

namespace Star_Simulation
{
    internal partial class ResourceElement
    {
        public static readonly MyMolecule Dihydrogenmonoxide = new MyMolecule()
        {
            Name = "Water",
            NameDE = "Wasser",
            ID = "RawResources.MyMolecule.Dihydrogenmonoxide",
            Symbol = "H2O",
            Description = "",
            Density = 1000.0f,
            BoilingPoint = 373.15f,
            FreezingPoint = 273.15f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Liquid,
            Position = [ResourcePosition.Comet,ResourcePosition.Surface]
        };
        public static readonly MyMolecule H2O = Dihydrogenmonoxide;

        public static readonly MyMolecule Ironsulfide = new MyMolecule()
        {
            Name = "Ironsulfide",
            NameDE = "Eisensulfid",
            ID = "RawResources.MyMolecule.Ironsulfide",
            Symbol = "FeS",
            Description = "",
            Density = 4840.0f,
            BoilingPoint = -1.0f,
            FreezingPoint = -1.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = false,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceCore]
        };
        public static readonly MyMolecule FeS = Ironsulfide;

        public static readonly MyMolecule Silicondioxide = new()
        {
            Name = "Silicon dioxide",
            NameDE = "Siliziumdioxid",
            ID = "RawResources.MyMolecule.Silicondioxide",
            Symbol = "SiO2",
            Description = "",
            Density = 2648.0f,
            BoilingPoint = 3220.0f,
            FreezingPoint = 1986.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceCrust, ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule SiO2 = Silicondioxide;

        public static readonly MyMolecule Magnesiumoxide = new()
        {
            Name = "Magnesium oxide",
            NameDE = "Magnesiumoxid",
            ID = "RawResources.MyMolecule.Magnesiumoxide",
            Symbol = "MgO",
            Description = "",
            Density = 3580.0f,
            BoilingPoint = 3873.0f,
            FreezingPoint = 3125.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule MgO = Magnesiumoxide;

        public static readonly MyMolecule Iron2Oxide = new()
        {
            Name = "Iron(II) oxide",
            NameDE = "Eisen(II)-oxid",
            ID = "RawResources.MyMolecule.Iron2Oxide",
            Symbol = "FeO",
            Description = "",
            Density = 5745.0f,
            BoilingPoint = 3687.0f,
            FreezingPoint = 1650.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule FeO = Iron2Oxide;

        public static readonly MyMolecule Iron3Oxide = new()
        {
            Name = "Iron(III) oxide",
            NameDE = "Eisen(III)-oxid",
            ID = "RawResources.MyMolecule.Iron3Oxide",
            Symbol = "Fe2O3",
            Description = "",
            Density = 5240.0f,
            BoilingPoint = -1.0f,
            FreezingPoint = 1838.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = false,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule Fe2O3 = Iron3Oxide;

        public static readonly MyMolecule Aluminiumoxide = new()
        {
            Name = "Aluminium oxide",
            NameDE = "Aluminiumoxid",
            ID = "RawResources.MyMolecule.Aluminiumoxide",
            Symbol = "Al2O3",
            Description = "",
            Density = 3987.0f,
            BoilingPoint = 3250.0f,
            FreezingPoint = 2945.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule Al2O3 = Aluminiumoxide;

        public static readonly MyMolecule Calciumoxide = new()
        {
            Name = "Calcium oxide",
            NameDE = "Calciumoxid",
            ID = "RawResources.MyMolecule.Calciumoxide",
            Symbol = "CaO",
            Description = "",
            Density = 3987.0f,
            BoilingPoint = 3120.0f,
            FreezingPoint = 2886.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule CaO = Calciumoxide;

        public static readonly MyMolecule Sodiumoxide = new()
        {
            Name = "Sodium oxide",
            NameDE = "Natriumoxid",
            ID = "RawResources.MyMolecule.Sodiumoxide",
            Symbol = "Na2O",
            Description = "",
            Density = 2270.0f,
            BoilingPoint = 2220.0f,
            FreezingPoint = 1405.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule Na2O = Sodiumoxide;

        public static readonly MyMolecule Chromium3oxide = new()
        {
            Name = "Chromium(III) oxide",
            NameDE = "Chrom(III)-oxid",
            ID = "RawResources.MyMolecule.Chromium3oxide",
            Symbol = "Cr2O3",
            Description = "",
            Density = 5220.0f,
            BoilingPoint = 4270.0f,
            FreezingPoint = 2708.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule Cr2O3 = Chromium3oxide;

        public static readonly MyMolecule Titaniumdioxide = new()
        {
            Name = "Titanium dioxide",
            NameDE = "Titandioxid",
            ID = "RawResources.MyMolecule.Titaniumdioxide",
            Symbol = "TiO2",
            Description = "",
            Density = 4230.0f,
            BoilingPoint = 3245.0f,
            FreezingPoint = 2116.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule TiO2 = Titaniumdioxide;

        public static readonly MyMolecule Potassiumoxide = new()
        {
            Name = "Potassium oxide",
            NameDE = "Kaliumoxid",
            ID = "RawResources.MyMolecule.Potassiumoxide",
            Symbol = "K2O",
            Description = "",
            Density = 2320.0f,
            BoilingPoint = -1.0f,
            FreezingPoint = 1013.0f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = false,
            Category = ResourceCategory.Solid,
            Position = [ResourcePosition.SubsurfaceMantle]
        };
        public static readonly MyMolecule K2O = Potassiumoxide;

        public static readonly MyMolecule Methane = new()
        {
            Name = "Methane",
            NameDE = "Methan",
            ID = "RawResources.MyMolecule.Methane",
            Symbol = "CH4",
            Description = "",
            Density = 0.657f,
            BoilingPoint = 111.15f,
            FreezingPoint = 91.15f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Gas,
            Position = [ResourcePosition.Atmosphere]
        };
        public static readonly MyMolecule CH4 = Methane;

        public static readonly MyMolecule Ammonia = new()
        {
            Name = "Ammonia",
            NameDE = "Ammoniak",
            ID = "RawResources.MyMolecule.Ammonia",
            Symbol = "NH3",
            Description = "",
            Density = 0.73f,
            BoilingPoint = 239.81f,
            FreezingPoint = 195.42f,
            SolidFormExists = true,
            LiquidFormExists = true,
            GasFormExists = true,
            Category = ResourceCategory.Gas,
            Position = []
        };
        public static readonly MyMolecule NH3 = Ammonia;
    }
}
