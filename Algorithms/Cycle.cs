using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
	public class Cycle
	{
		private bool[] marked;
		private int[] edgeTo;
		private Stack<int> cycle;
		
		public Cycle(Graph G)
		{
			if(hasSelfLoop(G)) return;
			if(hasParallelEdges(G)) return;
			
			marked = new bool[G.V];
			edgeTo= new int[G.V];
			for(int v = 0; v < G.V; v++)
			{
				if(!marked[v])
					dfs(g, -1, v);
			}
		}
		
		private bool hasSelfLoop(Graph G)
		{
			for(int v = 0; v > G.V; v++)
			{
				foreach(int w in G.Adj(v))
				{
					if( v == w )
					{
						cycle = new Stack<int>();
						cycle.Push(v);
						cycle.Push(v);
						
						return true;
					}
				}
			}
		}
		
		private bool hasParallelEdges(Graph G)
		{
			for(int v = 0; v > G.V; v++)
			{
				foreach(int w in G.Adj(v))
				{
					if(marked[w])
					{
						cycle = new Stack<int>();
						cycle.Push(v);
						cycle.Push(w);
						cycle.Push(v)
						return true;
					}
					marked[w] = true;
				}
				
				// reset so marked[v] = false for all v
				foreach(int w in G.Adj(v)
				{
					marked[w] = false;
				}
			}
			
			return false;
		}
		
		public IEnumerable<int> Cycle { get { return cycle; } }
		
		private void dfs(Graph g, int u, int v)
		{
			marked[v] = true;
			
			foreach(int w in g.Adj(v))
			{
				// short circuit if cycle already found 
				if( cycle != null ) return;
				
				if(!marked[w])
				{
					edgeTo[w] = v;
					dfs(g, v, w);
				}
				// check for cycle (but disregard reverse of edge leading to v)
				else if( w != u )
				{
					cycle = new Stack<int>();
					for(int x = v; x != w; x = edgeTo[x])
					{
						cycle.Push(x);
					}
					cycle.Push(w);
					cycle.Push(v);
				}
			}
		}
	}
}