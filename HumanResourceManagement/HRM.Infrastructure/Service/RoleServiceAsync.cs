using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class RoleServiceAsync: IRoleServiceAsync
	{
        private readonly IRoleRepositoryAsync roleRepositoryAsync;

        public RoleServiceAsync(IRoleRepositoryAsync _roleRepositoryAsync)
		{
            roleRepositoryAsync = _roleRepositoryAsync;
        }

        public Task<int> AddRoleAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Name = model.Name,
                Description = model.Description
            };
            return roleRepositoryAsync.InsertAsync(role);
        }

        public Task<int> DeleteRoleAsync(int id)
        {
            return roleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync()
        {
            var result = await roleRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new RoleResponseModel()
                { Id = x.Id, Name = x.Name, Description = x.Description });
            }
            return null;

        }

        public async Task<RoleResponseModel> GetRoleByIdAsync(int id)
        {
            var result = await roleRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new RoleResponseModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description
                };
            }
            return null;

        }

        public Task<int> UpdateRoleAsync(RoleRequestModel model)
        {
            Role role = new Role()
            {
                Name = model.Name,
                Description = model.Description
            };
            return roleRepositoryAsync.UpdateAsync(role);

        }
    }
}

