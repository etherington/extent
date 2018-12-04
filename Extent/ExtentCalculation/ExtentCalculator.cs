using System;

namespace Extent.ExtentCalculation
{
    /// <summary>
    /// This class allows the point to number of extents to be calculated.
    /// Usage:
    /// 1. Call AddExtent for all extents.
    /// 2. Call Initialize to calculate the mapping internally.
    /// 3. Call GetNumberOfExtentsForPoint for any point. 
    /// </summary>
    public class ExtentCalculator
    {
        private readonly ChangePointToChangeMagnitudeMap _changePointToChangeMagnitudeMap = new ChangePointToChangeMagnitudeMap();
        private ChangePointToNumberOfExtentsMap _changePointToNumberOfExtentsMap;
        private bool _isExtentsMapInitialized = false;
        
        /// <summary>
        /// Add the extent to the list of changePoints.
        /// </summary>
        /// <param name="extent">The extent</param>
        public void AddExtent(Extent extent)
        {
            if (extent == null)
                throw new ArgumentNullException(nameof(extent));
            _changePointToChangeMagnitudeMap.AddExtent(extent);
        }

        /// <summary>
        /// Method to initialize the ChangePointToNumberOfExtentsMap before the GetNumberOfExtentsForPoint can be called.
        /// </summary>
        public void Initialize()
        {
            _changePointToNumberOfExtentsMap = new ChangePointToNumberOfExtentsMap(_changePointToChangeMagnitudeMap);
            _isExtentsMapInitialized = true;
        }

        /// <summary>
        /// Method to return the number of extents overlapping for the supplied point.
        /// </summary>
        /// <param name="point">The point for which the number of extents will be calculated.</param>
        /// <returns>The number of extents for the supplied point.</returns>
        public uint GetNumberOfExtentsForPoint(int point)
        {
            if (!_isExtentsMapInitialized)
            {
                Initialize();
            }

            return _changePointToNumberOfExtentsMap.GetNumberOfExtentsForPoint(point);
        }
    }
}
