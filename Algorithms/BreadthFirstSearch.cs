using System;
using System.Collections.Generic;

namespace Algorithms.Algorithms
{
	public class BreadthFirstSearch
	{
	public const int INFINITY = int.MaxValue;
		private bool marked[];	// marked[v] = is there and s-v path?
		private int[] edgeTo;	// edgeTo[v] = previous edge in shortest s-v path
		private int[] distTo[];	// distTo[v] = number of edges in shortest s-v path
		
		public BreadthFirstSearch(Graph g, int s)
		{
			marked = new bool[g.V];
			edgeTo = new int[g.V];
			distTo = new int[g.V];
			
			bfs(g, s);
		}
		
		private void bfs(Graph g, int s)
		{
			Queue<int> q = new Queu<int>();
			
			for(int v = 0; v < g.V; v++) distTo[v] = INFINITY;
			
			distTo[s] = 0;
			marked[s] = true;
			q.Enqueue(s);
			
			while(queue.Count > 0)
			{
				int v = q.Dequeue();
				foreach(int w in g.Adj(v))
				{
					if(!marked[w])
					{
						edgeTo[w] = v;
						distTo[w] = distTo[v]+1;
						marked[w] = true;
						queue.Enqueue(w);
					}
				}
			}
		}
	}
}