using Microsoft.AspNetCore.Identity;

namespace SongDiaryV1._0.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        // public string? Role { get; set; } 
        //public int GroupId { get; set; }
        //public virtual Group Group { get; set; } = null!;
    }
}
