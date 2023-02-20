using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Request
{
	public class FeedbackRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "InterviewId is required")]
        public int InterviewId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "ABBR is required")]
        public string ABBR { get; set; }

        public FeedbackRequestModel()
		{
		}
	}
}

