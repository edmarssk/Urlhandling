using System;
using System.Collections.Generic;
using System.Text;

namespace UrlHandling.Business.Models
{
    public class UrlLink : Entity
    {
        public string ShortUrl { get; set; }
        public string OriginalUrl { get; set; }
        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }

    }
}