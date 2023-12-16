using SongDiaryV1._0.Domain;
using SongDiaryV1._0.Models.Tempo;
using SongDiaryV1._0.Models.Type;
using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Song
{
    public class SongVM
    {
        public SongVM()
        {
            SongTypes = new List<SongTypeVM>();
            SongTempos = new List<SongTempoVM>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name ="Title")]
        public string? Title { get; set; }
        [Required]
        [Display(Name = "Author")]

        public string? Author { get; set; }
        [Required]
        [Display(Name ="Song Category")]
        public int SongTypeId { get; set; }
        public virtual List<SongTypeVM> SongTypes { get; set; }

        [Required]
        [Display(Name = "Tempo")]
        public int SongTempoId { get; set; }
        public virtual List<SongTempoVM> SongTempos { get; set; }


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
