using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class MoviesLanguage
    {
        [Key]
        public int MoviesLanguageId { get; set; }
        public ICollection<Movie> MLan { get; set; }
        public string MoviesLanguageName { get; set; }

    }
}