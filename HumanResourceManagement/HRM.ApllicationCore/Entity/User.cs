using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Entity
{
	public class User
	{
		public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        public User()
		{
		}
	}
}

