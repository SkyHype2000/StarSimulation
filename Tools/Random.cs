using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
            public string seed { get; private set; }
            public string pos { get; private set; }
            public int state = 0;
            public bool lockState = false;
            public uint num = 0u;

            public SeedRandom(string seed = "new SeedRandom();")
            {
                this.seed = seed;
                pos = $"";
                NextState();

                //ConsoleLog($"The Seed: {this.seed}");
            }

            public void NextState()
            {
                if (lockState) return;

                int hash = 0;
                foreach (char c in seed) hash = (hash * 31 + c) & 0x7FFFFFFF;

                state = (1664525 * (state + hash) + 1013904223) & 0x7FFFFFFF;

                num++;

                pos = $"{seed:X16}";
                pos = $"{pos}:{state}";
                pos = $"{pos}({num:X8})";
            }

            public void Push(uint n = 0xFF)
            {
                for (int i = 0; i < n; i++)
                {
                    NextState();
                }
            }

            /// <summary>
            /// Extra Next() Function for double/float Values.
            /// </summary>
            /// <param name="Max"></param>
            /// <param name="Min"></param>
            /// <param name="minLarger"></param>
            /// <returns></returns>
            private double NextDouble(double Max, double Min = default!, bool minLarger = default!)
            {
                NextState();

                double min = double.CreateChecked(Min);
                double max = double.CreateChecked(Max);

                if (minLarger && min >= max) return max;
                if (min > max) min = max;

                double normalized = (double)state / ((double)int.MaxValue + 1);

                return min + normalized * (max - min);
            }

            /// <summary>
            /// Returns a pseudo random (and optional negative) Value that is greater than or equal to the specified minimum value and less than the specified maximum value.
            /// </summary>
            /// <remarks>
            /// Used AI to fix u-/long-range issues with decimal.<br/>
            /// </remarks>
            /// <param name="max">The Maximum Value (Can be Negative)</param>
            /// <param name="min">The Minimum Value (Can be Negative)</param>
            /// <param name="minLarger">If Min is Larger than Max, it will Return Max</param>
            /// <returns>A random T between min and max.</returns>
            public T Next<T>(T Max, T Min = default!, bool minLarger = default!) where T : INumber<T>
            {
                if (typeof(T) == typeof(double) || typeof(T) == typeof(float)) return T.CreateChecked(NextDouble(double.CreateChecked(Max), double.CreateChecked(Min), minLarger));
                NextState();

                decimal min = decimal.CreateChecked(Min);
                decimal max = decimal.CreateChecked(Max);

                if (minLarger && min >= max) return T.CreateChecked(max);
                if (min > max) min = max;

                decimal range = max - min;

                decimal normalized = (decimal)state / ((decimal)int.MaxValue + 1);

                decimal result = min + (normalized * range);

                return T.CreateChecked(result);
            }

            /// <summary>
            /// Returns a pseudo random (and optional negative) Value that is greater than or equal to the specified minimum value and less than the specified maximum value.
            /// </summary>
            /// <remarks>
            /// Used AI to fix u-/long-range issues
            /// </remarks>
            /// <param name="minMax">The Range Value (Can be Negative)</param>
            /// <param name="minLarger">If Min is Larger than Max, it will Return Max</param>
            /// <returns>A random <T> between min and max.</returns>
            public T Next<T>(MinMax<T> minMax, bool minLarger = default!) where T : INumber<T>
            { return T.CreateChecked(Next<T>(minMax.Max, minMax.Min, minLarger)); }

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
                T nextX = Next<T>(range.Max, range.Min);
                T nextY = Next<T>(range.Max, range.Min);
                T nextZ = Next<T>(range.Max, range.Min);

                return new Vector3<T>(nextX, nextY, nextZ);
            }

            /// <summary>
            /// Generates a ID
            /// </summary>
            /// <param name="length"></param>
            /// <param name="sectorSize">The Amount of Sectors between seperators, One Sector is 4 Hex</param>
            /// <param name="sectorSeperator"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public string NextID(uint length = 4, uint sectorSize = 1, char sectorSeperator = '-')
            {
                if (sectorSize <= 0) throw new ArgumentOutOfRangeException("SectorSize Value cannot be below 1");
                if (length <= 0) throw new ArgumentOutOfRangeException("Sector-Length Value cannot be below 1");

                string[] id = new string[length];
                for (int i = 0; i < length; i++)
                {
                    id[i] = "";
                    for (int j = 0; j < sectorSize; j++)
                    {
                        id[i] += Next<uint>(0xFFFFU).ToString("X4");
                    }
                }
                return string.Join(sectorSeperator, id);
            }

            /// <summary>
            /// Returns A Item of a List Based of his Probability.
            /// </summary>
            /// <param name="randomList"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public T GetItem<T>(T[] randomList) where T : SeedRandomList
            {
                float max = randomList.Sum(e => e.Probability);
                float randomValue = Next<float>(max);

                float currentSum = 0.0f;

                foreach (var item in randomList)
                {
                    currentSum += item.Probability;

                    if (randomValue <= currentSum)
                    {
                        return item;
                    }
                }

                return randomList[randomList.Length - 1];
            }
        }

        /// <summary>
        /// The Probability Interface needed for the SeedRandom.GetItem() Function to Work.<br/>
        /// The Value-Size in Probability is Irrelevant.
        /// </summary>
        public interface SeedRandomList
        {
            float Probability { get; }
        }
    }
}
