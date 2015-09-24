﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiscTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncT().Wait();
        }

        static async Task AsyncT()
        {

            HttpClient http = new HttpClient(new RedirectHandler() {InnerHandler = HttpMessageHandlerFactory .CreateDefault()});

            try
            {
                http.DefaultRequestHeaders.Add("X-ParkitectNexusInstaller-Version", "1.1.0.0");

                // Make the request
                var r =
                    await
                        http.SendAsync(
                            new HttpRequestMessage(HttpMethod.Get,
                                "https://api.github.com/repos/ParkitectNexus/TestMod/zipball/v0.2"),
                            HttpCompletionOption.ResponseContentRead)
                            .ConfigureAwait(false);


                Debug.WriteLine(r);
            }
            catch (AggregateException e)
            {
                throw e.InnerExceptions.FirstOrDefault();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }


    internal class RedirectHandler : DelegatingHandler
    {
        public const string RedirectCountKey = "RedirectCount";
        public bool Enabled { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            // Can't redirect without somewhere to redirect too.  Throw?
            if (response.Headers.Location == null) return response;

            // Don't redirect if we exceed max number of redirects
            var redirectCount = 0;
            if (request.Properties.Keys.Contains(RedirectCountKey))
            {
                redirectCount = (int)request.Properties[RedirectCountKey];
            }
            if (redirectCount > 3)
            {
                throw new InvalidOperationException("The redirect count for this request has been exceeded. Aborting.");
            }
            request.Properties[RedirectCountKey] = ++redirectCount;

            if (response.StatusCode == HttpStatusCode.MovedPermanently
                        || response.StatusCode == HttpStatusCode.Redirect
                        || response.StatusCode == HttpStatusCode.Found
                        || response.StatusCode == HttpStatusCode.SeeOther
                        || response.StatusCode == HttpStatusCode.TemporaryRedirect
                        || (int)response.StatusCode == 308)
            {
                var newRequest = CopyRequest(response.RequestMessage);

                if (response.StatusCode == HttpStatusCode.SeeOther)
                {
                    newRequest.Content = null;
                    newRequest.Method = HttpMethod.Get;
                }
                else
                {
                    if (request.Content != null && request.Content.Headers.ContentLength != 0)
                    {
                        var stream = await request.Content.ReadAsStreamAsync();
                        if (stream.CanSeek)
                        {
                            stream.Position = 0;
                        }
                        else
                        {
                            throw new Exception("Cannot redirect a request with an unbuffered body");
                        }
                        newRequest.Content = new StreamContent(stream);
                    }
                }
                newRequest.RequestUri = response.Headers.Location;
                if (String.Compare(newRequest.RequestUri.Host, request.RequestUri.Host, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    newRequest.Headers.Authorization = null;
                }
                response = await this.SendAsync(newRequest, cancellationToken);
            }

            return response;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private static HttpRequestMessage CopyRequest(HttpRequestMessage oldRequest)
        {
            var newrequest = new HttpRequestMessage(oldRequest.Method, oldRequest.RequestUri);

            foreach (var header in oldRequest.Headers)
            {
                newrequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            foreach (var property in oldRequest.Properties)
            {
                newrequest.Properties.Add(property);
            }

            return newrequest;
        }
    }

    public static class HttpMessageHandlerFactory
    {
        public static HttpMessageHandler CreateDefault()
        {
            return CreateDefault(null);
        }

        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "proxy")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static HttpMessageHandler CreateDefault(IWebProxy proxy)
        {
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = false
            };
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }
            if (handler.SupportsProxy && proxy != null)
            {
                handler.UseProxy = true;
                handler.Proxy = proxy;
            }
            return handler;
        }
    }
}
