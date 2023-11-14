using WhiteAndBlackIP.Models;

namespace WhiteAndBlackIP.Service
{
    public interface IIpService
    {
        Task<IpBlack> AddIpToBlackListAsync(IpBlack ipBlack);
        Task<IpWhite> AddIpToWhiteListAsync(IpWhite ipWhite);
        Task<string> GetBlackIp(string Ip);
        Task<string> GetWhiteIp(string Ip);
    }
}