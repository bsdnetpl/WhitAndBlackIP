using System.Net;
using WhiteAndBlackIP.Service;

namespace WhitAndBlackIP.Middleware
{
    public class IpBlockingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IIpService _ipService;


        public IpBlockingMiddleware(RequestDelegate next)//, IIpService ipService)
        {
            _next = next;
           // _ipService = ipService;
        }

        public async Task Invoke(HttpContext context)
        {
    
            string[] blockedIpAddresses = { "192.168.0.1", "10.0.0.2"};

           
            string[] trustedIpAddresses = { "192.168.0.3", "10.0.0.6", "127.0.0.1"};
        
        
            var ipAddress = context.Connection.RemoteIpAddress;

           //string ipadr = ipAddress?.ToString() ?? "Unknown";
            //var isBlack =_ipService.GetBlackIp(ipadr);

            //if ( isBlack != null)
            //{
               
            //    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            //    context.Response.ContentType = "text/plain";
            //    await context.Response.WriteAsync($"Access denied for IP: {ipAddress}");

            //    return;
            //}

         
            if (trustedIpAddresses.Contains(ipAddress.ToString()))
            {
               
                await _next(context);
            }
            else
            {
                await _next(context);
            }
        }
    }
    public static class IpBlockingMiddlewareExtensions
    {
        public static IApplicationBuilder UseIpBlockingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IpBlockingMiddleware>();
        }
    }
}
