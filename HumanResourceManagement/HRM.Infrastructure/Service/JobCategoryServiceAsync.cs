using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;

namespace HRM.Infrastructure.Repository
{
	public class JobCategoryServiceAsync: IJobCategoryServiceAsync
	{
        private readonly IJobCategoryRepositoryAsync jobCategoryRepositoryAsync;

        public JobCategoryServiceAsync(IJobCategoryRepositoryAsync _jobCategoryRepositoryAsync)
		{
            jobCategoryRepositoryAsync = _jobCategoryRepositoryAsync;
        }

        public Task<int> AddJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Name = model.Name,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.InsertAsync(jobCategory);
        }

        public Task<int> DeleteJobCategoryAsync(int id)
        {
            return jobCategoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobCategoryResponseModel>> GetAllJobCategoriesAsync()
        {
            var result = await jobCategoryRepositoryAsync.GetAllAsync();
            if(result != null)
            {
                return result.ToList().Select(x => new JobCategoryResponseModel()
                { Id = x.Id, Name = x.Name, IsActive = x.IsActive });
            }
            return null;
        }

        public async Task<JobCategoryResponseModel> GetJobCategoryByIdAsync(int id)
        {
            var result = await jobCategoryRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new JobCategoryResponseModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public Task<int> UpdateJobCategoryAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Id = model.Id,
                Name = model.Name,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.UpdateAsync(jobCategory);
        }
    }
}

