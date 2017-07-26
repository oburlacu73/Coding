using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
	public class Bipartite
	{
		private bool isBipartite;	// is the graph bipartite
		private bool[] color;		// color[v] gives vertices on one side of bipartition
		private bool[] marked;		// marked[v] = true if v has been visited in DFS
		private int[] edgeTo;		// edgeTo[v] = last edge on path to v
		private Stack<int> cycle;	// odd length cycle
		
		// Determines whether an undirected graph is bipartite
		// and finds either a bipartition or an odd-length cycle
		public Bipartite(Graph G)
		{
			isBipartite = true;
			color = new bool[G.V];
			marked = new bool[G.V];
			edgeTo = new int[G.V];
			
			for(int v = 0; v < G.V; v++
			{
				if(!marked[v])
				{
					dfs(G, v);
				}
			}
		}
		
		private void dfs(Graph G, int v)
		{
			marked[v] = true;
			
			foreach(int w in G.Adj(v))
			{
				// short circuit if odd-length cycle is found
				if(cycle != null) return;
				
				// found unmarked vertex so recur
				if(!marked[w])
				{
					edgeTo[w] = v;
					color[w] = !color[v];
					dfs(G, w);
				}
				// if v-w create an odd length cycle, find it
				else if(color[w] = color[v])
				{
					isBipartite = false;
					cycle = new Stack<int();
					cycle.push(w);
					
					for(int x = v, x != w; x = edgeTo[x])
					{
						cycle.Push(x);
					}
					cycle.Push(w);
				}
			}
		}
	}
}