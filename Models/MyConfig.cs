using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class MyConfig
    {
        private readonly IConfiguration Iconfig;
        public MyConfig(IConfiguration configuration)
        {
            Iconfig = configuration;
        }
        public string GetBaseUrl()
        {
            var smtpemail = Iconfig["smtp:smtpmail_id"];
            return Iconfig.GetValue<string>("smtp:smtpmail_id");
        }
        public HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(GetBaseUrl());
            return httpClient;
        }
        public string smtpmail_id { get; set; }
        public string smtpmail_password { get; set; }
        public int smtp_port { get; set; }
        public string smtp_host { get; set; }
        public bool smtp_enableSSL { get; set; }
    }
}
