using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
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
                Sorter.Swap<int>(ref elementList, i, pmin);
            }
        }

        public String StrategyName()
        {
            return "Selection Sort";
        }
    }

}
