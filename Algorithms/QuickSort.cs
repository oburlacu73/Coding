using System;
namespace Algorithms.Algorithms
{
	public class Quick
	{
		private Quick() {}
		
		public static void Sort(int[] a)
		{
			Sort(a,0, a.Length-1);
		}
		
		private static void Sort(int[] a, int lo, int hi)
		{
			if( hi <= lo ) return;

            int j = partition(a, lo, hi);
			Sort(a,lo,j-1);
			Sort(a, j+1, hi);
		}
		
		private static int partition(int[] a, int lo, int hi)
		{
			int i = lo;
			int j = hi+1;
			int v = a[lo];
			
			while(true)
			{
				// find item on lo to swap
				while(a[++i] < v)
				{
					if(i==hi) break;
				}
				
				// find item on hi to swap
				while(v < a[--j])
				{
					if(j==lo) break;
				}
				
				//check if pointers cross
				if(i >= j) break;
				
				exch(a,i,j);
			}
		
			// put partitioning item v at a[j]
			exch(a, lo, j);

			// now, a[lo .. j-1] <= a[j] <= a[j+1 .. hi]
			return j;
		}
	
		// exchange a[i] and a[j]
		private static void exch(int[] a, int i, int j) 
		{
			int swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}
		
		/* Rearranges the array so that a[k] contains the kth smallest key;
		* a[0] through a[k-1] are less than (or equal to) a[k]; and
		* a[k+1] through a[N-1] are greater than (or equal to) a[k].*/
		public static int Select(int[] a, int k)
		{
			if( k < 0 || k >= a.Length)
			{
				throw new ArgumentException("Selected element out of bounds");
			}
			int lo = 0, hi = a.Length-1;
		
			while(hi > lo)
			{
				int i = partition(a, lo, hi);

                if (i > k) hi = i - 1; //search on the left subarray
                else if (i < k) lo = i + 1;// search in the right subarray
                else return a[i];
			}
			
			return a[lo];
		}
	}
}