using erpLogin.Model;
using erpLogin.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erpLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadReg _leadreg;
        public LeadController(ILeadReg leadReg) {
            _leadreg = leadReg; 
        }
        [HttpPost]
        public async Task<IActionResult> LeadRegister([FromBody]LeadRegister register)
        {
            var result = await _leadreg.RegisterLead(register);
            return Ok(new { Message = result });
        }

       
    }
}
