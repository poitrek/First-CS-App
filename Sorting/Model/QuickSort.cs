using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
    // One of the implementations of quicksort
    class QuickSort : ISort
    {
        interface IPivotPicker
        {
            int PickPivot(List<int> elementList);
        }

        class LastElementPivot : IPivotPicker
        {
            public int PickPivot(List<int> elementList)
            {
                return elementList.Last();
            }
        }

        class FirstElementPivot : IPivotPicker
        {
            public int PickPivot(List<int> elementList)
            {
                return elementList.First();
            }
        }

        class RandomPivot : IPivotPicker
        {
            Random random;
            public RandomPivot()
            {
                random = new Random();
            }
            public int PickPivot(List<int> elementList)
            {
                return elementList[random.Next(elementList.Count)];
            }
        }

        class MedianPivot : IPivotPicker
        {
            public int PickPivot(List<int> elementList)
            {
                int a = elementList.First();
                int b = elementList.Last();
                int c = elementList[elementList.Count / 2];

                // Find the middle value of these three
                int max, min;
                if (a > b)
                {
                    max = a;
                    min = b;
                }
                else
                {
                    max = b;
                    min = a;
                }
                if (max < c)
                    return max;
                else if (min > c)
                    return min;
                else
                    return c;
            }
        }

        private IPivotPicker pivotPicker;

        public QuickSort()
        {
            pivotPicker = new RandomPivot();
        }

        public void SortElements(ref List<int> elementList)
        {
            if (elementList.Count <= 1)
            {
                return;
            }
            if (elementList.Count == 2)
            {
                if (elementList[0] > elementList[1])
                {
                    Sorter.Swap<int>(ref elementList, 0, 1);
                }
                return;
            }

            // Choose pivot using one of the strategies
            int pivot = pivotPicker.PickPivot(elementList);

            // Remove the first occurence of the pivot value
            elementList.Remove(pivot);

            int border = 0;
            for (int i = 0; i < elementList.Count; i++)
            {
                if (elementList[i] < pivot)
                {
                    Sorter.Swap<int>(ref elementList, i, border);
                    border++;
                }
            }

            // Insert the missing pivot into the right place
            elementList.Insert(border, pivot);

            // Generating two sub-ranges of the list
            List<int> firstHalf = elementList.GetRange(0, border); // Stack overflow exception
            List<int> secondHalf = elementList.GetRange(border + 1, elementList.Count - border - 1);


            /// ============= Previous attempt ===================
            //for (int i = 0; i < elementList.Count - 1; i++)
            //{
            //    if (elementList[i] < pivot)
            //    {
            //        Sorter.Swap<int>(ref elementList, i, border);
            //        border++;
            //    }
            //}
            //// Swapping current border with pivot
            //Sorter.Swap<int>(ref elementList, border, elementList.Count - 1);

            //// Generating two sub-ranges of the list
            //List<int> firstHalf = elementList.GetRange(0, border);
            //List<int> secondHalf = elementList.GetRange(border + 1, elementList.Count - border - 1);
            /// ===================================================

            /// This implementation may be inefficient due to lots of operations
            /// of copying, removing and inserting ranges into the lists
            /// Call sorting recursively on both halves
            SortElements(ref firstHalf);
            SortElements(ref secondHalf);

            elementList.RemoveRange(0, border);
            elementList.InsertRange(0, firstHalf);

            elementList.RemoveRange(border + 1, elementList.Count - border - 1);
            elementList.InsertRange(border + 1, secondHalf);

            //elementList.RemoveRange(border, elementList.Count - border);
            //elementList.InsertRange(border, secondHalf);

        }

        public String StrategyName()
        {
            return "Quick Sort";
        }
    }

}
