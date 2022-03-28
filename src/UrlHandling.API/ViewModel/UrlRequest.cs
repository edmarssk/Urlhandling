using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlHandling.API.ViewModel
{
    public class UrlRequest
    {
        [Required(ErrorMessage = "Field Original Url is mandatory!")]
        public string OriginalUrl { get; set; }
    }
}
