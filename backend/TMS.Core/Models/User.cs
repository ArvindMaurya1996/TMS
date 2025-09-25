using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TMS.Core.Models
{
    public class  User : IdentityUser
    {
        
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }


    public class TokenWrapper
    {

        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
