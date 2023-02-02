using System;
namespace OOPassignment
{
	public class Department: IDepartmentService
	{
		public Instructor head;
		public DateTime schoolYearStart;
		public DateTime schoolYearEnd;
		public List<Course> offerCourse;
		public List<Instructor> instructors;

		public Department(DateTime schoolYearStart, DateTime schoolYearEnd)
		{
			schoolYearStart = schoolYearStart;
			schoolYearEnd = schoolYearEnd;
			offerCourse = new List<Course>();
			instructors = new List<Instructor>();
		}

        public void addCourse(Course course)
        {
            offerCourse.Add(course);
        }

        public void addInstructor(Instructor instructor)
        {
            instructors.Add(instructor);
        }

        public void setHead(Instructor instructor)
        {
            head = instructor;
        }
    }
}

