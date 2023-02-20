using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IInterviewTypeServiceAsync
	{
        Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model);
        Task<int> DeleteInterviewTypeAsync(int id);
        Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id);
        Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypesAsync();

    }
}

