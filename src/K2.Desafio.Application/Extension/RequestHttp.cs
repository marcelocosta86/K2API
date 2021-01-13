using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace K2.Desafio.Application.Extension
{
    class RequestHttp
    {
        public static string Get(string urlPath)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(urlPath);
                request.ContentType = "json/appli";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.Method = "GET";
                request.Timeout = 60000;
                request.Headers.Add("Accept-Encoding", "gzip");
                HttpWebResponse httpResponse = (HttpWebResponse) request.GetResponseAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                Stream responseStream = httpResponse.GetResponseStream();

                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEndAsync().GetAwaiter().GetResult();
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
