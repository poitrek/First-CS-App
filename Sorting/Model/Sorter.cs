using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting.Model
{

    class Sorter
    {
        private ISort sortStrategy;
        
        private List<int> elementList;

        public Stopwatch stopwatch;

        public NumberGenerator numberGenerator;

        public Sorter()
        {
            numberGenerator = new NumberGenerator();
            stopwatch = new Stopwatch();
        }

        public void SetSortMethod(string methodKey)
        {
            switch (methodKey)
            {
                case "q":
                    sortStrategy = new QuickSort();
                    break;
                case "s":
                    sortStrategy = new SelectionSort();
                    break;
                case "i":
                    sortStrategy = new InsertionSort();
                    break;
                case "m":
                    sortStrategy = new MergeSort();
                    break;
                case "c":
                    sortStrategy = new CSharpListSort();
                    break;
                default:
                    throw new Exception("Exception setting sorting method.");
            }
        }

        public void SetElementList(List<int> elementList)
        {
            this.elementList = elementList;
        }

        public List<int> GetElementList()
        {
            return this.elementList;
        }

        public String UsedMethodName()
        {
            return sortStrategy.StrategyName();
        }

        public static void Swap<T>(ref List<T> objectList, int firstIndex, int secondIndex)
        {
            T temp;
            temp = objectList[firstIndex];
            objectList[firstIndex] = objectList[secondIndex];
            objectList[secondIndex] = temp;
        }

        public void SortElements()
        {
            stopwatch.Start();

            sortStrategy.SortElements(ref elementList);

            stopwatch.Stop();
        }
        
    }

}

