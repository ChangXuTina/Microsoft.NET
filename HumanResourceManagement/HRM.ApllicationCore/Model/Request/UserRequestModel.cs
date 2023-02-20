using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Model.Request
{
	public class UserRequestModel
	{
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }

        public UserRequestModel()
		{
		}
	}
}

