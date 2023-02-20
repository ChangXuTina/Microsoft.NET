using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Entity
{
	public class Role
	{
		public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }

        public Role()
		{
		}
	}
}

