using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Model.Request
{
	public class EmployeeStatusRequestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public EmployeeStatusRequestModel()
		{
		}
	}
}

