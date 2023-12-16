using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Song
{
    public class SongIndexVM
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Author")]

        public string? Author { get; set; }
        [Required]
        [Display(Name = "Song Category")]
        public int SongTypeId { get; set; }
        public string? SongTypeName { get; set; }

        [Required]
        [Display(Name = "Tempo")]
        public int SongTempoId { get; set; }
        public string? SongTempoName { get; set; }


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
