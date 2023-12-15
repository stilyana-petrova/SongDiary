using System.ComponentModel.DataAnnotations;

namespace SongDiaryV1._0.Models.Folder
{
    public class FolderVM
    {
        public int Id { get; set; }
        [Display(Name ="Folder Name")]
        public string? Name { get; set; }
    }
}
