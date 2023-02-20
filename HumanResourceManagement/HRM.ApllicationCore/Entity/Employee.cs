using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Entity
{
	public class Employee
	{
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        public DateTime DOB { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string SSN { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CurrentAddress { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeStatusId { get; set; }        

        public EmployeeRole EmployeeRole { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public Employee()
		{
		}
	}
}

