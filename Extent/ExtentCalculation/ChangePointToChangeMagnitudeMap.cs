using System.Collections.Generic;

namespace Extent.ExtentCalculation
{
    /// <summary>
    /// A class to precalculate the points at which the number of extents changes, and the change at those points.
    /// </summary>
    public class ChangePointToChangeMagnitudeMap
    {
        public SortedList<int, int> ChangePoints { get;}

        public ChangePointToChangeMagnitudeMap()
        {
            ChangePoints = new SortedList<int, int>();
        }

        /// <summary>
        /// Add the extent to the list of changePoints.
        /// </summary>
        /// <param name="extent">The extent</param>
        public void AddExtent(Extent extent)
        {
            // If the extent start is already in the list of changePoints, add one to the change at this point.
            if (ChangePoints.ContainsKey(extent.Start))
                ChangePoints[extent.Start]++;
            // Otherwise, the change at this point is +1
            else ChangePoints.Add(extent.Start,1);

            // If the extent end is already in the list of changePoints, subtract one to the change at the next integer after this point.
            if (ChangePoints.ContainsKey(extent.End + 1))
                ChangePoints[extent.End + 1]--;
            // Otherwise, the change at the next integer is -1
            else ChangePoints.Add(extent.End + 1, -1);
        }
    }
}
