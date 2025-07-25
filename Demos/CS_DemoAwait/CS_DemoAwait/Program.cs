namespace CS_DemoAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Process...\n");

            try
            {
                await PerformOperationAsync();
            }
            catch (Exception ex)
            {
                await LogErrorAsync(ex);
            }
            finally
            {
                await CleanupAsync();
            }
            Console.WriteLine("Process Completed.");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task PerformOperationAsync()
        {
            Console.WriteLine("Performing Operation...");
            // Simulate a delay to represent an asynchronous operation
            await Task.Delay(1000);
            //Simulate a potential error
            throw new InvalidOperationException("An error occurred during the operation.");
        }

        private static async Task LogErrorAsync(Exception ex)
        {
            Console.WriteLine($"Logging Error: {ex.Message}");
            await Task.Delay(1000);
            Console.WriteLine($"Error logged successfully: {ex.Message}...");
        }

        private static async Task CleanupAsync()
        {
            Console.WriteLine("Cleaning up resources...");
            await Task.Delay(1000);
            Console.WriteLine("Cleanup completed.");
        }
    }
}
