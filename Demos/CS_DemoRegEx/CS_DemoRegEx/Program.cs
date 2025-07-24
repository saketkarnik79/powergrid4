using System.Text.RegularExpressions;

namespace CS_DemoRegEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
           //Basic Pattern Matching
            string input="The quick brown fox jumps over the lazy dog.";
            string pattern = @"\b\w{4}\b"; // Matches any word with exactly `4 characters
            MatchCollection matches = Regex.Matches(input, pattern);
            Console.WriteLine("Four letter words...");
            foreach (Match match in matches)
            {
                Console.WriteLine($"- {match.Value}");
            }

            Console.WriteLine();
            //Extracing data(e.g. phone numbers)
            string phones= "Call me at 123-456-7890 or 987-654-3210 or 1800-266-266.";
            string phonePattern = @"\b\d{3}-\d{3}-\d{4}\b"; // Matches phone numbers in the format xxx-xxx-xxxx
            MatchCollection phoneMatches = Regex.Matches(phones, phonePattern);
            Console.WriteLine("Phone numbers found:");
            foreach (Match match in phoneMatches)
            {
                Console.WriteLine($"- {match.Value}");
            }

            Console.WriteLine();
            //Replacing Text
            string messyText="This   text    has   too   many    spaces.";
            string cleanedText = Regex.Replace(messyText, @"\s+", " ");
            Console.WriteLine($"Cleaned text: {cleanedText}");
            
            Console.WriteLine();
            //Validating Email Addresses
            string email = "user@demo.com";
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+"; // Basic email validation pattern
            bool isValidEmail = Regex.IsMatch(email, emailPattern);
            Console.WriteLine($"Is the email '{email}' valid? {(isValidEmail ? "Yes" : "No")}");


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
