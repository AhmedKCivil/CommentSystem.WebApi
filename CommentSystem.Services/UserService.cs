using CommentSystem.Data.Interfaces;
using CommentSystem.Entities;
using CommentSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentSystem.Services
{
	public class UserService : IUserService
	{
		private readonly ICommentSystemUnitOfWork _unitOfWork;
		public UserService(ICommentSystemUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<bool> CreateUser(User user)
		{
			var userCheck = await _unitOfWork.UsersRead.GetFirstOrDefaultAsync(s => s.UserName == user.UserName);
			if (userCheck != null || user.Password == null || user.UserName == null)
			{
				return false;
			}
			user.ID = Guid.NewGuid();
			_unitOfWork.UsersWrite.Add(user);

			await _unitOfWork.SaveAsync();
			return true;
		}
		public async Task<List<User>> GetUser(string userName, string passWord)
		{
			return await _unitOfWork.UsersRead.GetWhereAsync(s => s.UserName == userName && s.Password == passWord);
		}
	}	
}