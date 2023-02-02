using System;
namespace OOPassignment
{
	public class Course: ICourseService
    {
		public string name;
		public List<Student> enrolledStudent;
		public Course(string name)
		{
			this.name = name;
			enrolledStudent = new List<Student>();
		}

        public void addStudentToCourse(Student student)
        {
			enrolledStudent.Add(student);
        }
    }
}

