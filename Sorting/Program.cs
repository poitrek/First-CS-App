using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Model model = new Model();
            View view = new View();

            Controller controller = new Controller(model, view);

            controller.RunController();
        }
    }

    class Controller
    {
        bool error = false;
        private Model model;
        private View view;

        public Controller(Model model, View view)
        {
            this.model = model;
            this.view = view;
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
                view.Print(elements);
                this.model.SetElementList(elements);
                Console.WriteLine("Numbers correctly set.");
            }

        }

        // Performs input of parameters of random generation
        public void InputRandom()
        {
            Console.WriteLine("Set random-generation parameters");
            int numberOfElements = 0;
            int maximum = 0, minimum = 0;
            try
            {
                Console.Write("Number of random elements: ");
                numberOfElements = Convert.ToInt32(Console.ReadLine());
                Console.Write("Minimum value: ");
                minimum = Convert.ToInt32(Console.ReadLine());
                Console.Write("Maximum value: ");
                maximum = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("The string cannot be converted to int! Probably its not a number.");
                error = true;
            }

            if (!error)
            {
                model.numberGenerator.setParameters(numberOfElements, minimum, maximum);

                List<int> elements = model.numberGenerator.GenerateRandom();

                Console.WriteLine("List of generated numbers:");

                view.Print<int>(elements);

                model.SetElementList(elements);
            }

        }

        public void RunController()
        {
            //InputFromConsole();

            InputRandom();

            if (!error)
            {
                Console.WriteLine();

                model.SortElements();

                view.ShowResult(model.GetElementList());

                view.ShowReport(model.stopwatch, model.UsedMethodName());
            }

            Console.WriteLine("Program ended. Press any key to exit");

            Console.ReadKey();
        }


    }
}
