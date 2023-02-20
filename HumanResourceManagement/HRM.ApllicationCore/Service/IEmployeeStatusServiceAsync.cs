using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IEmployeeStatusServiceAsync
	{
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model);
        Task<int> DeleteEmployeeStatusAsync(int id);
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id);
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync();

	}
}

