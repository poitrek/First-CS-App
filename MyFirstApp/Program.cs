using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();

            controller.PutDataIn();
            
        }
    }

    class Controller
    {
        bool error = false;

        public void PutDataIn()
        {
            Console.WriteLine("Enter your numbers in a line:");
            // Read a set of numbers given in a line, separated by one or more spaces
            string inputString = Console.ReadLine();

            // Create new list of integers
            List<int> elements = new List<int>();

            try
            {
                // Split given string by white spaces
                string[] expressions = Regex.Split(input: inputString, pattern: @"\s+");

                // Convert expressions to ints and add them to the list
                foreach (string exp in expressions)
                {
                    elements.Add(Convert.ToInt32(exp));
                }
                Console.WriteLine();
            }
            // Catch an exception of number format
            catch(Exception)
            {
                Console.WriteLine("The string cannot be converted to int! Probably its not a number.");
                error = true;
            }

            if (!error)
            {
                //foreach (int e in elements)
                //{
                //    Console.Write(e + " ");
                //}

                // Find and print the maximum value
                var maximum = elements.First();
                foreach(int elem in elements)
                {
                    if (elem > maximum)
                    {
                        maximum = elem;
                    }
                }
                Console.WriteLine("Your biggest number is " + maximum);
            }

            // Wait for a key input to exit program
            Console.ReadKey();

        }
    }


}
