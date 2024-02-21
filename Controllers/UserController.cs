using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;

namespace SaudePlus.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<UserModel>> CreateUser(UserModelRequest user) {
            UserModel createdUser = await _userRepository.CreateUser(buildUserModel(user));
            return Ok(createdUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser(UserModelRequest user, int id) {
            UserModel updatedUser = await _userRepository.UpdateUser(buildUserModel(user), id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id) {
            bool hasDeletedUser = await _userRepository.DeleteUser(id);
            return Ok(hasDeletedUser);
        }

        private UserModel buildUserModel(UserModelRequest user) {
            UserModel newUser = new UserModel();
            newUser.Name = user.Name;
            newUser.Email = user.Email;

            return newUser;
        }
    }
}