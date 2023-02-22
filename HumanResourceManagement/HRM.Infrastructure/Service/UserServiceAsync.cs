using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class UserServiceAsync: IUserServiceAsync
	{
        private readonly IUserRepositoryAsync userRepositoryAsync;

        public UserServiceAsync(IUserRepositoryAsync _userRepositoryAsync)
		{
            userRepositoryAsync = _userRepositoryAsync;
        }

        public Task<int> AddUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                EmailId = model.EmailId,
                Password = model.Password
            };
            return userRepositoryAsync.InsertAsync(user);
        }

        public Task<int> DeleteUserAsync(int id)
        {
            return userRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsersAsync()
        {
            var result = await userRepositoryAsync.GetAllAsync();
            if(result != null)
            {
                return result.ToList().Select(x => new UserResponseModel()
                { Id = x.Id, EmailId = x.EmailId, Password = x.Password, Username = x.Username });
            }
            return null;
        }

        public async Task<UserResponseModel> GetUserByIdAsync(int id)
        {
            var result = await userRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new UserResponseModel()
                {
                    Id = result.Id,
                    EmailId = result.EmailId,
                    Password = result.Password,
                    Username = result.Username
                };
            }
            return null;
        }

        public Task<int> UpdateUserAsync(UserRequestModel model)
        {
            User user = new User()
            {
                Id = model.Id,
                Username = model.Username,
                EmailId = model.EmailId,
                Password = model.Password
            };
            return userRepositoryAsync.UpdateAsync(user);
        }
    }
}

