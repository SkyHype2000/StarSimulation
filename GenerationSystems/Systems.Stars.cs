using static Star_Simulation.CExceptions;
using static Star_Simulation.Libary;
using static Star_Simulation.Luminosity;
using static Star_Simulation.Spectral;
using static Star_Simulation.Systems;
using static Star_Simulation.SystemGeneration;
using static Star_Simulation.Export;

namespace Star_Simulation
{
    internal partial class Systems
    {
        /*
         * Vielleicht eine Erweiterung wäre in der Zukunft mit der Größe und der Masse eines Sternes sein Alter, Brennphase und Verbleibene Zeit zu Bestimmen.
         * Aber das Wäre zu Kompliziert, sogar für mich...
         */

        public class MyStar : IExport
        {
            public required string Name { get; set; }
            public required string ID { get; set; }
            public required double Mass { get; set; }
            public required double Radius { get; set; }
            public required float Norm { get; set; }
            public required float Temperature { get; set; }
            public required double Luminosity { get; set; }
            public required SubspectralClass SubSpectralClass { get; set; }
            public required ILuminosityClass LuminosityClass { get; set; }
            public required MyStellarSystem StellarSystem { get; set; }
        }

        public class MyStarGeneration : IMyObjectGeneration
        {
            public string? Name { get; set; }
            public string? ID { get; set; }
            public double? Mass { get; set; }
            public double? Radius { get; set; }
            public float? Norm { get; set; }
            public float? Temperature { get; set; }
            public double? Watt { get; set; }
            public SubspectralClass? SubSpectralClass { get; set; }
            public ILuminosityClass? LuminosityClass { get; set; }
            public MyStellarSystem? StellarSystem { get; set; }
        }

        /// <summary>
        /// Returns a MyStar Value Based of the MyStarGeneration Value
        /// </summary>
        /// <param name="starGeneration"></param>
        /// <returns></returns>
        /// <exception cref="MyObjectGenerationValueException"></exception>
        public static MyStar ReturnStarInformation(MyStarGeneration starGeneration)
        {
            if (starGeneration.Name == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.Name");
            if (starGeneration.ID == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.ID");
            if (starGeneration.Mass == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.Mass");
            if (starGeneration.Radius == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.Radius");
            if (starGeneration.Norm == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.Norm");
            if (starGeneration.Temperature == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.Temperature");
            if (starGeneration.Watt == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.Watt");
            if (starGeneration.SubSpectralClass == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.SubSpectralClass");
            if (starGeneration.LuminosityClass == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.LuminosityClass");
            if (starGeneration.StellarSystem == null) throw new MyObjectGenerationValueException("(MyStar).ReturnStarInformation.starGeneration.StellarSystem");

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
