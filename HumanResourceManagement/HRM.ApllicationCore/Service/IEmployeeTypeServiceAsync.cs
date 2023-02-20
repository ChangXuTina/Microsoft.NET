using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IEmployeeTypeServiceAsync
	{
        Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> DeleteEmployeeTypeAsync(int id);
        Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id);
        Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypesAsync();

	}
}

