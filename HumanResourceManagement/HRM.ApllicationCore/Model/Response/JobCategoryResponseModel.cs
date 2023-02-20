using System;
namespace HRM.ApllicationCore.Model.Response
{
	public class JobCategoryResponseModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public JobCategoryResponseModel()
		{
		}
	}
}

