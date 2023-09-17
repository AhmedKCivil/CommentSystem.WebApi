using System;
using System.Threading.Tasks;

namespace CommentSystem.Data.Interfaces
{
	public interface IUnitOfWork
	{
		Task SaveAsync();
	}
}