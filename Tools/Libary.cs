using System.Numerics;
using static Star_Simulation.Program;
using static Star_Simulation.Random;
using static Star_Simulation.SystemGeneration;

namespace Star_Simulation
{
    internal partial class Libary
    {
#pragma warning disable CS0660 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.Equals(Objekt o)
#pragma warning disable CS0661 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.GetHashCode()
        public class Vector2<T> where T : INumber<T>
        {
            public T X, Y;

            public Vector2(T x = default!, T y = default!)
            { X = x; Y = y; }

            public static Vector2<T> operator +(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X + b.X, a.Y + b.Y);
            public static Vector2<T> operator -(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X - b.X, a.Y - b.Y);
            public static Vector2<T> operator *(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X * b.X, a.Y * b.Y);
            public static Vector2<T> operator /(Vector2<T> a, Vector2<T> b) =>
                new Vector2<T>(a.X / b.X, a.Y / b.Y);

            public void operator +=(T a)
            {
                X += T.CreateChecked(a);
                Y += T.CreateChecked(a);
            }
            public void operator -=(T a)
            {
                X -= T.CreateChecked(a);
                Y -= T.CreateChecked(a);
            }
            public void operator *=(T a)
            {
                X *= T.CreateChecked(a);
                Y *= T.CreateChecked(a);
            }
            public void operator /=(T a)
            {
                X /= T.CreateChecked(a);
                Y /= T.CreateChecked(a);
            }

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
#pragma warning restore CS0660 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.Equals(Objekt o)
#pragma warning restore CS0661 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.GetHashCode()

#pragma warning disable CS0660 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.Equals(Objekt o)
#pragma warning disable CS0661 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.GetHashCode()
        public class Vector3<T> where T : INumber<T>
        {
            public T X, Y, Z;

            public Vector3(T x = default!, T y = default!, T z = default!)
            { X = x; Y = y; Z = z; }

            public static Vector3<T> operator +(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
            public static Vector3<T> operator -(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            public static Vector3<T> operator *(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
            public static Vector3<T> operator /(Vector3<T> a, Vector3<T> b) =>
                new Vector3<T>(a.X / b.X, a.Y / b.Y, a.Z / b.Z);

            public void operator +=(T a)
            {
                X += T.CreateChecked(a);
                Y += T.CreateChecked(a);
                Z += T.CreateChecked(a);
            }
            public void operator -=(T a)
            {
                X -= T.CreateChecked(a);
                Y -= T.CreateChecked(a);
                Z -= T.CreateChecked(a);
            }
            public void operator *=(T a)
            {
                X *= T.CreateChecked(a);
                Y *= T.CreateChecked(a);
                Z *= T.CreateChecked(a);
            }
            public void operator /=(T a)
            {
                X /= T.CreateChecked(a);
                Y /= T.CreateChecked(a);
                Z /= T.CreateChecked(a);
            }

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
#pragma warning restore CS0660 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.Equals(Objekt o)
#pragma warning restore CS0661 // Typ definiert Operator == oder Operator !=, überschreibt jedoch nicht Object.GetHashCode()

        public static T Distance2D<T>(Libary.Vector2<T> a, Libary.Vector2<T> b) where T : INumber<T>
        { return T.CreateChecked(Math.Sqrt(Math.Pow(double.CreateChecked(b.X - a.X), 2) + Math.Pow(double.CreateChecked(b.Y - a.Y), 2))); }
        public static T Distance3D<T>(Libary.Vector3<T> a, Libary.Vector3<T> b) where T : INumber<T>
        { return T.CreateChecked(Math.Sqrt(Math.Pow(double.CreateChecked(b.X - a.X), 2) + Math.Pow(double.CreateChecked(b.Y - a.Y), 2) + Math.Pow(double.CreateChecked(b.Z - a.Z), 2))); }

        /// <summary>
        /// Range Class that is very Helpful for storing (Like the Name sais) Min-Max Values
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        public class MinMax<T> where T : INumber<T>
        {
            public T Min;
            public T Max;
            public bool MaxZero;

            public MinMax(T min = default!, T max = default!, bool maxZero = false)
            {
                if (max < min && double.CreateChecked(max) != 0 && maxZero)
                    throw new ArgumentOutOfRangeException($"If max is smaller than min and maxZero is enabled, max has to be Zero and not {max}.");
                if (max < min && !maxZero)
                    throw new ArgumentOutOfRangeException($"If you want to have max smaller than min, you have to activate maxZero (And max has to be 0)");

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

            public static MinMax<T> operator -(MinMax<T> a, MinMax<T> b) =>
                new(a.Min - b.Min, a.Max - b.Max);

            public static MinMax<T> operator *(MinMax<T> a, MinMax<T> b) =>
                new(a.Min * b.Min, a.Max * b.Max);

            public static MinMax<T> operator /(MinMax<T> a, MinMax<T> b) =>
                new(a.Min / b.Min, a.Max / b.Max);

            public void operator +=(T a)
            { Min += T.CreateChecked(a); Max += T.CreateChecked(a); }
            public void operator -=(T a)
            { Min -= T.CreateChecked(a); Max -= T.CreateChecked(a); }
            public void operator *=(T a)
            { Min *= T.CreateChecked(a); Max *= T.CreateChecked(a); }
            public void operator /=(T a)
            { Min /= T.CreateChecked(a); Max /= T.CreateChecked(a); }

            public static bool operator >(MinMax<T> a, MinMax<T> b) =>
                a.Min > b.Min && a.Max > b.Max;

            public static bool operator <(MinMax<T> a, MinMax<T> b) =>
                a.Min < b.Min && a.Max < b.Max;

            public static bool operator >=(MinMax<T> a, MinMax<T> b) =>
                a.Min >= b.Min && a.Max >= b.Max;

            public static bool operator <=(MinMax<T> a, MinMax<T> b) =>
                a.Min <= b.Min && a.Max <= b.Max;
        }

        public class InterstellarSector
        {
            public string Name;
            public Vector2<int> Position;
            public SeedRandom Seed;

            public InterstellarSector(Vector2<int> position)
            {
                this.Seed = new SeedRandom($"InterstellarSector-{position.X}-{position.Y}");

                this.Name = GenerateNameMarkov(this.Seed, StarNames);
            }
        }
    }
}