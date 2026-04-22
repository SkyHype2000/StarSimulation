using System.Numerics;
using static Star_Simulation.Program;
using static Star_Simulation.Random;
using static Star_Simulation.SystemGeneration;

namespace Star_Simulation
{
    internal class Libary
    {
        public class Vector2<T> where T : INumber<T>
        {
            public T X, Y;

            public Vector2(T x = default!, T y = default!)
            { X = x; Y = y; }

            public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X + b.X, a.Y + b.Y);
            public static Vector2<T> operator +(Vector2<T> a, T b) =>
                new Vector2<T>(a.X + b, a.Y + b);
            public static Vector2<T> operator -(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X - b.X, a.Y - b.Y);
            public static Vector2<T> operator -(Vector2<T> a, T b) =>
                new Vector2<T>(a.X - b, a.Y - b);
            public static Vector2<T> operator *(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X * b.X, a.Y * b.Y);
            public static Vector2<T> operator *(Vector2<T> a, T b) =>
                new Vector2<T>(a.X * b, a.Y * b);
            public static Vector2<T> operator /(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X / b.X, a.Y / b.Y);
            public static Vector2<T> operator /(Vector2<T> a, T b) =>
                new Vector2<T>(a.X / b, a.Y / b);
            public static bool operator >(Vector2<T> a, Vector2<T> b)
            {
                if (a.X > b.X && a.Y > b.Y) return true;
                else return false;
            }
            public static bool operator <(Vector2<T> a, Vector2<T> b)
            {
                if (a.X < b.X && a.Y < b.Y) return true;
                else return false;
            }
            public static bool operator >=(Vector2<T> a, Vector2<T> b)
            {
                if (a.X >= b.X && a.Y >= b.Y) return true;
                else return false;
            }
            public static bool operator <=(Vector2<T> a, Vector2<T> b)
            {
                if (a.X <= b.X && a.Y <= b.Y) return true;
                else return false;
            }
            public static bool operator ==(Vector2<T> a, Vector2<T> b)
            {
                if (a.X == b.X && a.Y == b.Y) return true;
                else return false;
            }
            public static bool operator !=(Vector2<T> a, Vector2<T> b)
            {
                if (a.X != b.X || a.Y != b.Y) return true;
                else return false;
            }

            public override string ToString() =>
                $"Vector2({X}, {Y})";
        }

        public class Vector3<T> where T : INumber<T>
        {
            public T X, Y, Z;

            public Vector3(T x = default!, T y = default!, T z = default!)
            { X = x; Y = y; Z = z; }

