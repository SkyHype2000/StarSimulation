using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Export;
using static Star_Simulation.Libary;
using static Star_Simulation.Resource;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Systems;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public class MyPlanet : IMyStellarObject, IExport
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required double Radius { get; set; }
            public required MinMax<float> SurfaceTemperature { get; set; }
            public required CelestialType Type { get; set; }
            public required CelestialAtmosphereType AtmosphereType { get; set; }
            public required CelestialSurfaceType SurfaceType { get; set; }
            public required CelestialHabitability Habitability { get; set; }
            public required CelestialLifeType[] LifeType { get; set; }
            public required CelestialSpecialProperties[] SpecialProperties { get; set; }
            public required MyResourceList ResourceList { get; set; }
            public required MyPlanetResources Composition { get; set; }
            public required MyMoon[] Moons { get; set; }
            public required MyOrbit Orbit { get; set; }
            public required string Seed { get; set; }
        }

        public class MyPlanetGeneration : IMyObjectGeneration
        {
            public string? Name { get; set; }
            public string? ID { get; set; }
            public double? Mass { get; set; }
            public double? Radius { get; set; }
            public MyOrbit? Orbit { get; set; }
            public MinMax<float>? SurfaceTemperature { get; set; }
            public CelestialType? Type { get; set; }
            public CelestialAtmosphereType? AtmosphereType { get; set; }
            public CelestialSurfaceType? SurfaceType { get; set; }
            public CelestialHabitability? Habitability { get; set; }
            public CelestialLifeType[]? LifeType { get; set; }
            public CelestialSpecialProperties[]? SpecialProperties { get; set; }
            public MyResourceList? ResourceList { get; set; }
            public MyPlanetResources? Composition { get; set; }
            public MyMoon[]? Moons { get; set; }
            public string? Seed { get; set; }
        }

        /// <summary>
        /// Returns a MyPlanet Value Based of the IMyOlanetGeneration Value
        /// </summary>
        /// <param name="myPlanetGeneration"></param>
        /// <returns></returns>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static MyPlanet ReturnPlanetInformation(MyPlanetGeneration myPlanetGeneration)
        {
            if (myPlanetGeneration.Name == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Name");
            if (myPlanetGeneration.ID == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.ID");
            if (myPlanetGeneration.Mass == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Mass");
            if (myPlanetGeneration.Radius == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Radius");
            if (myPlanetGeneration.Orbit == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Orbit");
            if (myPlanetGeneration.SurfaceTemperature == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.SurfaceTemperature");
            if (myPlanetGeneration.Type == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Type");
            if (myPlanetGeneration.AtmosphereType == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.AtmosphereType");
            if (myPlanetGeneration.SurfaceType == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.SurfaceType");
            if (myPlanetGeneration.Habitability == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Habitability");
            if (myPlanetGeneration.LifeType == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.LifeType");
            if (myPlanetGeneration.SpecialProperties == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.SpecialProperties");
            if (myPlanetGeneration.ResourceList == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.ResourceList");
            if (myPlanetGeneration.Composition == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Composition");
            if (myPlanetGeneration.Moons == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Moons");
            if (myPlanetGeneration.Seed == null) throw new MyObjectGenerationValueException("(MyPlanet).ReturnPlanetInformation.myPlanetGeneration.Seed");

            return new MyPlanet()
            {
                Name = myPlanetGeneration.Name,
                ID = myPlanetGeneration.ID,
                Mass = (double)myPlanetGeneration.Mass,
                Radius = (double)myPlanetGeneration.Radius,
                SurfaceTemperature = (MinMax<float>)myPlanetGeneration.SurfaceTemperature,
                Type = (CelestialType)myPlanetGeneration.Type,
                AtmosphereType = (CelestialAtmosphereType)myPlanetGeneration.AtmosphereType,
                SurfaceType = (CelestialSurfaceType)myPlanetGeneration.SurfaceType,
                Habitability = (CelestialHabitability)myPlanetGeneration.Habitability,
                LifeType = myPlanetGeneration.LifeType,
                SpecialProperties = myPlanetGeneration.SpecialProperties,
                ResourceList = (MyResourceList)myPlanetGeneration.ResourceList,
                Composition = (MyPlanetResources)myPlanetGeneration.Composition,
                Moons = myPlanetGeneration.Moons,
                Orbit = myPlanetGeneration.Orbit,
                Seed = myPlanetGeneration.Seed!
            };
        }
    }
}
