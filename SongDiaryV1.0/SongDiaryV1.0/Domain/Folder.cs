using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Domain
{
    public class Folder
    {
        public int Id { get; set; }
        [Required]
        public string? FolderName { get; set; }
        //public string? UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
        public virtual ICollection<ApplicationUser> User { get; set; } = new List<ApplicationUser>();
    }
}
