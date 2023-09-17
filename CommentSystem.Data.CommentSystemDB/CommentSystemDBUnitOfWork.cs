using CommentSystem.Data.Interfaces;
using CommentSystem.Data.Common;
using CommentSystem.Entities;

namespace CommentSystem.Data.CommentSystemDB
{
	public class CommentSystemDBUnitOfWork : UnitOfWork<CommentSystemDB>, ICommentSystemUnitOfWork
	{
		private IReadRepository<CommentSystem.Entities.User> _usersRead;
		private IReadRepository<CommentSystem.Entities.Comment> _commentsRead;

		private IWriteRepository<CommentSystem.Entities.User> _usersWrite;
		private IWriteRepository<CommentSystem.Entities.Comment> _commentsWrite;

		public IReadRepository<CommentSystem.Entities.User> UsersRead => _usersRead ?? (_usersRead = new ReadRepository<CommentSystem.Entities.User, User>(Context));
		public IReadRepository<CommentSystem.Entities.Comment> CommentsRead => _commentsRead ?? (_commentsRead = new ReadRepository<CommentSystem.Entities.Comment, Comment>(Context));

		public IWriteRepository<CommentSystem.Entities.User> UsersWrite => _usersWrite ?? (_usersWrite = new WriteRepository<CommentSystem.Entities.User, User>(Context));
		public IWriteRepository<CommentSystem.Entities.Comment> CommentsWrite => _commentsWrite ?? (_commentsWrite = new WriteRepository<CommentSystem.Entities.Comment, Comment>(Context));

	}
}
