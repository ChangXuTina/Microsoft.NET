using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class InterviewStatusRepositoryAsync : BaseRepositoryAsync<InterviewStatus>, IInterviewStatusRepositoryAsync
    {
		public InterviewStatusRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

