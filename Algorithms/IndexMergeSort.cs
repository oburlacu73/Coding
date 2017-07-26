using System;
namespace Algorithms.Algorithms
{
	public static class IndexMergeSort
	{
		// stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
		private static void Merge(IComparable[] a, int[] index, int[] aux, int lo, int mid, int hi)
		{
			// precondition: a[lo .. mid] and a[mid+1 .. hi] are sorted sub-arrays

			// copy to aux[]
			for (int k = lo; k <=hi; k++) 
			{
				aux[k] = index[k]; 
			}

			// merge back to index[]
			int i = lo, j = mid+1;
			for (int k = lo; k < hi; k++) {
				if      (i > mid)              index[k] = aux[j++];   
				else if (j >= hi)              index[k] = aux[i++];
				else if (less(a, aux[j], aux[i])) index[k] = aux[j++];
				else                           index[k] = aux[i++];
			}
		}
        
        private static bool less(IComparable[] a, int i, int j)
        {
            return a[i].CompareTo(a[j]) < 0;
        }

		// mergesort a[lo..hi] using auxiliary array aux[lo..hi]
		private static void Sort(IComparable[] a, int[] index, int[] aux, int lo, int hi)
		{
			if( hi <= lo)
				return;
			
			int mid = lo + (hi-lo)/2;
			Sort(a, index, aux, lo, mid);
			Sort(a, index, aux, mid+1, hi);
			Merge(a, index, aux, lo, mid, hi);
		}
		
		// Returns a permutation that gives the elements in the array in ascending order.
		public static int[] Index(IComparable[] a)
		{
			int N = a.Length;
			int[] index = new int[N];
			for (int i = 0; i < N; i++)
				index[i] = i;

			int[] aux = new int[N];
			Sort(a, index, aux, 0, N);
			
			return index;
		}
	}
}