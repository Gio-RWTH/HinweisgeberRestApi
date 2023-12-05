using HinweigeberRestApi.SharedModels.RequestsParameter.Paging;
using System.Linq.Expressions;

namespace HinweigeberRestApi.Repository
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAll(
			Expression<Func<T, bool>> expression = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			List<string> includes = null
			);

		Task<List<T>> GetAll1(
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			PageRequest pageRequest = null,
		   params Expression<Func<T, object>>[] includes
		);

		Task<List<T>> GetAllFiltered(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
													 PageRequest pageRequest = null, params Expression<Func<T, object>>[] includes);
		Task<IList<T>> GetAll(List<string> types);
		Task<List<T>> GetAllSingle();

		Task<T> Get(
			Expression<Func<T, bool>> expression,
			params Expression<Func<T, object>>[] includes
			);

		Task<T> Insert(T entity);

		Task InsertRange(IEnumerable<T> entities);

		Task Delete(int id);

		Task DeleteRange(IEnumerable<T> entities);


		Task Update(T entity);
		Task UpdateRange(IEnumerable<T> entities);

		bool Existed(int id);
	}
}
