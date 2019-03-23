using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LetsMyDNSjp
{
    public class MyDNSJP
    {
        public string MYDNSJP_URL = "http://www.mydns.jp/directedit.html";
        public string MYDNSJP_MASTERID = "yourmasterid";
        public string MYDNSJP_MASTERPWD = "yourpasswd";
        public string MYDNSJP_DOMAIN = "yourdomain";

        public string CERTBOT_DOMAIN;
        public string CERTBOT_VALIDATION;

        public void REGISTAsync()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic["EDIT_CMD"] = "DELETE";
            dic["CERTBOT_DOMAIN"] = MYDNSJP_DOMAIN;
            dic["CERTBOT_VALIDATION"] = this.CERTBOT_VALIDATION;

            var content = new FormUrlEncodedContent(dic);

            HttpRequestMessage mes = new HttpRequestMessage();
            mes.Headers.Authorization = new AuthenticationHeaderValue("Basic", this.BuildAccout());
            mes.Method = HttpMethod.Post;
            mes.Content = content;
            mes.RequestUri = new Uri(this.MYDNSJP_URL);

            using (HttpClient client = new HttpClient())
            {

                Task<HttpResponseMessage> task = client.SendAsync(mes);

                task.Wait();

            }
        }


        private string BuildAccout()
        {
            byte[] src = new UTF8Encoding().GetBytes(this.MYDNSJP_MASTERID + ":" + MYDNSJP_MASTERPWD);
            string dest = Convert.ToBase64String(src);
            string ret = Regex.Replace(dest, "-", String.Empty);
            return ret;
        }
    }
}
