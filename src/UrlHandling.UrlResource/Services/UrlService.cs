using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UrlHandling.Business.Interfaces.Services;

namespace UrlHandling.UrlResource.Services
{
    public class UrlService : IUrlService
    {
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
    }
}
