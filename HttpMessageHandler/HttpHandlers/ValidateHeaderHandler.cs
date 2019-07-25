﻿namespace HttpMessageHandler.HttpHandlers
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class ValidateHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("SECRET-API-HEADER"))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("You must supply an API key header called SECRET-API-HEADER")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
