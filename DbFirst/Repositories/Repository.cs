using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DbFirst.Models;
using Abstraction;

namespace DbFirst.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarServiceKpzContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(CarServiceKpzContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public List<T> GetAll() => _dbSet.ToList();

        public T GetById(int id) => _dbSet.Find(id);

        public void Add(T entity) => _dbSet.Add(entity);

        public void Update(T entity) => _dbSet.Update(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public void SaveChanges() => _context.SaveChanges();
    }

}
