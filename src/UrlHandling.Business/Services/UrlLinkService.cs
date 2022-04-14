using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Interfaces.Repository;
using UrlHandling.Business.Interfaces.Services;
using UrlHandling.Business.Models;
using UrlHandling.Business.Useful;

namespace UrlHandling.Business.Services
{
    public class UrlLinkService : BaseService, IUrlLinkService
    {

        private readonly IUrlService _urlService;
        private readonly IUrlLinkRepository _urlLinkRepository;

        public UrlLinkService(IUrlService urlService,
            IUrlLinkRepository urlLinkRepository,
            INotifier notifier): base(notifier)
        {
            _urlService = urlService;
            _urlLinkRepository = urlLinkRepository;
        }

        public async Task<UrlLink> CreateShortUrl(string originalUrl)
        {
            var urlLinkExist = await _urlLinkRepository.FindUrlByOriginal(originalUrl);

            if (urlLinkExist != null) return urlLinkExist;

            if (UrlValidation.IsValid2(originalUrl))
            {
                Notify("This Url is invalid!");
                return null;
            }

            //var shortUrl = await _urlService.CreateShortUrl(originalUrl);
            var shortUrl = await _urlService.CreateShortUrlInternal();
            var shortUrlLinkExist = await _urlLinkRepository.FindUrlByOriginal(originalUrl);

            while (shortUrlLinkExist != null)
            {
                shortUrl = await _urlService.CreateShortUrlInternal();
                shortUrlLinkExist = await _urlLinkRepository.FindUrlByOriginal(originalUrl);
            }

            var urlLink = new UrlLink()
            {
                OriginalUrl = originalUrl,
                ShortUrl = shortUrl,
                Active = true,
                RegistrationDate = DateTime.Now
            };

            await _urlLinkRepository.Insert(urlLink);

            return urlLink;

        }

        public async Task<UrlLink> GetUrlLinkByHashCode(string hashCode)
        {
            var shortUrl = _urlService.GetShortUrlInternal(hashCode);
            return await _urlLinkRepository.FindUrlByShort(shortUrl.Result);
        }
    }
}
