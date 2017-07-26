using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
	public class Graph
	{
		public int V { get; private set; }		// number of vertices
		
		private int e;
		public int E { get{ return e; } }		// number of edges
		private List<int>[] adj; 				// adjacency list

		#region Constructors and initialization
		public Graph(int v)
		{
			if(v < 0) throw new ArgumentException("Number of vertices must be nonnegative");
			
			this.V = v;
			this.e = 0;
			
			adj = new List<int>[v];
			
			for(int i = 0; i < v; i++)
			{
				adj[i] = new List<int>();
			}
		}
		
		public Graph(Graph g)
		{
			this(g.V);
			this.e = g.E;
			
			for(int v = 0; v < g.V; v++)
			{
				adj[v] = new List<int>(g.adj[v]);
			}
		}
		#endregion
		
		public void AddEdge(int v, int w)
		{
			if( v < 0 || v >= V) throw new IndexOutOfBoundsException();
			if( w < 0 || w >= V) throw new IndexOutOfBoundsException();
			
			this.e++;
			adj[v].Add(w);
			adj[w].Add(v);
		}
		
		public IEnumerable<int> Adj(int v)
		{
			if( v < 0 || v >= V) throw new IndexOutOfBoundsException();
			return adj[v];
		}
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append( V + " vertices, " + E + " edges\n");
			
			for(int v = 0; v < V; v++)
			{
				sb.Append( v + ": ");
				foreach(int i in adv[v])
				{
					sb.Append(i + " ");
				}
				
				sb.Append(Enviroment.NewLine);
			}
			
			return sb.ToString();
		}
	}
}