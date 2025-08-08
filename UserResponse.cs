namespace Uplifted.DataAccessAPI.Contracts
{
    public class UserResponse
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
