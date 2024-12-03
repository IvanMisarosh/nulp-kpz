using System;
using System.Collections.Generic;
using System.Text;
using Abstraction.DTOs;
using Abstraction.ModelInterfaces;

namespace Abstraction.ServiceInterfaces
{
    public interface IUserService: IService<UserDTO>
    {
        UserDTO Authenticate(string username, string password);
        UserDTO RefreshToken(string token);
        IUser GetUserByUsername(string username);

        bool UpdateUser(IUser user);

        IUser GetUserByRefreshToken(string token);
    }
}
