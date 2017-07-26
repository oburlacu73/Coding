using System;
namespace Algorithms.Algorithms
{
	public static class Insertion
	{
		public static void Sort(IComparable[] a, int lo, int hi)
		{
			int n = a.Length;
			
			for(int i = lo; i < hi; i++)
			{
				for(int j = i; j>0; j--)
				{
					if(a[j].CompareTo(a[j-1]) < 0)
					{
						exch(a, j, j-1);
					}
				}
			}
		}
		
		// exchange a[i] and a[j]  (for indirect sort)
        private static void exch(IComparable[] a, int i, int j)
        {
			var swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}
		
	}
}