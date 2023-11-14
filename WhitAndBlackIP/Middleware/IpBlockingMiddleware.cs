using System.Net;

namespace WhitAndBlackIP.Middleware
{
    public class IpBlockingMiddleware
    {
        private readonly RequestDelegate _next;

        public IpBlockingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
    
            string[] blockedIpAddresses = { "192.168.0.1", "10.0.0.2", "127.0.0.1" };

           
            string[] trustedIpAddresses = { "192.168.0.3", "10.0.0.6" };

        
            var ipAddress = context.Connection.RemoteIpAddress;

         
            if (blockedIpAddresses.Contains(ipAddress.ToString()))
            {
               
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Access denied for IP: {ipAddress}");

                return;
            }

         
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
