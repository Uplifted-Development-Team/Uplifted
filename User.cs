using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace Uplifted.DataAccessAPI.Models
{
    [Table("Users")]
    public class User : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("UserID")]
        public string UserID { get; set; } = string.Empty;

        [Column("UserName")]
        public string? UserName { get; set; } = string.Empty;

        [Column("Email")]
        public string? Email { get; set; } = string.Empty;

        [Column("Password")]
        public string? Password { get; set; } = string.Empty;

        [Column("FirstName")]
        public string? FirstName { get; set; } = string.Empty;

        [Column("LastName")]
        public string? LastName { get; set; } = string.Empty;

        [Column("IsActive")]
        public bool IsActive { get; set; } = false;

        [Column("DateTimeLastActive")]
        public DateTime? DateTimeLastActive { get; set; }
    }
}
