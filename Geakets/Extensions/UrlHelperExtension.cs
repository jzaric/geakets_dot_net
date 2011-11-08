using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace System.Web.Mvc
{
    public static class UrlHelperExtension
    {
        public static MvcHtmlString JavascriptIncludeTag(this UrlHelper helper, string path)
        {
            string url = helper.Content("~/Scripts/" + path);
            return new MvcHtmlString(string.Format("<script src=\"{0}\" type=\"text/javascript\"></script>", url));
        }

        public static MvcHtmlString StylesheetLinkTag(this UrlHelper helper, string path)
        {
            string url = helper.Content("~/Content/" + path);
            return new MvcHtmlString(string.Format("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />", url));
        }

        public static MvcHtmlString GeaketUrl(this UrlHelper helper, int geaketId, string title)
        {
            return new MvcHtmlString(helper.RequestContext.HttpContext.Request.Url.Scheme + "://" + helper.RequestContext.HttpContext.Request.Url.Host + helper.RouteUrl("Details", new { controller = "Geakets", id = geaketId, title = title.ToLower().Replace(" ", "-") }));
            //return new MvcHtmlString(string.Format("{0}/geakets/{1}/{2}", helper.RequestContext.HttpContext.Request.Url.GetLeftPart(UriPartial.Authority), geaketId, title.ToLower().Replace(" ", "-")));
        }

        public static MvcHtmlString GravatarUrl(this UrlHelper helper, string email, int size)
        {
            return new MvcHtmlString(string.Format("http://www.gravatar.com/avatar/{0}?s={1}&d=identicon", GetMD5Hash(email), size));
        }

        private static string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }

    }
}