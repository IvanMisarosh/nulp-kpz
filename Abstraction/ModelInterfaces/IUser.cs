using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction.ModelInterfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string PasswordHash { get; set; }
        string RefreshToken { get; set; }
        DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
