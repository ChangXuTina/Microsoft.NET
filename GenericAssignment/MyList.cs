using System;
namespace GenericAssignment
{
	public class MyList<T>
	{
		private T[] list;
		private int capacity = 1024;
		private int size;

		public MyList()
		{
			list = new T[capacity];
		}

		public void Add(T element)
		{
			//check capacity
			if(capacity == size)
			{
				capacity = capacity * 2;
				T[] oldList = list;
				list = new T[capacity];
				oldList.CopyTo(list, 0);
			}

			list[size] = element;
            size++;
		}

		public T Remove(int index)
		{
			T removed = list[index];
			list[index] = default(T);
			return removed;	
		}

		public bool Contains(T element)
		{
			foreach(T ele in list)
			{
				if (ele.Equals(element))
				{
					return true;
				}
			}
			return false;
		}

		public void Clear()
		{
			for(int i = 0; i < size; i++)
			{
				list[i] = default(T);
			}
		}

		public void InsertAt(T element, int index)
		{
            if (capacity == size)
            {
                capacity = capacity * 2;
                T[] oldList = list;
                list = new T[capacity];
                oldList.CopyTo(list, 0);
            }
			size++;

            T prev = list[index];
			T curr = list[index + 1];
			for(int i = index + 1; i < size; i++)
			{
				curr = list[i];
				list[i] = prev;
				prev = curr;
			}
			list[index] = element;
        }

		public void DeletAt(int index)
		{
			for(int i = index; i < size - 1; i++)
			{
				list[i] = list[i + 1];
			}
		}

        public T Find(int index)
		{
			return list[index];
		}

		public void GetAllElement()
		{
			foreach(T ele in list) {
				Console.Write(ele + ",");
			}
		}
	}
}

