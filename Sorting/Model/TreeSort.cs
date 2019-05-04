using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting.Model
{
    // Implementation of the binary search tree sort
    class TreeSort : ISort
    {
        // Class representing binary search tree node
        class Node
        {
            int value;
            Node left;
            Node right;

            public Node(int value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
            }

            // Adds new value (number) to the tree
            public void Add(int v)
            {
                // Value smaller than current node goes to the left branch
                if (v < value)
                {
                    if (left == null)
                    {
                        left = new Node(v);
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
                        right = new Node(v);
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
            // Allocate the root of binary search tree
            Node treeRoot = new Node(elementList[0]);

            // Build the tree from the elements
            for (int i = 1; i < elementList.Count; i++)
            {
                treeRoot.Add(elementList[i]);
            }

            // Allocate the element list again (as empty list)
            elementList = new List<int>();

            // Fill the list back with elements from the tree
            treeRoot.ReturnToList(ref elementList);
        }

        public String StrategyName()
        {
            return "Tree Sort";
        }
    }
}
