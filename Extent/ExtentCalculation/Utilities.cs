using System;
using System.Collections.Generic;

namespace Extent.ExtentCalculation
{
    public static class Utilities
    {
        /// <summary>
        /// Performs a binary search on a list of integers to find the element in the list that is closest to and less than or equal to the given value.
        /// </summary>
        /// <param name="integersList">The list of integers to search</param>
        /// <param name="value">The value to match</param>
        /// <returns>The element from integersList closest to and less than or equal to value.</returns>
        public static int GetClosestIntLessThanOrEqualToValue(IList<int> integersList, int value)
        {
            if (integersList == null)
                throw new ArgumentNullException(nameof(integersList));

            int lowIndex = 0, highIndex = integersList.Count - 1;
            while (lowIndex < highIndex)
            {
                int midIndex = (highIndex + lowIndex) / 2;
                if (integersList[midIndex] > value)
                {
                    highIndex = midIndex - 1;
                }
                else
                {
                    lowIndex = midIndex + 1;
                }
            }
            if (integersList[lowIndex] > value) lowIndex--;
            return integersList[lowIndex];
        }
    }
}
