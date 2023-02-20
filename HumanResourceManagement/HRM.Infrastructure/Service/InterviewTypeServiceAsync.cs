using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class InterviewTypeServiceAsync: IInterviewTypeServiceAsync
	{
        private readonly IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;

        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
        {
            interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }

        public Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Title = model.Title,
                IsActive = model.IsActive
            };
            return interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public Task<int> DeleteInterviewTypeAsync(int id)
        {
            return interviewTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypesAsync()
        {
            var result = await interviewTypeRepositoryAsync.GetAllAsync();
            if(result != null)
            {
                return result.ToList().Select(x => new InterviewTypeResponseModel()
                { Id = x.Id, Title = x.Title, IsActive = x.IsActive });
            }
            return null;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var result = await interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;

        }

        public Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return interviewTypeRepositoryAsync.UpdateAsync(interviewType);

        }
    }
}

