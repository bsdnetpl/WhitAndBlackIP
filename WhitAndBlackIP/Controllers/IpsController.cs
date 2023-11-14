using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteAndBlackIP.Models;
using WhiteAndBlackIP.Service;

namespace WhiteAndBlackIP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpsController : ControllerBase
    {
        private readonly IIpService _ipService;

        public IpsController(IIpService ipService)
        {
            _ipService = ipService;
        }
        [HttpPost("AddIpToBlack")]
        public async Task<ActionResult<IpBlack>>AddIpToBlack(IpBlack ipBlack)
        {
            if(ipBlack is null)
            {
                return BadRequest(ModelState);
            }
           await _ipService.AddIpToBlackListAsync(ipBlack);
            return Ok(ipBlack);
        }
        [HttpPost("AddIpToWhite")]
        public async Task<ActionResult<IpWhite>> AddIpToWhite(IpWhite ipWhite)
        {
            if (ipWhite is null)
            {
                return BadRequest(ModelState);
            }
            await _ipService.AddIpToWhiteListAsync(ipWhite);
            return Ok(ipWhite);
        }
    }
}
