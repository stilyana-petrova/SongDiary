using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Domain
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string? EventName { get; set; }
        [Required]
        public string? EventDescription { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string? EventPlace { get; set; }
    }
}
