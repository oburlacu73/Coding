namespace Algorithms.DataStructures
{
	public class WeightedUnionFind
	{
		private int[] id;	// id[i] = parent of i
		private int[] size;	// sz[i] = number of objects in sub-tree rooted at i
		private int count;	// number of components

        public WeightedUnionFind(int n)
		{
			count = n;
			id = new int[n];
			size = new int[n];
			
			// Set id of each object to itself
			for(int i =0; i < n; i++)
			{
				id[i] = i;
				size[i] = 1;
			}
		}
		
		// Chase parent pointers until reach root
		public int Find(int p)
		{
			int root = p;
			while (root != id[root])
			{
				root = id[root];
			}
			
			// Make each node in the path point to root
			while (p != root) 
			{
				int newp = id[p];
				id[p] = root;
				p = newp;
			}
			
			return root;
		}
		
		public int Count
		{
			get { return this.count; }
		}
		
		// Check if p and q have the same root ( then they are connected)
		public bool Connected(int p, int q)
		{
			return Find(p) == Find(q);
		}

        // Chase parent pointers until reach root
        private int root(int i)
        {
            while (i != id[i])
            {
                i = id[i];
            }

            return i;
        }

        // Connects p and q by changing the root of p to point to root of q
		public void Union(int p, int q)
		{
			int rootP  = root(p);
			int rootQ = root(q);
			
			if (rootP == rootQ) return;
			
			// Make smaller tree point to the large one to keep tree balanced
			if(size[rootP] < size[rootQ])
			{
				id[rootP] = id[rootQ];
				size[rootQ] += size[rootP];
			}
			else
			{
                id[rootQ] = id[rootP];
				size[rootP] += size[rootQ];
			}
			
			this.count--;
		}
	}
}
