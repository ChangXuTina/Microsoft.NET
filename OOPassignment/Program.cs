// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace OOPassignment;

public class Program
{
    public static void Main()
    {
        //initialize course
        Course math = new Course("math");
        Course english = new Course("english");
        Course history = new Course("history");

        //initialize department
        Department engineer = new Department(DateTime.Parse("Jan 1, 2022"), DateTime.Parse("Dec 31, 2022"));
        engineer.addCourse(math);
        engineer.addCourse(english);
        engineer.addCourse(history);

        //initialize instructors
        Instructor instructor1 = new Instructor(
            name: "Christine",
            department: engineer,
            employStart: DateTime.Parse("Jan 1, 2005"),
            birth: DateTime.Parse("Feb 2, 1980")
        );
        Instructor instructor2 = new Instructor(
            name: "Anne",
            department: engineer,
            employStart: DateTime.Parse("Jan 1, 2015"),
            birth: DateTime.Parse("Mar 3, 1995")
        );
        engineer.setHead(instructor1);

        //check department
        List<Course> offerCourse = engineer.offerCourse;
        foreach(Course course in offerCourse)
        {
            Console.WriteLine(course.name);
        }
        List<Instructor> instructors = engineer.instructors;
        foreach(Instructor instructor in instructors)
        {
            Console.WriteLine(instructor.name);
        }

        //calculate age and salary for instructor
        Console.WriteLine(instructor1.CalculateAge());
        Console.WriteLine(instructor2.CalculateAge());
        Console.WriteLine(instructor1.CalculateSalary());
        Console.WriteLine(instructor2.CalculateSalary());

        //initialize students
        Student student1 = new Student(name: "Tom", birth: DateTime.Parse("Jan 1, 2013"));
        Student student2 = new Student(name: "Jerry", birth: DateTime.Parse("Sep 19, 2013"));
        student1.takeCourse(math);
        student1.takeCourse(history);
        student2.takeCourse(math);
        student2.takeCourse(history);
        student2.takeCourse(english);

        //check course
        foreach (Student student in math.enrolledStudent)
        {
            Console.WriteLine(student.name);
        }
        foreach (Student student in english.enrolledStudent)
        {
            Console.WriteLine(student.name);
        }
        foreach (Student student in history.enrolledStudent)
        {
            Console.WriteLine(student.name);
        }

        //calculate GPA for students
        student1.calculation(100);
        student1.calculation(254);
    }
}

