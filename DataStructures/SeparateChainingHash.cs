using System;
using System.Collections;
using System.Collections.Generic;
namespace Algorithms.DataStructures
{	public class SeparateChainingHash<Key, Value> where Key : IComparable
	{
		private const int INIT_CAPACITY = 4;
		private int n;	// number of key-value pairs
		private int m;	// hash table size
		private System.Collections.Generic.Dictionary<Key,Value>[] st;	//array of linked -list symbol stables
		
		// create separate chaining hash table
		public SeparateChainingHash() : this(INIT_CAPACITY)
		{
		}
		
		public SeparateChainingHash(int capacity)
		{
			this.m = capacity;
			st = new Dictionary<Key,Value>[capacity];
			for(int i = 0; i < capacity; i++)
			{
				st[i] = new Dictionary<Key,Value>();
			}
		}
		
		// resize the hash table to have the given number of chains b rehashing all of the keys
		private void resize(int chains)
		{
			SeparateChainingHash<Key,Value> temp = new SeparateChainingHash<Key,Value>(chains);
			for(int i = 0; i< this.m; i++)
			{
				foreach(Key key in st[i].Keys)
				{
					temp.Put(key, st[i][key]);
				}
			}
			
			this.m = temp.m;
            this.n = temp.n;
			this.st = temp.st;
		}
		
		// Hash value between 0 and M-1
		private int hash(Key key)
		{
			return (key.GetHashCode() & 0x7fffffff) % m;
		}
		
		// return the numbers of key value pairs in the hashtable
		public int Size { get { return this.n; } }
		
		// is the symbol table empty?
		public bool IsEmpty { get{ return this.Size == 0; } }
		
		// is the key in the symbol table?
		public bool Contains(Key key)
		{
			int i = hash(key);
			
			return st[i].ContainsKey(key);
		}
		
		// return the value associated with key, null if no such key
		public Value Get(Key key)
		{
			int i = hash(key);
			return st[i][key];
		}
		
		// insert key-value pair into table
		public void Put(Key key, Value val)
		{
			// double table size if average length of list >= 10
			if( n >= 10*m) resize(2*m);
			
			int i = hash(key);
			
			if(!st[i].ContainsKey(key)) n++;
			st[i][key]= val;
		}
		
		// delete key (and associated value) if key is in the table
		public void Delete(Key key)
		{
			int i = hash(key);
			if(st[i].ContainsKey(key)) n--;
			st[i].Remove(key);
			
			// halve table size if average length of list <= 2
			if(m > INIT_CAPACITY && n <= 2*m) resize(m/2);
		}
	}
}