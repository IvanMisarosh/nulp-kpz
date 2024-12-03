using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction;
using Abstraction.DTOs;
using Abstraction.ModelInterfaces;
using Abstraction.ServiceInterfaces;


namespace BLL.Services
{
    public class LoginService: IUserService
    {
        private readonly IRepository<IUser> _userRepository;
        private readonly IMapper _mapper;



        public LoginService(IRepository<IUser> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IUser GetUserByUsername(string username)
        {
            var employee = _userRepository.GetAll().FirstOrDefault(e => e.Username == username);
            return employee;
        }

        public bool Add(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserDTO entity)
        {
            var result = _userRepository.Update(_mapper.Map<IUser>(entity));
            if (result)
            {
                _userRepository.SaveChanges();
            }
            return result;
        }

        public UserDTO Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO RefreshToken(string token)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(IUser user)
        {
            var result = _userRepository.Update(user);
            if (result)
            {
                _userRepository.SaveChanges();
            }
            return result;
        }

        public IUser GetUserByRefreshToken(string token)
        {
            var user = _userRepository.GetAll().FirstOrDefault(e => e.RefreshToken == token);
            return user;
        }
    }
}
