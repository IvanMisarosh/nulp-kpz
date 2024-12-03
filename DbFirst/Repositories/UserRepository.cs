using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraction.ModelInterfaces;
using Abstraction;
using DbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        CarServiceKpzContext _context;

        public UserRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public bool Add(IUser entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(IUser entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetAll()
        {
            try
            {
                return (IEnumerable<IUser>)_context.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IUser GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Update(IUser entity)
        {
            var result = _context.Users.Update((User)entity);
            return result.State == EntityState.Modified;
        }
    }
}
