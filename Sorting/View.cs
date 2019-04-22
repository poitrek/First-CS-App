using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting
{
    class View
    {
        // Prints an object
        public void Print(object o)
        {
            Console.WriteLine(o);
        }

        public void ListSortMethods()
        {
            String[] names = { "Insertion sort", "Selection sort", "Quicksort", "Merge sort" };
            String[] chars = { "[i]", "[s]", "[q]", "[m]" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(String.Format("{0, -20} {1, 0}", names[i], chars[i]));
            }
            Console.WriteLine();
        }

        // Prints a list of objects
        public void Print<T>(List<T> objectList)
        {
            string outputString = "";
            foreach (T t in objectList)
            {
                outputString += Convert.ToString(t) + "  ";
            }
            outputString = outputString.Remove(outputString.Length - 2, 2);
            outputString = "[" + outputString + "]";
            Console.WriteLine(outputString);
        }

        public void ShowResult(List<int> intList)
        {
            Console.WriteLine("The list of sorted numbers is:");
            this.Print(intList);
        }

        public void ShowReport(Stopwatch stopwatch, String strategyName)
        {
            double elapsedSeconds = (double)stopwatch.ElapsedMilliseconds / 1000.0;
            Console.WriteLine("Time elapsed: " + elapsedSeconds + " s");
            Console.WriteLine("Used method: " + strategyName);
        }
    }
}
