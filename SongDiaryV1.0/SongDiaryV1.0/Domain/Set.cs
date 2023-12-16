using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace SongDiaryV1._0.Domain
{
    public class Set
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime DateForTheSet { get; set; }
        [Required]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser? User { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group? Group { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
       // public virtual ICollection<Group> Group { get; set; } = new List<Group>();
        //public virtual ICollection<ApplicationUser> User { get; set; } = new List<ApplicationUser>();
    }
}
