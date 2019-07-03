using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace UrlBackendMobile.Models
{
    public static class Cookie
    {
        private const string CookieSetting = "Cookie.Duration";
        private const string CookieIsHttp = "Cookie.IsHttp";
        private static HttpContext _context { get { return HttpContext.Current; } }
        private static int _cookieDuration { get; set; }
        private static bool _cookieIsHttp { get; set; }

        static Cookie()
        {
            _cookieDuration = GetCookieDuration();
            _cookieIsHttp = GetCookieType();
        }

        /// <summary>
        /// Armazena a chave e o valor no cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set(string key, string value)
        {
            var c = new HttpCookie(key)
            {
                Value = value,
                Expires = DateTime.Now.AddDays(_cookieDuration),
                HttpOnly = _cookieIsHttp
            };
            _context.Response.Cookies.Add(c);
        }

        /// <summary>
        /// Pega o valor atraves da chave
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Get(string key)
        {
            var value = string.Empty;

            var c = _context.Request.Cookies[key];
            return c != null
                    ? _context.Server.HtmlEncode(c.Value).Trim()
                    : value;
        }

        /// <summary>
        /// Verifica se existe a chave 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return _context.Request.Cookies[key] != null;
        }

        /// <summary>
        /// Exclui a chave/valor atraves da chave
        /// </summary>
        /// <param name="key"></param>
        public static void Delete(string key)
        {
            if (Exists(key))
            {
                var c = new HttpCookie(key) { Expires = DateTime.Now.AddDays(-1) };
                _context.Response.Cookies.Add(c);
            }
        }

        /// <summary>
        /// Exclui tudo do Cookie
        /// </summary>
        public static void DeleteAll()
        {
            for (int i = 0; i <= _context.Request.Cookies.Count - 1; i++)
            {
                if (_context.Request.Cookies[i] != null)
                    Delete(_context.Request.Cookies[i].Name);
            }
        }

        private static int GetCookieDuration()
        {
            //default
            int duration = 1;
            var setting = ConfigurationManager.AppSettings[CookieSetting];

            if (!string.IsNullOrEmpty(setting))
                int.TryParse(setting, out duration);

            return duration;
        }

        private static bool GetCookieType()
        {
            //default
            var isHttp = true;
            var setting = ConfigurationManager.AppSettings[CookieIsHttp];

            if (!string.IsNullOrEmpty(setting))
                bool.TryParse(setting, out isHttp);

            return isHttp;
        }
    }
}