using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class EmployeeTypeRepositoryAsync : BaseRepositoryAsync<EmployeeType>, IEmployeeTypeRepositoryAsync
    {
		public EmployeeTypeRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

