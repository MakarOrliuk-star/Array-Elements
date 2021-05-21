using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Looking_For_Array_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int example = GetIntegersCount(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, new[] { 2, 5, 8 });
            Console.WriteLine(example);

            int example2 = GetIntegersCount(new[] { 5, 4, 21, 38, 25, int.MaxValue, 48, 98, 14, 43, 11, 6, 81, 532, 58 }, new[] { int.MaxValue, 47, 14, 6, 532, int.MinValue }, 0, 8);
            Console.WriteLine(example2);
        }
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch));
            }
            else if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor));
            }

            int count = 0;
            for (int i = 0; i < elementsToSearchFor.Length; i++)
            {
                for (int j = 0; j < arrayToSearch.Length; j++)
                {
                    if (elementsToSearchFor[i] == arrayToSearch[j])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        public static int GetIntegersCount(int[] arrayToSearch, int[] elementsToSearchFor, int startIndex, int count)
        {
            if (arrayToSearch is null)
            {
                throw new ArgumentNullException(nameof(arrayToSearch), "Argument should not be null");
            }

            if (elementsToSearchFor is null)
            {
                throw new ArgumentNullException(nameof(elementsToSearchFor), "Argument should not be null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Argument should be positive");
            }

            if (startIndex > arrayToSearch.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "The argument should not be greater than the array length.");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Argument should be positive");
            }

            if (elementsToSearchFor.Length == 0)
            {
                return 0;
            }

            List<int> indexes = new List<int>();
            int currentElementToSearch = 0;
            int currentElementToSearchFor = 0;
            int endIndex = startIndex + count - 1;
            while (currentElementToSearchFor < elementsToSearchFor.Length)
            {
                while (currentElementToSearch < arrayToSearch.Length)
                {
                    if (arrayToSearch[currentElementToSearch] == elementsToSearchFor[currentElementToSearchFor])
                    {
                        indexes.Add(currentElementToSearch);
                    }

                    currentElementToSearch++;
                }

                currentElementToSearch = 0;
                currentElementToSearchFor++;
            }

            if (count > arrayToSearch.Length - startIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "The number of elements to search is greater than the number of elements available in the array starting from the startIndex position.");
            }

            int sum = 0;
            foreach (var ind in indexes)
            {
                if (ind >= startIndex && ind <= endIndex)
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
