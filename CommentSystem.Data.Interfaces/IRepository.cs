using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommentSystem.Data.Interfaces
{
	public interface IRepository<TEntity>
	{
		// read
		IQueryable<TEntity> AsQueryable();
		Task<List<TEntity>> GetAllAsync();
		TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate);
		Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
		Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
		Task<List<TEntity>> GetWhereWithPagingAsync(int skip, int take, string orderBy, bool asc, Expression<Func<TEntity, bool>> predicate = null);
		Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
		Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null);

		// write
		void Add(TEntity entity);
		void Remove(TEntity entity);
		void Update(TEntity entity);
	}
}
