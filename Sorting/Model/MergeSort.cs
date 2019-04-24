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

}
