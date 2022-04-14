using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Models;

namespace UrlHandling.Business.Interfaces.Services
{
    public interface IUrlLinkService
    {
        Task<UrlLink> CreateShortUrl(string originalUrl);

        Task<UrlLink> GetUrlLinkByHashCode(string hashcode);

    }
}
