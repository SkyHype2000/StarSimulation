using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Program;
using static Star_Simulation.Spectral;
using static Star_Simulation.Luminosity;
using static Star_Simulation.Calculation;
using static Star_Simulation.Libary;

namespace Star_Simulation
{
    internal class Luminosity
    {
        public interface ILuminosityClass
        {
            string Class { get; }
            // Theoretisch I, II, III, IV, V, VI, VII
            // Praktisch nur I, III, V
            string Description { get; } // Description of the luminosity class
            double RadiusRangeMin { get; } // in Solarradius
            double RadiusRangeMax { get; } // in Solarradius
        }
        public class LuminosityClass : ILuminosityClass
        {
            public required string Class { get; set; }
            // Theoretisch I, II, III, IV, V, VI, VII
            // Praktisch nur I, III, V
            public required string Description { get; set; } // Description of the luminosity class
            public required double RadiusRangeMin { get; set; } // in Solarradius
            public required double RadiusRangeMax { get; set; } // in Solarradius
        }

        public static ILuminosityClass LuminosityClassI = new LuminosityClass()
        {
            Class = "I",
            Description = "Supergiant",
            RadiusRangeMin = 75f * SunRadius,
            RadiusRangeMax = 1000f * SunRadius,
        };

        public static ILuminosityClass LuminosityClassII = new LuminosityClass()
        {
            Class = "II",
            Description = "Bright Giant",
            RadiusRangeMin = 35f * SunRadius,
            RadiusRangeMax = 75f * SunRadius,
        };

        public static ILuminosityClass LuminosityClassIII = new LuminosityClass()
        {
            Class = "III",
            Description = "Giant",
            RadiusRangeMin = 10f * SunRadius,
            RadiusRangeMax = 35f * SunRadius,
        };

        public static ILuminosityClass LuminosityClassIV = new LuminosityClass()
        {
            Class = "IV",
            Description = "Subgiant",
            RadiusRangeMin = 2f * SunRadius,
            RadiusRangeMax = 10f * SunRadius,
        };

        public static ILuminosityClass LuminosityClassV = new LuminosityClass()
        {
            Class = "V",
            Description = "Main Sequence",
            RadiusRangeMin = 0.15f * SunRadius,
            RadiusRangeMax = 2f * SunRadius,
        };

        public static ILuminosityClass LuminosityClassVI = new LuminosityClass()
        {
            Class = "VI",
            Description = "Subdwarf",
            RadiusRangeMin = 0.09f * SunRadius,
            RadiusRangeMax = 0.15f * SunRadius,
        };

        public static ILuminosityClass LuminosityClassBD = new LuminosityClass()
        {
            Class = "BD",
            Description = "Brown Dwarf",
            RadiusRangeMin = 0.086f * SunRadius,
            RadiusRangeMax = 0.09f * SunRadius,
        };


        public static ILuminosityClass[] LuminosityClasses = new ILuminosityClass[]
        {
            LuminosityClassI,
            LuminosityClassII,
            LuminosityClassIII,
            LuminosityClassIV,
            LuminosityClassV,
            LuminosityClassVI,
            LuminosityClassBD,
        };

        public static void LogAllLuminosityClasses()
        {
            ConsoleLog("<== LUMINOSITY CLASSES ================================================>");
            ConsoleLog($"Reading {LuminosityClasses.Length} Luminosity Classes");

            foreach (var lumClass in LuminosityClasses)
            {
                ConsoleLog($"Luminosity Class {lumClass.Class} ({lumClass.Description}); Rad ({lumClass.RadiusRangeMin}, {lumClass.RadiusRangeMax})");
            }
            ConsoleLog("<======================================================================>");
        }

        public static ILuminosityClass GetLuminosityClassByRadius(double radius)
        {
            foreach (var lumClass in LuminosityClasses)
            {
                if (radius >= lumClass.RadiusRangeMin && radius < lumClass.RadiusRangeMax)
                    return lumClass;
            }
            return LuminosityClassV; // Default fallback
        }

    }
    internal class Spectral
    {
        public class SubspectralClass
        {
            public required string SubClass { get; set; } // 0-9
            public required float TemperatureRangeMin { get; set; } // in Kelvin
            public required float TemperatureRangeMax { get; set; } // in Kelvin
            public required double MassRangeMin { get; set; } // in kg
            public required double MassRangeMax { get; set; } // in kg
            public required SpectralClass ParentSpectralClass { get; set; }
        }

        public class SpectralClass
        {
            public required string Class { get; set; } // O, B, A, F, G, K, M, L, T, Y
            public required float TemperatureRangeMin { get; set; } // in Kelvin
            public required float TemperatureRangeMax { get; set; } // in Kelvin
            public required double MassRangeMin { get; set; } // in kg
            public required double MassRangeMax { get; set; } // in kg
            public required string StarColorName { get; set; } // Color Name
            public required Color StarColor { get; set; } // RGB Color representation
        };

        public static SpectralClass SpectralClassO = new SpectralClass
        {
            Class = "O",
            TemperatureRangeMin = 33000,
            TemperatureRangeMax = 50000,
            MassRangeMin = 18 * SunMass,
            MassRangeMax = 100 * SunMass,
            StarColorName = "Blue",
            StarColor = Color.FromArgb(155, 176, 255)
        };

        public static SpectralClass SpectralClassB = new SpectralClass
        {
            Class = "B",
            TemperatureRangeMin = 10000,
            TemperatureRangeMax = 33000,
            MassRangeMin = 3f * SunMass,
            MassRangeMax = 18 * SunMass,
            StarColorName = "Blue-White",
            StarColor = Color.FromArgb(170, 191, 255)
        };

