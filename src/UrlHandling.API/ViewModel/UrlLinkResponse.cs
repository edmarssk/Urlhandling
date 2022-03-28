using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlHandling.API.ViewModel
{
    public class UrlLinkResponse
    {
        public Guid id { get; set; }
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
    }
}
