using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentSystem.Entities
{
	public class User
	{
		public Guid ID { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}