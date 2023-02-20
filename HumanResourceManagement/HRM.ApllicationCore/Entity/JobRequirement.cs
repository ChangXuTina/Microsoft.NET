using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRM.ApllicationCore.Entity
{
	public class JobRequirement
	{
        public int Id { get; set; }
		[Required]
		[Column(TypeName = "varchar(100)")]
		public string Title { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string? Description { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? JobLocation { get; set; }
		public int? TotalPositions { get; set; }
		public DateTime? PostingDate { get; set; }
		public DateTime? ClosingDate { get; set; }
		public int? JobCategoryId { get; set; }
		public bool IsActive { get; set; }

		//Create a navigational property to create FK, will not be used to create a column, it is used to create relation
		public JobCategory JobCategory { get; set; }
        public JobRequirement()
		{		
		}
	}
}

