using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sorting.Model
{
    class NumberGenerator
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

        // Generates values from 1..N in random order
        public List<int> GenerateRandom1ToN(int numberOfElements)
        {
            List<int> randomList = new List<int>();
            // An extra element for easier inserting
            randomList.Add(0);
            for (int i = 1; i <= numberOfElements; i++)
            {
                int idx = random.Next(i);
                randomList.Insert(idx, i);
            }
            // Remove the extra element
            randomList.RemoveAt(randomList.Count - 1);
            return randomList;
        }

        // Generates values from 1..N in ascending order
        public List<int> Generate1ToN(int numberOfElements)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= numberOfElements; i++)
            {
                list.Add(i);
            }
            return list;
        }

        // Generates values from N..1 (in descending order)
        public List<int> GenerateNTo1(int numberOfElements)
        {
            List<int> list = new List<int>();
            for (int i = numberOfElements; i >= 1; i--)
            {
                list.Add(i);
            }
            return list;
        }

    }
}