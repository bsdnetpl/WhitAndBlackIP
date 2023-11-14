using Microsoft.EntityFrameworkCore;
using WhiteAndBlackIP.Models;

namespace WhiteAndBlackIP.DB
{
    public class MsContext : DbContext
    {
        public MsContext(DbContextOptions options) : base(options)
        {
        }
      public  DbSet<IpWhite> ipWhites { get; set; }
     public   DbSet<IpBlack> ipBlacks { get; set; }
    }
}
