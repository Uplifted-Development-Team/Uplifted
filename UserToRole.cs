using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace Uplifted.DataAccessAPI.Models
{
    [Table("UserToRole")]
    public class UserToRole : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }

        [Column("UserID")]
        public long UserID { get; set; }

        [Column("RoleID")]
        public long RoleID { get; set; }
    }
}
