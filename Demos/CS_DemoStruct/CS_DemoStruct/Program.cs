using CS_DemoStruct.CustomTypes.ValueTypes.Demographics;    

namespace CS_DemoStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point();
            point.X = 10;
            point.Y = 20;
            
            point.Display();
            Console.WriteLine(point);

            Point point2 = new Point(5, 15);
            point2.Display();
            Console.WriteLine(point2);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
