using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAU_Project_RentACarPortal.App.Entity.Interfaces
{
    public interface IGenericRepository<T> where T : class, new()
    {
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetById(int id);
		Task<T> Get(Expression<Func<T, bool>> predicate);
		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);

		Task Add(T entity);
		void Update(T entity);
		void DeleteById(int id);
        void Delete(T entity);
        T GetByIdNoAsync(int id);
        T GetNoAsync(Expression<Func<T, bool>> predicate);
        List<T> GetAllDetay();
        Task<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, params Expression<Func<T, object>>[] includes);
    }
}
