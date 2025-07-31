using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_DemoMVCWithEFCoreCodeFirst.Models;
using Web_DemoMVCWithEFCoreCodeFirst.DAL;
using Microsoft.EntityFrameworkCore;

namespace Web_DemoMVCWithEFCoreCodeFirst.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PGInventoryDbContext _context;

        public Repository(PGInventoryDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
            //_context.Database.Migrate();
            _context.Database.SetCommandTimeout(TimeSpan.FromMinutes(1));
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            //await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                //await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {   _context.Set<TEntity>().Update(entity);
            //await _context.SaveChangesAsync();
        }
    }
}
