using System;

namespace OOPassignment
{
    public class Student : Person, IStudentService
    {
        public List<Course> takedCourse;
        private int courseNum; //3. Encapsulation        
        public List<string> address { get; set; }

        public Student(string name, DateTime birth)
        {
            this.name = name;
            this.birth = birth;
            this.takedCourse = new List<Course>();
        }

        public override void behaviour()
        {
            Console.WriteLine("Take exams");
        }
        public override void calculation(int num) // 5. Polymorphism
        {
            // calculate average grade
            courseNum = takedCourse.Count();
            Console.WriteLine(num / courseNum);
        }

        public void takeCourse(Course course)
        {
            takedCourse.Add(course);
            course.addStudentToCourse(this);
        }

        public int CalculateAge()
        {
            age = calculateYearGap(birth);
            return age; // 4. Inheritance, base class method calculateYearGap()
        }

        public decimal CalculateSalary()
        {
            return 0m; // no salary for student
        }
    }

}

