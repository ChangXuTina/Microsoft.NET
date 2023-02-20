using System;
namespace HRM.ApllicationCore.Model.Request
{
	public class UserRoleRequestModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public UserRoleRequestModel()
		{
		}
	}
}

