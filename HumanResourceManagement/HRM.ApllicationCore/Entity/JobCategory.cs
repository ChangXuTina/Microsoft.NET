using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Entity
{
	public class JobCategory
	{
		public int Id { get; set; }
		[Required]
		[Column(TypeName = "varchar(20)")]
		public string Name { get; set; }
		public bool IsActive { get; set; }
        public JobCategory()
		{
		}
	}
}

