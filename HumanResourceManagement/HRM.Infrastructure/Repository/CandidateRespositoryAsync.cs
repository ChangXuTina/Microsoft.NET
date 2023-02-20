using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class CandidateRespositoryAsync:BaseRepositoryAsync<Candidate>, ICandidateRepositoryAsync
    {
		public CandidateRespositoryAsync(HRMDbContext _context):base(_context)
		{
		}
    }
}

