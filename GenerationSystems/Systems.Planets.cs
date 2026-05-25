using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Resource;
using static Star_Simulation.Systems;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Libary;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public interface IMyPlanet : IMyStellarObject
        {
            string Name { get; }
            string ID { get; }
            double Mass { get; }
            double Radius { get; }
            IMyOrbit Orbit { get; }
            MinMax<float> SurfaceTemperature { get; }
            CelestialType Type { get; }
            CelestialAtmosphereType AtmosphereType { get; }
            CelestialSurfaceType SurfaceType { get; }
            CelestialHabitability Habitability { get; }
            CelestialLifeType[] LifeType { get; }
            CelestialSpecialProperties[] SpecialProperties { get; }
            MyResourceList ResourceList { get; }
            MyPlanetResources Composition { get; }
            IMyMoon[] Moons { get; }
        }
        public class MyPlanet : IMyPlanet, IMyStellarObject
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
            public required IMyMoon[] Moons { get; set; }
            public required IMyOrbit Orbit { get; set; }
        }

        public interface IMyPlanetGeneration : IMyObjectGeneration
        {
            string? Name { get; set; }
            string? ID { get; set; }
            double? Mass { get; set; }
            MyResourceList? ResourceList { get; set; }
            MyPlanetResources? Composition { get; set; }
            double? Radius { get; set; }
            IMyOrbit? Orbit { get; set; }
            MinMax<float>? SurfaceTemperature { get; set; }
            CelestialType? Type { get; set; }
            CelestialAtmosphereType? AtmosphereType { get; set; }
            CelestialSurfaceType? SurfaceType { get; set; }
            CelestialHabitability? Habitability { get; set; }
            CelestialLifeType[]? LifeType { get; set; }
            CelestialSpecialProperties[]? SpecialProperties { get; set; }
            IMyMoon[]? Moons { get; set; }
        }
        public class MyPlanetGeneration : IMyPlanetGeneration, IMyObjectGeneration
        {
            public string? Name { get; set; }
            public string? ID { get; set; }
            public double? Mass { get; set; }
            public double? Radius { get; set; }
            public IMyOrbit? Orbit { get; set; }
            public MinMax<float>? SurfaceTemperature { get; set; }
            public CelestialType? Type { get; set; }
            public CelestialAtmosphereType? AtmosphereType { get; set; }
            public CelestialSurfaceType? SurfaceType { get; set; }
            public CelestialHabitability? Habitability { get; set; }
            public CelestialLifeType[]? LifeType { get; set; }
            public CelestialSpecialProperties[]? SpecialProperties { get; set; }
            public MyResourceList? ResourceList { get; set; }
            public MyPlanetResources? Composition { get; set; }
            public IMyMoon[]? Moons { get; set; }
        }

        /// <summary>
        /// Returns a IMyPlanet Value Based of the IMyOlanetGeneration Value
        /// </summary>
        /// <param name="myPlanetGeneration"></param>
        /// <returns></returns>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static IMyPlanet ReturnPlanetInformation(IMyPlanetGeneration myPlanetGeneration)
        {
            if (myPlanetGeneration.Name == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Name");
            if (myPlanetGeneration.ID == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.ID");
            if (myPlanetGeneration.Mass == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Mass");
            if (myPlanetGeneration.Radius == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Radius");
            if (myPlanetGeneration.Orbit == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Orbit");
            if (myPlanetGeneration.SurfaceTemperature == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.SurfaceTemperature");
            if (myPlanetGeneration.Type == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Type");
            if (myPlanetGeneration.AtmosphereType == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.AtmosphereType");
            if (myPlanetGeneration.SurfaceType == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.SurfaceType");
            if (myPlanetGeneration.Habitability == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Habitability");
            if (myPlanetGeneration.LifeType == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.LifeType");
            if (myPlanetGeneration.SpecialProperties == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.SpecialProperties");
            if (myPlanetGeneration.ResourceList == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.ResourceList");
            if (myPlanetGeneration.Composition == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Composition");
            if (myPlanetGeneration.Moons == null) throw new MyObjectGenerationValueException("(IMyPlanet).ReturnPlanetInformation.myPlanetGeneration.Moons");

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
                Orbit = myPlanetGeneration.Orbit
            };
        }
    }
}
