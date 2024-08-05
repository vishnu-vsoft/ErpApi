using erpLogin.Model;
using erpLogin.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erpLogin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FetchLeadController : ControllerBase
    {
        private readonly IFetchLead _fetchLead;
        public FetchLeadController(IFetchLead fetchLead) {
            _fetchLead = fetchLead;
        }
        [HttpGet("GetLeadList")]
        public async Task<ActionResult<IEnumerable<LeadRegister>>> GetLeadList()
        {
            var response = await  _fetchLead.getLeadDetails();
            return(Ok(response));
        }
    }
}
