/* This is the Merge sort enhanced:
	1. •Use insertion sort for small subarrays.
	2. •Test whether array is already in order.
	3. •Eliminate the copy to the auxiliary array
*/
using System;
namespace Algorithms.Algorithms
{
	public static class MergeX
	{
		private const int CUTOFF = 7;  // cutoff to insertion sort

		private static void Merge(IComparable[] src, IComparable[] dst, int lo, int mid, int hi)
		{
			int i = lo, j = mid+1;
			
			for(int k = lo; k < hi; k++)
			{
				if(i > mid)
				{
					dst[k] = src[j++];
				}
				else if(j >= hi)
				{
					dst[k] = src[i++];
				}
				else if(src[j].CompareTo(src[i]) < 0)
				{
					dst[k] = src[j++];
				}
				else
				{
					dst[k] = src[i++];
				}	
			}
		}
		
		private static void Sort(IComparable[] src, IComparable[] dst, int lo, int hi)
		{
			// Insertion sort for CUTOFF
			if( hi <= lo + CUTOFF)
			{
				Insertion.Sort(dst, lo, hi);
				return;
			}
			
			int mid = lo + (hi - lo) / 2;
			Sort(dst, src, lo, mid);
			Sort(dst, src, mid+1, hi);
			
			// Test if array is already sorted
			if( src[mid].CompareTo(src[mid+1]) <= 0)
				return;
				
			Merge(src, dst, lo, mid, hi);
		}
		
		public static void Sort(IComparable[] a)
		{
			IComparable[] aux = new IComparable[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                aux[i] = a[i];
            }
			
			Sort(aux, a, 0, a.Length);
		}
	}
}