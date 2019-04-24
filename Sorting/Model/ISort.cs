using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
    interface ISort
    {
        void SortElements(ref List<int> elementList);

        String StrategyName();
    }
}
