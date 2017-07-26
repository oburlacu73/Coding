using Algorithms.DataStructures;
using System;

namespace Algorithms.Algorithms
{
	public class Evaluate
	{
		
		public Evaluate(string expr)
		{
			Stack<string> ops = new Stack<string>();
			Stack<double> vals = new Stack<double>();
			
			// split the expression by spaces
			string[] elements = expr.Split(' ');
			
			foreach(string s in elements)
			{
				if(s == "(")
				{
					continue; // ignore left parenthesis
				}
				else if(s=="+" || s=="-" || s=="*" || s=="/")
				{
					ops.Push(s);
				}
				else if(s == ")")
				{
					String op = ops.Pop();
					
					if(op=="-") vals.Push(vals.Pop()-vals.Pop());
					else if(op=="+") vals.Push(vals.Pop()+vals.Pop());
					else if(op=="*") vals.Push(vals.Pop()*vals.Pop());
					else if(op=="/") vals.Push(vals.Pop()/vals.Pop());
				}
				else
				{
					vals.Push(double.Parse(s));
				}
			}
		}
	}
}