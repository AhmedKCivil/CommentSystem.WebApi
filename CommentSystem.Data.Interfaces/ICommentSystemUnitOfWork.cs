using CommentSystem.Entities;
namespace CommentSystem.Data.Interfaces
{
	public interface ICommentSystemUnitOfWork : IUnitOfWork
	{
		IReadRepository<User> UsersRead { get; }
		IReadRepository<Comment> CommentsRead { get; }

		IWriteRepository<User> UsersWrite { get; }
		IWriteRepository<Comment> CommentsWrite { get; }
	}
}
