using CS_DemoOOP.Demographics;
using CS_DemoOOP.Arithmetic;
using CS_DemoOOP.Banking;
using CS_DemoOOP.Insurance;
using CS_DemoOOP.Arithmetic.Extensions;

namespace CS_DemoOOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("John", "Doe", 30);
            //using (Person person = new Person("John", "Doe", 30))
            //{
            //    // Using the person object
            //    Console.WriteLine(person);
            //} // Dispose will be called automatically here
            //Console.WriteLine(person);
            //person = null;
            //This will trigger the destructor when the garbage collector runs
            //GC.Collect();
            //person.Dispose();
            //CalcV1 calc=new CalcV1();
            ////CalcV2 calc=new CalcV2();
            //Console.WriteLine($"Add: {calc.Add(5, 3)}");
            //Console.WriteLine($"Add: {calc.Add(5.987d, 3.4532d)}");
            //Console.WriteLine($"Subtract: {calc.Subtract(5, 3)}");
            //Console.WriteLine($"Multiply: {calc.Multiply(5, 3)}");
            //Console.WriteLine($"Factorial: {calc.Factorial(6)}");
            //try
            //{
            //    Console.WriteLine($"Divide: {calc.Divide(5, 3)}");
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Cleaning up...");
            //}
            //try
            //{
            //    Console.WriteLine($"Modulus: {calc.Modulus(5, 3)}");
            //}
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    Console.WriteLine("Cleaning up...");
            //}
            //Console.WriteLine($"Power: {calc.Power(2, 3)}");
            //Console.WriteLine($"Add (Strings): {calc.Add("Hello", "World")}");
            //Employee emp = new Employee("James", "Bond", 55, "007", "MI6", 100000);
            //Person emp = new Employee("James", "Bond", 55, "007", "MI6", 100000);
            //Console.WriteLine(emp.Display());
            SavingsAccount account = new SavingsAccount();
            account.LowBalance += (balance) =>
            {
                Console.WriteLine($"Warning: Low balance detected - {balance}");
            };
            try
            {
                account.AccountNumber = "1234567890";
                Console.WriteLine($"Balance: {account.Balance}");
                account.Deposit(10000);
                (account as IInsurance)?.CalculatePremium(); // This will deduct the premium from the balance
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"Premium: {(account as IInsurance)?.Premium}");
                account.Withdraw(5500);
                Console.WriteLine($"Balance: {account.Balance}");
                account.Withdraw(4001);
                Console.WriteLine($"Balance: {account.Balance}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                account = null; // This will not call Dispose, but it will allow the object to be garbage collected
                GC.Collect();
                Console.WriteLine("Transaction completed.");
            }
            Console.ReadKey();
        }
    }
}
