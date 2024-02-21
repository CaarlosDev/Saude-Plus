using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudePlus.Models;

namespace SaudePlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UserModels>> SearchAllUsers()
        {
            return Ok();
        }
    }
}
