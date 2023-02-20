using System;
namespace HRM.ApllicationCore.Model.Response
{
	public class UserRoleResponseModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserRoleResponseModel()
		{
		}
	}
}