            public static Vector3<T> operator +(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            public static Vector3<T> operator +(Vector3<T> a, T b) =>
                new Vector3<T>(a.X + b, a.Y + b, a.Z + b);
            public static Vector3<T> operator -(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            public static Vector3<T> operator -(Vector3<T> a, T b) =>
                new Vector3<T>(a.X - b, a.Y - b, a.Z - b);
            public static Vector3<T> operator *(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
            public static Vector3<T> operator *(Vector3<T> a, T b) =>
                new Vector3<T>(a.X * b, a.Y * b, a.Z * b);
            public static Vector3<T> operator /(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
            public static Vector3<T> operator /(Vector3<T> a, T b) =>
                new Vector3<T>(a.X / b, a.Y / b, a.Z / b);
            public static bool operator >(Vector3<T> a, Vector3<T> b)
            {
                if (a.X > b.X && a.Y > b.Y && a.Z > b.Z) return true;
                else return false;
            }
            public static bool operator <(Vector3<T> a, Vector3<T> b)
            {
                if (a.X < b.X && a.Y < b.Y && a.Z < b.Z) return true;
                else return false;
            }
            public static bool operator >=(Vector3<T> a, Vector3<T> b)
            {
                if (a.X >= b.X && a.Y >= b.Y && a.Z >= b.Z) return true;
                else return false;
            }
            public static bool operator <=(Vector3<T> a, Vector3<T> b)
            {
                if (a.X <= b.X && a.Y <= b.Y && a.Z <= b.Z) return true;
                else return false;
            }
            public static bool operator ==(Vector3<T> a, Vector3<T> b)
            {
                if (a.X == b.X && a.Y == b.Y && a.Z == b.Z) return true;
                else return false;
            }
            public static bool operator !=(Vector3<T> a, Vector3<T> b)
            {
                if (a.X != b.X || a.Y != b.Y || a.Z != b.Z) return true;
                else return false;
            }

            public override string ToString() =>
                $"Vector3({X}, {Y}, {Z})";
        }

        public static T Distance2D<T>(Libary.Vector2<T> a, Libary.Vector2<T> b) where T : INumber<T>
        { return T.CreateChecked(Math.Sqrt(Math.Pow(double.CreateChecked(b.X - a.X), 2) + Math.Pow(double.CreateChecked(b.Y - a.Y), 2))); }
        public static T Distance3D<T>(Libary.Vector3<T> a, Libary.Vector3<T> b) where T : INumber<T>
        { return T.CreateChecked(Math.Sqrt(Math.Pow(double.CreateChecked(b.X - a.X), 2) + Math.Pow(double.CreateChecked(b.Y - a.Y), 2) + Math.Pow(double.CreateChecked(b.Z - a.Z), 2))); }

        public class MinMax<T> where T : INumber<T>
        {
            public T Min;
            public T Max;
            public bool MaxZero;

            public MinMax(T min = default!, T max = default!, bool maxZero = false)
            {
                Min = min;
                Max = max;
                MaxZero = maxZero;
            }

            public override string ToString() =>
                $"MinMax({Min}, {Max}, {MaxZero.ToString().ToLower()})";

            public MinMax<double> Floor() =>
                new(Math.Floor(Convert.ToDouble(Min)), Math.Floor(Convert.ToDouble(Max)), MaxZero);

            public MinMax<double> Round() =>
                new(Math.Round(Convert.ToDouble(Min)), Math.Round(Convert.ToDouble(Max)), MaxZero);

            public static MinMax<T> operator +(MinMax<T> a, MinMax<T> b) =>
                new(a.Min + b.Min, a.Max + b.Max);
            public static MinMax<T> operator +(MinMax<T> a, T b) =>
                new(a.Min + b, a.Max + b);

            public static MinMax<T> operator -(MinMax<T> a, MinMax<T> b) =>
                new(a.Min - b.Min, a.Max - b.Max);
            public static MinMax<T> operator -(MinMax<T> a, T b) =>
                new(a.Min - b, a.Max - b);

            public static MinMax<T> operator *(MinMax<T> a, MinMax<T> b) =>
                new(a.Min * b.Min, a.Max * b.Max);
            public static MinMax<T> operator *(MinMax<T> a, T b) =>
                new(a.Min * b, a.Max * b);

            public static MinMax<T> operator /(MinMax<T> a, MinMax<T> b) =>
                new(a.Min / b.Min, a.Max / b.Max);
            public static MinMax<T> operator /(MinMax<T> a, T b) =>
                new(a.Min / b, a.Max / b);

            public static bool operator >(MinMax<T> a, MinMax<T> b) =>
                a.Min > b.Min && a.Max > b.Max;

            public static bool operator <(MinMax<T> a, MinMax<T> b) =>
                a.Min < b.Min && a.Max < b.Max;

            public static bool operator >=(MinMax<T> a, MinMax<T> b) =>
                a.Min >= b.Min && a.Max >= b.Max;

            public static bool operator <=(MinMax<T> a, MinMax<T> b) =>
                a.Min <= b.Min && a.Max <= b.Max;

            public static MinMax<T> defaultValue = new MinMax<T>(T.CreateChecked(0), T.CreateChecked(0), false);
        }

        public class InterstellarSector
        {
            public string Name;
            public Vector2<int> Position;
            public SeedRandom Seed;

            public InterstellarSector(Vector2<int> position)
            {
                this.Seed = new SeedRandom($"InterstellarSector-{position.X}-{position.Y}");

                this.Name = GenerateName2(this.Seed, starNames);
            }
        }
    }
}