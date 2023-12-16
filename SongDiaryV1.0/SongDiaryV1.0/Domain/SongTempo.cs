using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Domain
{
    public class SongTempo
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<Song> Songs { get; set; } = new List<Song>();

    }
}
