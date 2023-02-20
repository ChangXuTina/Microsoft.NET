using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class RoleRepositoryAsync : BaseRepositoryAsync<Role>, IRoleRepositoryAsync
    {
		public RoleRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

