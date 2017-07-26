namespace Algorithms.DataStructures
{
	public class UnionFind
	{
		private int[] id;
		
		public UnionFind(int n)
		{
			id = new int[n];
			
			// Set id of each object to itself
			for(int i =0; i < n; i++)
			{
				id[i] = i;
			}
		}
		
		// Chase parent pointers until reach root
		private int root(int i)
		{
			while( i != id[i])
			{
				i = id[i];
			}

            return i;
		}
		
		// Check if p and q have the same root ( then they are conected)
		public bool Connected(int p, int q)
		{
			return root(p) == root(q);
		}
		
		// Connects p and q by changing the root of p to point to root of q
		public void Union(int p, int q)
		{
			int i = root(p);
			int j = root(q);
			
			id[i] = j;
		}
	}
}
