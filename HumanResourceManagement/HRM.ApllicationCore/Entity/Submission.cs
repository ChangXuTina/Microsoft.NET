using System;
namespace HRM.ApllicationCore.Entity
{
	public class Submission
	{
		public int id { get; set; }
		public int CandidateId { get; set; }
		public int JobRequirementId { get; set; }
		public DateTime AppliedOn { get; set; }

		//Navigational properties
		public Candidate Candidate { get; set; }
		public JobRequirement JobRequirement { get; set; }

        public Submission()
		{
		}

    }
}

