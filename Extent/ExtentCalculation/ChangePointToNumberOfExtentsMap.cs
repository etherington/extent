using System;
using System.Collections.Generic;

namespace Extent.ExtentCalculation
{
    /// <summary>
    /// Stores a mapping from the integer changePoints to the number of extents overlapping that changePoint.
    /// </summary>
    public class ChangePointToNumberOfExtentsMap
    {       
        private SortedList<int, uint> MappingPoints { get; }

        private bool IsValid => MappingPoints.Count > 0;
        private int? FirstKey { get; }
        private int? LastKey { get; }

        public ChangePointToNumberOfExtentsMap(ChangePointToChangeMagnitudeMap changePoints)
        {
            int numberOfExtents = 0;
            int i = 0; 
            MappingPoints = new SortedList<int, uint>(changePoints.ChangePoints.Count);

            //Iterate through the changePoints and store the number of extents at each changePoint in MappingPoints
            foreach (var change in changePoints.ChangePoints)
            {
                numberOfExtents += change.Value;
                MappingPoints.Add(change.Key, (uint)numberOfExtents);

                //Calculate the first and last keys so that we know the range where the number of extents is non-zero
                if (i++ == 0)
                    FirstKey = change.Key;
                if (i == changePoints.ChangePoints.Count)
                    LastKey = change.Key;
            }
        }

        /// <summary>
        /// Method to return the number of extents overlapping for the supplied point.
        /// </summary>
        /// <param name="point">The point for which the number of extents will be calculated.</param>
        /// <returns>The number of extents for the supplied point.</returns>
        public uint GetNumberOfExtentsForPoint(int point)
        {
            if (!IsValid)
                throw new ArgumentException("ChangePointToNumberOfExtentsMap has not been initialized.");
            if (point < FirstKey.Value || point > LastKey.Value)
                return 0;

            return MappingPoints[Utilities.GetClosestIntLessThanOrEqualToValue(MappingPoints.Keys, point)];
        }

    }
}
