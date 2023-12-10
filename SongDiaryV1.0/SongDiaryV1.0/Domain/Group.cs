using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Domain
{
    public class Group
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Place { get; set; }

        public virtual ICollection<Set> Sets { get; set; } = new List<Set>();
        public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
