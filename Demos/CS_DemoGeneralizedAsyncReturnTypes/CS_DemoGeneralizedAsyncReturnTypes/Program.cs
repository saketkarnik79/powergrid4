using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CS_DemoGeneralizedAsyncReturnTypes
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting custom async operation...\n");
            await new CustomAwaitable(1000);
            Console.WriteLine("Custom async operation completed.\n");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    class CustomAwaiter: INotifyCompletion
    {
        private readonly int _delay;
        private Action _continuation;
        
        public CustomAwaiter(int delay)
        {
            _delay = delay;
        }

        public bool IsCompleted { get; private set; } = false;

        public void OnCompleted(Action continuation)
        {
            _continuation = continuation;
            Task.Run(async() =>
            {
                await Task.Delay(_delay);
                _continuation?.Invoke();
            });
        }

        public void GetResult()
        {
            Console.WriteLine($"Waited {_delay}ms asynchronously using custom awaiter.");
        }
    }

    class CustomAwaitable
    {
        private readonly int _delay;

        public CustomAwaitable(int delay)
        {
            _delay = delay;
        }

        public CustomAwaiter GetAwaiter() => new CustomAwaiter(_delay);
    }
}
