using CommentSystem.Data.Interfaces;
using CommentSystem.Entities;
using CommentSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentSystem.Services
{
	public class CommentService : ICommentService
	{
		private readonly ICommentSystemUnitOfWork _unitOfWork;
		private readonly IDateTimeService _dateTimeService;
		public CommentService(ICommentSystemUnitOfWork unitOfWork, IDateTimeService dateTimeService)
		{
			_unitOfWork = unitOfWork;
			_dateTimeService = dateTimeService;
		}
		public async Task<List<Comment>> GetComments()
		{
			List<Comment> allSortedComments = new List<Comment>();
			var allComments = await _unitOfWork.CommentsRead.GetAllAsync();

			foreach (var comment in allComments)
			{
				if ((comment.CommentID == null && comment.Edited == false)|| (comment.CommentID != null && comment.Edited == false))
				{
					allSortedComments.Add(new Comment() { ID = comment.ID, UserID = comment.UserID, UserName = comment.UserName, DateTime = comment.DateTime, UserComment = comment.UserComment, Edited = comment.Edited, CommentID = comment.CommentID});
				}				
			}
			return allSortedComments;
		}
		public async Task<bool> CreateComment(Comment comment)
		{
			var userCheck = await _unitOfWork.UsersRead.GetFirstOrDefaultAsync(j => j.UserName == comment.UserName);
			if (userCheck == null || comment.UserComment=="")
			{
				return false;
			}
			comment.ID = Guid.NewGuid();
			comment.UserID = userCheck.ID;
			comment.UserName = userCheck.UserName;
			comment.DateTime = _dateTimeService.UtcNow;
			comment.CommentID = null;
			comment.UserComment = comment.UserComment;
			comment.Edited = false;

			_unitOfWork.CommentsWrite.Add(comment);
			await _unitOfWork.SaveAsync();
			return true;
		}
		public async Task<bool> UpdateComment(Comment comment)
		{
			var commentCheck = await _unitOfWork.CommentsRead.GetFirstOrDefaultAsync(j => j.ID == comment.ID);			

			var userCheck = await _unitOfWork.UsersRead.GetFirstOrDefaultAsync(j => j.UserName == comment.UserName);
			if (userCheck == null || commentCheck == null || comment.UserComment == commentCheck.UserComment || comment.UserComment =="")
			{
				return false;
			}
			if (comment.CommentID == null)
			{
				comment.CommentID = comment.ID;
			}
			comment.ID = Guid.NewGuid();
			comment.UserID = userCheck.ID;
			comment.UserName = userCheck.UserName;
			comment.DateTime = _dateTimeService.UtcNow;	
			comment.UserComment = comment.UserComment;
			commentCheck.Edited = true;

			_unitOfWork.CommentsWrite.Update(commentCheck);
			_unitOfWork.CommentsWrite.Add(comment);
			await _unitOfWork.SaveAsync();
			return true;
		}
		public async Task<List<Comment>> ViewComment(string username, Guid commentID)
		{
			return await _unitOfWork.CommentsRead.GetWhereAsync(j => j.UserName == username && j.ID == commentID || j.CommentID == commentID);
		}
	}
}