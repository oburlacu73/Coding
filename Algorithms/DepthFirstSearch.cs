using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
	public class DepthFirstSearch
	{
		private bool marked[];	// marked[v] = is there and s-v path?
		private int count;		// number of vertices connected to s
		
		public DepthFirstSearch(Graph g, int s)
		{
			marked = new bool[g.V];
			dfs(G, s);
		}
		
		private void dfs(Graph g, int v)
		{
			count++;
			marked[v] = true;
			foreach(int w in g.Adj[v])
			{
				if(!marked[w])
					dfs(g, w);
			}
		}
		
		// Is there a path between s and v?
		public bool Marked(int v)
		{
			return marked[v];
		}
		
		public int Count { get { return this.count; } }
	}
}