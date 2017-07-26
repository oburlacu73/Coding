using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
	public class ConnectedComponents
	{
		private bool[] marked;	// marked[v] = has vertex v been marked?
		private int[] id;		// id[v] = id of connected component containing v
		private int[] size		// size[id] = number of vertices in a given component
		private int count;		// number of connected components
		
		
		public ConnectedComponents(Graph g)
		{
			marked = new bool[g.V];
			id = new int[g.V];
			size = new int[g.V];
			
			for(int v = 0; v< g.V; v++)
			{
				if(!marked[v])
				{
					dfs(g, v);
					count++
				}
			}
		}
		
		// depth-first search
		private void dfs(Graph g, int v)
		{
			marked[v] = true;
			id[v] = count;
			size[count]++;
			
			foreach(int w in g.Aj(v))
			{
				if(!marked[w])
				{
					df(g, w);
				}
			}
		}
		
		// returns the component id of the connected component containing vertex v
		public int Id(int v)
		{
			return id[v];
		}
		
		// returns the number of vertices in the connected component containing vertex v
		public int size(int v)
		{
			return size[v];
		}
		
		// return the number of connected components
		public int Count { get { return count; } }
	}
}