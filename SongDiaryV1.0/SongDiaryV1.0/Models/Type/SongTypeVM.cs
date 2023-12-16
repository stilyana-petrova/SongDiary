using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Type
{
    public class SongTypeVM
    {
        public int Id { get; set; }
        [Required]

        public string? Name { get; set; }
    }
}
