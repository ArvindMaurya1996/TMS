using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TMS.Core.DB;
using TMS.Core.Models;

namespace TMS.Core.Services
{
    public class  UserService
    {

        private TMSDbContext _dbContext;

        private readonly IConfiguration _configuration;
                
        public UserService(TMSDbContext tMSDbContext, IConfiguration configuration)
        {
                _dbContext = tMSDbContext;
            _configuration = configuration;
        }

        public (string,DateTime) GenerateTokens(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(issuer: "localhost",audience: "localhost", claims: claims, expires: DateTime.Now.AddHours(2), signingCredentials: credentials);

            var stringToken = new JwtSecurityTokenHandler().WriteToken(token);
            
            return (stringToken, token.ValidTo);
        }

        public async Task<List<User>> getAllUser()
        {
            return await  _dbContext.Users.ToListAsync();
        }
            

        public async Task<User> CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Login(Login login)
        {
            var user = _dbContext.Users.Where(x => x.Name == login.Email && x.Password == login.Password).First();
            return user;
        }
        
    }

}
