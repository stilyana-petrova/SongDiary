using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Tempo
{
    public class SongTempoVM
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
