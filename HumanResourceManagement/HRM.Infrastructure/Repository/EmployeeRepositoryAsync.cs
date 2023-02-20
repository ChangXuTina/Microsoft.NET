using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class EmployeeRepositoryAsync : BaseRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
		public EmployeeRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

