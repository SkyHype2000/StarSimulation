using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Systems;

namespace Star_Simulation
{
    internal partial class SystemGeneration
    {
        /// <summary>A Moon Object</summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static IMyMoon GenerateMoon(MyDwarfPlanetGeneration Parent, MyStarGeneration StarParent, float MoonOrbit, int ObjectNumber)
        {
            // Placeholder for moon generation logic
            // Have to translate from ts to c#, but i'am lazy
            // In Theory Moons are generated similar to planets, so i can just generate a Planet and call it a Moon lol. Okay i shouldn't do that.

            throw new NotImplementedException();
        }
    }
}
