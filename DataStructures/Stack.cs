/*************************************************************************
 *
 *  A generic stack, implemented using a singly-linked list.
 *  Each stack element is of type Item.
 *
 *
 *************************************************************************/
using System;
using System.Text;

namespace Algorithms.DataStructures
{
	public class Stack<Item>
	{
		// helper linked list class
		private class Node
		{
			public Item Item { get; set;}
			public Node Next { get; set; }
		}
		
		private int N; //size of the stack
		private Node first; //top of the stack
		
		public Stack()
		{
			this.first = null;
			this.N = 0;
		}
		
		/**
		 * Is this stack empty?
		 * @return true if this stack is empty; false otherwise
		 */
		public bool IsEmpty 
		{
			get { return this.first == null; }
		}
		
		/// Returns the numbers of items in the stack
		public int Size
		{
			get { return this.N; }
		}
		
		///Adds the item to this stack.
		public void Push(Item item)
		{
			Node oldFirst = this.first;
			
			this.first = new Node()
				{
					Item = item,
					Next = oldFirst
				};
			this.N++;
		}
		
		//Removes and returns the item most recently added to this stack.
		public Item Pop() 
		{
			if (this.IsEmpty) 
			{
				throw new ApplicationException("Stack underflow");
			}
			
			Item item = this.first.Item;	// save item to return
			this.first = this.first.Next;	// delete first node
			N--;
		
			return item;					// return the saved item
		}
	
		//Returns (but does not remove) the item most recently added to this stack.
		public Item Peek()
		{
			if (this.IsEmpty) 
			{
				throw new ApplicationException("Stack underflow");
			}

            return this.first.Item;
		}
		
		// Returns the sequence of items in the stack in LIFO order, separated by spaces.
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
	}
}