namespace Algorithms.Algorithms
{
	public class Quick3way
	{
		private Quick3way() {}
		
		public static void sort(int[] a)
		{
			sort(a, 0, a.Length-1);
		}
		
		// quicksort the subarray a[lo .. hi] using 3-way partitioning
		private static void sort(int[]a, int lo, int hi)
		{
			if( hi <= lo ) return;
			
			int lt = lo, gt=hi;
			int v = a[lo];
			int i = lo;
		
			while(i <= gt)
			{
				if( a[i] < v)		exch(a, lt++, i++);
				else if(a[i] > v)	exch(a, i, gt--);
				else 				i++;
			}
			
			 // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]. 
			sort(a, lo, lt-1);
			sort(a, gt+1, hi);
		}
	
		// exchange a[i] and a[j]
		private static void exch(int[] a, int i, int j) 
		{
			int swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}
	}
}