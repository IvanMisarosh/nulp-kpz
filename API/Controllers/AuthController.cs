using Microsoft.AspNetCore.Mvc;
using Abstraction;
using Abstraction.DTOs;
using Microsoft.AspNetCore.Identity.Data;
using API.TokenProviders;
using Abstraction.ServiceInterfaces;
using DbFirst.Models;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly TokenProvider _tokenProvider;

        public AuthController(IUserService userService, TokenProvider tokenProvider)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            var user = _userService.GetUserByUsername(request.Username);
            //if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            //{
            //    return Unauthorized(new { Message = "Invalid username or password" });
            //}

            //TODO: Implement password hashing
            if (user == null || !(request.Password == user.PasswordHash))
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            // Generate tokens
            var accessToken = _tokenProvider.CreateToken(user);
            var refreshToken = _tokenProvider.GenerateRefreshToken(); // Custom method for refresh tokens

            // Save refresh token in the database
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(55); // Example: 7 days
            _userService.UpdateUser(user);

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("refresh")]
        public IActionResult RefreshToken([FromBody] RefreshTokenRequestDTO request)
        {
            var user = _userService.GetUserByRefreshToken(request.RefreshToken);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return Unauthorized(new { Message = "Invalid or expired refresh token" });
            }

            // Generate new tokens
            var newAccessToken = _tokenProvider.CreateToken(user);
            var newRefreshToken = _tokenProvider.GenerateRefreshToken();

            // Update refresh token in the database
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(55);
            _userService.UpdateUser(user);

            return Ok(new
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequestDTO request)
        {
            if (_userService.UserExists(request.Username))
            {
                return BadRequest("Username already exists.");
            }

            var user = new UserDTO
            {
                Username = request.Username,
                PasswordHash = HashPassword(request.Password)
            };

            _userService.Add(user);
            return Ok(new { Message = "Registration successful" });
        }

        private string HashPassword(string password)
        {
            // Implement your password hashing logic here (e.g., using BCrypt or other libraries)
            return password;  // Simplified for demo purposes
        }
    }
}
