using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class MoviesCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public ICollection<Movie> Mcat { get; set; }
        public string CategoryName { get; set; }
    }
}