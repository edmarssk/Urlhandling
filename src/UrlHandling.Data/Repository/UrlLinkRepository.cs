using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UrlHandling.Business.Interfaces.Repository;
using UrlHandling.Business.Models;
using UrlHandling.Data.Context;
using X.PagedList;

namespace UrlHandling.Data.Repository
{
    public class UrlLinkRepository: Repository<UrlLink>, IUrlLinkRepository
    {
        public UrlLinkRepository(MainUrlHandlingDbContext context) : base(context) { }

        public async Task<UrlLink> FindUrlByOriginal(string originalUrl)
        {
            return await Db.UrlLinks.AsNoTracking().FirstOrDefaultAsync(c => c.OriginalUrl == originalUrl);
        }


        public async Task<UrlLink> FindUrlByShort(string shortUrl)
        {
            return await Db.UrlLinks.AsNoTracking().FirstOrDefaultAsync(c => c.ShortUrl == shortUrl);
        }

        public async Task<IEnumerable<UrlLink>> FindAll(int pagination, int amountItensByPage)
        {
            return await Db.UrlLinks.ToPagedListAsync(pagination, amountItensByPage);
        }

        public override async Task<IEnumerable<UrlLink>> FindAll()
        {
            return await Db.UrlLinks.OrderBy(c => c.RegistrationDate).ToPagedListAsync(1, 50);
        }
    }
}
