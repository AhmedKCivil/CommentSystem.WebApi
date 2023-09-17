using CommentSystem.Entities;
using CommentSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CommentSystem.WebApi.Controllers
{
    public class UserController : ApiController
    {
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IHttpActionResult> Post(User user)
		{
			try
			{
				bool create = false;
				var specCheck = await _userService.CreateUser(user);
				if (!specCheck)
				{
					return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Account couldn't be created. Please try again."));
				}
				create = true;
				return Ok(create);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		public async Task<IHttpActionResult> Get(string userName, string passWord)
		{
			try
			{
				var users = await _userService.GetUser(userName, passWord);
				if (users == null || users.Count == 0)
				{
					return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Account couldn't be found"));
				}
				return Ok(users);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}



	}

}