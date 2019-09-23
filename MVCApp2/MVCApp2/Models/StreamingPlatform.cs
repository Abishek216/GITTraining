using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class StreamingPlatform
    {
        [Key]
        public int StreamingPlatformId { get; set; }
        public ICollection<Movie> MStr { get; set; }
        public string StreamingPlatformName { get; set; }
    }
}