        public static SpectralClass SpectralClassA = new SpectralClass
        {
            Class = "A",
            TemperatureRangeMin = 7500,
            TemperatureRangeMax = 10000,
            MassRangeMin = 2f * SunMass,
            MassRangeMax = 3f * SunMass,
            StarColorName = "White",
            StarColor = Color.FromArgb(202, 215, 255)
        };

        public static SpectralClass SpectralClassF = new SpectralClass
        {
            Class = "F",
            TemperatureRangeMin = 6000,
            TemperatureRangeMax = 7500,
            MassRangeMin = 1.1f * SunMass,
            MassRangeMax = 1.7f * SunMass,
            StarColorName = "Yellow-White",
            StarColor = Color.FromArgb(248, 247, 255)
        };

        public static SpectralClass SpectralClassG = new SpectralClass
        {
            Class = "G",
            TemperatureRangeMin = 5200,
            TemperatureRangeMax = 6000,
            MassRangeMin = 0.8f * SunMass,
            MassRangeMax = 1.1f * SunMass,
            StarColorName = "Yellow",
            StarColor = Color.FromArgb(255, 244, 234)
        };

        public static SpectralClass SpectralClassK = new SpectralClass
        {
            Class = "K",
            TemperatureRangeMin = 3900,
            TemperatureRangeMax = 5200,
            MassRangeMin = 0.45f * SunMass,
            MassRangeMax = 0.8f * SunMass,
            StarColorName = "Orange",
            StarColor = Color.FromArgb(255, 210, 161)
        };

        public static SpectralClass SpectralClassM = new SpectralClass
        {
            Class = "M",
            TemperatureRangeMin = 2000,
            TemperatureRangeMax = 3900,
            MassRangeMin = 0.08f * SunMass,
            MassRangeMax = 0.45f * SunMass,
            StarColorName = "Red",
            StarColor = Color.FromArgb(255, 204, 111)
        };

        public static SpectralClass SpectralClassL = new SpectralClass
        {
            Class = "L",
            TemperatureRangeMin = 1300,
            TemperatureRangeMax = 2000,
            MassRangeMin = 0.03f * SunMass,
            MassRangeMax = 0.08f * SunMass,
            StarColorName = "Brownish-Red",
            StarColor = Color.FromArgb(255, 180, 100)
        };

        public static SpectralClass SpectralClassT = new SpectralClass
        {
            Class = "T",
            TemperatureRangeMin = 600,
            TemperatureRangeMax = 1300,
            MassRangeMin = 0.01f * SunMass,
            MassRangeMax = 0.03f * SunMass,
            StarColorName = "Magenta",
            StarColor = Color.FromArgb(150, 100, 255)
        };

        public static SpectralClass SpectralClassY = new SpectralClass
        {
            Class = "Y",
            TemperatureRangeMin = 200,
            TemperatureRangeMax = 600,
            MassRangeMin = 0.001f * SunMass,
            MassRangeMax = 0.01f * SunMass,
            StarColorName = "Blueish-Magenta",
            StarColor = Color.FromArgb(100, 150, 255)
        };

        public static SpectralClass[] SpectralClasses =
        {
            SpectralClassO,
            SpectralClassB,
            SpectralClassA,
            SpectralClassF,
            SpectralClassG,
            SpectralClassK,
            SpectralClassM,
            SpectralClassL,
            SpectralClassT,
            SpectralClassY
        };

        public static void GenerateSubspectralClasses()
        {
            SubspectralClass[] SubClassesList = new SubspectralClass[SpectralClasses.Length * 10];

            for (int i = 0; i < SpectralClasses.Length; i++)
            {
                var spectralClass = SpectralClasses[i];
                for (int j = 0; j <= 9; j++)
                {
                    float tempMin = (float)((spectralClass.TemperatureRangeMax - spectralClass.TemperatureRangeMin) * (j / 10f) + spectralClass.TemperatureRangeMin);
                    float tempMax = (float)((spectralClass.TemperatureRangeMax - spectralClass.TemperatureRangeMin) * ((j + 1) / 10f) + spectralClass.TemperatureRangeMin);

                    double massMin = (spectralClass.MassRangeMax - spectralClass.MassRangeMin) * (j / 10f) + spectralClass.MassRangeMin;
                    double massMax = (spectralClass.MassRangeMax - spectralClass.MassRangeMin) * ((j + 1) / 10f) + spectralClass.MassRangeMin;

                    //ConsoleLog($"Debug (GenerateSubspectralClasses): Creating subclass {spectralClass.Class}{9 - j} with mass {massMin}-{massMax} and temp {tempMin}-{tempMax}");

                    SubspectralClass subclass = new SubspectralClass
                    {
                        SubClass = (9 - j).ToString(),
                        MassRangeMin = massMin,
                        MassRangeMax = massMax,
                        TemperatureRangeMin = tempMin,
                        TemperatureRangeMax = tempMax,
                        ParentSpectralClass = spectralClass
                    };
                    SubClassesList[i * 10 + (9 - j)] = subclass;
                }
            }
            SubspectralClasses = SubClassesList;
        }

        //public static void LogAllSubspectralClasses()
        //{
        //    ConsoleLog("<== SUBSPECTRAL CLASSES ===============================================>");
        //    ConsoleLog("Generated " + SubspectralClasses.Length + " Subspectral classes");
        //    foreach (var subspectral in SubspectralClasses)
        //    {
        //        ConsoleLog($"{subspectral.ParentSpectralClass.Class}{subspectral.SubClass}; Temp ({subspectral.TemperatureRangeMin}, {subspectral.TemperatureRangeMax}); Mass ({subspectral.MassRangeMin}, {subspectral.MassRangeMax});");
        //    }
        //    ConsoleLog("<======================================================================>");
        //}
    }
}
