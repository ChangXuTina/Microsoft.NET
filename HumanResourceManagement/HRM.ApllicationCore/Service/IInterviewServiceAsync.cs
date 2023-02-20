using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IInterviewServiceAsync
	{
        Task<int> AddInterviewAsync(InterviewRequestModel model);
        Task<int> UpdateInterviewAsync(InterviewRequestModel model);
        Task<int> DeleteInterviewAsync(int id);
        Task<InterviewResponseModel> GetInterviewByIdAsync(int id);
        Task<IEnumerable<InterviewResponseModel>> GetAllInterviewsAsync();

    }
}

