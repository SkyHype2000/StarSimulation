using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Star_Simulation.Libary;
using static Star_Simulation.Program;

namespace Star_Simulation
{
    internal class Random
    {

        /**
         * class SeedRandom {
         *    private seed: number;
         *
         *    constructor(seed: string | number) {
         *        if (typeof seed === "string") {
         *            this.seed = 0;
         *            for (let i = 0; i < seed.length; i++) {
         *                this.seed = (this.seed * 31 + seed.charCodeAt(i)) >>> 0;
         *            }
         *        } else {
         *            this.seed = seed >>> 0;
         *        }
         *    }
         *
         *    next(): number {
         *        const a = 1664525;
         *        const c = 1013904223;
         *        const m = 0xFFFF_FFFF_FFFF;
         *        this.seed = (a * this.seed + c) % m;
         *        return this.seed / m;
         *    }
         *
         *    nextInt(max: number): number {
         *        return Math.floor(this.next() * max);
         *    }
         *}
         */

        public class SeedRandom
        {
            internal string seed { get; private set; }
            internal int state = 0;

            public SeedRandom(string seed = "new SeedRandom();")
            {
                this.seed = seed;

                //Console.WriteLine($"The Seed: {this.seed}");
            }

            public void NextState()
            {
                int hash = 0;
                foreach (char c in seed) hash = (hash * 31 + c) & 0x7FFFFFFF;

                state = (1664525 * (state + hash) + 1013904223) & 0x7FFFFFFF;
            }

            public void Push(uint n = 0xFF)
            {
                for (int i = 0; i < n; i++)
                {
                    NextState();
                }
            }

            /// <summary>
            /// Returns a pseudo random (and optional negative) double that is greater than or equal to the specified minimum value and less than the specified maximum value.
            /// </summary>
            /// <param name="max">The Maximum Value (Can be Negative)</param>
            /// <param name="min">The Minimum Value (Can be Negative)</param>
            /// <param name="minLarger">If Min is Larger than Max, it will Return Max</param>
            /// <returns>A random <T> between min and max.</returns>
            public T Next<T>(T Max, T Min = default!, bool minLarger = default!) where T : INumber<T>
            {
                NextState();

                double min = double.CreateChecked(Min);
                double max = double.CreateChecked(Max);

                if (minLarger && min >= max) return T.CreateChecked(max);
                if (min > max) min = max;

                double normalized = (double)state / ((double)int.MaxValue + 1.0);

                return T.CreateChecked(min + normalized * (max - min));
            }

            /// <summary>
            /// Returns a pseudo random (and optional negative) double that is greater than or equal to the specified minimum value and less than the specified maximum value.
            /// </summary>
            /// <param name="minMax">The Range Value (Can be Negative)</param>
            /// <param name="minLarger">If Min is Larger than Max, it will Return Max</param>
            /// <returns>A random <T> between min and max.</returns>
            public T Next<T>(MinMax<T> minMax, bool minLarger = default!) where T : INumber<T>
            {
                NextState();

                double min = double.CreateChecked(minMax.Min);
                double max = double.CreateChecked(minMax.Max);

                if (minLarger && min >= max) return T.CreateChecked(max);
                if (min > max) min = max;

                double normalized = (double)state / ((double)int.MaxValue + 1.0);

                return T.CreateChecked(min + normalized * (max - min));
            }

            /// <summary>
            /// Returns a random floating-point number greater than or equal to 0.0 and less or equal than 1.0.
            /// </summary>
            /// <returns>A pseudorandom float value in the range 0.0 to 1.0.</returns>
            public T NextOne<T>() where T : INumber<T>
            {
                return Next<T>(T.CreateChecked(1), T.CreateChecked(0));
            }

            /// <summary>
            /// Creates a new Vector 2 Value
            /// </summary>
            /// <param name="range"></param>
            /// <returns></returns>
            public Vector2<T> NextVector2<T>(MinMax<T> range) where T : INumber<T>
            {
                T nextX = Next<T>(range.Max, range.Min);
                T nextY = Next<T>(range.Max, range.Min);
                return new Vector2<T>(nextX, nextY);
            }

            /// <summary>
            /// Creates a new Vector 3 Value
            /// </summary>
            /// <param name="range"></param>
            /// <returns></returns>
            public Vector3<T> NextVector3<T>(MinMax<T> range) where T : INumber<T>
            {
                T nextX = Next(range.Max, range.Min);
                T nextY = Next(range.Max, range.Min);
                T nextZ = Next(range.Max, range.Min);

                return new Vector3<T>(nextX, nextY, nextZ);
            }

            public string NextID(uint length = 4, uint sectorLength = uint.MaxValue)
            {
                if (length <= 0) throw new ArgumentOutOfRangeException("NextID-Length Value cannot be below 1");

                string[] id = new string[length];
                for (int i = 0; i < length; i++)
                {
                    id[i] = Next<uint>(sectorLength).ToString("X8");
                }
                return string.Join('-', id);
            }

            public string NextIDL(uint length = 4, ulong sectorLength = ulong.MaxValue)
            {
                if (length <= 0) throw new ArgumentOutOfRangeException("NextID-Length Value cannot be below 1");

                string[] id = new string[length];
                for (int i = 0; i < length; i++)
                {
                    id[i] = Next<ulong>(sectorLength).ToString("X16");
                }
                return string.Join('-', id);
            }
        }
    }
}
