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
	public class WriteRepository<TEntity, TDto> : IWriteRepository<TEntity>
	   where TEntity : class
	   where TDto : class
	{

		internal DbContext _context;
		private readonly DbSet<TDto> _dbSet;

		public WriteRepository(DbContext context)
		{
			_context = context;
			_dbSet = _context.Set<TDto>();
		}

		public IQueryable<TEntity> AsQueryable()
		{
			return _dbSet.ProjectToQueryable<TEntity>();
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
