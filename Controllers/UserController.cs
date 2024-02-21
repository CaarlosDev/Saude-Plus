using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;

namespace SaudePlus.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UserController : ControllerBase {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers() {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserById(int id) {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> CreateUser(UserModel user) {
            UserModel createdUser = await _userRepository.CreateUser(user);
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModel user, int id) {
            UserModel createdUser = await _userRepository.UpdateUser(user, id);
            return Ok(createdUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id) {
            bool hasDeletedUser = await _userRepository.DeleteUser(id);
            return Ok(hasDeletedUser);
        }
    }
}