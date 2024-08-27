using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using static OOP3_2.Vector2D;
using static OOP3_2;

public class OOP3_2
{
    public abstract class Vector
    {
        public abstract Vector sum(Vector vector);
        public abstract bool orth(Vector vector);
        public abstract void show_info();
    }
    public class Vector2D : Vector
    {
        public double x;
        public double y;
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public Vector2D(double x_, double y_)
        {
            x = x_;
            y = y_;
        }
        public Vector2D()
        {
            x = 0;
            y = 0;
        }
        public override void show_info()
        {
            Console.WriteLine($"({x}, {y})");
        }
        public override Vector sum(Vector vector)
        {
            if (vector is Vector2D v2D)
            {
                return new Vector2D(x + v2D.x, y + v2D.y);
            }
            throw new ArgumentException("Invalid vector type.");
        }
        public override bool orth(Vector vector)
        {
            if (vector is Vector2D v2d)
            {
                return (X * v2d.X + Y * v2d.Y) == 0;
            }
            throw new ArgumentException("Invalid vector type.");
        }
        public class Vector3D : Vector
        {
            public double x;
            public double y;
            public double z;
            public double X { get => x; set => x = value; }
            public double Y { get => y; set => y = value; }
            public double Z { get => z; set => z = value; }
            public Vector3D (double x_, double y_, double z_)
            {
                x = x_;
                y = y_;
                z = z_;
            }
            public Vector3D()
            {
                x = 0;
                y = 0;
                z = 0;
            }
            public override void show_info()
            {
                Console.WriteLine($"({x}, {y}, {z})");
            }
            public override Vector sum(Vector vector)
            {
                if (vector is Vector3D v3D)
                {
                    return new Vector3D(x + v3D.x, y + v3D.y, z + v3D.z);
                }
                throw new ArgumentException("Invalid vector type.");
               // throw new NotImplementedException();
            }
            public override bool orth(Vector vector)
            {
                if (vector is Vector3D v3D)
                {
                    return (x * v3D.x + y * v3D.y + z * v3D.z) == 0;
                }
                throw new ArgumentException("Invalid vector type.");
            }
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {

        // Câu b//
        Vector2D v2D1 = new Vector2D(1, 2);
        Vector2D v2D2 = new Vector2D(2, -1);
        Console.Write("Vector 1: ");
        v2D1.show_info();
        Console.Write("Vector 2: ");
        v2D2.show_info();

        OOP3_2.Vector sum2D = v2D1.sum(v2D2);
        Console.Write("Sum = ");
        sum2D.show_info();

        Console.WriteLine($"Orthogonal: {v2D1.orth(v2D2)}");

        Vector3D v3D1 = new Vector3D(1, 0, 0);
        Vector3D v3D2 = new Vector3D(0, 1, 0);
        Console.Write("Vector 1: ");
        v3D1.show_info();
        Console.Write("Vector 2: ");
        v3D2.show_info();
        Console.Write("Sum = ");
        OOP3_2.Vector sum3D = v3D1.sum(v3D2);
        sum3D.show_info();
        Console.WriteLine($"Orthogonal: {v3D1.orth(v3D2)}");


        // Câu c //

        Console.WriteLine();
        Random rand = new Random();
        OOP3_2.Vector[] vectors = new OOP3_2.Vector[10];
        for (int i = 0; i < vectors.Length; i++)
        {
            if (rand.Next(2) ==0)
            {
                vectors[i] = new Vector2D(Math.Floor(rand.NextDouble()) * 10, Math.Floor(rand.NextDouble() * 10));
            }
            else
            {
                vectors[i] = new Vector3D(Math.Floor(rand.NextDouble() * 10), Math.Floor(rand.NextDouble() * 10), Math.Floor(rand.NextDouble() * 10));
            }
        }
        Console.WriteLine("Cac Vector ngau nhien da tao:");
        foreach (var vector in vectors)
        {
            vector.show_info();
        }
        for (int i = 0; i < vectors.Length; i++)
        {
            for (int j = i + 1; j < vectors.Length; j++)
            {
                if (vectors[i].GetType() == vectors[j].GetType())
                {
                    Console.WriteLine("\nSo sanh 2 vector cung loai: ");
                    vectors[i].show_info();
                    vectors[j].show_info();

                    OOP3_2.Vector sum = vectors[i].sum(vectors[j]);
                    Console.Write("Sum = ");
                    sum.show_info();

                    Console.WriteLine($"Orthogonal = " + vectors[i].orth(vectors[j]));
                }
            }
        }
    }
}