using System;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace testApp.Service.Utility
{
    public static class UtilityUrl
    {
        public static string GetUrl(HttpContext url, int Id)
        {
            var path = url.Request.Path;
            var client = new WebClient();

            return "a";
        }
    }
}
