using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Model.Request
{
	public class JobRequirementRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        public JobRequirementRequestModel()
		{
		}
	}
}

