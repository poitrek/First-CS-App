using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sorting.Model;
using Sorting.View;


namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Sorter model = new Sorter();
            Printer printer = new Printer();

            Controller controller = new Controller(model, printer);

            controller.RunController();
        }
    }

    class Controller
    {
        bool error = false;
        private Sorter sorter;
        private Printer printer;

        public Controller(Sorter sorter, Printer printer)
        {
            this.sorter = sorter;
            this.printer = printer;
        }

        // Performs data input from console
        public void InputFromConsole()
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
            catch (Exception)
            {
                Console.WriteLine("The string cannot be converted to int! Probably its not a number.");
                error = true;
            }

            if (!error)
            {
                Console.WriteLine("Set sorting method by typing one of the letters\n");
                printer.ListSortMethods();
                try
                {
                    string key = Console.ReadLine();
                    sorter.SetSortMethod(key);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    error = true;
                }

                if (!error)
                {
                    printer.Print(elements);
                    this.sorter.SetElementList(elements);
                    Console.WriteLine("Numbers correctly set.");
                }
            }

        }

        // Performs input of parameters of random generation
        public void InputRandom()
        {
            try
            {
                //Console.WriteLine("Set random-generation parameters");
                Console.Write("Number of random elements: ");
                int numberOfElements = Convert.ToInt32(Console.ReadLine());
                //Console.Write("Minimum value: ");
                //int minimum = Convert.ToInt32(Console.ReadLine());
                //Console.Write("Maximum value: ");
                //int maximum = Convert.ToInt32(Console.ReadLine());

                //model.numberGenerator.setParameters(numberOfElements, minimum, maximum);
                List<int> elements = sorter.numberGenerator.Generate1ToN(numberOfElements);
                Console.WriteLine("List of generated numbers:");
                printer.Print<int>(elements);
                sorter.SetElementList(elements);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                error = true;
            }
        }

        public void ChooseSortingMethod()
        {
            Console.WriteLine("Set sorting method by typing the letter\n");
            printer.ListSortMethods();
            string key = Console.ReadLine();
            sorter.SetSortMethod(key);
        }

        public void RunController()
        {

            //InputFromConsole();

            //InputRandom();

            ChooseSortingMethod();

            List<int> elements = ReadFromFile("numbers1.txt");

            //Console.WriteLine("List of loaded numbers:");
            //printer.Print<int>(elements);
            sorter.SetElementList(elements);


            //List<int> elements = sorter.numberGenerator.Generate1ToN(100000);

            //SaveToFile(ref elements, "numbers2.txt");

            if (!error)
            {
                Console.WriteLine();

                sorter.SortElements();

                printer.ShowResult(sorter.GetElementList());

                printer.ShowReport(sorter.GetElementList(), sorter.stopwatch, sorter.UsedMethodName());
            }


            Console.WriteLine("Program ended. Press any key to exit");

            Console.ReadKey();

        }

        public void SaveToFile(ref List<int> elementList, String fileName)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(fileName))
            {
                foreach (int element in elementList)
                {
                    file.Write(element + " ");
                }
            }
            Console.WriteLine("Successfully saved numbers to file.");
        }

        public List<int> ReadFromFile(String fileName)
        {
            try
            {   // Open the text file using a stream reader.
                String line;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                }
                // Split read line by spaces
                String[] splittedLine = Regex.Split(line, @"\s+");

                // Add converted values to the list
                List<int> elementList = new List<int>();
                for(var index = 0; index < splittedLine.Length - 1; index++)
                {
                    elementList.Add(Convert.ToInt32(splittedLine[index]));
                }
                Console.WriteLine("Numbers loaded from the file.");
                return elementList;
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                error = true;
                return null;
            }
        }

    }
}
