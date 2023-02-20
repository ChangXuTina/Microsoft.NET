using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class EmployeeStatusServiceAsync: IEmployeeStatusServiceAsync
    {
        private readonly IEmployeeStatusRepositoryAsync employeeStatusRepositoryAsync;

        public EmployeeStatusServiceAsync(IEmployeeStatusRepositoryAsync _employeeStatusRepositoryAsync)
		{
            employeeStatusRepositoryAsync = _employeeStatusRepositoryAsync;
        }

        public Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeStatusRepositoryAsync.InsertAsync(employeeStatus);
        }

        public Task<int> DeleteEmployeeStatusAsync(int id)
        {
            return employeeStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync()
        {
            var result = await employeeStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new EmployeeStatusResponseModel()
                { Id = x.Id, Description = x.Description, IsActive = x.IsActive, Title = x.Title });
            }
            return null;
        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
        {
            var result = await employeeStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new EmployeeStatusResponseModel()
                {
                    Id = result.Id,
                    Description = result.Description,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;

        }

        public Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            EmployeeStatus employeeStatus = new EmployeeStatus()
            {
                Title = model.Title,
                Description = model.Description,
                IsActive = model.IsActive
            };
            return employeeStatusRepositoryAsync.UpdateAsync(employeeStatus);
        }
    }
}

