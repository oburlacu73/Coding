using System;
namespace Algorithms.Algorithms
{
	public static class MergeSort
	{
		// stably merge a[lo .. mid] with a[mid+1 ..hi] using aux[lo .. hi]
		private static void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
		{
			// precondition: a[lo .. mid] and a[mid+1 .. hi] are sorted sub-arrays

			// copy to aux[]
			for (int k = lo; k <= hi; k++) 
			{
				aux[k] = a[k]; 
			}

			// merge back to a[]
			int i = lo, j = mid+1;
			for (int k = lo; k <= hi; k++) {
				if      (i > mid)                       a[k] = aux[j++];   
				else if (j > hi)                        a[k] = aux[i++];
				else if (aux[j].CompareTo(aux[i]) < 0)  a[k] = aux[j++];
				else                                    a[k] = aux[i++];
			}
		}

		// mergesort a[lo..hi] using auxiliary array aux[lo..hi]
		private static void Sort(IComparable[] a, IComparable[] aux, int lo, int hi)
		{
			if( hi <= lo)
				return;
			
			int mid = lo + (hi-lo)/2;
			Sort(a, aux, lo, mid);
			Sort(a, aux, mid+1, hi);
			Merge(a, aux, lo, mid, hi);
		}
		
		public static void Sort(IComparable[] a)
		{
			IComparable[] aux = new IComparable[a.Length];
			Sort(a, aux, 0, a.Length-1);
		}
	}
}