using System;
using System.ComponentModel.DataAnnotations;

namespace HRM.ApllicationCore.Model.Response
{
	public class UserResponseModel
	{
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public UserResponseModel()
		{
		}
	}
}

