using System;
using System.Diagnostics;
namespace Algorithms.DataStructures
{	public class RebBlackBST<Key, Value> where Key : IComparable where Value : class
	{
		private const bool RED = true;
		private const bool BLACK = false;
	
		private Node root; 	// root of the BST
		
		#region helper class

		private class Node
		{
			public Key key;		//sorted by key
			public Value val;	// associated data
			public Node left, right;
			public int rank;	// number of nodes in subtree
			public bool color;	// color of parent link
			
			public Node(Key key, Value val, bool color, int rank)
			{
				this.key = key;
				this.val = val;
				this.color = color;
				this.rank = rank;
			}
		}
		#endregion
		
		#region Node helper methods
		// is the node x red, false of x is null
		private bool isRed(Node x)
		{
			if(x == null) return false;
			
			return (x.color == RED);
		}
		
		// number of nodes in subtree rooted at x; 0 if x is null
		private int size(Node x)
		{
			if(x == null) return 0;
			
			return x.rank;
		}
		#endregion

		#region Size methods
		public int Size
		{
			get { return size(root); }
		}
		
		public bool IsEmpty
		{
			get { return root == null; }
		}
		#endregion
		
		#region Standard BST search
		// value associated with the given key; null if no such key
		public Value Get(Key key)
		{
			return get(root, key);
		}
		
		private Value get(Node x, Key key)
		{
			while( x != null)
			{
				int cmp = key.CompareTo(x.key);
				if		(cmp < 0)	x = x.left;
				else if	(cmp > 0)	x = x.right;
				else 				return x.val;
			}
			
			return null;
		}
		
		public bool Contains(Key key)
		{
			return contains(root, key);
		}

		private bool contains(Node x, Key key)
		{
			while( x != null)
			{
				int cmp = key.CompareTo(x.key);
				if		(cmp < 0)	x = x.left;
				else if	(cmp > 0)	x = x.right;
				else 				return true;
			}
			
			return false;
		}
		
		#endregion

		#region Red-black insertion
		public void Put(Key key, Value val)
		{
			root = put(root, key, val);
			root.color = BLACK;
		}
		
		private Node put(Node h, Key key, Value val)
		{
			if(h == null) return new Node(key, val, RED, 1);
			
			int cmp = key.CompareTo(h.key);
			if		(cmp < 0)	h.left	= put(h.left, key, val);
			else if	(cmp > 0)	h.right	= put(h.right, key, val);
			else				h.val	= val;
			
			// fix-up any right-leaning links
			if(isRed(h.right) && !isRed(h.left))	h = rotateLeft(h);
			if(isRed(h.left) && isRed(h.left.left))	h = rotateRight(h);
			if(isRed(h.left) && isRed(h.right))		flipColors(h);
			
			h.rank = 1 + size(h.left) + size(h.right);
			
			return h;
		}
		#endregion
		
		#region Red-black tree helper functions
		// rotate right
		private Node rotateRight(Node h)
		{
			Debug.Assert( h!= null && isRed(h.left));
			Node x = h.left;
			h.left = x.right;
			x.right = h;
			x.color = h.color;
            h.color = RED;
            
            return x;
		}
		
		// rotate left
		private Node rotateLeft(Node h)
		{
            Debug.Assert(h != null && isRed(h.right));
			Node x = h.right;
			h.right = x.left;
			x.left = h;
			x.color = h.color;
			h.color = RED;
			
			return x;
		}
		
		// precondition: two children are red, node is black
		// postcondition: two children are black, node is red
		private void flipColors(Node h)
		{
            Debug.Assert(h != null && !isRed(h) && isRed(h.left) && isRed(h.right));
			h.color = RED;
			h.left.color = BLACK;
			h.right.color = BLACK;
		}
		#endregion
	}
}