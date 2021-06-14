using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly ManagerContext _context;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Get(long id)
        {
            return _context.Set<T>()
                    .AsNoTracking()
                    .Where(x => x.id == id)
                    .FirstOrDefaultAsync();

        }

        public virtual Task<List<T>> Get()
        {
            return _context
                    .AsNoTracking()
                    .ToListAsync();
        }

        public virtual async Task Remove(long id)
        {
            var obj = await _context.Get(id);
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return obj;
        }
    }
}