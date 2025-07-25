using System.Globalization;
using System.IO;

namespace CS_DemoFileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoFileAndDirectoryClasses();

            //DemoBinaryFileHandling();

            string filePath = "example.txt";
            // Create and write to a file
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Hello, World!");
                    writer.WriteLine(12345);
                    writer.WriteLine(3.14d);
                }
                Console.WriteLine("File created successfully...");
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine($"Reading file: {filePath}");
                using (StreamReader reader = new StreamReader(fs))
                {
                    string message = reader.ReadLine();
                    int number = int.Parse(reader.ReadLine());
                    double pi = double.Parse(reader.ReadLine(), CultureInfo.InvariantCulture);
                    Console.WriteLine($"Message: {message}");
                    Console.WriteLine($"Number: {number}");
                    Console.WriteLine($"Pi: {pi.ToString(CultureInfo.InvariantCulture)}");
                }
                //File.Delete(filePath);
                //Console.WriteLine($"Deleted File: {filePath}...");
            }

            Console.WriteLine();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void DemoBinaryFileHandling()
        {
            string filePath = "binary_file.dat";
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write("Hello, World!");
                    writer.Write(12345);
                    writer.Write(3.14d);
                }
                Console.WriteLine("File created successfully...");
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine($"Reading file: {filePath}");
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    string message = reader.ReadString();
                    int number = reader.ReadInt32();
                    double pi = reader.ReadDouble();
                    Console.WriteLine($"Message: {message}");
                    Console.WriteLine($"Number: {number}");
                    Console.WriteLine($"Pi: {pi.ToString(CultureInfo.InvariantCulture)}");
                }
                File.Delete(filePath);
                Console.WriteLine($"Deleted File: {filePath}...");
            }
        }

        private static void DemoFileAndDirectoryClasses()
        {
            string basePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "DemoFolder");
            string filePath = Path.Combine(basePath, "demo.txt");
            string copyPath = Path.Combine(basePath, "demo_copy.txt");

            //Create the directory if it doesn't exist
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
                Console.WriteLine($"Directory created at {basePath}");
            }
            else
            {
                Console.WriteLine($"Directory already exists at {basePath}");
            }

            //Create a file and write some text to it
            File.WriteAllText(filePath, "Hello, this is a demo file!");
            Console.WriteLine($"File created at {filePath}");

            //Read the content of the file
            string content = File.ReadAllText(filePath);
            Console.WriteLine($"Content of the file: {content}");

            //Append some text to the file
            File.AppendAllText(filePath, "\nThis is an appended line.");
            Console.WriteLine("Appended a line to the file.");

            //Copy the file to a new location
            File.Copy(filePath, copyPath, true);
            Console.WriteLine($"File copied to {copyPath}");

            //Move the original file to a new location
            string movedPath = Path.Combine(basePath, "demo_moved.txt");
            File.Move(filePath, movedPath, true);
            Console.WriteLine($"File moved to {movedPath}");

            //List the files in the directory
            Console.WriteLine("Files in the directory:");
            string[] files = Directory.GetFiles(basePath);

            foreach (string file in files)
            {
                Console.WriteLine($" - {Path.GetFileName(file)}");
            }

            //Delete all file
            Console.WriteLine("Deleting all files in the directory...");
            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"Deleted {Path.GetFileName(file)}");
            }

            //Delete the directory
            Console.WriteLine("Deleting the directory...");
            Directory.Delete(basePath, true);
        }
    }
}
