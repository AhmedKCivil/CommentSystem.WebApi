using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CommentSystem.Data.Interfaces;
using System.Data.Entity;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DelegateDecompiler.EntityFramework;

namespace CommentSystem.Data.Common
{
	public class Repository<TEntity, TDto> : IRepository<TEntity>
	   where TEntity : class
	   where TDto : class
	{
		internal DbContext _context;
		private readonly DbSet<TDto> _dbSet;

		public Repository(DbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TDto>();
		}

		public IQueryable<TEntity> AsQueryable()
		{
			return _dbSet.ProjectToQueryable<TEntity>();
		}

		public Task<List<TEntity>> GetAllAsync()
		{
			return _dbSet.ProjectToListAsync<TEntity>();
		}

		public Task<List<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
		{
			var query = _dbSet.ProjectTo<TEntity>().Where(predicate);

			if (orderBy != null)
				query = orderBy(query);

			return query.DecompileAsync().ToListAsync();
		}

		public Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null)
		{
			if (predicate == null)
			{
				return _dbSet.ProjectTo<TEntity>().CountAsync();
			}
			else
			{
				return _dbSet.ProjectTo<TEntity>().Where(predicate).CountAsync();
			}
		}

		public Task<List<TEntity>> GetWhereWithPagingAsync(int skip, int take, string orderBy, bool asc, Expression<Func<TEntity, bool>> predicate = null)
		{
			if (predicate != null)
			{
				return _dbSet.ProjectTo<TEntity>().Where(predicate).OrderByPropertyOrField(orderBy, asc).Skip(skip).Take(take).ToListAsync();
			}
			else
			{
				return _dbSet.ProjectTo<TEntity>().OrderByPropertyOrField(orderBy, asc).Skip(skip).Take(take).ToListAsync();
			}
		}

		public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbSet.ProjectToQueryable<TEntity>().FirstOrDefault(predicate);
		}

		public Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbSet.ProjectTo<TEntity>().DecompileAsync().FirstOrDefaultAsync(predicate);
		}

		public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbSet.ProjectTo<TEntity>().DecompileAsync().AnyAsync(predicate);
		}

		public void Add(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));
			_dbSet.Add(Mapper.Map<TDto>(entity));
		}

		public void Remove(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			var dto = Mapper.Map<TDto>(entity);

			_dbSet.Attach(dto);
			_dbSet.Remove(dto);
		}

		public void Update(TEntity entity)
		{
			if (entity == null)
				throw new ArgumentNullException(nameof(entity));

			var dto = Mapper.Map<TDto>(entity);

			_dbSet.Attach(dto);
			_context.Entry(dto).State = EntityState.Modified;
		}
	}
}