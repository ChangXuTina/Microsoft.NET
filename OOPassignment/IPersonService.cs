using System;
namespace OOPassignment
/*
	Person
	Calculate Age of the Person
	Calculate the Salary of the person, Use decimal for salary
	Salary cannot be negative number
	Can have multiple Addresses, should have method to get addresses
*/
{
	public interface IPersonService
	{
		public List<string> address { get; set; }
		public int CalculateAge();
		public decimal CalculateSalary();
	}
}

