using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
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
                while (element > newList[j])
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

}
