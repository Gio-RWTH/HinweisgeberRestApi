using HinweigeberRestApi.Data;
using HinweigeberRestApi.SharedModels.RequestsParameter.Paging;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HinweigeberRestApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HinweisDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(IDbContextFactory<HinweisDbContext> context)
        {
            _context = context.CreateDbContext(); ;
            _db = _context.Set<T>();
        }

        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public bool Existed(int id)
        {
            var result = _db.Find(id);
            if (result != null)
                return true;
            else
                return false;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _db;
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> GetAll(List<string> types)
        {
            IQueryable<T> query = _db;
            if (types != null)
            {
                foreach (var includeProperty in types)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<T> Insert(T entity)
        {
            try
            {
                await _db.AddAsync(entity);
                var res = await _context.SaveChangesAsync();

                if (res > 0)
                {
                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task InsertRange(IEnumerable<T> entities)
        {

            await _db.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _db.Update(entity);
                //_context.Orders.Update(entity);
                //_context.Entry(entity).State = EntityState.Modified;
                var ss = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task UpdateRange(IEnumerable<T> entities)
        {
            //await _db.UpdateRange(entities);
            _db.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll1(/* Expression<Func<T, bool>> filter = null,*/ Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, PageRequest pageRequest = null, params Expression<Func<T, object>>[] includes)
        {
            var query = _db.AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));

            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            //if (filter != null)
            //{
            //    query = query.AsExpandable().Where(filter);
            //}
            if (pageRequest != null)
            {
                query = query.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize).Take(pageRequest.PageSize);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllFiltered(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                     PageRequest pageRequest = null, params Expression<Func<T, object>>[] includes)
        {
            var query = _db.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
                //query = query.AsExpandable().Where(filter);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));

            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (pageRequest != null)
            {
                query = query.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize).Take(pageRequest.PageSize);
            }
            return await query.AsNoTracking().ToListAsync();
        }


        public async Task<List<T>> GetAllSingle()
        {
            IQueryable<T> query = _db;
            return await query.AsNoTracking().ToListAsync();
        }
    }

}
