using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Models;

namespace UrlHandling.Business.Interfaces.Repository
{
    public interface IUrlLinkRepository: IRepository<UrlLink>
    {

        Task<UrlLink> FindUrlByShort(string shortUrl);

        Task<UrlLink> FindUrlByOriginal(string originalUrl);

        Task<IEnumerable<UrlLink>> FindAll(int pagination, int amountItensByPage);

    }
}
