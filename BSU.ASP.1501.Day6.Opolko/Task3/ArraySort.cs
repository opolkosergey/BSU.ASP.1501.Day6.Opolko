﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class Sort
    {
        public delegate int RowComparator(int[] x, int[] y);
        public static void BubbleSort(int[][] array, IComparer<int[]> comparator)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));
            var method = (RowComparator)comparator.Compare;
            InterfaceToDelegate(method,array);
        }

        public static void BubbleSort(int[][] array, RowComparator comparator)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));
            var comparer = comparator.Target as IComparer<int[]>;
            DelegateToInterface(comparer, array);
        }

        private static void InterfaceToDelegate(RowComparator comparator, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (comparator(array[i], array[j]) > 1)
                    {
                        ReplaceRows(ref array[i], ref array[j]);
                    }
                }
            }
        }

        private static void DelegateToInterface(IComparer<int[]> comparer, int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (comparer.Compare(array[i], array[j]) > 1)
                    {
                        ReplaceRows(ref array[i], ref array[j]);
                    }
                }
            }
        }

        private static void ReplaceRows(ref int[] a, ref int[] b)
        {
            int[] row = a;
            a = b;
            b = row;
        }
    }
}