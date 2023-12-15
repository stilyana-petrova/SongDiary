using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Song
{
    public class SongVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Author")]

        public string? Author { get; set; }

        [Required]
        [Display(Name = "Link in YouTube")]

        public string? YouTubeLink { get; set; }
        [Required]
        [Display(Name = "Lyrics and Chords")]

        public string? LyricsChords { get; set; }
        [Display(Name = "Capo")]

        public int Capo { get; set; }
    }
}
