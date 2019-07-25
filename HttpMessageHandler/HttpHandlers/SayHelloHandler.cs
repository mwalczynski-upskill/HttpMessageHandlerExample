namespace HttpMessageHandler.HttpHandlers
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Logging;

    public class SayHelloHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            LogHelper.LogInformation("Hello from SayHelloHandler");
            return base.SendAsync(request, cancellationToken);
        }
    }
}