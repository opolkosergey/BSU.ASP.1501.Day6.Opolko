using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class DecreaseSumRowComparator : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            if (x.Sum() < y.Sum()) return -1;
            if (x.Sum() > y.Sum()) return 1;
            return 0;
        }
    }

    public class IncreaseSumRowComparator : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            if (x.Sum() < y.Sum()) return 1;
            if (x.Sum() > y.Sum()) return -1;
            return 0;
        }
    }

    public class DecreaseMaxAbsElementRowComparator : IComparer<int []>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            if (x.Max(a => Math.Abs(a)) > y.Max(b => Math.Abs(b))) return 1;
            if (x.Max(a => Math.Abs(a)) < y.Max(b => Math.Abs(b))) return -1;
            return 0;
        }
    }

    public class IncreaseMaxAbsElementRowComparator : IComparer<int []>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            if (x.Max(a => Math.Abs(a)) > y.Max(b => Math.Abs(b))) return -1;
            if (x.Max(a => Math.Abs(a)) < y.Max(b => Math.Abs(b))) return 1;
            return 0;
        }
    }
}