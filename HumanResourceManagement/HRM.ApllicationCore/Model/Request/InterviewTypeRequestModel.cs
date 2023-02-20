using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Request
{
	public class InterviewTypeRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "IsActive is required")]
        public bool IsActive { get; set; }

        public InterviewTypeRequestModel()
		{
		}
	}
}

