using System;
using static Star_Simulation.Random;

/*
 * ====================================================================================================================================================================================================================================================================
 * 
 * GOOGLE:
 * 
 * Bei einem prozedural (zufallsgenerierten) Planeten, besonders wenn man von terrestrischen (gesteinsbasierten) Planeten ausgeht, besteht der Kern am wahrscheinlichsten aus Eisen und Nickel.
 * 
 *  -> Eisen-Nickel-Kern: Ähnlich wie bei der Erde, Merkur, Venus und Mars, sind Eisen und Nickel die wahrscheinlichsten Hauptkomponenten im Kern eines terrestrischen Planeten.
 *  -> Andere schwere Elemente: Neben Eisen und Nickel können auch andere schwere Elemente wie Schwefel oder Silizium im Kern enthalten sein.
 *  -> Gestein/Metall-Mischung: Insgesamt bestehen terrestrische Planeten hauptsächlich aus Gestein und Metallen.
 * 
 * Bei größeren, gasreichen Planeten (Gasriesen oder Eisriesen) ist der Kern oft von einer dicken Schicht aus Wasser, Ammoniak oder anderen Stoffen umgeben, aber auch hier ist ein fester, metallischer Kern im Zentrum sehr wahrscheinlich.
 * 
 * ====================================================================================================================================================================================================================================================================
 */

namespace Star_Simulation
{
    internal partial class Resource
    {
        public class PlanetResources
        {
            public required MyResourceList CoreResourceList { get; set; }
            public required MyResourceList CrustResourceList { get; set; }
            public required float CrustSizeKM { get; set; }
        }
        /// <summary>
        /// Generates the Resources of a Planet.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static PlanetResources GeneratePlanetResources(SeedRandom seed)
        {
            MyResourceList core = GeneratePlanetCoreResources(seed);

            throw new NotImplementedException();
        }
        /// <summary>
        /// Generates the Resources in the Core of a Planet.
        /// </summary>
        /// <returns></returns>
        public static MyResourceList GeneratePlanetCoreResources(SeedRandom seed)
        {
            MyResourceList core = new MyResourceList() { Resources = [] };

            int valueFeNi = seed.Next<int>(8000, 7000);
            int valueFe = seed.Next<int>(8000);
            int valueNi = valueFeNi - valueFe;
            int valueFeS = 10000 - valueFeNi;
            MyResourceValue core_iron = new() { Value = valueFe, Resource = ResourceElements.Iron };
            MyResourceValue core_nickel = new() { Value = valueNi, Resource = ResourceElements.Nickel };
            MyResourceValue core_Ironsulfide = new() { Value = valueFeS, Resource = ResourceElements.Ironsulfide };

            //throw new NotImplementedException();

            core.Resources.Add(core_iron);
            core.Resources.Add(core_nickel);
            core.Resources.Add(core_Ironsulfide);

            return core;
        }
        /// <summary>
        /// Generates the Resources in the Core of a Planet.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MyResourceList GeneratePlanetCrustResources(SeedRandom seed)
        {
            throw new NotImplementedException();
        }
    }
}