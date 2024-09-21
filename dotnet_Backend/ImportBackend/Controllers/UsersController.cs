using ImportBackend.Contracts.User;
using ImportBackend.Models;
using ImportBackend.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ImportBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserRequest request)
        {
            if (_userService.UserNameExists(request.UserName))
            {
                return BadRequest(new { error = "User with this username already exists." });
            }

            var user = new User(
                    0
                    , request.GivenName
                    , request.LastName
                    , request.UserName
                    , request.Email
                    , request.Password
                    , DateTime.UtcNow
                    , DateTime.UtcNow
                );
            _userService.CreateUser(user);

            var response = new UserResponse(
                    user.Id
                    , request.GivenName
                    , request.LastName
                    , request.UserName
                    , request.Email
                    , request.Password
                    , request.DateCreated
                    , request.DateUpdated
                );
            return CreatedAtAction(
                    nameof(GetUser),
                    routeValues: new { id = user.Id },
                    value: response
                );
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            User user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            var response = new UserResponse(
                user.Id
                , user.GivenName
                , user.LastName
                , user.UserName
                , user.Email
                , user.Password
                , user.DateCreated
                , user.DateUpdated
                );
            return Ok(response);

        }

        [HttpGet("GetAll")]
        public IActionResult GetUsers()
        {
            IEnumerable<User> users = _userService.GetUsers();
            var response = users.Select(user => new UserResponse(
                user.Id
                , user.GivenName
                , user.LastName
                , user.UserName
                , user.Email
                , user.Password
                , user.DateCreated
                , user.DateUpdated
            ));
            return Ok(response);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpsertUser(int id, UpsertUserRequest request)
        {
            User user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            var UpsertUser = new User(
                    id
                    ,request.GivenName
                    , request.LastName
                    , request.UserName
                    , request.Email
                    , request.Password
                    , request.DateCreated
                    , DateTime.UtcNow
                );
            _userService.UpsertUser(UpsertUser);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            User user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.DeleteUser(id);
            return Ok(id);
        }
    }
}
