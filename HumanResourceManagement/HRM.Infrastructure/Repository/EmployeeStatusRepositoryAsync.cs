using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class EmployeeStatusRepositoryAsync : BaseRepositoryAsync<EmployeeStatus>, IEmployeeStatusRepositoryAsync
    {
		public EmployeeStatusRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

