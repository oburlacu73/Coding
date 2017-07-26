using System;
namespace Algorithms.DataStructures
{
/*5.Stack + max. Create a data structure that efficiently supports the stack operations (pop and push)
 and also return the maximum element. Assume the elements are integers or real 
 so that you can compare them. */
	
	public class StackMax<Item> where Item : IComparable
	{
		public Stack<Item> elements; // stack holding the elements
		public Stack<Item> max;		// stack holding max
		
		public StackMax()
		{
			elements = new Stack<Item>();
			max = new Stack<Item>();
		}
	
		public bool IsEmpty 
		{
			get { return this.elements.IsEmpty; }
		}
		
		/// Returns the numbers of items in the stack
		public int Size
		{
			get { return this.elements.Size; }
		}
		
		///Adds the item to this stack.
		public void Push(Item item)
		{
			if(this.max.Peek().CompareTo(item) <= 0)
			{
				this.max.Push(item);
			}
			
			this.elements.Push(item);
		}
		
		//Removes and returns the item most recently added to this stack.
		public Item Pop() 
		{
			Item retValue = this.elements.Pop();
			
			if( retValue.CompareTo(this.max.Peek()) == 0)
			{
				this.max.Pop(); // remove top of the max stack
			}
			return retValue;		// pop the top of elements stack
		}
	
		public Item Max() 
		{
			return this.max.Peek();	 // return the current Max
		}

	}
}