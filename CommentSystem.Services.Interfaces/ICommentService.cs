using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommentSystem.Entities;

namespace CommentSystem.Services.Interfaces
{
	public interface ICommentService
	{
		Task<bool> CreateComment(Comment comment);

		Task<List<Comment>> GetComments();

		Task<bool> UpdateComment(Comment comment);

		Task<List<Comment>> ViewComment(string username, Guid commentID);

	}
}