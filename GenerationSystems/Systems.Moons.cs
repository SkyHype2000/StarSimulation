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
using static Star_Simulation.Calculation;

namespace Star_Simulation
{
    internal partial class Systems
    {

        public interface IMyMoon
        {
            string Name { get; }
            string ID { get; }
            double Mass { get; }
            double Radius { get; }
            MyOrbit Orbit { get; set; }
            /// <summary>
            /// Hier ist es ein Wenig Konplexer da sich der Mond um den Planeten kreist.<br/>
            /// Dadurch ist die Distanz zum Stern nicht immer Gleich. (Aber das kann man Ignorieren)<br/>
            /// Und Manchmal wird der Mond auch vom Planeten beschattet. (Aber das kann man auch Ignorieren)
            /// </summary>
            MinMax<float> SurfaceTemperature { get; set; }
            CelestialType Type { get; set; }
            CelestialAtmosphereType AtmosphereType { get; set; }
            CelestialSurfaceType SurfaceType { get; set; }
            CelestialHabitability Habitability { get; set; }
            CelestialLifeType[] LifeType { get; set; }
            CelestialSpecialProperties[] SpecialProperties { get; set; }
            MyResourceList ResourceList { get; set; }
        }
        public class MyMoon : IMyMoon
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required double Radius { get; set; }
            public required MyOrbit Orbit { get; set; }
            public required MinMax<float> SurfaceTemperature { get; set; }
            public required CelestialType Type { get; set; }
            public required CelestialAtmosphereType AtmosphereType { get; set; }
            public required CelestialSurfaceType SurfaceType { get; set; }
            public required CelestialHabitability Habitability { get; set; }
            public required CelestialLifeType[] LifeType { get; set; }
            public required CelestialSpecialProperties[] SpecialProperties { get; set; }
            public required MyResourceList ResourceList { get; set; }
        }

        public interface IMyMoonGeneration
        {
            string? Name { get; set; }
            string? ID { get; set; }
            double? Mass { get; set; }
            double? Radius { get; set; }

            MyOrbit? Orbit { get; set; }
            /// <summary>
            /// Hier ist es ein Wenig Konplexer da sich der Mond um den Planeten kreist.<br/>
            /// Dadurch ist die Distanz zum Stern nicht immer Gleich. (Aber das kann man Ignorieren)<br/>
            /// Und Manchmal wird der Mond auch vom Planeten beschattet. (Aber das kann man auch Ignorieren)
            /// </summary>
            MinMax<float>? SurfaceTemperature { get; set; }
            CelestialType? Type { get; set; }
            CelestialAtmosphereType? AtmosphereType { get; set; }
            CelestialSurfaceType? SurfaceType { get; set; }
            CelestialHabitability? Habitability { get; set; }
            CelestialLifeType[]? LifeType { get; set; }
            CelestialSpecialProperties[]? SpecialProperties { get; set; }
            MyResourceList? ResourceList { get; set; }
        }
        public class MyMoonGeneration : IMyMoonGeneration, IMyObjectGeneration
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
        }

        /// <summary>
        /// Returns a IMyMoon Value Based of the IMyMoonGeneration Value
        /// </summary>
        /// <param name="myMoonGeneration"></param>
        /// <returns></returns>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static IMyMoon ReturnMoonInformation(MyDwarfPlanetGeneration myMoonGeneration)
        {
            if (myMoonGeneration.Name == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.Name");
            if (myMoonGeneration.ID == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.ID");
            if (myMoonGeneration.Mass == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.Mass");
            if (myMoonGeneration.Radius == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.Radius");
            if (myMoonGeneration.Orbit == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.Orbit");
            if (myMoonGeneration.SurfaceTemperature == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.SurfaceTemperature");
            if (myMoonGeneration.Type == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.Type");
            if (myMoonGeneration.AtmosphereType == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.AtmosphereType");
            if (myMoonGeneration.SurfaceType == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.SurfaceType");
            if (myMoonGeneration.Habitability == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.Habitability");
            if (myMoonGeneration.LifeType == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.LifeType");
            if (myMoonGeneration.SpecialProperties == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.SpecialProperties");
            if (myMoonGeneration.ResourceList == null) throw new MyObjectGenerationValueException("(IMyMoon).ReturnMoonInformation.myMoonGeneration.ResourceList");

            return new MyMoon()
            {
                Name = myMoonGeneration.Name,
                ID = myMoonGeneration.ID,
                Mass = (double)myMoonGeneration.Mass,
                Radius = (double)myMoonGeneration.Radius,
                SurfaceTemperature = (MinMax<float>)myMoonGeneration.SurfaceTemperature,
                Type = (CelestialType)myMoonGeneration.Type,
                AtmosphereType = (CelestialAtmosphereType)myMoonGeneration.AtmosphereType,
                SurfaceType = (CelestialSurfaceType)myMoonGeneration.SurfaceType,
                Habitability = (CelestialHabitability)myMoonGeneration.Habitability,
                LifeType = myMoonGeneration.LifeType,
                SpecialProperties = myMoonGeneration.SpecialProperties,
                ResourceList = (MyResourceList)myMoonGeneration.ResourceList,
                Orbit = myMoonGeneration.Orbit
            };
        }
    }
}
