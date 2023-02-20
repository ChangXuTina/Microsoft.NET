using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IUserServiceAsync
	{
        Task<int> AddUserAsync(UserRequestModel model);
        Task<int> UpdateUserAsync(UserRequestModel model);
        Task<int> DeleteUserAsync(int id);
        Task<UserResponseModel> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseModel>> GetAllUsersAsync();

    }
}

