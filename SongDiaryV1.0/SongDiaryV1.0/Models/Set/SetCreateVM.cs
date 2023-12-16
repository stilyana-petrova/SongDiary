using SongDiaryV1._0.Models.Song;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SongDiaryV1._0.Models.Set
{
    public class SetCreateVM
    {
        public SetCreateVM()
        {
            Songs = new List<SongVM>();
        }
        public int Id { get; set; }
        [Display(Name = "Set Name")]
        public string? Name { get; set; }
        [Display(Name = "Date")]
        public string? DateForTheSet { get; set; }
       
        public virtual List<SongVM> Songs { get; set; }
    }
}
