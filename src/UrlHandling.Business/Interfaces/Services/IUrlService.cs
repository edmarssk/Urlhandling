using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Models;

namespace UrlHandling.Business.Interfaces.Services
{
    public interface IUrlService
    {
        Task<string> CreateShortUrl(string originalUrl);

        Task<string> CreateShortUrlInternal();

        Task<string> GetShortUrlInternal(string hashCode);
    }
}
