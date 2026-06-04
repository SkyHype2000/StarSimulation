using static Star_Simulation.Program;
using static Star_Simulation.Spectral;
using static Star_Simulation.Random;
using static Star_Simulation.Systems;
using static Star_Simulation.Resource;
using static Star_Simulation.Libary;
using static Star_Simulation.GenerationTable;

namespace Star_Simulation
{
    internal class Calculation
    {
        /// <summary>Gravitational Constant in m^3 kg^-1 s^-2</summary>
        public static readonly double G = 6.67430e-11d;
        /// <summary>Stefan-Boltzmann Constant in W m^-2 K^-4</summary>
        public static readonly double SB = 5.670374419e-8d;
        /// <summary>Speed of Light in m/s</summary>
        public static readonly int C = 299792458;

        /// <summary>Astronomical Unit in meters</summary>
        public static readonly double AU = 1.496e+11d;
        /// <summary>Astronomical Unit in meters</summary>
        public static readonly MinMax<double> MinMaxAU = new MinMax<double>(AU, AU);
        /// <summary>Parsec in meters</summary>
        public static readonly double PC = 3.0857e+16d;
        /// <summary>Parsec to Light Year conversion factor</summary>
        public static readonly double PC_LY = 3.26156d;
        /// <summary>Light Year to Parsec conversion factor</summary>
        public static readonly double LY_PC = 0.306601d;

        /// <summary>Light Year in meters</summary>
        public static readonly double LY = 9.4607e+15d; // Light Year in meters
        /// <summary>Light Day in meters</summary>
        public static readonly double LD = 2.590206837e+13d; // Light Day in meters
        /// <summary>Light Hour in meters</summary>
        public static readonly double LH = 1.0792528488e+12d; // Light Hour in meters
        /// <summary>Light Minute in meters</summary>
        public static readonly double LM = 1.7987550813e+10d; // Light Minute in meters
        /// <summary>Light Second in meters</summary>
        public static readonly double LS = 299792458d; // Light Second in meters

        /// <summary>Mass of the Sun in KG</summary>
        public static readonly double SunMass = 1.989e30d;
        /// <summary>Radius of the Sun in Meters</summary>
        public static readonly double SunRadius = 6.957e8d;
        /// <summary>Sun's Energyoutput? in Watts</summary>
        public static readonly double SunWatt = 3.828e26d;
        /// <summary>Surface Temperature of the Sun in °K</summary>
        public static readonly int SunTemp = 5778;

        /// <summary>Year in Seconds</summary>
        public static readonly double Year = 31557600d;

        public static readonly float CelciusOffset = -273.15f;

        /// <summary>Mass of the Earth in KG</summary>
        public static readonly double EarthMass = 5.9722e24;
        /// <summary>Radius of the Earth in Meter</summary>
        public static readonly double EarthRadius = 6371000.785;
        /// <summary>Density of the Earth in KG/m^3</summary>
        public static readonly double EarthDensity = 5517;

        /// <summary>Mass of the Moon in KG</summary>
        public static readonly double MoonMass = 7.346e22d;
        /// <summary>Radius of the Moon in Meter</summary>
        public static readonly double MoonRadius = 1738000;
        /// <summary>Density of the Moon in KG/m^3</summary>
        public static readonly double MoonDensity = 3341;

        /// <summary>Constant that Helps making Volume Calculations more Compact</summary>
        public static readonly double VolumeConst = (4.0 / 3.0) * Math.PI;

        /// <summary>
        /// Returns the subspectral class that contains the specified mass value.
        /// </summary>
        /// <param name="M">The mass value to locate within the available subspectral classes.</param>
        /// <returns>An object representing the subspectral class whose mass range includes the specified value. If no matching
        /// class is found, returns the first subspectral class in the collection.</returns>
        public static SubspectralClass GetSubspectral(double M)
        {
            foreach (var sub in SubspectralClasses)
            {
                if (sub.MassRangeMin <= M && sub.MassRangeMax >= M)
                {
                    return sub;
                }
            }
            return SubspectralClasses[0];
        }

