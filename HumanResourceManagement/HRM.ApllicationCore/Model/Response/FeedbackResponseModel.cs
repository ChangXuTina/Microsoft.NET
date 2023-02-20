using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Response
{
	public class FeedbackResponseModel
	{
        public int Id { get; set; }
        public int InterviewId { get; set; }
        public string Description { get; set; }
        public string ABBR { get; set; }

        public FeedbackResponseModel()
		{
		}
	}
}

