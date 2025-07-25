using System.Collections;

namespace CS_DemoCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoArrayList();

            //DemoStack();

            //DemoQueue();

            //DemoHashTable();

            //DemoGenericList();

            //DemoenericStack();

            //DemoGenericQueue();

            //DemoGenericDictionary();

            //DemoGenericSortedDictionary();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DemoGenericSortedDictionary()
        {
            SortedDictionary<string, int> dictionary = new SortedDictionary<string, int>();
            dictionary.Add("One", 1);
            dictionary.Add("Two", 2);
            dictionary.Add("Three", 3);
            Console.WriteLine($"Dictionary Count: {dictionary.Count}");
            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {dictionary[key]}");
            }
        }

        private static void DemoGenericDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("One", 1);
            dictionary.Add("Two", 2);
            dictionary.Add("Three", 3);
            Console.WriteLine($"Dictionary Count: {dictionary.Count}");
            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {dictionary[key]}");
            }
        }

        private static void DemoGenericQueue()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            Console.WriteLine($"Queue Count: {queue.Count}");
            while (queue.Count > 0)
            {
                Console.WriteLine($"Dequeued: {queue.Dequeue()}");
                Console.WriteLine($"Queue Count: {queue.Count}");
            }
        }

        private static void DemoenericStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine($"Stack Count: {stack.Count}");
            while (stack.Count > 0)
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
                Console.WriteLine($"Stack Count: {stack.Count}");
            }
        }

        private static void DemoGenericList()
        {
            List<int> list = new List<int>();
            List<string> stringList = new List<string>();
            List<double> doubleList = new List<double>();
            List<int> listWithCapacity = new List<int>(3);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine($"List Count: {list.Count}");
            int sum = 0;
            foreach (int item in list)
            {
                Console.WriteLine($"Item: {item}");
                sum += item;
            }
        }

        private static void DemoHashTable()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add("One", 1);
            hashtable.Add("Two", 2);
            hashtable.Add("Three", 3);

            Console.WriteLine($"Hashtable Count: {hashtable.Count}");
            foreach (object key in hashtable.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {hashtable[key]}");
            }
        }

        private static void DemoQueue()
        {
            Queue queue = new Queue();
            Console.WriteLine($"Queue Count: {queue.Count}");
            queue.Enqueue(1);
            Console.WriteLine($"Queue Count: {queue.Count}");
            queue.Enqueue(2);
            Console.WriteLine($"Queue Count: {queue.Count}");
            while (queue.Count > 0)
            {
                Console.WriteLine($"Dequeued: {queue.Dequeue()}");
                Console.WriteLine($"Queue Count: {queue.Count}");
            }
        }

        private static void DemoStack()
        {
            Stack stack = new Stack();
            Console.WriteLine($"Stack Count: {stack.Count}");
            stack.Push(1);
            Console.WriteLine($"Stack Count: {stack.Count}");
            stack.Push(2);
            Console.WriteLine($"Stack Count: {stack.Count}");
            stack.Push(3.234d);
            Console.WriteLine($"Stack Count: {stack.Count}");
            stack.Push("Four");
            Console.WriteLine($"Stack Count: {stack.Count}");
            while (stack.Count > 0)
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
                Console.WriteLine($"Stack Count: {stack.Count}");
            }
        }

        private static void DemoArrayList()
        {
            ArrayList arrayList = new ArrayList(3);
            Console.WriteLine($"Capacity: {arrayList.Capacity}, Count: {arrayList.Count}");
            arrayList.Add(1);
            Console.WriteLine($"Capacity: {arrayList.Capacity}, Count: {arrayList.Count}");
            arrayList.Add(2);
            Console.WriteLine($"Capacity: {arrayList.Capacity}, Count: {arrayList.Count}");
            arrayList.Add(3.234d);
            Console.WriteLine($"Capacity: {arrayList.Capacity}, Count: {arrayList.Count}");
            arrayList.Add("Four");
            Console.WriteLine($"Capacity: {arrayList.Capacity}, Count: {arrayList.Count}");

            int sum = 0;
            foreach (object item in arrayList)
            {
                Console.WriteLine(item);
                if (item is int number)
                {
                    sum += number;
                }
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
