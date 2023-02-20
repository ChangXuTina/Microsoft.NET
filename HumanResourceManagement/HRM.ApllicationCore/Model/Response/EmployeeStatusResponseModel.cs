using System;
namespace HRM.ApllicationCore.Model.Response
{
	public class EmployeeStatusResponseModel
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public EmployeeStatusResponseModel()
		{
		}
	}
}

