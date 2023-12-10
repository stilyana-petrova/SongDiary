using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Domain
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? YouTubeLink { get; set; }
        [Required]
        public string? LyricsChords { get; set; }

        public int Capo { get; set; }
        public virtual ICollection<Folder> Folder { get; set; } = new List<Folder>();
        public virtual ICollection<Set> Set { get; set; } = new List<Set>();

        //public int FolderId { get; set; }
        //[ForeignKey("FolderId")]
        //public virtual Folder? Folder { get; set; }
        //public int SetId { get; set; }
        //[ForeignKey("SetId")]
        //public virtual Set? Set { get; set; }
    }
}
