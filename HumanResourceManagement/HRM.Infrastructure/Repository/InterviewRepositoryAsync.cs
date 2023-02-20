using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class InterviewRepositoryAsync : BaseRepositoryAsync<Interview>, IInterviewRepositoryAsync
    {
		public InterviewRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