        /// <summary>
        /// Calculates the normalizes value of mass M within the specified spectral class.
        /// </summary>
        /// <param name="M">Star Mass in Sun Masses</param>
        /// <param name="spectral">Specralinformation</param>
        /// <returns>Normalized Value</returns>
        public static float CalculateNorm(double M, SpectralClass spectral)
        {
            float norm = (float)(((M) - spectral.MassRangeMin) / (spectral.MassRangeMax - spectral.MassRangeMin));
            return norm;
        }
        /// <summary>
        /// Calculates the normalizes value of mass M within the specified subspectral class.
        /// </summary>
        /// <param name="M">Star Mass in KG</param>
        /// <param name="subspectral">Subspecralinformation</param>
        /// <returns>Normalized Value</returns>
        public static float CalculateNorm(double M, SubspectralClass subspectral)
        {
            float norm = (float)((M - subspectral.MassRangeMin) / (subspectral.MassRangeMax - subspectral.MassRangeMin));
            return norm;
        }

        public static double CalculateStarWatt(float T, double R)
        {
            double lum = 4 * Math.PI * (R * R) * SB * Math.Pow(T, 4);
            return lum;
        }

        public static double GetStarMass(SeedRandom seed)
        {
            double r = seed.NextOne<double>();

            double result = Math.Pow(r / STAR_GENERATION_CONSTANT, -0.4f) * SunMass;

            //ConsoleLog(result);

            return result;
        }

        public static double GetStarRadius(double M)
        {
            double result = Math.Pow(M / SunMass, 0.8) * SunRadius;
            return result;
        }

        public static float CalculateStarSurfaceTemperatureNorm(float norm, SpectralClass spectral)
        {
            return (spectral.TemperatureRangeMax - spectral.TemperatureRangeMin) * norm + spectral.TemperatureRangeMin;
        }

        public static float CalculateStarSurfaceTemperatureNorm(float norm, SubspectralClass subspectral)
        {
            return (subspectral.TemperatureRangeMax - subspectral.TemperatureRangeMin) * norm + subspectral.TemperatureRangeMin;
        }

        public static double CalculateSOI(double massMain, double massParent, double orbitalHeight)
        {
            return (orbitalHeight * Math.Pow(massMain / massParent, 0.4f));
        }

        public static double CalculateSOI(MyPlanet Planet, MyStar Star)
        {
            return (Planet.Orbit.OrbitalRadiusPerigee * Math.Pow(Planet.Mass / Star.Mass, 0.4f));
        }

        public static double CalculateSOI(MyDwarfPlanetGeneration DwarfPlanet, MyStarGeneration Star)
        {
            if (DwarfPlanet.Orbit == null) throw new MyObjectGenerationValueException("(double).CalculateSOI.DwarfPlanet.Orbit");
            if (DwarfPlanet.Mass == null) throw new MyObjectGenerationValueException("(double).CalculateSOI.DwarfPlanet.Mass");
            if (Star.Mass == null) throw new MyObjectGenerationValueException("(double).CalculateSOI.Star.Mass");
            return (DwarfPlanet.Orbit.OrbitalRadiusPerigee * Math.Pow((double)(DwarfPlanet.Mass / Star.Mass), 0.4f));
        }

        public static double CalculateSOI(IMyMoon Moon, MyPlanet Planet)
        {
            return (Moon.Orbit.OrbitalRadiusPerigee * Math.Pow(Moon.Mass / Planet.Mass, 0.4f));
        }

        public static double CalculateSOI(IMyMoonGeneration Moon, MyDwarfPlanetGeneration Planet)
        {
            if (Moon.Orbit == null) throw new MyObjectGenerationValueException("(double).CalculateSOI.Moon.Orbit");
            if (Moon.Mass == null) throw new MyObjectGenerationValueException("(double).CalculateSOI.Moon.Mass");
            if (Planet.Mass == null) throw new MyObjectGenerationValueException("(double).CalculateSOI.DwarfPlanet.Mass");
            return (Moon.Orbit.OrbitalRadiusPerigee * Math.Pow((double)(Moon.Mass / Planet.Mass), 0.4f));
        }

        public static double CalculatePlanetRadius(double mass, MyResourceList resources)
        {
            float totalDensity = 0;

            if (resources.RawResources.Count <= 0) throw new MyResourceListLengthException($"(double).CalculatePlanetRadius.resources.RawResources.Length has a Length of {resources.RawResources.Count} (Zero or Below)");

            for (int i = 0; i < resources.RawResources.Count; i++)
            {
                IMyResource res = resources.RawResources[i].Resource;
                if (res.Density <= 0) throw new MyResourceInvalidValueException($"(double).CalculatePlanetRadius.resources[{i}] = '{res.Name}' Density has a invalid Value of '{res.Density}' (Zero or Below)");

                totalDensity += resources.RawResources[i].Resource.Density;
            }

            return totalDensity;

            throw new NotImplementedException();
        }

