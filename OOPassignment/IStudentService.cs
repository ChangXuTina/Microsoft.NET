using System;
namespace OOPassignment
{
	public interface IStudentService: IPersonService
	{
		public void takeCourse(Course course);
	}
}

