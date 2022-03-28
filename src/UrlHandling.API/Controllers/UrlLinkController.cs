using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlHandling.API.ViewModel;
using UrlHandling.Business.Interfaces.Repository;
using UrlHandling.Business.Interfaces.Services;

namespace UrlHandling.API.Controllers
{
    [Route("urllink")]
    [ApiController]
    public class UrlLinkController : MainBaseController
    {
        private readonly IUrlLinkService _urlLinkService;

        private readonly IUrlLinkRepository _urlLinkRepository;

        private readonly IMapper _mapper;
        public UrlLinkController(INotifier notifier,
            IUrlLinkService urlLinkService,
            IUrlLinkRepository urlLinkRepository,
            IMapper mapper) : base(notifier)
        {
            _urlLinkService = urlLinkService;
            _urlLinkRepository = urlLinkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("urls/{pagination:int}")]
        public async Task<ActionResult> FindUrl(int pagination)
        {
            var listUrlLink = _mapper.Map<IEnumerable<UrlLinkResponse>>(await _urlLinkRepository.FindAll(pagination, 10));

            if (listUrlLink == null) return NotFound();

            return Ok(listUrlLink);
        }


        [HttpGet]
        [Route("url/details/{id:guid}")]
        public async Task<ActionResult> FindUrlById(Guid id)
        {
            var urlLink = _mapper.Map<UrlLinkResponse>(await _urlLinkRepository.FindById(id));

            if (urlLink == null) return NotFound();

            return Ok(urlLink);
        }


        [HttpPost]
        public async Task<ActionResult> Post(UrlRequest urlRequest)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var urlLink = _mapper.Map<UrlLinkResponse>(await _urlLinkService.CreateShortUrl(urlRequest.OriginalUrl));

            return CustomResponse(urlLink);

        }

    }
}