        /// <summary>
        /// Calculates the Basic Mass of a Sphere with the Average Density
        /// </summary>
        /// <param name="radius">Radius in Meters</param>
        /// <param name="density">Density in kg/m³</param>
        /// <returns></returns>
        public static double CalculateBasicSphereMass(double radius, double density)
        {
            return CalculateSphereVolume(radius) * density;
        }

        public static double CalculateSphereVolume(double radius)
        {
            return VolumeConst * Math.Pow(radius, 3);
        }

        /// <summary>
        /// Calculates Simplefied the Mass of a Planet with the Compositions of the Planet, if this makes sense
        /// </summary>
        /// <param name="resources">Resources</param>
        /// <param name="radius">Radius in Meters</param>
        /// <returns></returns>
        public static double CalculatePlanetMass(MyPlanetResources resources, double radius)
        {
            double radiusCore = radius * GC_Planet.PlanetCoreSize;
            double radiusMantle = radius - resources.CrustHeight;

            double volumeCore = VolumeConst * Math.Pow(radiusCore, 3);
            double volumeMantle = (VolumeConst * Math.Pow(radiusMantle, 3)) - volumeCore;
            double volumeCrust = (VolumeConst * Math.Pow(radius, 3)) - (VolumeConst * Math.Pow(radiusMantle, 3));

            double massCore = volumeCore * resources.CoreResourceList.AverageDensity;
            double massMantle = volumeMantle * resources.MantleResourceList.AverageDensity;
            double massCrust = volumeCrust * resources.CrustResourceList.AverageDensity;

            return massCore + massMantle + massCrust;
        }

        /// <summary>
        /// Calculates the Average Amount of Asteroids in a AsteroidF ield
        /// </summary>
        /// <param name="density"></param>
        /// <param name="innerRadius"></param>
        /// <param name="outerRadius"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static double CalculateAsteroidsInAsteroidBelt(double density, double innerRadius, double outerRadius, double height)
        {
            return (Math.PI * height * (Math.Pow(outerRadius, 2) - Math.Pow(innerRadius, 2))) * density;
        }

        /// <summary>
        /// Calculates the Surface Temperature with the albedo.
        /// </summary>
        /// <param name="albedo"></param>
        /// <param name="orbitalHeight"></param>
        /// <param name="Watt"></param>
        /// <returns></returns>
        public static float CalculateObjectSurfaceTemperature(float albedo, double orbitalHeight, double Watt)
        {
            float temperature = MathF.Pow((float)((Watt * (1 - albedo)) / (16 * Math.PI * Math.Pow(orbitalHeight, 2) * SB)), 0.25f);
            return temperature;
        }

        public static class OrbitalCalculation
        {
            /*
             * \text{1. Semi-Major-Achse mit Periapsis Berechnen}\\
             * a = \frac{1}{\frac{2}{r_p}-\frac{r_p^2}{GM}}\\
             * \text{2. Exzentrizität Berechnen}\\
             * e = 1 - \frac{r_p}{a}\\
             * \text{3. Höhe der Apoapsis Berechnen}\\
             * r_a = a(1+e)\\
             * \text{4. Orbitale Geschwindigkeit an der Apoapsis Berechnen}\\
             * v_a = \sqrt{\frac{GM}{a} \cdot \frac{1-e}{1+e}}

             * (Dumme version)
             * r_a = \frac{1}{\frac{2}{r_p}-\frac{v_p^2}{GM}} \cdot \Bigg(1 - \frac{r_p}{\frac{1}{\frac{2}{r_p}-\frac{v_p^2}{GM}}}\Bigg)
             * \\
             * v_a = \sqrt{\frac{GM}{\frac{1}{\frac{2}{r_p}-\frac{v_p^2}{GM}}} \cdot \frac{1-1 - \frac{r_p}{\frac{1}{\frac{2}{r_p}-\frac{v_p^2}{GM}}}}{1 + 1 - \frac{r_p}{\frac{1}{\frac{2}{r_p}-\frac{v_p^2}{GM}}}}}
             *

             * G = \text{Gravitationskonstante}\\
             * M = \text{Masse des Zentralobjektes}\\
             * r_p = \text{Radius des Orbits von der Periapsis}\\
             * v_p = \text{Orbitalgeschwindigkeit an der Periapsis}\\
             * a = \text{Semi-Major-Achse}\\
             * e = \text{Exzentrizität}\\
             * r_a = \text{Radius des Orbits von der Apoapsis}\\
             * v_a = \text{Orbitalgeschwindigkeit an der Apoapsis}\\
             */

