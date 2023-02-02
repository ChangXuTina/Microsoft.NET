using System;
namespace OOPassignment
{
    public abstract class Person
    {
        public string name;
        public int age;
        public DateTime birth;
        public abstract void behaviour();
        public virtual void calculation(int num)
        {
            Console.WriteLine(num);
        }
        public void sleep()
        {
            Console.WriteLine("zzz");
        }
        public int calculateYearGap(DateTime start)
        {
            var today = DateTime.Today;
            var gap = today.Year - start.Year;
            if (start.Date > today.AddYears(-age)) age--;
            return gap;

        }
    }
}

