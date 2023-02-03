using System;
namespace GenericAssignment
{
	public class MyStack<T>
	{
		private int size;
		private List<T> stack;
		public T top;

		public MyStack()
		{
			stack = new List<T>();
		}
		public void Push(T element)
		{
			top = element;
			stack.Add(element);
			size++;
		}
		public int Count()
		{
			return size;
		}
		public T Pop()
		{
			stack.RemoveAt(size - 1);
			size--;
			T oldTop = top;
			top = stack[size - 1];
			return oldTop;
		}
	}
}

