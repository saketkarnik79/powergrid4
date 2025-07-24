using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DemoArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] singleArray=new int[] { 1, 2, 3 };

            Console.WriteLine(singleArray[2]);//Outputs 3
            Console.WriteLine(singleArray.Length);//Outputs 3
            Console.WriteLine(singleArray.GetType());//Outputs System.Int32[]
            Console.WriteLine(singleArray.GetType().Name);//Outputs Int32[]
            Console.WriteLine(singleArray.GetType().FullName);//Outputs System.Int32[]
            Console.WriteLine(singleArray.GetType().BaseType);//Outputs System.Array
            singleArray[1] = 5; //Change the value at index 1
            foreach (var item in singleArray)
            {
                Console.WriteLine(item); //Outputs 1, 5, 3
            }
            Array.Sort(singleArray); //Sort the array
            Console.WriteLine();
            Console.WriteLine("Sorted Array:");
            foreach (var item in singleArray)
            {
                Console.WriteLine(item); //Outputs 1, 3, 5
            }
            Console.WriteLine();
            Array.Reverse(singleArray); //Reverse the array
            Console.WriteLine("Reversed Array:");
            foreach (var item in singleArray)
            {
                Console.WriteLine(item); //Outputs 5, 3, 1
            }

            Array.Resize(ref singleArray, 5); //Resize the array to hold 5 elements
            singleArray[3] = 7; //Add a new element at index 3
            Console.WriteLine(singleArray.Length);

            Console.WriteLine("Resized Array:");
            foreach (var item in singleArray)
            {
                Console.WriteLine(item); //Outputs 5, 3, 1, 7, 0
            }

            //Multidimesional array
            int[,] multiArray = new int[2, 3] 
            { 
                { 1, 2, 3 }, 
                { 4, 5, 6 } 
            };
            Console.WriteLine(multiArray.GetLength(1));
            Console.WriteLine(multiArray.GetLength(0));

            Console.WriteLine();
            Console.WriteLine("Jagged Array:");
            //Jagged array
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };
            foreach (var item in jaggedArray)
            {
                foreach (var subItem in item)
                {
                    Console.Write(subItem + " "); //Outputs 1 2 3 4 5 6 7 8 9
                }
                Console.WriteLine();
            }

            int[][,] jaggedMultiArray = new int[2][,];
            int[,][] jaggedMultiArray2 = new int[2,3][];
            int[,][,] jaggedMultiArray3 = new int[2, 3][,];
            jaggedMultiArray3[0, 0] = new int[,] { { 1, 2 }, { 3, 4 } };
            Console.ReadKey();

        }
    }
}
