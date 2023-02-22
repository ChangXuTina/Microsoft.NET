using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Request
{
	public class SubmissionRequestModel
	{
        public int id { get; set; }
        [Required(ErrorMessage = "CandidateId is required")]
        public int CandidateId { get; set; }
        [Required(ErrorMessage = "JobRequirementId is required")]
        public int JobRequirementId { get; set; }
        [Required(ErrorMessage = "AppliedOn is required")]
        public DateTime AppliedOn { get; set; }

        public SubmissionRequestModel()
		{
		}
	}
}

