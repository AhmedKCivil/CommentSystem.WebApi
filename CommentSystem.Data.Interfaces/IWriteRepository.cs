namespace CommentSystem.Data.Interfaces
{
	public interface IWriteRepository<TEntity>
	{
		// write
		void Add(TEntity entity);
		void Remove(TEntity entity);
		void Update(TEntity entity);
	}
}
