using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;

namespace HRM.Infrastructure.Service
{
	public class CandidateServiceAsync:ICandidateServiceAsync
	{
        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync)
		{
            candidateRepositoryAsync = _candidateRepositoryAsync;
        }

        public Task<int> AddCandidateAsync(CandidateRequestModel model) //candidate repository
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailId = model.EmailId,
                Mobile = model.Mobile
            };
            //return candidateRepositoryAsync.InsertAsync(candidate).Result;
            return candidateRepositoryAsync.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(int id)
        {
            return candidateRepositoryAsync.DeleteAsync(id);
        }


        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync()
        {
            var result = await candidateRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new CandidateResponseModel()
                { Id = x.Id, EmailId = x.EmailId, FirstName = x.FirstName, LastName = x.LastName, Mobile = x.Mobile });
            }
            return null;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var result = await candidateRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new CandidateResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Mobile = result.Mobile,
                    EmailId = result.EmailId
                };
            }
            return null;
        }

        public Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                EmailId = model.EmailId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile
            };
            return candidateRepositoryAsync.UpdateAsync(candidate);
        }
    }
}

