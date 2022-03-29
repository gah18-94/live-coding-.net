using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecureFlight.Core.Interfaces;

namespace SecureFlight.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly SecureFlightDbContext _context;

        public BaseRepository(SecureFlightDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public TEntity Save(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
