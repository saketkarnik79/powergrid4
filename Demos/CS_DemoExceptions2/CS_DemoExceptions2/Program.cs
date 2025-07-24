namespace CS_DemoExceptions2
{
    internal class Program
    {
        static void SimulateError(string errorType) 
        {
            switch (errorType)
            {
                case "critical":
                    throw new Exception("A critical error occurred.");
                case "warning":
                    throw new Exception("A warning error occurred.");
                case "info":
                    throw new Exception("A info error occurred.");
                default:
                    throw new Exception("An unknown error occurred.");
            }
        }
        static void Main(string[] args)
        {
            try
            {
                SimulateError("warning");
            }
            catch (Exception ex) when (ex.Message.Contains("critical"))
            {
                Console.WriteLine($"Critical Error: {ex.Message}");
            }
            catch (Exception ex) when (ex.Message.Contains("warning"))
            {
                Console.WriteLine($"Warning Error: {ex.Message}");
            }
            catch (Exception ex) when (ex.Message.Contains("info"))
            {
                Console.WriteLine($"Info Error: {ex.Message}");
            }
            
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
