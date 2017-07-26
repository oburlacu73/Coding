using System;
using System.Collections.Generic;
namespace Algorithms.DataStructures
{
	public class BST<Key, Value> where Key : class, IComparable where Value : class
	{
		#region helper class
		private class Node
		{
			public Key key;		//sorted by key
			public Value val;	// associated data
			public Node left, right;
			public int rank;	// number of nodes in subtree
			
			public Node(Key key, Value val, int rank)
			{
				this.key = key;
				this.val = val;
				this.rank = rank;
			}
		}
		#endregion
		
		private Node root;
		
		// is the symbol table empty?
		public bool IsEmpty
		{
			get {return this.Size ==0;}
		}

		// returns the number of key-value pairs in BST
		public int Size
		{
			get { return this.size(root); }
		}
		
		// return the number of key-value pairs in the BST rooted at node
		private int size(Node node)
		{
			if(node == null) return 0;
			
			return node.rank;
		}
		
		/******************************************************************
		* Search BST for a given Key and return associated value if found,
		* return null if not found
		******************************************************************/
		// is there a key-value pair with the given key?
		public bool Contains(Key key)
		{
			return this.Get(key) != null;
		}
		
		// return value associated with the given key, or null if no such key exists
		public Value Get(Key key)
		{
			return get(root, key);
		}
		
		private Value get(Node x, Key key)
		{
			if(x==null) return null;
			int cmp = key.CompareTo(x.key);
			
			if      (cmp < 0) return get(x.left, key);
			else if (cmp > 0) return get(x.right, key);
			else			  return x.val;
		}
		
		// inserts a key value pair if key does not exists,
		// or updates the value if the key exists
		private Node put(Node x, Key key, Value val)
		{
			if(x==null) return new Node(key, val, 1);
			
			int cmp = key.CompareTo(x.key);
			
			if		(cmp < 0)	x.left	= put(x.left, key, val);
			else if	(cmp > 0)	x.right	= put(x.right, key, val);
			else				x.val	= val;
			
			x.rank = 1 + size(x.left) + size(x.right);
			
			return x;
		}
		

		#region Delete
	   /***********************************************************************
		*  Delete
		***********************************************************************/
		
		public void DeleteMin()
		{
			if(this.IsEmpty) throw new ApplicationException("Symbol table underflow");
			root = deleteMin(root);
		}
		
		private Node deleteMin(Node x)
		{
			if(x.left == null) return x.right;
			x.left = deleteMin(x.left);
			x.rank = 1 + size(x.left) + size(x.right);
			
			return x;
		}
		
		public void DeleteMax()
		{
			if(this.IsEmpty) throw new ApplicationException("Symbol table underflow");
			root = deleteMax(root);
		}

		private Node deleteMax(Node x)
		{
			if(x.right == null) return x.left;
			x.right = deleteMin(x.right);
			x.rank = 1 + size(x.left) + size(x.right);
			
			return x;
		}
		
		public void Delete(Key key)
		{
			this.root = this.delete(this.root, key);
		}
		
		private Node delete(Node x, Key key)
		{
			if(x==null) return null;
			
			int cmp = key.CompareTo(root.key);
			
			if		(cmp < 0)	x.left	= delete(x.left, key);
			else if	(cmp > 0)	x.right	= delete(x.right, key);
			else
			{
				if	(x.right == null) return x.left;
				if	(x.left == null) return x.right;
				
				// If we have both descendants we swap the node with min from right and delete the min
				Node t = x;
				x = min(x.right);
				x.right = deleteMin(t.right);
				x.left = t.left;
				
				x.rank = 1 + size(x.left) + size(x.right);
				
			}
            
            return x;
        }
		#endregion
		
		#region Min, max, floor and ceiling
		public Key Min()
		{
			if(this.IsEmpty)  return null;
			
			return min(root).key;
		}
		
		private Node min(Node x)
		{
			if( x.left == null ) 	return x;
			else					return min(x.left);
		}
		
		public Key Max()
		{
			if(this.IsEmpty)	return null;
			
			return max(root).key;
		}
		
		private Node max(Node x)
		{
			if(x.right == null)	return x;
			else				return max(x.right);
		}
		
		public Key Floor(Key key)
		{
			Node x = floor(root, key);
			
			if(x == null) return null;
			else return x.key;
		}
		
		private Node floor(Node x, Key key)
		{
			if(x == null) return null;
			
			int cmp = key.CompareTo(x.key);
			if (cmp == 0)	return x;
			if (cmp < 0)	return floor(x.left, key);
			
			Node t = floor(x.right, key);
			if(t != null) return t;
			else return x;
		}
		
	   public Key Ceiling(Key key) 
	   {
			Node x = ceiling(root, key);
			if (x == null) return null;
			else return x.key;
		}

		private Node ceiling(Node x, Key key) 
		{
			if (x == null) return null;
			int cmp = key.CompareTo(x.key);
			if (cmp == 0) return x;
			if (cmp < 0) 
			{ 
				Node t = ceiling(x.left, key); 
				if (t != null) return t;
				else return x; 
			} 
			
			return ceiling(x.right, key); 
		} 
		#endregion
		
		#region Rank and selection
		public Key Select(int k) 
		{
			if (k < 0 || k >= this.Size)  return null;
			Node x = select(root, k);
			return x.key;
		}

		// Return key of rank k. 
		private Node select(Node x, int k) 
		{
			if (x == null) return null; 
			int t = size(x.left); 
			if      (t > k) return select(x.left,  k); 
			else if (t < k) return select(x.right, k-t-1); 
			else            return x; 
		} 

		public int Rank(Key key) 
		{
			return rank(key, root);
		} 

		// Number of keys in the subtree less than key.
		private int rank(Key key, Node x) 
		{
			if (x == null) return 0; 
			int cmp = key.CompareTo(x.key); 
			if      (cmp < 0) return rank(key, x.left); 
			else if (cmp > 0) return 1 + size(x.left) + rank(key, x.right); 
			else              return size(x.left); 
		} 
		#endregion
		
		#region Range count and range search

		private void keys(Node x, Queue<Key> queue, Key lo, Key hi) 
		{ 
			if (x == null) return; 
			int cmplo = lo.CompareTo(x.key); 
			int cmphi = hi.CompareTo(x.key); 
			if (cmplo < 0) keys(x.left, queue, lo, hi); 
			if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.key); 
			if (cmphi > 0) keys(x.right, queue, lo, hi); 
		} 

		public int size(Key lo, Key hi) 
		{
			if (lo.CompareTo(hi) > 0) return 0;
			if (Contains(hi)) return Rank(hi) - Rank(lo) + 1;
			else              return Rank(hi) - Rank(lo);
		}


		// height of this BST (one-node tree has height 0)
		public int Height() { return Height(root); }
		
		private int Height(Node x) 
		{
			if (x == null) return -1;
			return 1 + Math.Max(Height(x.left), Height(x.right));
		}


		// level order traversal
		public IEnumerable<Key> LevelOrder()
		{
			Queue<Key> keys = new Queue<Key>();
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);
			while (!queue.IsEmpty) 
			{
				Node x = queue.Dequeue();
				if (x == null) continue;
				keys.Enqueue(x.key);
				queue.Enqueue(x.left);
				queue.Enqueue(x.right);
			}
			
            return keys;
		}
		#endregion
	}
}