using System;
namespace OOPassignment
{
	public interface IDepartmentService
	{
		public void addInstructor(Instructor instructor);
		public void addCourse(Course course);
		public void setHead(Instructor instructor);
	}
}

