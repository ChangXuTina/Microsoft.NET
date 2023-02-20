using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IRoleServiceAsync
	{
        Task<int> AddRoleAsync(RoleRequestModel model);
        Task<int> UpdateRoleAsync(RoleRequestModel model);
        Task<int> DeleteRoleAsync(int id);
        Task<RoleResponseModel> GetRoleByIdAsync(int id);
        Task<IEnumerable<RoleResponseModel>> GetAllRolesAsync();

    }
}

