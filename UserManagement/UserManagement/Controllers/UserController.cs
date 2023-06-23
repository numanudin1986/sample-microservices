using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UserManagement.Services.Interfaces;
using UserManagement.DataAccess.EntityDTO;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagement.Helper;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserInfoService _userInfoService;
        private readonly ISessionManager _sessionManager;
        public UserController(IUserInfoService userInfoService, ISessionManager sessionManager)
        {
            _userInfoService = userInfoService;
          //  _configuration = configuration;
            _sessionManager = sessionManager;
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDTO model)
        {
            try
            {
                var user = _userInfoService.GetUserAuthenticate(model);
                if (user != null)
                {
                    var token = _sessionManager.GenerateToken(user);
                    return Ok(new
                    {
                        token = token,

                    });
                }
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                return BadRequest(Error);
            }

            return Unauthorized();
        }
    }
}
