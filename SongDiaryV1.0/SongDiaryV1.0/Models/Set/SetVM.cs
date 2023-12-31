﻿using SongDiaryV1._0.Models.Song;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SongDiaryV1._0.Models.Set
{
    public class SetVM  
    {
        public int Id { get; set; }
        [Display(Name ="Set Name")]
        public string? Name { get; set; }
        [Display(Name="Date")]
        public string? DateForTheSet { get; set; }
        public string? UserId { get; set; }
        public string? User { get; set; }
        public int GroupId { get; set; }
        public string? Group { get; set; }
        public virtual List<SongVM> Songs { get; set; }
    }
}
