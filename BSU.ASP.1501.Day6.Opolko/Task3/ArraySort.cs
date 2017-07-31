using System;
using System.Collections.Generic;

namespace Task3
{
    public static class Sort
    {
        public static void BubbleSort(int[][] array, IComparer<int[]> comparator)
        {
	        if (array == null)
	        {
		        throw new ArgumentNullException(nameof(array));
	        }

	        if (comparator == null)
	        {
		        throw new ArgumentNullException(nameof(comparator));
	        }

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
				{
					if (comparator.Compare(array[i], array[j]) > 1)
					{
						ReplaceRows(ref array[i], ref array[j]);
					}
				}
            }
        }

        public static void BubbleSort(int[][] array, Comparison<int[]> comparator)
        {
	        if (array == null)
	        {
		        throw new ArgumentNullException(nameof(array));
	        }

	        if (comparator == null)
	        {
		        throw new ArgumentNullException(nameof(comparator));
	        }

            var c = new CompareAdapter<int[]>(comparator);
            BubbleSort(array,c);
        }      

        private static void ReplaceRows(ref int[] a, ref int[] b)
        {
            int[] row = a;
            a = b;
            b = row;
        }
    }

    class CompareAdapter<T> : IComparer<T>
    {
        private Comparison<T> comparison;

        public CompareAdapter(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }

        public int Compare(T x, T y) => comparison(x, y);
    }
}
