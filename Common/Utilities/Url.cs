using Microsoft.AspNetCore.Http;
using System;
using System.Web;

namespace Common.Utilities
{
    public static class Url
    {
        public const string DefaultUrl = "~/Content/Images/no-image.png";
        public static string ResolveServerUrl(IHttpContextAccessor httpContextAccessor,string serverUrl, bool forceHttps)
        {

            if (serverUrl.IndexOf("://", StringComparison.Ordinal) > -1)
                return serverUrl;

            string newUrl = serverUrl;


            var request = httpContextAccessor.HttpContext.Request;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Query = request.QueryString.ToString();


            Uri originalUri = uriBuilder.Uri;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        /// <summary>
        /// مخصوص فروشگاه
        /// </summary>
        /// <param name="serverurl"></param>
        /// <param name="forceHttps"></param>
        /// <param name="defaulturl"></param>
        /// <returns></returns>
        public static string ResolveServerUrlForShop(IHttpContextAccessor httpContextAccessor,string serverurl, string defaulturl, bool forceHttps)
        {
            if (serverurl == null)
                serverurl = string.Empty;

            if (serverurl.ToLower().Contains("~/files"))
            {
                return ResolveServerUrl(httpContextAccessor, VirtualPathUtility.ToAbsolute(!string.IsNullOrEmpty(serverurl) ? serverurl : defaulturl ?? DefaultUrl), forceHttps);
            }

            return ResolveServerUrl(httpContextAccessor, VirtualPathUtility.ToAbsolute(!string.IsNullOrEmpty(serverurl) ? ImageUtility.ShopRoot + serverurl : defaulturl ?? DefaultUrl), forceHttps);
        }

        /// <returns></returns>
        public static string ResolveDynamicUrl(string action, string paramter,IHttpContextAccessor httpContextAccessor)
        {
            var request = httpContextAccessor.HttpContext.Request;
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = request.Scheme;
            uriBuilder.Host = request.Host.Host;
            uriBuilder.Path = request.Path.ToString();
            uriBuilder.Query = request.QueryString.ToString();

            return $"{uriBuilder.Uri.Scheme}://{uriBuilder.Uri.Host}/api/Common/Image/{action}?{paramter}";

        }
    }
}
