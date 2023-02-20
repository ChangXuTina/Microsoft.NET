using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IUserRoleServiceAsync
	{
        Task<int> AddUserRoleAsync(UserRoleRequestModel model);
        Task<int> UpdateUserRoleAsync(UserRoleRequestModel model);
        Task<int> DeleteUserRoleAsync(int id);
        Task<UserRoleResponseModel> GetUserRoleByIdAsync(int id);
        Task<IEnumerable<UserRoleResponseModel>> GetAllUserRolesAsync();

    }
}

