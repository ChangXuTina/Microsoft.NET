using System;
using HRM.ApllicationCore.Entity;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;
using HRM.ApllicationCore.Repository;
using HRM.ApllicationCore.Service;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class FeedbackServiceAsync : IFeedbackServiceAsync
    {
        private readonly IFeedbackRepositoryAsync feedbackRepositoryAsync;

        public FeedbackServiceAsync(IFeedbackRepositoryAsync _feedbackRepositoryAsync)
		{
            feedbackRepositoryAsync = _feedbackRepositoryAsync;
        }

        public Task<int> AddFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                InterviewId = model.InterviewId,
                Description = model.Description,
                ABBR = model.ABBR
            };
            return feedbackRepositoryAsync.InsertAsync(feedback);
        }

        public Task<int> DeleteFeedbackAsync(int id)
        {
            return feedbackRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<FeedbackResponseModel>> GetAllFeedbacksAsync()
        {
            var result = await feedbackRepositoryAsync.GetAllAsync();
            if(result != null)
            {
                return result.ToList().Select(x => new FeedbackResponseModel()
                { Id = x.Id, InterviewId = x.InterviewId, ABBR = x.ABBR, Description = x.Description });
            }
            return null;
        }

        public async Task<FeedbackResponseModel> GetFeedbackByIdAsync(int id)
        {
            var result = await feedbackRepositoryAsync.GetByIdAsync(id);
            if(result != null)
            {
                return new FeedbackResponseModel()
                {
                    Id = result.Id,
                    InterviewId = result.InterviewId,
                    ABBR = result.ABBR,
                    Description = result.Description
                };
            }
            return null;
        }

        public Task<int> UpdateFeedbackAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                InterviewId = model.InterviewId,
                ABBR = model.ABBR,
                Description = model.Description
            };
            return feedbackRepositoryAsync.UpdateAsync(feedback);
        }
    }
}

