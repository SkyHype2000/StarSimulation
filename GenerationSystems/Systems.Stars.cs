using static Star_Simulation.CExceptions;
using static Star_Simulation.Libary;
using static Star_Simulation.Luminosity;
using static Star_Simulation.Spectral;
using static Star_Simulation.Systems;
using static Star_Simulation.SystemGeneration;

namespace Star_Simulation
{
    internal partial class Systems
    {
        /*
         * Vielleicht eine Erweiterung wäre in der Zukunft mit der Größe und der Masse eines Sternes sein Alter, Brennphase und Verbleibene Zeit zu Bestimmen.
         * Aber das Wäre zu Kompliziert, sogar für mich...
         */

        public interface IMyStar : IMyStellarObject
        {
            string Name { get; set; }
            string ID { get; set; }
            double Mass { get; set; }
            double Radius { get; set; }
            float Norm { get; set; }
            float Temperature { get; set; }
            double Luminosity { get; set; }
            ISubspectralClass SubSpectralClass { get; set; }
            ILuminosityClass LuminosityClass { get; set; }
            IMyStellarSystem StellarSystem { get; set; }
        }
        public class MyStar : IMyStar
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required double Radius { get; set; }
            public required float Norm { get; set; }
            public required float Temperature { get; set; }
            public required double Luminosity { get; set; }
            public required ISubspectralClass SubSpectralClass { get; set; }
            public required ILuminosityClass LuminosityClass { get; set; }
            public required IMyStellarSystem StellarSystem { get; set; }
        }

        public interface IMyStarGeneration : IMyObjectGeneration
        {
            string? Name { get; set; }
            string? ID { get; set; }
            double? Mass { get; set; }
            double? Radius { get; set; }
            float? Norm { get; set; }
            float? Temperature { get; set; }
            double? Watt { get; set; }
            ISubspectralClass? SubSpectralClass { get; set; }
            ILuminosityClass? LuminosityClass { get; set; }
            IMyStellarSystem? StellarSystem { get; set; }
        };

        public class MyStarGeneration : IMyStarGeneration, IMyObjectGeneration
        {
            public string? Name { get; set; }
            public string? ID { get; set; }
            public double? Mass { get; set; }
            public double? Radius { get; set; }
            public float? Norm { get; set; }
            public float? Temperature { get; set; }
            public double? Watt { get; set; }
            public ISubspectralClass? SubSpectralClass { get; set; }
            public ILuminosityClass? LuminosityClass { get; set; }
            public IMyStellarSystem? StellarSystem { get; set; }
        }

        /// <summary>
        /// Returns a IMyStar Value Based of the IMyStarGeneration Value
        /// </summary>
        /// <param name="starGeneration"></param>
        /// <returns></returns>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static IMyStar ReturnStarInformation(IMyStarGeneration starGeneration)
        {
            if (starGeneration.Name == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.Name");
            if (starGeneration.ID == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.ID");
            if (starGeneration.Mass == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.Mass");
            if (starGeneration.Radius == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.Radius");
            if (starGeneration.Norm == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.Norm");
            if (starGeneration.Temperature == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.Temperature");
            if (starGeneration.Watt == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.Watt");
            if (starGeneration.SubSpectralClass == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.SubSpectralClass");
            if (starGeneration.LuminosityClass == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.LuminosityClass");
            if (starGeneration.StellarSystem == null) throw new MyObjectGenerationValueException("(IMyStar).ReturnStarInformation.starGeneration.StellarSystem");

            return new MyStar()
            {
                Name = starGeneration.Name,
                ID = starGeneration.ID,
                Mass = (double)starGeneration.Mass,
                Radius = (double)starGeneration.Radius,
                Norm = (float)starGeneration.Norm,
                Temperature = (float)starGeneration.Temperature,
                Luminosity = (double)starGeneration.Watt,
                SubSpectralClass = starGeneration.SubSpectralClass,
                LuminosityClass = starGeneration.LuminosityClass,
                StellarSystem = starGeneration.StellarSystem
            };
        }
    }
}
