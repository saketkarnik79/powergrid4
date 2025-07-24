namespace CS_DemoOperatorOverloading
{
    public class Vector
    {
        public int X { get; }
        public int Y { get; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Overload the + operator to add two vectors
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }

        public override string ToString()
        {
            return $"Vector ({X}, {Y})";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2);
            Vector v2 = new Vector(3, 4);
            Vector v3 = v1 + v2;
            Console.WriteLine(v3);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
