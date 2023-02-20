using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class InterviewTypeRepositoryAsync : BaseRepositoryAsync<InterviewType>, IInterviewTypeRepositoryAsync
    {
		public InterviewTypeRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

