using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.CExceptions;
using static Star_Simulation.Libary;
using static Star_Simulation.Resource;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Systems;

namespace Star_Simulation
{
    internal partial class Systems
    {
        public interface IMyDwarfPlanet : IMyStellarObject
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
            IMyResourceList ResourceList { get; }
            IMyMoon[] Moons { get; }
        }
        public class MyDwarfPlanet : IMyDwarfPlanet, IMyStellarObject
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
            public required IMyResourceList ResourceList { get; set; }
            public required IMyMoon[] Moons { get; set; }
            public required IMyOrbit Orbit { get; set; }
        }

        public interface IMyDwarfPlanetGeneration : IMyObjectGeneration
        {
            string? Name { get; set; }
            string? ID { get; set; }
            double? Mass { get; set; }
            IMyResourceList? ResourceList { get; set; }
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
        public class MyDwarfPlanetGeneration : IMyDwarfPlanetGeneration, IMyObjectGeneration
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
            public IMyResourceList? ResourceList { get; set; }
            public IMyMoon[]? Moons { get; set; }
        }

        /// <summary>
        /// Returns a IMyDwarfPlanet Value Based of the IMyDwarfPlanetGeneration Value
        /// </summary>
        /// <param name="myDwarfPlanetGeneration"></param>
        /// <returns></returns>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static IMyDwarfPlanet ReturnDwarfPlanetInformation(IMyDwarfPlanetGeneration myDwarfPlanetGeneration)
        {
            if (myDwarfPlanetGeneration.Name == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Name");
            if (myDwarfPlanetGeneration.ID == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.ID");
            if (myDwarfPlanetGeneration.Mass == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Mass");
            if (myDwarfPlanetGeneration.Radius == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Radius");
            if (myDwarfPlanetGeneration.Orbit == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Orbit");
            if (myDwarfPlanetGeneration.SurfaceTemperature == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.SurfaceTemperature");
            if (myDwarfPlanetGeneration.Type == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Type");
            if (myDwarfPlanetGeneration.AtmosphereType == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.AtmosphereType");
            if (myDwarfPlanetGeneration.SurfaceType == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.SurfaceType");
            if (myDwarfPlanetGeneration.Habitability == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Habitability");
            if (myDwarfPlanetGeneration.LifeType == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.LifeType");
            if (myDwarfPlanetGeneration.SpecialProperties == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.SpecialProperties");
            if (myDwarfPlanetGeneration.ResourceList == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.ResourceList");
            if (myDwarfPlanetGeneration.Moons == null) throw new MyObjectGenerationValueException("(IMyDwarfPlanet).ReturnDwarfPlanetInformation.myDwarfPlanetGeneration.Moons");

            return new MyDwarfPlanet()
            {
                Name = myDwarfPlanetGeneration.Name,
                ID = myDwarfPlanetGeneration.ID,
                Mass = (double)myDwarfPlanetGeneration.Mass,
                Radius = (double)myDwarfPlanetGeneration.Radius,
                SurfaceTemperature = (MinMax<float>)myDwarfPlanetGeneration.SurfaceTemperature,
                Type = (CelestialType)myDwarfPlanetGeneration.Type,
                AtmosphereType = (CelestialAtmosphereType)myDwarfPlanetGeneration.AtmosphereType,
                SurfaceType = (CelestialSurfaceType)myDwarfPlanetGeneration.SurfaceType,
                Habitability = (CelestialHabitability)myDwarfPlanetGeneration.Habitability,
                LifeType = myDwarfPlanetGeneration.LifeType,
                SpecialProperties = myDwarfPlanetGeneration.SpecialProperties,
                ResourceList = myDwarfPlanetGeneration.ResourceList,
                Moons = myDwarfPlanetGeneration.Moons,
                Orbit = myDwarfPlanetGeneration.Orbit
            };
        }
    }
}
