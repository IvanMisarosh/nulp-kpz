using Abstraction.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.DTOs
{
    public class UserDTO: IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
