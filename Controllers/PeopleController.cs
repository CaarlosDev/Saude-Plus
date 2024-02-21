using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudePlus.Models;

namespace SaudePlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<PeopleModel>> SearchAllUsers()
        {
            return Ok();
        }
    }
}
