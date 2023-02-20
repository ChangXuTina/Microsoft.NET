using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	//request & response model
	public interface ICandidateServiceAsync
	{
		Task<int> AddCandidateAsync(CandidateRequestModel model);
		Task<int> UpdateCandidateAsync(CandidateRequestModel model);
		Task<int> DeleteCandidateAsync(int id);
		Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync();

    }
}