            /// <summary>
            /// Calculates the Semi-Major-Axis with the Periapsis Orbital Radios and Speed
            /// </summary>
            /// <param name="velocityPe"></param>
            /// <param name="orbitalRadiusPe"></param>
            /// <param name="centralMass"></param>
            /// <returns></returns>
            public static double a_WithPe(double velocityPe, double orbitalRadiusPe, double centralMass)
            {
                return (1) / (((2) / (orbitalRadiusPe)) - ((Math.Pow(velocityPe, 2)) / (G * centralMass)));
            }

            /// <summary>
            /// Calculates the eccentricity of the Orbit with the Periapsis Orbital Radius and Speed
            /// </summary>
            /// <param name="velocityPe"></param>
            /// <param name="orbitalRadiusPe"></param>
            /// <param name="centralMass"></param>
            /// <returns></returns>
            public static double e_WithPe(double velocityPe, double orbitalRadiusPe, double centralMass)
            {
                return 1 - ((orbitalRadiusPe) / (a_WithPe(velocityPe, orbitalRadiusPe, centralMass)));
            }

            /// <summary>
            /// Calculates the Orbital Radius on the Apoapsis with the Speed and Orbital Radius on the Periapsis
            /// </summary>
            /// <param name="velocityPe"></param>
            /// <param name="orbitalRadiusPe"></param>
            /// <param name="centralMass"></param>
            /// <returns></returns>
            public static double OrbitalRadius_ApWithPe(double velocityPe, double orbitalRadiusPe, double centralMass)
            {
                return a_WithPe(velocityPe, orbitalRadiusPe, centralMass) * (1 + e_WithPe(velocityPe, orbitalRadiusPe, centralMass));
            }

            /// <summary>
            /// Calculates the Orbital Velocity on the Apoapsis with the Periapsis Orbital Radius and Speed.
            /// </summary>
            /// <param name="velocityPe"></param>
            /// <param name="orbitalRadiusPe"></param>
            /// <param name="centralMass"></param>
            /// <returns></returns>
            public static double OrbitalVelocity_ApWithPe(double velocityPe, double orbitalRadiusPe, double centralMass)
            {
                double a = (1) / (((2) / (orbitalRadiusPe)) - ((Math.Pow(velocityPe, 2)) / (G * centralMass)));
                double e = 1 - ((orbitalRadiusPe) / (a));
                return Math.Sqrt(((G * centralMass) / (a_WithPe(velocityPe, orbitalRadiusPe, centralMass))) * ((1 - e) / (1 + e)));
            }

            /// <summary>
            /// Calculates the Orbital Period with the Ap and e Included.
            /// </summary>
            /// <param name="velocityPe"></param>
            /// <param name="orbitalRadiusPe"></param>
            /// <param name="centralMass"></param>
            /// <returns></returns>
            public static double OrbitalPeriod_WithApPe(double velocityPe, double orbitalRadiusPe, double centralMass)
            {
                return 2 * Math.PI * Math.Sqrt(Math.Pow(a_WithPe(velocityPe, orbitalRadiusPe, centralMass), 3) / (G * centralMass));
            }

            /// <summary>
            /// Calculates the orbital period (in seconds) of an object orbiting at a distance R (in meters) from a mass M (in kilograms).<br/>
            /// (on a Perfect Orbit where the eccentricity is 0, or 1? anyways, where Ap is the Same Orbital Radius as Pe)
            /// </summary>
            /// <param name="type">The type of output for the orbital period</param>
            /// <param name="R">The Height in Meters</param>
            /// <param name="M">The Mass in kg</param>
            /// <returns>Orbital Period in Seconds or AU</returns>
            public static double CalculateOrbitalPeriod(double R, double M)
            {
                double period = (double)(2 * Math.PI * Math.Sqrt(Math.Pow(R, 3) / (G * M)));

                ConsoleLog($"Calculated Orbital Period: {period} seconds with R={R * SunRadius} m and M={M} kg");

                return period;
            }
            /// <summary>
            /// Calculates the orbital velocity of an object orbiting at a distance R (in meters) from a mass M (in kilograms).
            /// </summary>
            /// <param name="type">The type of output for the orbital velocity</param>
            /// <param name="R">The Height in Meters</param>
            /// <param name="M">The Mass in kg</param>
            /// <returns>Orbital Velocity in m/s, AU/s or C</returns>
            public static double CalculateOrbitalVelocity(double R, double M)
            {
                double v = (double)Math.Sqrt((G * M) / (R));

                return v;
            }

