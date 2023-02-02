using System;

namespace OOPassignment
{
    public class Instructor : Person, IInstructorService
    {
        public Department department;
        private DateTime employStart; //3. Encapsulation
        private decimal salary { get; set; }
        List<string> IPersonService.address { get; set; }

        public Instructor(string name, Department department, DateTime employStart, DateTime birth)
        {
            this.name = name;
            this.department = department;
            this.employStart = employStart;
            this.birth = birth;
            department.addInstructor(this);
        }
        public override void behaviour()
        {
            Console.WriteLine("Grade exam");
        }

        public int CalculateAge()
        {
            age = calculateYearGap(birth);
            return age; // 4. Inheritance, base class method calculateYearGap()
        }

        public decimal CalculateBonus()
        {
            int workYear = calculateYearGap(employStart);  
            return (decimal) (workYear * 100 * 0.9);
        }

        public decimal CalculateSalary()
        {
            salary = 6000 + CalculateBonus();
            return salary;
        }

        public override void calculation(int num) // 5. Polymorphism
        {
            // calculate average salary per month
            Console.WriteLine(num / 12);
        }
    }
}

