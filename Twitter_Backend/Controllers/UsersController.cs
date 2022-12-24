using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Twitter_Backend.DTO;
using Twitter_Backend.JWT;
using Twitter_Backend.Models;
using Twitter_Backend.Repository.IRepository;

namespace Twitter_Backend.Controllers
{

    [Route("api/v1/tweets")]
    [ApiController]
    [EnableCors]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogger<UsersController> _logger;
        private readonly Ijwtservice _jwtservice;
        public UsersController(IUserRepository userRepo, ILogger<UsersController> logger, Ijwtservice jwtservice)
        {
            _userRepo = userRepo;
            _logger = logger;
            _jwtservice = jwtservice;
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] LoginDTO login)
        {
            IActionResult response = Unauthorized();
            var user = new User
            {
                userName = login.Username,
                password = login.Password,
            };
            var rep = _userRepo.Authenticate(user.userName, user.password);
            if (!rep)
            {
                _logger.LogError("Invalid username or password");
                return NotFound();
            }
            else
            {
                var tokenstring = _jwtservice.GenerateToken(login);
                response = Ok(new { token = tokenstring });
                _logger.LogInformation("Authenticated Successfuuly");
            }
            return response;
        }


        [HttpGet("users/all")]
        public IActionResult GetAllUsers()
        {
            try
            {
                List<User> users = _userRepo.GetAll().ToList();
                _logger.LogInformation("Details fetched Successfuuly");
                return Ok(users);

            }
            catch (Exception)
            {
                _logger.LogError("Unable to get the information");
                return NotFound();
            }
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO registerDto)
        {
            try
            {
                var checkUser = _userRepo.IsUniqueUser(registerDto.Email);
                if (checkUser)
                {
                    User user = new User
                    {
                        firstName = registerDto.FirstName,
                        lastName = registerDto.LastName,
                        DOB = registerDto.DOB,
                        contactNumber = registerDto.ContactNumber,
                        userName = registerDto.Email,
                        password = registerDto.Password
                    };
                    var response = _userRepo.Register(user);
                    if (response == null)
                    {
                        _logger.LogError("Invalid User Details");
                        return NotFound("Invalid User Details");

                    }
                    else
                    {
                        return Ok(response);
                    }
                }
                else
                {
                    _logger.LogInformation("User Already Exists");
                    return NotFound("User Already Exists");
                }

            }
            catch (Exception)
            {
                _logger.LogError("unable to get the information");
                return NotFound("unable to get the information");
            }
        }

        [Authorize]
        [HttpPost("changePassword/{username}/{password}")]
        public IActionResult ChangePassword(string username, string password)
        {
            var result = _userRepo.ChangePassword(username, password);
            if (result)
            {
                _logger.LogInformation("Password Changed Successfully");
                return Ok(result);

            }
            else
            {
                _logger.LogError("unable to change the password");
                return NotFound("unable to change the password");
            }
        }

       // [Authorize]
        [HttpDelete("deletePassword/{username}")]
        public IActionResult DeleteUser(string username)
        {
            var result = _userRepo.ForgotPassword(username);
            if (result)
            {
                _logger.LogInformation("User Deleted Successfully");
                return Ok(result);
            }
            else
            {
                _logger.LogError("unable to delete the user");
                return NotFound("unable to delete the user");
            }
        }
    }
}
