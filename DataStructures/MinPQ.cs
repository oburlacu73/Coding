using System;
namespace Algorithms.DataStructures
{
	public class MinPQ
	{
		private int[] pq; 	// store items at indices 1 to N
		private int N;		// number of items on priority queue

		/**
		 * Initializes an empty priority queue with the given initial capacity.
		 * @param initCapacity the initial capacity of the priority queue
		 */
		public MinPQ(int capacity)
		{
			pq = new int[capacity+1];
			N = 0;
		}
		 /**
		 * Initializes an empty priority queue.
		 */
		public MinPQ() : this(1)
		{
		}
			/**
		 * Initializes a priority queue from the array of keys.
		 * Takes time proportional to the number of keys, using sink-based heap construction.
		 * @param keys the array of keys
		 */
		public MinPQ(int[] keys) 
		{
			N = keys.Length;
			pq = new int[keys.Length + 1]; 
			for (int i = 0; i < N; i++)
				pq[i+1] = keys[i];  
			for (int k = N/2; k >= 1; k--)
				sink(k);
		}
		
		public bool IsEmpty
		{
			get { return N == 0; }
		}
		
		public int Size { get { return N; } }
		
		public int max()
		{
			if(this.IsEmpty) throw new ApplicationException("Priority queue underflow");
			
			return pq[1];
		}
		
		public void Insert(int x)
		{
			if(N == pq.Length-1) resize(2*pq.Length);
			
			pq[++N] = x;
			swim(N);
		}
		
		public int DeleteMin()
		{
			if(this.IsEmpty) throw new ApplicationException("Priority queue underflow");
			
			exch(1,N);
			int min = pq[N--];
			sink(1);
			
			if( N > 0 && N == (pq.Length-1)/4) resize (pq.Length*2);
			
			return min;

		}
		
		#region private helpers
		// helper function to double the size of the heap array
		private void resize(int capacity) 
		{
			//assert capacity > N;
			int[] temp = new int[capacity];
			for (int i = 1; i <= N; i++) temp[i] = pq[i];
			pq = temp;
		}

		private void swim(int k)
		{
			while(k>1 && pq[k/2] > pq[k])
			{
				exch(k,k/2);
                k = k / 2;
			}
		}
		
		private void sink(int k)
		{
			while(2*k <= N)
			{
				int j = 2*k;
				
				// pick the smallest descendant
				if(j<N && pq[j] > pq[j+1]) j++;
				
				if( pq[k] < pq[j] ) break;

				exch(k,j);
				k=j;
			}
		}
		
		private void exch(int i, int j)
		{
			int swap = pq[i];
			pq[i] = pq[j];
			pq[j] = swap;
		}
		#endregion
	}
}