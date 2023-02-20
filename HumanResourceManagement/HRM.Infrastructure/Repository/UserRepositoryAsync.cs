﻿using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Repository;
using HRM.Infrastructure.Data;

namespace HRM.Infrastructure.Repository
{
	public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
		public UserRepositoryAsync(HRMDbContext _context) : base(_context)
        {
		}
	}
}

