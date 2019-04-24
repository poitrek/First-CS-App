using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
    // Using built-in method in C#
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
}
