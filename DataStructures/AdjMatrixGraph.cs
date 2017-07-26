using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
	public class AdjMatrixGraph
	{
		public int V { get; private set; }
		public int E { get; private set; }
		private bool[][] adj;
		
		public AdjMatrixGraph(int v)
		{
			if(v < 0) throw new ArgumentException("Number of vertices must be nonnegative");
			
			this.V = v;
			this.E = 0;
			
			adj = new bool [v][v];
		}
		
		public void AddEdge(int v, int w)
		{
			if(!adj[v][w]) this.E = this.E+1;
			
			adj[v][w] = true;
			adj[w][v] = true;
		}
		
		// does the graph contain the edge v-q?
		public bool Contains(int v, int w)
		{
			if( v < 0 || v >= V) throw new IndexOutOfBoundsException();
			if( w < 0 || w >= V) throw new IndexOutOfBoundsException();
			
			return adj[v][w];
		}
		
		public IEnumerable<int> Adj(int v)
		{
			if( v < 0 || v >= V) throw new IndexOutOfBoundsException();
			return adj[v];
		}
	}
}