using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting
{

    interface ISort
    {
        void SortElements(ref List<int> elementList);
        String StrategyName();
    }

    // Implementation of selection sort
    class SelectionSort : ISort
    {
        public void SortElements(ref List<int> elementList)
        {
            for (var i = 0; i < elementList.Count - 1; i++)
            {
                var pmin = i;
                for (var j = i + 1; j < elementList.Count; j++)
                {
                    if (elementList[j] < elementList[pmin])
                    {
                        pmin = j;
                    }
                }
                Model.Swap<int>(ref elementList, i, pmin);
            }
        }

        public String StrategyName()
        {
            return "Selection Sort";
        }
    }

    class CSharpListSort : ISort
    {
        public void SortElements(ref List<int> elementList)
        {
            elementList.Sort();
        }

        public String StrategyName()
        {
            return "C# List.Sort()";
        }
    }

    // Implementation of insertion sort
    class InsertionSort : ISort
    {
        public void SortElements(ref List<int> elementList)
        {
            List<int> newList = new List<int>();
            newList.Insert(0, elementList[0]);
            
            for (var i = 1; i < elementList.Count; i++)
            {
                int element = elementList[i];
                int j = 0;
                while(element > newList[j])
                {
                    j++;
                    if (j == i)
                    {
                        break;
                    }
                }
                newList.Insert(j, element);
            }
            elementList = newList;
        }

        public String StrategyName()
        {
            return "Insertion Sort";
        }
    }

    // Implementation of merge sort
    class MergeSort : ISort
    {
        public void SortElements(ref List<int> elementList)
        {
            if (elementList.Count > 1)
            {
                // Dividing list into two halves
                int center = elementList.Count / 2;

                List<int> firstHalf = elementList.GetRange(0, center);
                List<int> secondHalf = elementList.GetRange(center, elementList.Count - center);

                SortElements(ref firstHalf);
                SortElements(ref secondHalf);

                // Merging sorted halves
                //int k = 0;
                //while (k <= firstHalf.Count && i <= secondHalf.Count)
                //{
                //    while (firstHalf[k] > secondHalf[i] && i <= secondHalf.Count - 1)
                //    {
                //        i++;
                //    }
                //    k++;
                //}
                secondHalf.Add(Int32.MaxValue);
                int i = 0;
                foreach (int element in firstHalf)
                {
                    while(element > secondHalf[i])
                    {
                        i++;
                    }
                    secondHalf.Insert(i, element);
                    i++;
                }
                secondHalf.RemoveAt(secondHalf.Count - 1);
                elementList = secondHalf;
            }
        }

        //private void SortRange(ref List<int> elementList, int begin, int count)
        //{
        //    if (count > 1)
        //    {

        //    }
        //}

        public String StrategyName()
        {
            return "Merge Sort";
        }
    }

    // One of the implementations of quicksort
    class QuickSort : ISort
    {
        public void SortElements(ref List<int> elementList)
        {
            if (elementList.Count <= 1)
            {
                return;
            }

            int pivot = elementList.Last();
            int border = 0;
            for (int i = 0; i < elementList.Count - 1; i++)
            {
                if (elementList[i] < pivot)
                {
                    Model.Swap<int>(ref elementList, i, border);
                    border++;
                }
            }
            // Swapping current border with pivot
            Model.Swap<int>(ref elementList, border, elementList.Count - 1);

            // Generating two sub-ranges of the list
            List<int> firstHalf = elementList.GetRange(0, border);
            List<int> secondHalf = elementList.GetRange(border + 1, elementList.Count - border - 1);

            /// This implementation may be inefficient due to lots of operations
            /// of copying, removing and inserting ranges into the lists
            SortElements(ref firstHalf);
            SortElements(ref secondHalf);

            elementList.RemoveRange(0, border);
            elementList.InsertRange(0, firstHalf);

            elementList.RemoveRange(border + 1, elementList.Count - border - 1);
            elementList.InsertRange(border + 1, secondHalf);

        }

        public String StrategyName()
        {
            return "Quick Sort";
        }
    }
    

    class Model
    {
        private ISort sortStrategy;
        
        private List<int> elementList;

        public Stopwatch stopwatch;

        public class NumberGenerator
        {
            Random random;
            int numberOfNumbers;
            int minimumValue;
            int maximumValue;

            public NumberGenerator()
            {
                random = new Random();
            }

            public NumberGenerator(int numberOfNumbers, int minimumValue, int maximumValue)
            {
                this.numberOfNumbers = numberOfNumbers;
                this.minimumValue = minimumValue;
                this.maximumValue = maximumValue;
                random = new Random();
            }

            public void setParameters(int numberOfNumbers, int minimumValue, int maximumValue)
            {
                this.numberOfNumbers = numberOfNumbers;
                this.minimumValue = minimumValue;
                this.maximumValue = maximumValue;
            }

            public List<int> GenerateRandom()
            {
                List<int> randomList = new List<int>();
                for (int i = 0; i < numberOfNumbers; i++)
                {
                    randomList.Add(random.Next(minimumValue, maximumValue));
                }
                return randomList;
            }

            public List<int> Generate1ToN(int numberOfElements)
            {
                List<int> randomList = new List<int>();
                // An extra element for easier inserting
                randomList.Add(0);
                for(int i = 1; i <= numberOfElements; i++)
                {
                    int idx = random.Next(i);
                    randomList.Insert(idx, i);
                }
                // Remove the extra element
                randomList.RemoveAt(randomList.Count - 1);
                return randomList;
            }
            
        }

        public NumberGenerator numberGenerator;

        public Model()
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

    //class Timer
    //{
    //    public Stopwatch stopwatch;
    //    public void 
    //}

}

