using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.DataAccess.EntityDTO;

namespace UserManagement.Helper
{
    public class SessionManager : ISessionManager
    {

        private readonly IConfiguration _configuration;
        public SessionManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(UserRecordDTO userRecordDTO)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var _stringObject = JsonConvert.SerializeObject(userRecordDTO);
            var claims = new[] {
        new Claim("LoginModel", _stringObject.ToString()),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
       };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
