using System;
namespace HRM.ApllicationCore.Model.Response
{
	public class EmployeeResponseModel
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public DateTime DOB { get; set; }
        public string SSN { get; set; }
        public string CurrentAddress { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeStatusId { get; set; }
        public int ManagerId { get; set; }

        public EmployeeResponseModel()
		{
		}
	}
}

