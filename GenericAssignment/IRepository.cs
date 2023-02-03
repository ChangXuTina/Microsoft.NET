using System;
namespace GenericAssignment
{
	public interface IRepository<T>
	{
		public void Add(T item);
		public void Remove(T item);
		public void Save();
		public IEnumerable<T> GetAll();
		public T GetById(int id);
	}
}

