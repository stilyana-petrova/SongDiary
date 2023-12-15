using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SongDiaryV1._0.Models.Set
{
    public class SetVM
    {
        public int Id { get; set; }
        [Display(Name ="Set Name")]
        public string Name { get; set; }
        [Display(Name="Date")]
        public DateTime DateForTheSet { get; set; }
    }
}
