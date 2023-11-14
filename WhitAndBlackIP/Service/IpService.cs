using Microsoft.EntityFrameworkCore;
using WhiteAndBlackIP.DB;
using WhiteAndBlackIP.Models;

namespace WhiteAndBlackIP.Service
{
    public class IpService : IIpService
    {
        private readonly MsContext _msContext;

        public IpService(MsContext msContext)
        {
            _msContext = msContext;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public async Task<IpBlack> AddIpToBlackListAsync(IpBlack ipBlack)
        {
            ipBlack.dateTimeAdd = DateTime.Now;
            await _msContext.ipBlacks.AddAsync(ipBlack);
            await _msContext.SaveChangesAsync();
            return ipBlack;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public async Task<IpWhite> AddIpToWhiteListAsync(IpWhite ipWhite)
        {
            ipWhite.dateTimeAdd = DateTime.Now;
            await _msContext.ipWhites.AddAsync(ipWhite);
            await _msContext.SaveChangesAsync();
            return ipWhite;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public async Task<string> GetWhiteIp(string Ip)
        {
            var ips = await _msContext.ipWhites.Where(ip => ip.IP == Ip).FirstOrDefaultAsync();
            return ips.IP;
        }
        //----------------------------------------------------------------------------------------------------------------------------
        public async Task<string> GetBlackIp(string Ip)
        {
            var ips = await _msContext.ipBlacks.Where(ip => ip.IP == Ip).FirstOrDefaultAsync();
            return ips.IP;
        }
        //----------------------------------------------------------------------------------------------------------------------------


    }
}
