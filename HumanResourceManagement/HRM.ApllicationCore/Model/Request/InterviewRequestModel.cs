using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApllicationCore.Entity;

namespace HRM.ApllicationCore.Model.Request
{
	public class InterviewRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "SubmissionId is required")]
        public int SubmissionId { get; set; }
        [Required(ErrorMessage = "InterviewDate is required")]
        public DateTime InterviewDate { get; set; }
        [Required(ErrorMessage = "InterviewRound is required")]
        public int InterviewRound { get; set; }
        [Required(ErrorMessage = "InterviewTypeId is required")]
        public int InterviewTypeId { get; set; }
        [Required(ErrorMessage = "InterviewStatusId is required")]
        public int InterviewStatusId { get; set; }
        [Required(ErrorMessage = "InterviewerId is required")]
        public int InterviewerId { get; set; }

        public InterviewRequestModel()
		{
		}
	}
}

