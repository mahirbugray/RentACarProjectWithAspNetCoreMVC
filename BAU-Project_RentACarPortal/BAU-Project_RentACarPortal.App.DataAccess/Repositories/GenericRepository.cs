using BAU_Project_RentACarPortal.App.DataAccess.Contexts;
using BAU_Project_RentACarPortal.App.Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
		private readonly RentalDbContext _context;
		private DbSet<T> _dbSet;

		public GenericRepository(RentalDbContext context)
		{
			_context = context;         //veritabanı
			_dbSet = _context.Set<T>(); //ilgili tablo
		}

        public async Task Add(T entity)
        {
            //_context.Set<T>().Add(entity);
            await _dbSet.AddAsync(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            //_dbSet.Entry().State = EntityState.Deleted;
            if (entity.GetType().GetProperty("IsDeleted") != null)
            {
                entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                _dbSet.Update(entity);
                //this.Update(entity);   böyle de diyebiliriz.
            }
            else
            {
                _dbSet.Remove(entity);
            }

        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public T GetNoAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            foreach (var table in includes)
            {
                query = query.Include(table);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();   //Ef verileri takip (modified, deleted, detached gibi) etmiyor.
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetByIdNoAsync(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetAllByIndex(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAllDetay()
        {
            return _dbSet.ToList();
        }
        public async Task<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderby != null)
            {
                query = orderby(query);
            }
            foreach (var table in includes)
            {
                query = query.Include(table);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
