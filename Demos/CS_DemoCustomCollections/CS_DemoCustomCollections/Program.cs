using CS_DemoCustomCollections.Collections;

namespace CS_DemoCustomCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list=new MyList<int>();
            //list.Add("Hello");
            //list.Add("World");
            list.Add(42);

            list.Add(100);
            //list.Add(3.14);
            //list.Add(true);
            //list.Add(new DateTime(2023, 10, 1));
            Console.WriteLine($"Count: {list.Count}, Capacity: {list.Capacity}");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine($"Item {i}: {list[i]}");
            //}
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
