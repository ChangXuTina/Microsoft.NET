using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface ISubmissionServiceAsync
	{
        Task<int> AddSubmissiontAsync(SubmissionRequestModel model);
        Task<int> UpdateSubmissionAsync(SubmissionRequestModel model);
        Task<int> DeleteSubmissionAsync(int id);
        Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id);
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionsAsync();

	}
}

