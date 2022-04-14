using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlHandling.Business.Interfaces.Services;

namespace UrlHandling.API.Controllers
{
    [Route("url")]
    [ApiController]
    public class UrlOpenController : MainBaseController
    {
        private readonly IUrlLinkService _urlLinkService;

        public UrlOpenController(INotifier notifier,
            IUrlLinkService urlLinkService) : base(notifier)
        {
            _urlLinkService = urlLinkService;
        }

        [HttpGet]
        [Route("{hashcode}")]
        public async Task<RedirectResult> FindOriginalByShortUrl(string hashcode)
        {
            var urlLink = await _urlLinkService.GetUrlLinkByHashCode(hashcode);

            if (urlLink == null) return RedirectPermanent("https://www.google.com/search?q=" + hashcode);

            return RedirectPermanent(urlLink.OriginalUrl);
        }
    }
}

