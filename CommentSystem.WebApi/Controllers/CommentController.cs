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
	public class CommentController : ApiController
	{
		private readonly ICommentService _commentService;

		public CommentController(ICommentService commentService)
		{
			_commentService = commentService;
		}
		[HttpGet]
		[Route("api/Comment/GetAllComments")]
		public async Task<IHttpActionResult> GetAllComments()
		{
			try
			{
				var comments = await _commentService.GetComments();
				if (comments == null)
				{
					return NotFound();
				}
				return Ok(comments);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}
		[HttpPost]
		[Route("api/Comment/CreateComment")]
		public async Task<IHttpActionResult> CreateComment(Comment comment)
		{
			try
			{
				bool create = false;
				var commentCheck = await _commentService.CreateComment(comment);
				if (!commentCheck)
				{
					return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, create));
				}
				create = true;
				return Ok(create);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}
		[HttpPost]
		[Route("api/Comment/UpdateComment")]
		public async Task<IHttpActionResult> UpdateComment(Comment comment)
		{
			try
			{
				bool create = false;
				var commentCheck = await _commentService.UpdateComment(comment);
				if (!commentCheck)
				{
					return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, create));
				}
				create = true;
				return Ok(create);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}


		}

		[HttpGet]
		[Route("api/Comment/ViewComment")]
		public async Task<IHttpActionResult> ViewComment(string username, Guid commentID)
		{
			try
			{
				
				var commentAll = await _commentService.ViewComment(username, commentID);
				if (commentAll == null)
				{
					return NotFound();
				}
				
				return Ok(commentAll);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}


		}

	}
}