            /// <summary>
            /// Calcumates the orbital radius (in meters) of an object orbiting a mass M (in kilograms) with an orbital period T (in seconds).
            /// </summary>
            /// <param name="type">The type of output for the orbital radius</param>
            /// <param name="T">The Orbital Period in Seconds</param>
            /// <param name="M">The Mass in kg</param>
            /// <returns>Orbital radius in Meters</returns>
            public static double CalculateOrbitalRadius(float T, float M)
            {
                double R = (double)Math.Pow((G * M) * ((T) / Math.Pow(2 * Math.PI, 2)), (1 / 3));

                ConsoleLog($"Calculated Orbital Radius: {R} m with T={T} s and M={M} kg");

                return R;
            }

            public static double GetOrbitalRadiusPlanet(SeedRandom seed, double objectMassMain, double objectMassParent, double lastOrbitalRadius, double lastSOI, MinMax<double> SOIRange, bool AstroidMove)
            {
                double currentOrbitalRadius = lastOrbitalRadius;
                if (AstroidMove) currentOrbitalRadius += seed.Next(GC_Planet.RangeDistanceBetweenPlanets.Min / 10);
                else seed.Next(GC_Planet.RangeDistanceBetweenPlanets.Max, GC_Planet.RangeDistanceBetweenPlanets.Min);
                double currentSOI = CalculateSOI(objectMassMain, objectMassParent, currentOrbitalRadius);

                bool validOrbit = false;

                while (!validOrbit)
                {
                    if ((lastOrbitalRadius + lastSOI) < (currentOrbitalRadius - currentSOI)) validOrbit = true;
                    else
                    {
                        currentOrbitalRadius += seed.Next(GC_Planet.RangeDistanceBetweenPlanets.Min);
                        currentSOI = CalculateSOI(objectMassMain, objectMassParent, currentOrbitalRadius);
                    }
                }

                return currentOrbitalRadius;
            }

            /// <summary>
            /// GEts the Current Orbital Object Position.<br/>
            /// Assisted by Gemini.
            /// </summary>
            /// <param name="orbit"></param>
            /// <param name="simulationTime"></param>
            /// <returns></returns>
            public static Vector2<double> GetOrbitPosition(MyOrbit orbit, double simulationTime)
            {
                double ra = orbit.OrbitalRadiusApogee;
                double rp = orbit.OrbitalRadiusPerigee;

                double a = (ra + rp) / 2;                         // semi major axis
                double e = (ra - rp) / (ra + rp);                 // eccentricity

                double t = (simulationTime + orbit.OrbitalOffset) % orbit.OrbitalPeriod;

                double M = 2.0 * Math.PI * t / orbit.OrbitalPeriod;   // mean anomaly

                // Solve Kepler: M = E - e*sin(E)
                double E = M;
                for (int i = 0; i < 5; i++)
                {
                    E = E - (E - e * Math.Sin(E) - M) / (1 - e * Math.Cos(E));
                }

                double x = a * (Math.Cos(E) - e);
                double y = a * Math.Sqrt(1 - e * e) * Math.Sin(E);

                double rot = orbit.AxialRotationLR * Math.PI / 180.0;

                double xr = x * Math.Cos(rot) - y * Math.Sin(rot);
                double yr = x * Math.Sin(rot) + y * Math.Cos(rot);

                return new Vector2<double>(xr, yr);
            }

            /// <summary>
            /// Get Orbital Points for Rendering/Visulasation<br/>
            /// Written by Gemini.
            /// </summary>
            /// <param name="orbit"></param>
            /// <param name="segments"></param>
            /// <returns></returns>
            public static Vector2<double>[] GetOrbitPoints(MyOrbit orbit, int segments)
            {
                Vector2<double>[] points = new Vector2<double>[segments];

                for (int i = 0; i < segments; i++)
                {
                    double t = orbit.OrbitalPeriod * i / segments;
                    points[i] = GetOrbitPosition(orbit, t);
                }

                return points;
            }
        }
    }
}