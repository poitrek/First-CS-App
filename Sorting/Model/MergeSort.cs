using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
    // Implementation of merge sort
    class MergeSort : ISort
    {
        // Inherited method that sorts elements
        public void SortElements(ref List<int> elementList)
        {
            //SortRange2(ref elementList, 0, elementList.Count);
            SortWhole(ref elementList);
        }

        // First implementation of the algorithm. Uses allocating new
        // lists to divide the input element list into two halves
        public void SortWhole(ref List<int> elementList)
        {
            if (elementList.Count > 1)
            {
                // Dividing list into two halves
                int center = elementList.Count / 2;

                List<int> firstHalf = elementList.GetRange(0, center);
                List<int> secondHalf = elementList.GetRange(center, elementList.Count - center);

                SortWhole(ref firstHalf);
                SortWhole(ref secondHalf);

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
                    while (element > secondHalf[i])
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

        // The other implementation of the algorithm. Uses specifying the ranges
        // of the input element list to divide it into two halves
        private void SortRange(ref List<int> elementList, int begin, int count)
        {
            if (count > 2)
            {
                // Center index of the range
                int half = count / 2;

                SortRange(ref elementList, begin, half);
                SortRange(ref elementList, begin + half, count - half);

                int i = begin;
                int j = begin + half;
                int end = begin + count;

                while (i < j && j < end)
                {
                    if (elementList[i] <= elementList[j])
                    {
                        i++;
                    }
                    else
                    {
                        int temp = elementList[j];
                        elementList.RemoveAt(j);
                        elementList.Insert(i, temp);
                        i++;
                        j++;
                    }
                }

            }
            else if (count == 2)
            {
                if (elementList[begin] > elementList[begin + 1])
                {
                    var temp = elementList[begin + 1];
                    elementList[begin + 1] = elementList[begin];
                    elementList[begin] = temp;
                }
            }
        }


        private void SortRange2(ref List<int> elementList, int begin, int count)
        {
            if (count > 2)
            {
                // Half of the count
                int half = count / 2;

                // Sort both halves of the range
                SortRange2(ref elementList, begin, half);
                SortRange2(ref elementList, begin + half, count - half);

                int center = begin + half;
                int end = begin + count;

                int i = begin;
                int j = center;

                // Merge halves into new list
                List<int> newList = new List<int>();

                while (i < center && j < end)
                {
                    if (elementList[i] <= elementList[j])
                    {
                        newList.Add(elementList[i]);
                        i++;
                    }
                    else
                    {
                        newList.Add(elementList[j]);
                        j++;
                    }
                }

                if (i == center)
                {
                    newList.AddRange(elementList.GetRange(j, end - j));
                }
                else if (j == end)
                {
                    newList.AddRange(elementList.GetRange(i, center - i));
                }

                // Remove the old range from the list and insert sorted range
                elementList.RemoveRange(begin, count);
                elementList.InsertRange(begin, newList);

            }
            else if (count == 2)
            {
                if (elementList[begin] > elementList[begin + 1])
                {
                    var temp = elementList[begin + 1];
                    elementList[begin + 1] = elementList[begin];
                    elementList[begin] = temp;
                }
            }
        }

        public String StrategyName()
        {
            return "Merge Sort";
        }
    }

}
