using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UrlHandling.Business.Interfaces.Services
{
    public interface IUrlService
    {
        Task<string> CreateShortUrl(string originalUrl);
    }
}
