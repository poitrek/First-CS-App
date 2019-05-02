using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
    // Implementation of heap sort
    class HeapSort : ISort
    {
        // Class representing binary tree node
        class TreeNode
        {
            int value;
            TreeNode left;
            TreeNode right;

            public TreeNode(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }

            // Adds new value (number) to the binary tree
            public void Add(int v)
            {
                // Value smaller than current node goes to the left branch
                if (v < value)
                {
                    if (left == null)
                    {
                        left = new TreeNode(v);
                    }
                    else
                    {
                        left.Add(v);
                    }
                }
                // Value greater than current node goes to the right branch
                else
                {
                    if (right == null)
                    {
                        right = new TreeNode(v);
                    }
                    else
                    {
                        right.Add(v);
                    }
                }
            }

            public void ReturnToList(ref List<int> list)
            {
                if (left != null)
                {
                    left.ReturnToList(ref list);
                }
                list.Add(value);
                if (right != null)
                {
                    right.ReturnToList(ref list);
                }
            }

        }

        public void SortElements(ref List<int> elementList)
        {
            TreeNode treeRoot = new TreeNode(elementList[0]);

            for (int i = 1; i < elementList.Count; i++)
            {
                treeRoot.Add(elementList[i]);
            }

            // Allocate the element list again (as empty list)
            elementList = new List<int>();

            treeRoot.ReturnToList(ref elementList);
        }

        public String StrategyName()
        {
            return "Heap Sort";
        }
    }
}
