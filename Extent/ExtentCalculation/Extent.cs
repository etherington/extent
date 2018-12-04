using System;

namespace Extent.ExtentCalculation
{
    /// <summary>
    /// A class to encapsulate an extent.
    /// </summary>
    public class Extent
    {
        public int Start { get; }
        public int End { get; }

        public Extent(int start, int end)
        {
            if (start > end)
                throw new ArgumentException("Start was after End");
            Start = start;
            End = end;
        }
    }
}
