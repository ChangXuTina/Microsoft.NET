using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class EmployeeRoleRepositoryAsync : BaseRepositoryAsync<EmployeeRole>, IEmployeeRoleRepositoryAsync
    {
		public EmployeeRoleRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

