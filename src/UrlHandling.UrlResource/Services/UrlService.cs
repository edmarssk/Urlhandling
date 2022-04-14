using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Interfaces.Services;

namespace UrlHandling.UrlResource.Services
{
    public class UrlService : IUrlService
    {

        private readonly IConfiguration _config;

        public UrlService(IConfiguration config)
        {
            _config = config;
        }

        public Task<string> CreateShortUrl(string originalUrl)
        {
            Task<string> currentTask = Task.Run(() => CreationUrl(originalUrl));

            return currentTask;
        }

        private string CreationUrl(string originalUrl)
        {
            string creationURL = "http://tinyurl.com/api-create.php?url=" +
                   originalUrl.ToLower();

            HttpWebRequest objWebRequest;
            HttpWebResponse objWebResponse;

            System.IO.StreamReader srReader;

            string shortUrl;

            objWebRequest = (System.Net.HttpWebRequest)System.Net
               .WebRequest.Create(creationURL);

            objWebRequest.Method = "GET";

            objWebResponse = (System.Net.HttpWebResponse)objWebRequest
               .GetResponse();
            srReader = new System.IO.StreamReader(objWebResponse
               .GetResponseStream());

            shortUrl = srReader.ReadToEnd();

            srReader.Close();
            objWebResponse.Close();
            objWebRequest.Abort();

            return shortUrl;
        }

        public Task<string> CreateShortUrlInternal()
        {
            Task<string> currentTask = Task.Run(() => GenerateShortUrl());

            return currentTask;
        }

        private string GenerateShortUrl()
        {
            string urlsafe = string.Empty;
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
            var token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));

            var domain = _config.GetSection("AppSettings").GetSection("DomainLocalHost").Value;
            var shortUrl = String.Concat(domain, token);
            return shortUrl;
        }

        private string GetShortUrl(string hashCode)
        {
            var domain = _config.GetSection("AppSettings").GetSection("DomainLocalHost").Value;
            var shortUrl = String.Concat(domain, hashCode);
            return shortUrl;
        }

        public Task<string> GetShortUrlInternal(string hashCode)
        {
            Task<string> currentTask = Task.Run(() => GetShortUrl(hashCode));

            return currentTask;
        }
    }
}