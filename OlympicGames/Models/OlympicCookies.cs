using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace OlympicGames.Models
{
    public class OlympicCookies
    {
        private const string CountryKey = "mycountry";
        private const string Delimiter = "-";

        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }
        public OlympicCookies(IRequestCookieCollection cookies)
        {
            requestCookies = cookies;
        }
        public OlympicCookies(IResponseCookies cookies)
        {
            responseCookies = cookies;
        }

        public void SetMyCountryIds(List<Country> mycountries)
        {
            List<string> ids = mycountries.Select(c => c.CountryId).ToList();
            string idsString = String.Join(Delimiter, ids);
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            RemoveMyCountryIds();     // delete old cookie first
            responseCookies.Append(CountryKey, idsString, options);
        }

        public string[] GetMyCountryIds()
        {
            string cookie = requestCookies[CountryKey];
            if (string.IsNullOrEmpty(cookie))
                return new string[] { };   // empty string array
            else
                return cookie.Split(Delimiter);
        }

        public void RemoveMyCountryIds()
        {
            responseCookies.Delete(CountryKey);
        }
    }
}
