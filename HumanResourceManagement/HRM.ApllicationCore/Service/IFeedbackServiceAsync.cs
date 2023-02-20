using System;
using HRM.ApllicationCore.Model.Request;
using HRM.ApllicationCore.Model.Response;

namespace HRM.ApllicationCore.Service
{
	public interface IFeedbackServiceAsync
	{
        Task<int> AddFeedbackAsync(FeedbackRequestModel model);
        Task<int> UpdateFeedbackAsync(FeedbackRequestModel model);
        Task<int> DeleteFeedbackAsync(int id);
        Task<FeedbackResponseModel> GetFeedbackByIdAsync(int id);
        Task<IEnumerable<FeedbackResponseModel>> GetAllFeedbacksAsync();
    }
}

