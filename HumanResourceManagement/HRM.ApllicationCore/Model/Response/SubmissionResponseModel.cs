using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Response
{
	public class SubmissionResponseModel
	{
        public int id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequredmentId { get; set; }
        public DateTime AppliedOn { get; set; }

        public SubmissionResponseModel()
		{
		}
	}
}

