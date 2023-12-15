using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Group
{
    public class GroupVM
    {
        public int Id { get; set; }
        [Display(Name="Group Name")]
        public string? Name { get; set; }
        [Display(Name="Description")]
        public string? Description { get; set; }
        [Display(Name="Place")]
        public string? Place { get; set; }
    }
}
