using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class FeedbackRepositoryAsync : BaseRepositoryAsync<Feedback>, IFeedbackRepositoryAsync
    {
		public FeedbackRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

