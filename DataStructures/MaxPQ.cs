using System;
namespace Algorithms.DataStructures
{
	public class MaxPQ
	{
		private int[] pq; 	// store items at indices 1 to N
		private int N;		// number of items on priority queue

		/**
		 * Initializes an empty priority queue with the given initial capacity.
		 * @param initCapacity the initial capacity of the priority queue
		 */
		public MaxPQ(int capacity)
		{
			pq = new int[capacity+1];
			N = 0;
		}
		 /**
		 * Initializes an empty priority queue.
		 */
		public MaxPQ() : this(1)
		{
		}

		/**
		 * Initializes a priority queue from the array of keys.
		 * Takes time proportional to the number of keys, using sink-based heap construction.
		 * @param keys the array of keys
		 */
		public MaxPQ(int[] keys) 
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
		
	   /**
		 * Returns a largest key on the priority queue.
		 * @return a largest key on the priority queue
		 * @throws java.util.NoSuchElementException if the priority queue is empty
		 */
		public int max() {
			if (IsEmpty) throw new ApplicationException("Priority queue underflow");
			return pq[1];
		}
	
	   // helper function to double the size of the heap array
		private void resize(int capacity) 
		{
			//assert capacity > N;
			int[] temp = new int[capacity];
			for (int i = 1; i <= N; i++) temp[i] = pq[i];
			pq = temp;
		}
		
		/**
		 * Adds a new key to the priority queue.
		 * @param x the new key to add to the priority queue
		 */
		 public void insert(int x)
		 {
			// double the size of the array if necessary
			if( N > pq.Length -1) resize(2*pq.Length);
			
			// add x, and move it up as necessary to maintain heap invariant
			pq[++N] = x;
			swim(N);
		 }

		 /**
		 * Removes and returns a largest key on the priority queue.
		 * @return a largest key on the priority queue
		 */
		 public int DeleteMax()
		 {
			if (IsEmpty) throw new ApplicationException("Priority queue underflow");
			
			int max = pq[1];
			exch(1, N--);
			sink(1);
			pq[N+1] = 0;
			
			return max;
		 }
	
	/***********************************************************************
    * Helper functions to restore the heap invariant.
    **********************************************************************/

		private void swim(int k)
		{
			while(k>1 && pq[k/2] < pq[k])
			{
				exch(k, k/2);
				k = k/2;
			}
		}
	
		private void sink(int k)
		{
			while(2*k <= N)
			{
				int j = 2*k;
				if( j < N && pq[j] < pq[j+1]) j++;
				
				if( pq[k] < pq[j] ) break;
				
				exch(k,j);
				k = j;
			}
		}
		
		private void exch(int i, int j) 
		{
			int swap = pq[i];
			pq[i] = pq[j];
			pq[j] = swap;
		}

	}
}