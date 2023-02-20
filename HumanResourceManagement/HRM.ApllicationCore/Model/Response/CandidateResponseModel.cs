using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Response
{
	public class CandidateResponseModel
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }

        public CandidateResponseModel()
		{
		}
	}
}

