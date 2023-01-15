﻿namespace MyWebServer.Results
{
    using MyWebServer.Http;
    using MyWebServer.Http.Collection;
    using System.Collections.Generic;

    public abstract class ActionResult : HttpResponse
    {
        protected ActionResult(HttpResponse response)
            : base(response.StatusCode)
        {
            this.Content = response.Content;

            this.PrepareHeaders(response.Headers);
            this.PrepareCookies(response.Cookies);
        }

        private void PrepareHeaders(HeaderCollection headers)
        {
            foreach (var header in headers)
            {
                this.Headers.Add(header.Name, header.Value);
            }
        }

        private void PrepareCookies(CookieCollection cookies)
        {
            foreach (var cookie in cookies)
            {
                this.Cookies.Add(cookie.Name, cookie.Value);
            }
        }
    }
}
