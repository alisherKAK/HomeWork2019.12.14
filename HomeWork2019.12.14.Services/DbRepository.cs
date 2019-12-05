using HomeWork2019._12._14.AbstractModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HomeWork2019._12._14.Services
{
    public class DbRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        public DbRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.Set<T>().Find(id);
            Delete(item);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T item)
        {
            Add(item);
        }
    }
}
