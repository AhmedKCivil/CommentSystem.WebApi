using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CommentSystem.Data.Common
{
	public class UnitOfWork<TContext> : IDisposable
	   where TContext : DbContext, new()
	{
		private TContext _context;
		private bool _disposed;

		public TContext Context => _context ?? (_context = new TContext());

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing && _context != null)
				{
					_context.Dispose();
					_context = null;
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public Task SaveAsync()
		{
			return Context.SaveChangesAsync();
		}
	}
}
