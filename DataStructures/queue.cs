/*************************************************************************
 *
 *  A generic queue, implemented using a linked list.
 *  Each queue element is of type Item.
 *
 *
 *************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.DataStructures
{
	public class Queue<Item> :IEnumerable<Item>, IEnumerator<Item> where Item : class
	{
		// helper linked list class
		private class Node
		{
			public Item Item { get; set;}
			public Node Next { get; set; }

        }
		
		private int N; //size of the queue
		private Node first; //beginning of the queue
		private Node last; //end of the queue
        private Node _current;
        private int _index;
		
		public Queue()
		{
			this.first = null;
			this.last = null;
			this.N = 0;
		}
		
		/**
		 * Is this queue empty?
		 * @return true if this queue is empty; false otherwise
		 */
		public bool IsEmpty 
		{
			get { return this.first == null; }
		}
		
		/// Returns the numbers of items in the queue
		public int Size
		{
			get { return this.N; }
		}
		
		///Adds the item to this queue.
		public void Enqueue(Item item)
		{
			Node oldLast = this.last;
			
			this.last = new Node()
				{
					Item = item,
					Next = null
				};
			
			if( this.IsEmpty )
			{
				this.first = this.last;
			}
			else
			{
				oldLast.Next = this.last;
			}
			
			this.N++;
		}
		
		//Removes and returns the item on this queue that was least recently added.
		public Item Dequeue() 
		{
			if (this.IsEmpty) 
			{
				throw new ApplicationException("Queue underflow");
			}
			
			Item item = this.first.Item;	// save item to return
			this.first = this.first.Next;	// delete first node
			N--;
		
			if (this.IsEmpty) this.last = null;
			
			return item;					// return the saved item
		}
	
		//Returns (but does not remove) the item most recently added to this queue.
		public Item Peek()
		{
			if (this.IsEmpty) 
			{
				throw new ApplicationException("Queue underflow");
			}

            return this.first.Item;
		}
		
		// Returns the sequence of items in the queue in LIFO order, separated by spaces.
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			
			Node current = this.first;
			while(current != null)
			{
				string valToAppend = current.Item != null ?  current.Item.ToString() : string.Empty;
				sb.Append(valToAppend + " ");
				current = current.Next;
			}

            return sb.ToString();
		}

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            // we are at the end of enumeration
            if (this._index == -2)
            {
                return false;
            }

            this._index++;
            if (this._index == this.Size)
            {
                this._index = -2;
                this._current = null;
                return false;
            }

            this._current = this._current != null ? this._current.Next : this.first;
            return true;
        }

        public void Reset()
        {
            this._index = -1;
            this._current = null;
        }

        Item IEnumerator<Item>.Current
        {
            get
            {
                if (this._index < 0)
                {
                    if (this._index == -1)
                    {
                        throw new InvalidOperationException("Enum not started. Need to call MoveNext before accesing this");
                    }
                    else
                    {
                        throw new InvalidOperationException("Enum ended");
                    }
                }

                return this._current.Item;
            }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return ((IEnumerator<Item>)this).Current; }
        }

        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            return this;
        }
    }
}