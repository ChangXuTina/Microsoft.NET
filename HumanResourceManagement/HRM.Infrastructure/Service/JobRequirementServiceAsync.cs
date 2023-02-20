using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class JobRequirementServiceAsync: IJobRequirementServiceAsync
	{
        private readonly IJobRequirementRepositoryAsync jobRequirementRepositoryAsync;

        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync _jobRequirementRepositoryAsync)
		{
            jobRequirementRepositoryAsync = _jobRequirementRepositoryAsync;
        }

        public Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Title = model.Title,
                IsActive = model.IsActive
            };
            return jobRequirementRepositoryAsync.InsertAsync(jobRequirement);

        }

        public Task<int> DeleteJobRequirementAsync(int id)
        {
            return jobRequirementRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementsAsync()
        {
            var result = await jobRequirementRepositoryAsync.GetAllAsync();
            if(result != null)
            {
                return result.ToList().Select(x => new JobRequirementResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsActive = x.IsActive
                });
            }
            return null;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var result = await jobRequirementRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new JobRequirementResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return jobRequirementRepositoryAsync.InsertAsync(jobRequirement);
        }  
    }
}

