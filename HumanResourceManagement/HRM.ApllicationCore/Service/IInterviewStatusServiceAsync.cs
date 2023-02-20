using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IInterviewStatusServiceAsync
	{
        Task<int> AddInterviewStatusAsync(InterviewStatusRequestModel model);
        Task<int> UpdateInterviewStatusAsync(InterviewStatusRequestModel model);
        Task<int> DeleteInterviewStatusAsync(int id);
        Task<InterviewStatusResponseModel> GetInterviewStatusByIdAsync(int id);
        Task<IEnumerable<InterviewStatusResponseModel>> GetAllInterviewStatusAsync();

    }
}

