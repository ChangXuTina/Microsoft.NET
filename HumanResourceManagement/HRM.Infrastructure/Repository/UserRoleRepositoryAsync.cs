using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class UserRoleRepositoryAsync : BaseRepositoryAsync<UserRole>, IUserRoleRepositoryAsync
    {
		public UserRoleRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

