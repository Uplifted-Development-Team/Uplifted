using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Uplifted.DataAccessAPI.Contracts
{
    public class CreateUserToRoleRequest
    {
        public long UserID { get; set; }
        public long RoleID { get; set; }
    }
}
