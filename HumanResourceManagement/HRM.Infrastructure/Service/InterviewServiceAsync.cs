using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class InterviewServiceAsync: IInterviewServiceAsync
	{
        private readonly IInterviewRepositoryAsync interviewRepositoryAsync;

        public InterviewServiceAsync(IInterviewRepositoryAsync _interviewRepositoryAsync)
		{
            interviewRepositoryAsync = _interviewRepositoryAsync;
        }

        public Task<int> AddInterviewAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                SubmissionId = model.SubmissionId,
                InterviewDate = model.InterviewDate,
                InterviewRound = model.InterviewRound,
                InterviewTypeId = model.InterviewTypeId,
                InterviewStatusId = model.InterviewStatusId,
                InterviewerId = model.InterviewerId
            };
            return interviewRepositoryAsync.InsertAsync(interview);
        }

        public Task<int> DeleteInterviewAsync(int id)
        {
            return interviewRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllInterviewsAsync()
        {
            var result = await interviewRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewResponseModel()
                {
                    Id = x.Id,
                    SubmissionId = x.SubmissionId,
                    InterviewDate = x.InterviewDate,
                    InterviewRound = x.InterviewRound,
                    InterviewTypeId = x.InterviewTypeId,
                    InterviewStatusId = x.InterviewStatusId,
                    InterviewerId = x.InterviewerId
                });
            }
            return null;

        }

        public async Task<InterviewResponseModel> GetInterviewByIdAsync(int id)
        {
            var result = await interviewRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new InterviewResponseModel()
                {
                    Id = result.Id,
                    SubmissionId = result.SubmissionId,
                    InterviewDate = result.InterviewDate,
                    InterviewRound = result.InterviewRound,
                    InterviewTypeId = result.InterviewTypeId,
                    InterviewStatusId = result.InterviewStatusId,
                    InterviewerId = result.InterviewerId
                };
            }
            return null;
        }

        public Task<int> UpdateInterviewAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewDate = model.InterviewDate,
                InterviewRound = model.InterviewRound,
                InterviewTypeId = model.InterviewTypeId,
                InterviewStatusId = model.InterviewStatusId,
                InterviewerId = model.InterviewerId
            };
            return interviewRepositoryAsync.UpdateAsync(interview);
        }
    }
}

