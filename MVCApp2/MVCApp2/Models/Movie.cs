using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [MaxLength(20)]
        //[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Invalid movie name")]
        public string MovieName {get;set;}
        [Required]
        [MaxLength(4)]
       // [RegularExpression(@"^[0-9]*$",ErrorMessage ="Year can only be a number")]
        public string MovieYearOfRelease { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public MoviesCategory Category { get; set; }
        [Required]
        public int MoviesLanguageId { get; set; }
        public MoviesLanguage Language { get; set; }
        //[RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid director name")]
        public string MovieDirectorName { get; set; }
        [Required]
        public int StreamingPlatformId { get; set; }
        public StreamingPlatform Streaming { get; set; }


    }
}