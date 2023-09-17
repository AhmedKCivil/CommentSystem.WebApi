using System;

namespace CommentSystem.Entities
{
	public class Comment
	{
		public Guid ID { get; set; }
		public Guid UserID { get; set; }
		public string UserName { get; set; }
		public DateTime DateTime { get; set; }
		public string UserComment { get; set; }
		public Boolean Edited { get; set; }
		public Guid? CommentID { get; set; }
	}
}