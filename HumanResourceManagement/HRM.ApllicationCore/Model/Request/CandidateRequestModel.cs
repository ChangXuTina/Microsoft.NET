using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Model.Request
{
	public class CandidateRequestModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }

        public CandidateRequestModel()
		{

        }
    }
}

