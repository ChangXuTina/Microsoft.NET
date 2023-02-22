using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class SubmissionServiceAsync: ISubmissionServiceAsync
	{
        private readonly ISubmissionRepositoryAsync submissionRepositoryAsync;

        public SubmissionServiceAsync(ISubmissionRepositoryAsync _submissionRepositoryAsync)
		{
            submissionRepositoryAsync = _submissionRepositoryAsync;
        }

        public async Task<int> AddSubmissiontAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                AppliedOn = model.AppliedOn
            };
            return await submissionRepositoryAsync.InsertAsync(submission);
        }

        public Task<int> DeleteSubmissionAsync(int id)
        {
            return submissionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionsAsync()
        {
            var result = await submissionRepositoryAsync.GetAllAsync();
            if(result != null)
            {
                return result.ToList().Select(x => new SubmissionResponseModel()
                { id = x.id, CandidateId = x.CandidateId, JobRequirementId = x.JobRequirementId, AppliedOn = x.AppliedOn});
            }
            return null;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var result = await submissionRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new SubmissionResponseModel()
                {
                    id = result.id,
                    CandidateId = result.CandidateId,
                    JobRequirementId = result.JobRequirementId,
                    AppliedOn = result.AppliedOn
                };
            }
            return null;
        }

        public Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
        {
            Submission submission = new Submission()
            {
                id = model.id,
                CandidateId = model.CandidateId,
                JobRequirementId = model.JobRequirementId,
                AppliedOn = model.AppliedOn
            };
            return submissionRepositoryAsync.UpdateAsync(submission);
        }

    }
}

