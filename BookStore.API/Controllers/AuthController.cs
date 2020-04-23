
using System.Threading.Tasks;
using BookStore.API.Data;
using BookStore.API.Dtos;
using BookStore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
            // string username, string password as parameter will not work here as user will sent this info as a single JSON serilizer object. 
            // Hence we need another onject or class and that is DTO (Data transfer onject).
            // Here it is userForRegisterDto
        {
            // validate request

            //convert username to lowercase to maintain uniqueness amongst username in database
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
             return BadRequest("Username alread exists");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var cratedUser = await _repo.Register(userToCreate, userForRegisterDto.Password);
            return StatusCode(201);
        }





    }
}