using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentSystem.Entities;

namespace CommentSystem.Services.Interfaces
{
	public interface IUserService
	{
		Task<bool> CreateUser(User user);
		Task<List<User>> GetUser(string userName, string passWord);
	}
}