using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class CustomModel
    {
        public int MovieId { get; set; }
     
        public string MovieName { get; set; }
      
        public string MovieYearOfRelease { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int MoviesLanguageId { get; set; }
        public string MoviesLanguageName { get; set; }
        public string MovieDirectorName { get; set; }
        public int StreamingPlatformId { get; set; }
        public string StreamingPlatformName { get; set; }
    }
}