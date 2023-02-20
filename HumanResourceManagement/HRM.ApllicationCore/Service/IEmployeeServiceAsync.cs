using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IEmployeeServiceAsync
	{
        Task<int> AddEmployeeAsync(EmployeeRequestModel model);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel model);
        Task<int> DeleteEmployeeAsync(int id);
        Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeesAsync();

	}
}

