using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Request
{
	public class JobCategoryRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        public JobCategoryRequestModel()
		{
		}
	}
}

