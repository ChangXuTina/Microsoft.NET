using System;
using Microsoft.EntityFrameworkCore;
using HRM.ApllicationCore.Entity;

namespace HRM.Infrastructure.Data
{
	// connection stream: work with sql database
	public class HRMDbContext: DbContext
	{
		public HRMDbContext(DbContextOptions<HRMDbContext> options):base(options) //pass db context option
		{
		}
		//DbSet -> table
		public DbSet<JobRequirement> JobRequirement { get; set; }
		public DbSet<JobCategory> JobCategory { get; set; }
		public DbSet<Candidate> Candidate { get; set; }
		public DbSet<Submission> Submission { get; set; }
		public DbSet<Interview> Interview { get; set; }
		public DbSet<InterviewType> InterviewType { get; set; }
		public DbSet<InterviewStatus> InterviewStatus { get; set; }
		public DbSet<Feedback> Feedback { get; set; }
		public DbSet<Employee> Employee { get; set; }
		public DbSet<EmployeeRole> EmployeeRole { get; set; }
		public DbSet<EmployeeType> EmployeeType { get; set; }
		public DbSet<EmployeeStatus> EmployeeStatus { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<Role> Role { get; set; }
		public DbSet<UserRole> UserRole { get; set; }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Employee>()
		//		.HasOne(e => e.Manager)
		//		.WithMany()
		//		.HasForeignKey(m => m.ManagerId)
		//		.OnDelete(DeleteBehavior.ClientNoAction);
		//}
	}
}

