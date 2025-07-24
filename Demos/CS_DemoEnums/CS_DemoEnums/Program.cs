using CS_DemoEnums.CustomTypes.ValueTypes;

namespace CS_DemoEnums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderStatus status = OrderStatus.Pending;
            Console.WriteLine($"CurrentOrder status: {status} (Value: {(int)status})");
            //Change status
            status = OrderStatus.Shipped;
            Console.WriteLine($"Updated Order status: {status} (Value: {(int)status})");
            
            HandleOrderStatus(status);

            string[] names= Enum.GetNames(typeof(OrderStatus));
            foreach (string name in names)
            {
                Console.WriteLine($"OrderStatus Name: {name}");
            }

            OrderStatus parsedStatus=(OrderStatus)Enum.Parse(
                typeof(OrderStatus), "Delivered");
            Console.WriteLine($"Parsed Status: {parsedStatus}");
            Console.ReadKey();
        }

        static void HandleOrderStatus(OrderStatus status)
        {
            switch (status)
            {
                case OrderStatus.Pending:
                    Console.WriteLine("Order is pending.");
                    break;
                case OrderStatus.Processing:
                    Console.WriteLine("Order is being processed.");
                    break;
                case OrderStatus.Shipped:
                    Console.WriteLine("Order has been shipped.");
                    break;
                case OrderStatus.Delivered:
                    Console.WriteLine("Order has been delivered.");
                    break;
                case OrderStatus.Cancelled:
                    Console.WriteLine("Order has been cancelled.");
                    break;
                default:
                    Console.WriteLine("Unknown order status.");
                    break;
            }
        }
    }
}
