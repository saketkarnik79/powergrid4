namespace CS_DemoLiteralImprovements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Digit literals
            int million= 1_000_000;
            long creditCardNumber = 1234_5678_9012_3456L;
            Console.WriteLine($"Million: {million}");
            Console.WriteLine($"Credit Card Number: {creditCardNumber}");

            //Binary literals Hexadecimal Literals
            int binaryValue = 0b1010_1011_1100_1101; // Binary literal
            int hexValue = 0xAB12CD; // Hexadecimal literals
            
            Console.WriteLine($"Binary Value: {binaryValue}");
            Console.WriteLine($"Hexadecimal Value: {hexValue}");

            //Raw string literals
            string json = """
            {
                "name": "John",
                "age": 30,
                "city": "New York"
            }
            """;
            Console.WriteLine("Raw String Literal (JSON):");
            Console.WriteLine(json);

            //UTF-8 encoded string literal
            ReadOnlySpan<byte> utf8Bytes = "Hello, UTF-8! 👋"u8;
            Console.WriteLine("UTF-8 Bytes: ");
            foreach (var b in utf8Bytes)
            {
                Console.Write($"{b} ");
            }
            Console.WriteLine();

            //Native-sized integers
            nint nativeInt = 1234567890; // Native-sized integer
            Console.WriteLine($"Native-sized Integer: {nativeInt}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
