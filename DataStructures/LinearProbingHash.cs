using System;
namespace Algorithms.DataStructures
{	public class LinearProbingHash<Key, Value> where Key : class, IComparable
    where Value : class
	{
		private const int INIT_CAPACITY = 16;
		private int n;	// number of key-value pairs
		private int m;	// hash table size
		private Key[] keys;
		private Value[] vals;
		
		// create an empty hash table - use 16 as default size
		public LinearProbingHash() : this(INIT_CAPACITY)
		{
		}
		
		// create linear probing hash table of given capacity
		public LinearProbingHash(int capacity)
		{
			m = capacity;
			keys = new Key[m];
			vals = new Value[m];
		}
		
		#region private helpers
		// has function for keys - returns value between 0 and M-1
		private int hash(Key key)
		{
			return (key.GetHashCode() & 0x7fffffff) % m;
		}
		
		// resize the hash table to given capacity by rehashing all of the keys
		private void resize(int capacity)
		{
			LinearProbingHash<Key,Value> temp = new LinearProbingHash<Key,Value>(capacity);
			
			for(int i = 0; i < m; i++)
			{
				if(keys[i] != null)
				{
					temp.Put(keys[i], vals[i]);
				}
			}
			
			keys = temp.keys;
			vals = temp.vals;
			m = temp.m;
		}
		#endregion
		
		#region Properties
		public int Size { get { return n; } }
		
		public bool IsEmpty { get{ return this.Size == 0; } }
		#endregion
		
		#region public functions
		public bool Contains(Key key)
		{
			for(int i = hash(key); keys[i] != null; i = (i+1)%m)
			{
				if(keys[i].Equals(key))
					return true;
			}
			
			return false;
		}
		
		public Value Get(Key key)
		{
			for(int i = hash(key); keys[i] != null; i = (i+1)%m)
			{
				if(keys[i].Equals(key))
					return vals[i];
			}
			
			return null;
		}
		
		public void Put(Key key, Value val)
		{
			// double the size if 50% full
			if( n >= m/2) resize(2*m);
			
			int i;
			for(i = hash(key); keys[i] != null; i = (i+1)%m)
			{
				if(keys[i].Equals(key)) 
				{
					vals[i] = val;
					return;
				}
			}
			
			keys[i] = key;
			vals[i] = val;
			n++;
		}
		
		public void Delete(Key key)
		{
			if(!Contains(key)) return;
			
			// find the position i of the key
			int i = hash(key);
			while(!key.Equals(keys[i]))
			{
				i = (i+1)%m;
			}
			
			// delete the key and associated value
			keys[i] = null;
			vals[i] = null;
			
			// rehash all the keys in the same cluster - we need to rehash from current position forward
			i = (i+1) % m;
			while(keys[i] != null)
			{
				// delete keys[i] and vals[i] and reinsert
				Key keyToRehash = keys[i];
				Value valToRehash = vals[i];
				keys[i] = null;
				vals[i] = null;
				n--;
				
				Put(keyToRehash, valToRehash);
				i = (i+1) % m;
			}

            n--;
			
			// halve size of array if it's 12.5% full or less
			if( n>0 && n <= m/8) resize(m/2);
		}
		#endregion
		
	}
}